using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace System.Xml;

internal sealed class XmlCanonicalWriter
{
	private sealed class AttributeSorter : IComparer
	{
		private readonly XmlCanonicalWriter _writer;

		public AttributeSorter(XmlCanonicalWriter writer)
		{
			_writer = writer;
		}

		public void Sort()
		{
			object[] array = new object[_writer._attributeCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = i;
			}
			Array.Sort(array, this);
			Attribute[] array2 = new Attribute[_writer._attributes.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array2[j] = _writer._attributes[(int)array[j]];
			}
			_writer._attributes = array2;
		}

		public int Compare(object obj1, object obj2)
		{
			int num = (int)obj1;
			int num2 = (int)obj2;
			return _writer.Compare(ref _writer._attributes[num], ref _writer._attributes[num2]);
		}
	}

	private struct Scope
	{
		public int xmlnsAttributeCount;

		public int xmlnsOffset;
	}

	private struct Element
	{
		public int prefixOffset;

		public int prefixLength;

		public int localNameOffset;

		public int localNameLength;
	}

	private struct Attribute
	{
		public int prefixOffset;

		public int prefixLength;

		public int localNameOffset;

		public int localNameLength;

		public int nsOffset;

		public int nsLength;

		public int offset;

		public int length;
	}

	private struct XmlnsAttribute
	{
		public int prefixOffset;

		public int prefixLength;

		public int nsOffset;

		public int nsLength;

		public bool referred;
	}

	private XmlUTF8NodeWriter _writer;

	private MemoryStream _elementStream;

	private byte[] _elementBuffer;

	private XmlUTF8NodeWriter _elementWriter;

	private bool _inStartElement;

	private int _depth;

	private Scope[] _scopes;

	private int _xmlnsAttributeCount;

	private XmlnsAttribute[] _xmlnsAttributes;

	private int _attributeCount;

	private Attribute[] _attributes;

	private Attribute _attribute;

	private Element _element;

	private byte[] _xmlnsBuffer;

	private int _xmlnsOffset;

	private const int maxBytesPerChar = 3;

	private int _xmlnsStartOffset;

	private bool _includeComments;

	private string[] _inclusivePrefixes;

	private const string xmlnsNamespace = "http://www.w3.org/2000/xmlns/";

	private static readonly bool[] s_isEscapedAttributeChar = new bool[64]
	{
		true, true, true, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, false, false, true, false, false, false, true, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		true, false, false, false
	};

	private static readonly bool[] s_isEscapedElementChar = new bool[64]
	{
		true, true, true, true, true, true, true, true, true, false,
		false, true, true, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, false, false, false, false, false, false, true, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		true, false, true, false
	};

