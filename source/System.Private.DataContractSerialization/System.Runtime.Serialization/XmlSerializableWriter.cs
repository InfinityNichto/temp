using System.Xml;

namespace System.Runtime.Serialization;

internal sealed class XmlSerializableWriter : XmlWriter
{
	private XmlWriter _xmlWriter;

	private int _depth;

	private object _obj;

	public override WriteState WriteState => _xmlWriter.WriteState;

	public override XmlSpace XmlSpace => _xmlWriter.XmlSpace;

	public override string XmlLang => _xmlWriter.XmlLang;

	internal void BeginWrite(XmlWriter xmlWriter, object obj)
	{
		_depth = 0;
		_xmlWriter = xmlWriter;
		_obj = obj;
	}

	internal void EndWrite()
	{
		if (_depth != 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(XmlObjectSerializer.CreateSerializationException(System.SR.Format(System.SR.IXmlSerializableMissingEndElements, (_obj == null) ? string.Empty : DataContract.GetClrTypeFullName(_obj.GetType()))));
		}
		_obj = null;
	}

	public override void WriteStartDocument()
	{
		if (WriteState == WriteState.Start)
		{
			_xmlWriter.WriteStartDocument();
		}
	}

	public override void WriteEndDocument()
	{
		_xmlWriter.WriteEndDocument();
	}

	public override void WriteStartDocument(bool standalone)
	{
		if (WriteState == WriteState.Start)
		{
			_xmlWriter.WriteStartDocument(standalone);
		}
	}

	public override void WriteDocType(string name, string pubid, string sysid, string subset)
	{
	}

	public override void WriteStartElement(string prefix, string localName, string ns)
	{
		_xmlWriter.WriteStartElement(prefix, localName, ns);
		_depth++;
	}

	public override void WriteEndElement()
	{
		if (_depth == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(XmlObjectSerializer.CreateSerializationException(System.SR.Format(System.SR.IXmlSerializableWritePastSubTree, (_obj == null) ? string.Empty : DataContract.GetClrTypeFullName(_obj.GetType()))));
		}
		_xmlWriter.WriteEndElement();
		_depth--;
	}

	public override void WriteFullEndElement()
	{
		if (_depth == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(XmlObjectSerializer.CreateSerializationException(System.SR.Format(System.SR.IXmlSerializableWritePastSubTree, (_obj == null) ? string.Empty : DataContract.GetClrTypeFullName(_obj.GetType()))));
		}
		_xmlWriter.WriteFullEndElement();
		_depth--;
	}

	public override void Close()
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(XmlObjectSerializer.CreateSerializationException(System.SR.IXmlSerializableIllegalOperation));
	}

	public override void WriteStartAttribute(string prefix, string localName, string ns)
	{
		_xmlWriter.WriteStartAttribute(prefix, localName, ns);
	}

	public override void WriteEndAttribute()
	{
		_xmlWriter.WriteEndAttribute();
	}

	public override void WriteCData(string text)
	{
		_xmlWriter.WriteCData(text);
	}

	public override void WriteComment(string text)
	{
		_xmlWriter.WriteComment(text);
	}

	public override void WriteProcessingInstruction(string name, string text)
	{
		_xmlWriter.WriteProcessingInstruction(name, text);
	}

	public override void WriteEntityRef(string name)
	{
		_xmlWriter.WriteEntityRef(name);
	}

	public override void WriteCharEntity(char ch)
	{
		_xmlWriter.WriteCharEntity(ch);
	}

	public override void WriteWhitespace(string ws)
	{
		_xmlWriter.WriteWhitespace(ws);
	}

	public override void WriteString(string text)
	{
		_xmlWriter.WriteString(text);
	}

	public override void WriteSurrogateCharEntity(char lowChar, char highChar)
	{
		_xmlWriter.WriteSurrogateCharEntity(lowChar, highChar);
	}

	public override void WriteChars(char[] buffer, int index, int count)
	{
		_xmlWriter.WriteChars(buffer, index, count);
	}

	public override void WriteRaw(char[] buffer, int index, int count)
	{
		_xmlWriter.WriteRaw(buffer, index, count);
	}

	public override void WriteRaw(string data)
	{
		_xmlWriter.WriteRaw(data);
	}

	public override void WriteBase64(byte[] buffer, int index, int count)
	{
		_xmlWriter.WriteBase64(buffer, index, count);
	}

	public override void WriteBinHex(byte[] buffer, int index, int count)
	{
		_xmlWriter.WriteBinHex(buffer, index, count);
	}

	public override void Flush()
	{
		_xmlWriter.Flush();
	}

	public override void WriteName(string name)
	{
		_xmlWriter.WriteName(name);
	}

	public override void WriteQualifiedName(string localName, string ns)
	{
		_xmlWriter.WriteQualifiedName(localName, ns);
	}

	public override string LookupPrefix(string ns)
	{
		return _xmlWriter.LookupPrefix(ns);
	}

	public override void WriteNmToken(string name)
	{
		_xmlWriter.WriteNmToken(name);
	}
}
