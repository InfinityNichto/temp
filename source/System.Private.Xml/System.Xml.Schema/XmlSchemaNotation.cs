using System.Xml.Serialization;

namespace System.Xml.Schema;

public class XmlSchemaNotation : XmlSchemaAnnotated
{
	private string _name;

	private string _publicId;

	private string _systemId;

	private XmlQualifiedName _qname = XmlQualifiedName.Empty;

	[XmlAttribute("name")]
	public string? Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	[XmlAttribute("public")]
	public string? Public
	{
		get
		{
			return _publicId;
		}
		set
		{
			_publicId = value;
		}
	}

	[XmlAttribute("system")]
	public string? System
	{
		get
		{
			return _systemId;
		}
		set
		{
			_systemId = value;
		}
	}

	[XmlIgnore]
	internal XmlQualifiedName QualifiedName
	{
		get
		{
			return _qname;
		}
		set
		{
			_qname = value;
		}
	}

	[XmlIgnore]
	internal override string? NameAttribute
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}
}