	public void SetOutput(Stream stream, bool includeComments, string[] inclusivePrefixes)
	{
		if (stream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
		}
		if (_writer == null)
		{
			_writer = new XmlUTF8NodeWriter(s_isEscapedAttributeChar, s_isEscapedElementChar);
		}
		_writer.SetOutput(stream, ownsStream: false, null);
		if (_elementStream == null)
		{
			_elementStream = new MemoryStream();
		}
		if (_elementWriter == null)
		{
			_elementWriter = new XmlUTF8NodeWriter(s_isEscapedAttributeChar, s_isEscapedElementChar);
		}
		_elementWriter.SetOutput(_elementStream, ownsStream: false, null);
		if (_xmlnsAttributes == null)
		{
			_xmlnsAttributeCount = 0;
			_xmlnsOffset = 0;
			WriteXmlnsAttribute("xml", "http://www.w3.org/XML/1998/namespace");
			WriteXmlnsAttribute("xmlns", "http://www.w3.org/2000/xmlns/");
			WriteXmlnsAttribute(string.Empty, string.Empty);
			_xmlnsStartOffset = _xmlnsOffset;
			for (int i = 0; i < 3; i++)
			{
				_xmlnsAttributes[i].referred = true;
			}
		}
		else
		{
			_xmlnsAttributeCount = 3;
			_xmlnsOffset = _xmlnsStartOffset;
		}
		_depth = 0;
		_inStartElement = false;
		_includeComments = includeComments;
		_inclusivePrefixes = null;
		if (inclusivePrefixes == null)
		{
			return;
		}
		_inclusivePrefixes = new string[inclusivePrefixes.Length];
		for (int j = 0; j < inclusivePrefixes.Length; j++)
		{
			if (inclusivePrefixes[j] == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.InvalidInclusivePrefixListCollection);
			}
			_inclusivePrefixes[j] = inclusivePrefixes[j];
		}
	}

	public void Flush()
	{
		ThrowIfClosed();
		_writer.Flush();
	}

	public void Close()
	{
		if (_writer != null)
		{
			_writer.Close();
		}
		if (_elementWriter != null)
		{
			_elementWriter.Close();
		}
		if (_elementStream != null && _elementStream.Length > 512)
		{
			_elementStream = null;
		}
		_elementBuffer = null;
		if (_scopes != null && _scopes.Length > 16)
		{
			_scopes = null;
		}
		if (_attributes != null && _attributes.Length > 16)
		{
			_attributes = null;
		}
		if (_xmlnsBuffer != null && _xmlnsBuffer.Length > 1024)
		{
			_xmlnsAttributes = null;
			_xmlnsBuffer = null;
		}
		_inclusivePrefixes = null;
	}

	public void WriteDeclaration()
	{
	}

	public void WriteComment(string value)
	{
		if (value == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
		ThrowIfClosed();
		if (_includeComments)
		{
			_writer.WriteComment(value);
		}
	}

	[MemberNotNull("_scopes")]
	private void StartElement()
	{
		if (_scopes == null)
		{
			_scopes = new Scope[4];
		}
		else if (_depth == _scopes.Length)
		{
			Scope[] array = new Scope[_depth * 2];
			Array.Copy(_scopes, array, _depth);
			_scopes = array;
		}
		_scopes[_depth].xmlnsAttributeCount = _xmlnsAttributeCount;
		_scopes[_depth].xmlnsOffset = _xmlnsOffset;
		_depth++;
		_inStartElement = true;
		_attributeCount = 0;
		_elementStream.Position = 0L;
	}

	private void EndElement()
	{
		_depth--;
		_xmlnsAttributeCount = _scopes[_depth].xmlnsAttributeCount;
		_xmlnsOffset = _scopes[_depth].xmlnsOffset;
	}

	public void WriteStartElement(string prefix, string localName)
	{
		if (prefix == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("prefix");
		}
		if (localName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("localName");
		}
		ThrowIfClosed();
		bool flag = _depth == 0;
		StartElement();
		_element.prefixOffset = _elementWriter.Position + 1;
		_element.prefixLength = Encoding.UTF8.GetByteCount(prefix);
		_element.localNameOffset = _element.prefixOffset + _element.prefixLength + ((_element.prefixLength != 0) ? 1 : 0);
		_element.localNameLength = Encoding.UTF8.GetByteCount(localName);
		_elementWriter.WriteStartElement(prefix, localName);
		if (!flag || _inclusivePrefixes == null)
		{
			return;
		}
		for (int i = 0; i < _scopes[0].xmlnsAttributeCount; i++)
		{
			if (IsInclusivePrefix(ref _xmlnsAttributes[i]))
			{
				XmlnsAttribute xmlnsAttribute = _xmlnsAttributes[i];
				AddXmlnsAttribute(ref xmlnsAttribute);
			}
		}
	}

	public void WriteStartElement(byte[] prefixBuffer, int prefixOffset, int prefixLength, byte[] localNameBuffer, int localNameOffset, int localNameLength)
	{
		if (prefixBuffer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("prefixBuffer"));
		}
		if (prefixOffset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixOffset", System.SR.ValueMustBeNonNegative));
		}
		if (prefixOffset > prefixBuffer.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixOffset", System.SR.Format(System.SR.OffsetExceedsBufferSize, prefixBuffer.Length)));
		}
		if (prefixLength < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixLength", System.SR.ValueMustBeNonNegative));
		}
		if (prefixLength > prefixBuffer.Length - prefixOffset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixLength", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, prefixBuffer.Length - prefixOffset)));
		}
		if (localNameBuffer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("localNameBuffer"));
		}
		if (localNameOffset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("localNameOffset", System.SR.ValueMustBeNonNegative));
		}
		if (localNameOffset > localNameBuffer.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("localNameOffset", System.SR.Format(System.SR.OffsetExceedsBufferSize, localNameBuffer.Length)));
		}
		if (localNameLength < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("localNameLength", System.SR.ValueMustBeNonNegative));
		}
		if (localNameLength > localNameBuffer.Length - localNameOffset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("localNameLength", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, localNameBuffer.Length - localNameOffset)));
		}
		ThrowIfClosed();
		bool flag = _depth == 0;
		StartElement();
		_element.prefixOffset = _elementWriter.Position + 1;
		_element.prefixLength = prefixLength;
		_element.localNameOffset = _element.prefixOffset + prefixLength + ((prefixLength != 0) ? 1 : 0);
		_element.localNameLength = localNameLength;
		_elementWriter.WriteStartElement(prefixBuffer, prefixOffset, prefixLength, localNameBuffer, localNameOffset, localNameLength);
		if (!flag || _inclusivePrefixes == null)
		{
			return;
		}
		for (int i = 0; i < _scopes[0].xmlnsAttributeCount; i++)
		{
			if (IsInclusivePrefix(ref _xmlnsAttributes[i]))
			{
				XmlnsAttribute xmlnsAttribute = _xmlnsAttributes[i];
				AddXmlnsAttribute(ref xmlnsAttribute);
			}
		}
	}

	private bool IsInclusivePrefix(ref XmlnsAttribute xmlnsAttribute)
	{
		for (int i = 0; i < _inclusivePrefixes.Length; i++)
		{
			if (_inclusivePrefixes[i].Length == xmlnsAttribute.prefixLength && string.Equals(Encoding.UTF8.GetString(_xmlnsBuffer, xmlnsAttribute.prefixOffset, xmlnsAttribute.prefixLength), _inclusivePrefixes[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	public void WriteEndStartElement(bool isEmpty)
	{
		ThrowIfClosed();
		_elementWriter.Flush();
		_elementBuffer = _elementStream.GetBuffer();
		_inStartElement = false;
		ResolvePrefixes();
		_writer.WriteStartElement(_elementBuffer, _element.prefixOffset, _element.prefixLength, _elementBuffer, _element.localNameOffset, _element.localNameLength);
		for (int i = _scopes[_depth - 1].xmlnsAttributeCount; i < _xmlnsAttributeCount; i++)
		{
			int num = i - 1;
			bool flag = false;
			while (num >= 0)
			{
				if (Equals(_xmlnsBuffer, _xmlnsAttributes[i].prefixOffset, _xmlnsAttributes[i].prefixLength, _xmlnsBuffer, _xmlnsAttributes[num].prefixOffset, _xmlnsAttributes[num].prefixLength))
				{
					if (!Equals(_xmlnsBuffer, _xmlnsAttributes[i].nsOffset, _xmlnsAttributes[i].nsLength, _xmlnsBuffer, _xmlnsAttributes[num].nsOffset, _xmlnsAttributes[num].nsLength))
					{
						break;
					}
					if (_xmlnsAttributes[num].referred)
					{
						flag = true;
						break;
					}
				}
				num--;
			}
			if (!flag)
			{
				WriteXmlnsAttribute(ref _xmlnsAttributes[i]);
			}
		}
		if (_attributeCount > 0)
		{
			if (_attributeCount > 1)
			{
				SortAttributes();
			}
			for (int j = 0; j < _attributeCount; j++)
			{
				_writer.WriteText(_elementBuffer, _attributes[j].offset, _attributes[j].length);
			}
		}
		_writer.WriteEndStartElement(isEmpty: false);
		if (isEmpty)
		{
			_writer.WriteEndElement(_elementBuffer, _element.prefixOffset, _element.prefixLength, _elementBuffer, _element.localNameOffset, _element.localNameLength);
			EndElement();
		}
		_elementBuffer = null;
	}

	public void WriteEndElement(string prefix, string localName)
	{
		if (prefix == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("prefix");
		}
		if (localName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("localName");
		}
		ThrowIfClosed();
		_writer.WriteEndElement(prefix, localName);
		EndElement();
	}

	[MemberNotNull("_xmlnsBuffer")]
	private void EnsureXmlnsBuffer(int byteCount)
	{
		if (_xmlnsBuffer == null)
		{
			_xmlnsBuffer = new byte[Math.Max(byteCount, 128)];
		}
		else if (_xmlnsOffset + byteCount > _xmlnsBuffer.Length)
		{
			byte[] array = new byte[Math.Max(_xmlnsOffset + byteCount, _xmlnsBuffer.Length * 2)];
			Buffer.BlockCopy(_xmlnsBuffer, 0, array, 0, _xmlnsOffset);
			_xmlnsBuffer = array;
		}
	}

	[MemberNotNull("_xmlnsAttributes")]
	public void WriteXmlnsAttribute(string prefix, string ns)
	{
		if (prefix == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("prefix");
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("ns");
		}
		ThrowIfClosed();
		if (prefix.Length > int.MaxValue - ns.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("ns", System.SR.Format(System.SR.CombinedPrefixNSLength, 715827882)));
		}
		int num = prefix.Length + ns.Length;
		if (num > 715827882)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("ns", System.SR.Format(System.SR.CombinedPrefixNSLength, 715827882)));
		}
		EnsureXmlnsBuffer(num * 3);
		Unsafe.SkipInit(out XmlnsAttribute xmlnsAttribute);
		xmlnsAttribute.prefixOffset = _xmlnsOffset;
		xmlnsAttribute.prefixLength = Encoding.UTF8.GetBytes(prefix, 0, prefix.Length, _xmlnsBuffer, _xmlnsOffset);
		_xmlnsOffset += xmlnsAttribute.prefixLength;
		xmlnsAttribute.nsOffset = _xmlnsOffset;
		xmlnsAttribute.nsLength = Encoding.UTF8.GetBytes(ns, 0, ns.Length, _xmlnsBuffer, _xmlnsOffset);
		_xmlnsOffset += xmlnsAttribute.nsLength;
		xmlnsAttribute.referred = false;
		AddXmlnsAttribute(ref xmlnsAttribute);
	}

	[MemberNotNull("_xmlnsAttributes")]
	public void WriteXmlnsAttribute(byte[] prefixBuffer, int prefixOffset, int prefixLength, byte[] nsBuffer, int nsOffset, int nsLength)
	{
		if (prefixBuffer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("prefixBuffer"));
		}
		if (prefixOffset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixOffset", System.SR.ValueMustBeNonNegative));
		}
		if (prefixOffset > prefixBuffer.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixOffset", System.SR.Format(System.SR.OffsetExceedsBufferSize, prefixBuffer.Length)));
		}
		if (prefixLength < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixLength", System.SR.ValueMustBeNonNegative));
		}
		if (prefixLength > prefixBuffer.Length - prefixOffset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixLength", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, prefixBuffer.Length - prefixOffset)));
		}
		if (nsBuffer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("nsBuffer"));
		}
		if (nsOffset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("nsOffset", System.SR.ValueMustBeNonNegative));
		}
		if (nsOffset > nsBuffer.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("nsOffset", System.SR.Format(System.SR.OffsetExceedsBufferSize, nsBuffer.Length)));
		}
		if (nsLength < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("nsLength", System.SR.ValueMustBeNonNegative));
		}
		if (nsLength > nsBuffer.Length - nsOffset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("nsLength", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, nsBuffer.Length - nsOffset)));
		}
		ThrowIfClosed();
		if (prefixLength > int.MaxValue - nsLength)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("nsLength", System.SR.Format(System.SR.CombinedPrefixNSLength, int.MaxValue)));
		}
		EnsureXmlnsBuffer(prefixLength + nsLength);
		Unsafe.SkipInit(out XmlnsAttribute xmlnsAttribute);
		xmlnsAttribute.prefixOffset = _xmlnsOffset;
		xmlnsAttribute.prefixLength = prefixLength;
		Buffer.BlockCopy(prefixBuffer, prefixOffset, _xmlnsBuffer, _xmlnsOffset, prefixLength);
		_xmlnsOffset += prefixLength;
		xmlnsAttribute.nsOffset = _xmlnsOffset;
		xmlnsAttribute.nsLength = nsLength;
		Buffer.BlockCopy(nsBuffer, nsOffset, _xmlnsBuffer, _xmlnsOffset, nsLength);
		_xmlnsOffset += nsLength;
		xmlnsAttribute.referred = false;
		AddXmlnsAttribute(ref xmlnsAttribute);
	}

	public void WriteStartAttribute(string prefix, string localName)
	{
		if (prefix == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("prefix");
		}
		if (localName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("localName");
		}
		ThrowIfClosed();
		_attribute.offset = _elementWriter.Position;
		_attribute.length = 0;
		_attribute.prefixOffset = _attribute.offset + 1;
		_attribute.prefixLength = Encoding.UTF8.GetByteCount(prefix);
		_attribute.localNameOffset = _attribute.prefixOffset + _attribute.prefixLength + ((_attribute.prefixLength != 0) ? 1 : 0);
		_attribute.localNameLength = Encoding.UTF8.GetByteCount(localName);
		_attribute.nsOffset = 0;
		_attribute.nsLength = 0;
		_elementWriter.WriteStartAttribute(prefix, localName);
	}

	public void WriteStartAttribute(byte[] prefixBuffer, int prefixOffset, int prefixLength, byte[] localNameBuffer, int localNameOffset, int localNameLength)
	{
		if (prefixBuffer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("prefixBuffer"));
		}
		if (prefixOffset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixOffset", System.SR.ValueMustBeNonNegative));
		}
		if (prefixOffset > prefixBuffer.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixOffset", System.SR.Format(System.SR.OffsetExceedsBufferSize, prefixBuffer.Length)));
		}
		if (prefixLength < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixLength", System.SR.ValueMustBeNonNegative));
		}
		if (prefixLength > prefixBuffer.Length - prefixOffset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefixLength", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, prefixBuffer.Length - prefixOffset)));
		}
		if (localNameBuffer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("localNameBuffer"));
		}
		if (localNameOffset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("localNameOffset", System.SR.ValueMustBeNonNegative));
		}
		if (localNameOffset > localNameBuffer.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("localNameOffset", System.SR.Format(System.SR.OffsetExceedsBufferSize, localNameBuffer.Length)));
		}
		if (localNameLength < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("localNameLength", System.SR.ValueMustBeNonNegative));
		}
		if (localNameLength > localNameBuffer.Length - localNameOffset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("localNameLength", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, localNameBuffer.Length - localNameOffset)));
		}
		ThrowIfClosed();
		_attribute.offset = _elementWriter.Position;
		_attribute.length = 0;
		_attribute.prefixOffset = _attribute.offset + 1;
		_attribute.prefixLength = prefixLength;
		_attribute.localNameOffset = _attribute.prefixOffset + prefixLength + ((prefixLength != 0) ? 1 : 0);
		_attribute.localNameLength = localNameLength;
		_attribute.nsOffset = 0;
		_attribute.nsLength = 0;
		_elementWriter.WriteStartAttribute(prefixBuffer, prefixOffset, prefixLength, localNameBuffer, localNameOffset, localNameLength);
	}

	public void WriteEndAttribute()
	{
		ThrowIfClosed();
		_elementWriter.WriteEndAttribute();
		_attribute.length = _elementWriter.Position - _attribute.offset;
		AddAttribute(ref _attribute);
	}

	public void WriteCharEntity(int ch)
	{
		ThrowIfClosed();
		if (ch <= 65535)
		{
			char[] chars = new char[1] { (char)ch };
			WriteEscapedText(chars, 0, 1);
		}
		else
		{
			WriteText(ch);
		}
	}

	public void WriteEscapedText(string value)
	{
		if (value == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
		ThrowIfClosed();
		if (_depth > 0)
		{
			if (_inStartElement)
			{
				_elementWriter.WriteEscapedText(value);
			}
			else
			{
				_writer.WriteEscapedText(value);
			}
		}
	}

	public void WriteEscapedText(byte[] chars, int offset, int count)
	{
		if (chars == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("chars"));
		}
		if (offset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.ValueMustBeNonNegative));
		}
		if (offset > chars.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.Format(System.SR.OffsetExceedsBufferSize, chars.Length)));
		}
		if (count < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.ValueMustBeNonNegative));
		}
		if (count > chars.Length - offset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, chars.Length - offset)));
		}
		ThrowIfClosed();
		if (_depth > 0)
		{
			if (_inStartElement)
			{
				_elementWriter.WriteEscapedText(chars, offset, count);
			}
			else
			{
				_writer.WriteEscapedText(chars, offset, count);
			}
		}
	}

	public void WriteEscapedText(char[] chars, int offset, int count)
	{
		ThrowIfClosed();
		if (_depth > 0)
		{
			if (_inStartElement)
			{
				_elementWriter.WriteEscapedText(chars, offset, count);
			}
			else
			{
				_writer.WriteEscapedText(chars, offset, count);
			}
		}
	}

	public void WriteText(int ch)
	{
		ThrowIfClosed();
		if (_inStartElement)
		{
			_elementWriter.WriteText(ch);
		}
		else
		{
			_writer.WriteText(ch);
		}
	}

	public void WriteText(byte[] chars, int offset, int count)
	{
		ThrowIfClosed();
		if (chars == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("chars"));
		}
		if (offset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.ValueMustBeNonNegative));
		}
		if (offset > chars.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.Format(System.SR.OffsetExceedsBufferSize, chars.Length)));
		}
		if (count < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.ValueMustBeNonNegative));
		}
		if (count > chars.Length - offset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, chars.Length - offset)));
		}
		if (_inStartElement)
		{
			_elementWriter.WriteText(chars, offset, count);
		}
		else
		{
			_writer.WriteText(chars, offset, count);
		}
	}

	public void WriteText(string value)
	{
		if (value == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
		if (value.Length > 0)
		{
			if (_inStartElement)
			{
				_elementWriter.WriteText(value);
			}
			else
			{
				_writer.WriteText(value);
			}
		}
	}

	public void WriteText(char[] chars, int offset, int count)
	{
		ThrowIfClosed();
		if (chars == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("chars"));
		}
		if (offset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.ValueMustBeNonNegative));
		}
		if (offset > chars.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.Format(System.SR.OffsetExceedsBufferSize, chars.Length)));
		}
		if (count < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.ValueMustBeNonNegative));
		}
		if (count > chars.Length - offset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, chars.Length - offset)));
		}
		if (_inStartElement)
		{
			_elementWriter.WriteText(chars, offset, count);
		}
		else
		{
			_writer.WriteText(chars, offset, count);
		}
	}

	private void ThrowIfClosed()
	{
		if (_writer == null)
		{
			ThrowClosed();
		}
	}

	private void ThrowClosed()
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().ToString()));
	}

	private void WriteXmlnsAttribute(ref XmlnsAttribute xmlnsAttribute)
	{
		if (xmlnsAttribute.referred)
		{
			_writer.WriteXmlnsAttribute(_xmlnsBuffer, xmlnsAttribute.prefixOffset, xmlnsAttribute.prefixLength, _xmlnsBuffer, xmlnsAttribute.nsOffset, xmlnsAttribute.nsLength);
		}
	}

	private void SortAttributes()
	{
		if (_attributeCount < 16)
		{
			for (int i = 0; i < _attributeCount - 1; i++)
			{
				int num = i;
				for (int j = i + 1; j < _attributeCount; j++)
				{
					if (Compare(ref _attributes[j], ref _attributes[num]) < 0)
					{
						num = j;
					}
				}
				if (num != i)
				{
					Attribute attribute = _attributes[i];
					_attributes[i] = _attributes[num];
					_attributes[num] = attribute;
				}
			}
		}
		else
		{
			new AttributeSorter(this).Sort();
		}
	}

	private void AddAttribute(ref Attribute attribute)
	{
		if (_attributes == null)
		{
			_attributes = new Attribute[4];
		}
		else if (_attributeCount == _attributes.Length)
		{
			Attribute[] array = new Attribute[_attributeCount * 2];
			Array.Copy(_attributes, array, _attributeCount);
			_attributes = array;
		}
		_attributes[_attributeCount] = attribute;
		_attributeCount++;
	}

	[MemberNotNull("_xmlnsAttributes")]
	private void AddXmlnsAttribute(ref XmlnsAttribute xmlnsAttribute)
	{
		if (_xmlnsAttributes == null)
		{
			_xmlnsAttributes = new XmlnsAttribute[4];
		}
		else if (_xmlnsAttributes.Length == _xmlnsAttributeCount)
		{
			XmlnsAttribute[] array = new XmlnsAttribute[_xmlnsAttributeCount * 2];
			Array.Copy(_xmlnsAttributes, array, _xmlnsAttributeCount);
			_xmlnsAttributes = array;
		}
		if (_depth > 0 && _inclusivePrefixes != null && IsInclusivePrefix(ref xmlnsAttribute))
		{
			xmlnsAttribute.referred = true;
		}
		if (_depth == 0)
		{
			_xmlnsAttributes[_xmlnsAttributeCount++] = xmlnsAttribute;
			return;
		}
		int i = _scopes[_depth - 1].xmlnsAttributeCount;
		bool flag = true;
		for (; i < _xmlnsAttributeCount; i++)
		{
			int num = Compare(ref xmlnsAttribute, ref _xmlnsAttributes[i]);
			if (num <= 0)
			{
				if (num == 0)
				{
					_xmlnsAttributes[i] = xmlnsAttribute;
					flag = false;
				}
				break;
			}
		}
		if (flag)
		{
			Array.Copy(_xmlnsAttributes, i, _xmlnsAttributes, i + 1, _xmlnsAttributeCount - i);
			_xmlnsAttributes[i] = xmlnsAttribute;
			_xmlnsAttributeCount++;
		}
	}

	private void ResolvePrefix(int prefixOffset, int prefixLength, out int nsOffset, out int nsLength)
	{
		int xmlnsAttributeCount = _scopes[_depth - 1].xmlnsAttributeCount;
		int num = _xmlnsAttributeCount - 1;
		while (!Equals(_elementBuffer, prefixOffset, prefixLength, _xmlnsBuffer, _xmlnsAttributes[num].prefixOffset, _xmlnsAttributes[num].prefixLength))
		{
			num--;
		}
		nsOffset = _xmlnsAttributes[num].nsOffset;
		nsLength = _xmlnsAttributes[num].nsLength;
		if (num < xmlnsAttributeCount)
		{
			if (!_xmlnsAttributes[num].referred)
			{
				XmlnsAttribute xmlnsAttribute = _xmlnsAttributes[num];
				xmlnsAttribute.referred = true;
				AddXmlnsAttribute(ref xmlnsAttribute);
			}
		}
		else
		{
			_xmlnsAttributes[num].referred = true;
		}
	}

	private void ResolvePrefix(ref Attribute attribute)
	{
		if (attribute.prefixLength != 0)
		{
			ResolvePrefix(attribute.prefixOffset, attribute.prefixLength, out attribute.nsOffset, out attribute.nsLength);
		}
	}

	private void ResolvePrefixes()
	{
		ResolvePrefix(_element.prefixOffset, _element.prefixLength, out var _, out var _);
		for (int i = 0; i < _attributeCount; i++)
		{
			ResolvePrefix(ref _attributes[i]);
		}
	}

	private int Compare(ref XmlnsAttribute xmlnsAttribute1, ref XmlnsAttribute xmlnsAttribute2)
	{
		return Compare(_xmlnsBuffer, xmlnsAttribute1.prefixOffset, xmlnsAttribute1.prefixLength, xmlnsAttribute2.prefixOffset, xmlnsAttribute2.prefixLength);
	}

	private int Compare(ref Attribute attribute1, ref Attribute attribute2)
	{
		int num = Compare(_xmlnsBuffer, attribute1.nsOffset, attribute1.nsLength, attribute2.nsOffset, attribute2.nsLength);
		if (num == 0)
		{
			num = Compare(_elementBuffer, attribute1.localNameOffset, attribute1.localNameLength, attribute2.localNameOffset, attribute2.localNameLength);
		}
		return num;
	}

	private int Compare(byte[] buffer, int offset1, int length1, int offset2, int length2)
	{
		if (offset1 == offset2)
		{
			return length1 - length2;
		}
		return Compare(buffer, offset1, length1, buffer, offset2, length2);
	}

	private int Compare(byte[] buffer1, int offset1, int length1, byte[] buffer2, int offset2, int length2)
	{
		int num = Math.Min(length1, length2);
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			if (num2 != 0)
			{
				break;
			}
			num2 = buffer1[offset1 + i] - buffer2[offset2 + i];
		}
		if (num2 == 0)
		{
			num2 = length1 - length2;
		}
		return num2;
	}

	private bool Equals(byte[] buffer1, int offset1, int length1, byte[] buffer2, int offset2, int length2)
	{
		if (length1 != length2)
		{
			return false;
		}
		for (int i = 0; i < length1; i++)
		{
			if (buffer1[offset1 + i] != buffer2[offset2 + i])
			{
				return false;
			}
		}
		return true;
	}
}
