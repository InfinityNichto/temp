using System.IO;

namespace System.Xml.Serialization;

internal sealed class IndentedWriter
{
	private readonly TextWriter _writer;

	private bool _needIndent;

	private int _indentLevel;

	private readonly bool _compact;

	internal int Indent
	{
		get
		{
			return _indentLevel;
		}
		set
		{
			_indentLevel = value;
		}
	}

	internal IndentedWriter(TextWriter writer, bool compact)
	{
		_writer = writer;
		_compact = compact;
	}

	internal void Write(string s)
	{
		if (_needIndent)
		{
			WriteIndent();
		}
		_writer.Write(s);
	}

	internal void Write(char c)
	{
		if (_needIndent)
		{
			WriteIndent();
		}
		_writer.Write(c);
	}

	internal void WriteLine(string s)
	{
		if (_needIndent)
		{
			WriteIndent();
		}
		_writer.WriteLine(s);
		_needIndent = true;
	}

	internal void WriteLine()
	{
		_writer.WriteLine();
		_needIndent = true;
	}

	internal void WriteIndent()
	{
		_needIndent = false;
		if (!_compact)
		{
			for (int i = 0; i < _indentLevel; i++)
			{
				_writer.Write("    ");
			}
		}
	}
}
