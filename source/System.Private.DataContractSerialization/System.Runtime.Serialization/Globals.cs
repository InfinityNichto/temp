using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.Runtime.Serialization;

internal static class Globals
{
	internal const BindingFlags ScanAllMembers = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	private static XmlQualifiedName s_idQualifiedName;

	private static XmlQualifiedName s_refQualifiedName;

	private static Type s_typeOfObject;

	private static Type s_typeOfValueType;

	private static Type s_typeOfArray;

	private static Type s_typeOfString;

	private static Type s_typeOfInt;

	private static Type s_typeOfULong;

	private static Type s_typeOfVoid;

	private static Type s_typeOfByteArray;

	private static Type s_typeOfTimeSpan;

	private static Type s_typeOfGuid;

	private static Type s_typeOfDateTimeOffset;

	private static Type s_typeOfDateTimeOffsetAdapter;

	private static Type s_typeOfMemoryStream;

	private static Type s_typeOfMemoryStreamAdapter;

	private static Type s_typeOfUri;

	private static Type s_typeOfTypeEnumerable;

	private static Type s_typeOfStreamingContext;

	private static Type s_typeOfISerializable;

	private static Type s_typeOfIDeserializationCallback;

	private static Type s_typeOfIObjectReference;

	private static Type s_typeOfXmlFormatClassWriterDelegate;

	private static Type s_typeOfXmlFormatCollectionWriterDelegate;

	private static Type s_typeOfXmlFormatClassReaderDelegate;

	private static Type s_typeOfXmlFormatCollectionReaderDelegate;

	private static Type s_typeOfXmlFormatGetOnlyCollectionReaderDelegate;

	private static Type s_typeOfKnownTypeAttribute;

	private static Type s_typeOfDataContractAttribute;

	private static Type s_typeOfDataMemberAttribute;

	private static Type s_typeOfEnumMemberAttribute;

	private static Type s_typeOfCollectionDataContractAttribute;

	private static Type s_typeOfOptionalFieldAttribute;

	private static Type s_typeOfObjectArray;

	private static Type s_typeOfOnSerializingAttribute;

	private static Type s_typeOfOnSerializedAttribute;

	private static Type s_typeOfOnDeserializingAttribute;

	private static Type s_typeOfOnDeserializedAttribute;

	private static Type s_typeOfFlagsAttribute;

	private static Type s_typeOfIXmlSerializable;

	private static Type s_typeOfXmlSchemaProviderAttribute;

	private static Type s_typeOfXmlRootAttribute;

	private static Type s_typeOfXmlQualifiedName;

	private static Type s_typeOfXmlSchemaType;

	private static Type s_typeOfIExtensibleDataObject;

	private static Type s_typeOfExtensionDataObject;

	private static Type s_typeOfISerializableDataNode;

	private static Type s_typeOfClassDataNode;

	private static Type s_typeOfCollectionDataNode;

	private static Type s_typeOfXmlDataNode;

	private static Type s_typeOfNullable;

	private static Type s_typeOfIDictionaryGeneric;

	private static Type s_typeOfIDictionary;

	private static Type s_typeOfIListGeneric;

	private static Type s_typeOfIList;

	private static Type s_typeOfICollectionGeneric;

	private static Type s_typeOfICollection;

	private static Type s_typeOfIEnumerableGeneric;

	private static Type s_typeOfIEnumerable;

	private static Type s_typeOfIEnumeratorGeneric;

	private static Type s_typeOfIEnumerator;

	private static Type s_typeOfKeyValuePair;

	private static Type s_typeOfKeyValuePairAdapter;

	private static Type s_typeOfKeyValue;

	private static Type s_typeOfIDictionaryEnumerator;

	private static Type s_typeOfDictionaryEnumerator;

	private static Type s_typeOfGenericDictionaryEnumerator;

	private static Type s_typeOfDictionaryGeneric;

	private static Type s_typeOfHashtable;

	private static Type s_typeOfXmlElement;

	private static Type s_typeOfXmlNodeArray;

	private static Type s_typeOfDBNull;

	private static Uri s_dataContractXsdBaseNamespaceUri;

	private static readonly Type s_typeOfScriptObject;

	public const bool DefaultIsRequired = false;

	public const bool DefaultEmitDefaultValue = true;

	public const int DefaultOrder = 0;

	public const bool DefaultIsReference = false;

	public static readonly string NewObjectId = string.Empty;

	public const string NullObjectId = null;

	public const string FullSRSInternalsVisiblePattern = "^[\\s]*System\\.Runtime\\.Serialization[\\s]*,[\\s]*PublicKey[\\s]*=[\\s]*(?i:00240000048000009400000006020000002400005253413100040000010001008d56c76f9e8649383049f383c44be0ec204181822a6c31cf5eb7ef486944d032188ea1d3920763712ccb12d75fb77e9811149e6148e5d32fbaab37611c1878ddc19e20ef135d0cb2cff2bfec3d115810c3d9069638fe4be215dbf795861920e5ab6f7db2e2ceef136ac23d5dd2bf031700aec232f6c6b1c785b4305c123b37ab)[\\s]*$";

	public const string Space = " ";

	public const string XsiPrefix = "i";

	public const string XsdPrefix = "x";

	public const string SerPrefix = "z";

	public const string SerPrefixForSchema = "ser";

	public const string ElementPrefix = "q";

	public const string DataContractXsdBaseNamespace = "http://schemas.datacontract.org/2004/07/";

	public const string DataContractXmlNamespace = "http://schemas.datacontract.org/2004/07/System.Xml";

	public const string SchemaInstanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";

	public const string SchemaNamespace = "http://www.w3.org/2001/XMLSchema";

	public const string XsiNilLocalName = "nil";

	public const string XsiTypeLocalName = "type";

	public const string TnsPrefix = "tns";

	public const string OccursUnbounded = "unbounded";

	public const string AnyTypeLocalName = "anyType";

	public const string StringLocalName = "string";

	public const string IntLocalName = "int";

	public const string True = "true";

	public const string False = "false";

	public const string ArrayPrefix = "ArrayOf";

	public const string XmlnsNamespace = "http://www.w3.org/2000/xmlns/";

	public const string XmlnsPrefix = "xmlns";

	public const string SchemaLocalName = "schema";

	public const string CollectionsNamespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";

	public const string DefaultClrNamespace = "GeneratedNamespace";

	public const string DefaultTypeName = "GeneratedType";

	public const string DefaultGeneratedMember = "GeneratedMember";

	public const string DefaultFieldSuffix = "Field";

	public const string DefaultPropertySuffix = "Property";

	public const string DefaultMemberSuffix = "Member";

	public const string NameProperty = "Name";

	public const string NamespaceProperty = "Namespace";

	public const string OrderProperty = "Order";

	public const string IsReferenceProperty = "IsReference";

	public const string IsRequiredProperty = "IsRequired";

	public const string EmitDefaultValueProperty = "EmitDefaultValue";

	public const string ClrNamespaceProperty = "ClrNamespace";

	public const string ItemNameProperty = "ItemName";

	public const string KeyNameProperty = "KeyName";

	public const string ValueNameProperty = "ValueName";

	public const string SerializationInfoPropertyName = "SerializationInfo";

	public const string SerializationInfoFieldName = "info";

	public const string NodeArrayPropertyName = "Nodes";

	public const string NodeArrayFieldName = "nodesField";

	public const string ExportSchemaMethod = "ExportSchema";

	public const string IsAnyProperty = "IsAny";

	public const string ContextFieldName = "context";

	public const string GetObjectDataMethodName = "GetObjectData";

	public const string GetEnumeratorMethodName = "GetEnumerator";

	public const string MoveNextMethodName = "MoveNext";

	public const string AddValueMethodName = "AddValue";

	public const string CurrentPropertyName = "Current";

	public const string ValueProperty = "Value";

	public const string EnumeratorFieldName = "enumerator";

	public const string SerializationEntryFieldName = "entry";

	public const string ExtensionDataSetMethod = "set_ExtensionData";

	public const string ExtensionDataSetExplicitMethod = "System.Runtime.Serialization.IExtensibleDataObject.set_ExtensionData";

	public const string ExtensionDataObjectPropertyName = "ExtensionData";

	public const string ExtensionDataObjectFieldName = "extensionDataField";

	public const string AddMethodName = "Add";

	public const string GetCurrentMethodName = "get_Current";

	public const string SerializationNamespace = "http://schemas.microsoft.com/2003/10/Serialization/";

	public const string ClrTypeLocalName = "Type";

	public const string ClrAssemblyLocalName = "Assembly";

	public const string IsValueTypeLocalName = "IsValueType";

	public const string EnumerationValueLocalName = "EnumerationValue";

	public const string SurrogateDataLocalName = "Surrogate";

	public const string GenericTypeLocalName = "GenericType";

	public const string GenericParameterLocalName = "GenericParameter";

	public const string GenericNameAttribute = "Name";

	public const string GenericNamespaceAttribute = "Namespace";

	public const string GenericParameterNestedLevelAttribute = "NestedLevel";

	public const string IsDictionaryLocalName = "IsDictionary";

	public const string ActualTypeLocalName = "ActualType";

	public const string ActualTypeNameAttribute = "Name";

	public const string ActualTypeNamespaceAttribute = "Namespace";

	public const string DefaultValueLocalName = "DefaultValue";

	public const string EmitDefaultValueAttribute = "EmitDefaultValue";

	public const string IdLocalName = "Id";

	public const string RefLocalName = "Ref";

	public const string ArraySizeLocalName = "Size";

	public const string KeyLocalName = "Key";

	public const string ValueLocalName = "Value";

	public const string MscorlibAssemblyName = "0";

	public const string ParseMethodName = "Parse";

	public const string SafeSerializationManagerName = "SafeSerializationManager";

	public const string SafeSerializationManagerNamespace = "http://schemas.datacontract.org/2004/07/System.Runtime.Serialization";

	public const string ISerializableFactoryTypeLocalName = "FactoryType";

	public const string SerializationSchema = "<?xml version='1.0' encoding='utf-8'?>\r\n<xs:schema elementFormDefault='qualified' attributeFormDefault='qualified' xmlns:tns='http://schemas.microsoft.com/2003/10/Serialization/' targetNamespace='http://schemas.microsoft.com/2003/10/Serialization/' xmlns:xs='http://www.w3.org/2001/XMLSchema'>\r\n  <xs:element name='anyType' nillable='true' type='xs:anyType' />\r\n  <xs:element name='anyURI' nillable='true' type='xs:anyURI' />\r\n  <xs:element name='base64Binary' nillable='true' type='xs:base64Binary' />\r\n  <xs:element name='boolean' nillable='true' type='xs:boolean' />\r\n  <xs:element name='byte' nillable='true' type='xs:byte' />\r\n  <xs:element name='dateTime' nillable='true' type='xs:dateTime' />\r\n  <xs:element name='decimal' nillable='true' type='xs:decimal' />\r\n  <xs:element name='double' nillable='true' type='xs:double' />\r\n  <xs:element name='float' nillable='true' type='xs:float' />\r\n  <xs:element name='int' nillable='true' type='xs:int' />\r\n  <xs:element name='long' nillable='true' type='xs:long' />\r\n  <xs:element name='QName' nillable='true' type='xs:QName' />\r\n  <xs:element name='short' nillable='true' type='xs:short' />\r\n  <xs:element name='string' nillable='true' type='xs:string' />\r\n  <xs:element name='unsignedByte' nillable='true' type='xs:unsignedByte' />\r\n  <xs:element name='unsignedInt' nillable='true' type='xs:unsignedInt' />\r\n  <xs:element name='unsignedLong' nillable='true' type='xs:unsignedLong' />\r\n  <xs:element name='unsignedShort' nillable='true' type='xs:unsignedShort' />\r\n  <xs:element name='char' nillable='true' type='tns:char' />\r\n  <xs:simpleType name='char'>\r\n    <xs:restriction base='xs:int'/>\r\n  </xs:simpleType>\r\n  <xs:element name='duration' nillable='true' type='tns:duration' />\r\n  <xs:simpleType name='duration'>\r\n    <xs:restriction base='xs:duration'>\r\n      <xs:pattern value='\\-?P(\\d*D)?(T(\\d*H)?(\\d*M)?(\\d*(\\.\\d*)?S)?)?' />\r\n      <xs:minInclusive value='-P10675199DT2H48M5.4775808S' />\r\n      <xs:maxInclusive value='P10675199DT2H48M5.4775807S' />\r\n    </xs:restriction>\r\n  </xs:simpleType>\r\n  <xs:element name='guid' nillable='true' type='tns:guid' />\r\n  <xs:simpleType name='guid'>\r\n    <xs:restriction base='xs:string'>\r\n      <xs:pattern value='[\\da-fA-F]{8}-[\\da-fA-F]{4}-[\\da-fA-F]{4}-[\\da-fA-F]{4}-[\\da-fA-F]{12}' />\r\n    </xs:restriction>\r\n  </xs:simpleType>\r\n  <xs:attribute name='FactoryType' type='xs:QName' />\r\n  <xs:attribute name='Id' type='xs:ID' />\r\n  <xs:attribute name='Ref' type='xs:IDREF' />\r\n</xs:schema>\r\n";

	internal static XmlQualifiedName IdQualifiedName
	{
		get
		{
			if (s_idQualifiedName == null)
			{
				s_idQualifiedName = new XmlQualifiedName("Id", "http://schemas.microsoft.com/2003/10/Serialization/");
			}
			return s_idQualifiedName;
		}
	}

	internal static XmlQualifiedName RefQualifiedName
	{
		get
		{
			if (s_refQualifiedName == null)
			{
				s_refQualifiedName = new XmlQualifiedName("Ref", "http://schemas.microsoft.com/2003/10/Serialization/");
			}
			return s_refQualifiedName;
		}
	}

	internal static Type TypeOfObject
	{
		get
		{
			if (s_typeOfObject == null)
			{
				s_typeOfObject = typeof(object);
			}
			return s_typeOfObject;
		}
	}

	internal static Type TypeOfValueType
	{
		get
		{
			if (s_typeOfValueType == null)
			{
				s_typeOfValueType = typeof(ValueType);
			}
			return s_typeOfValueType;
		}
	}

	internal static Type TypeOfArray
	{
		get
		{
			if (s_typeOfArray == null)
			{
				s_typeOfArray = typeof(Array);
			}
			return s_typeOfArray;
		}
	}

	internal static Type TypeOfString
	{
		get
		{
			if (s_typeOfString == null)
			{
				s_typeOfString = typeof(string);
			}
			return s_typeOfString;
		}
	}

	internal static Type TypeOfInt
	{
		get
		{
			if (s_typeOfInt == null)
			{
				s_typeOfInt = typeof(int);
			}
			return s_typeOfInt;
		}
	}

	internal static Type TypeOfULong
	{
		get
		{
			if (s_typeOfULong == null)
			{
				s_typeOfULong = typeof(ulong);
			}
			return s_typeOfULong;
		}
	}

	internal static Type TypeOfVoid
	{
		get
		{
			if (s_typeOfVoid == null)
			{
				s_typeOfVoid = typeof(void);
			}
			return s_typeOfVoid;
		}
	}

	internal static Type TypeOfByteArray
	{
		get
		{
			if (s_typeOfByteArray == null)
			{
				s_typeOfByteArray = typeof(byte[]);
			}
			return s_typeOfByteArray;
		}
	}

	internal static Type TypeOfTimeSpan
	{
		get
		{
			if (s_typeOfTimeSpan == null)
			{
				s_typeOfTimeSpan = typeof(TimeSpan);
			}
			return s_typeOfTimeSpan;
		}
	}

	internal static Type TypeOfGuid
	{
		get
		{
			if (s_typeOfGuid == null)
			{
				s_typeOfGuid = typeof(Guid);
			}
			return s_typeOfGuid;
		}
	}

	internal static Type TypeOfDateTimeOffset
	{
		get
		{
			if (s_typeOfDateTimeOffset == null)
			{
				s_typeOfDateTimeOffset = typeof(DateTimeOffset);
			}
			return s_typeOfDateTimeOffset;
		}
	}

	internal static Type TypeOfDateTimeOffsetAdapter
	{
		get
		{
			if (s_typeOfDateTimeOffsetAdapter == null)
			{
				s_typeOfDateTimeOffsetAdapter = typeof(DateTimeOffsetAdapter);
			}
			return s_typeOfDateTimeOffsetAdapter;
		}
	}

	internal static Type TypeOfMemoryStream
	{
		get
		{
			if (s_typeOfMemoryStream == null)
			{
				s_typeOfMemoryStream = typeof(MemoryStream);
			}
			return s_typeOfMemoryStream;
		}
	}

	internal static Type TypeOfMemoryStreamAdapter
	{
		get
		{
			if (s_typeOfMemoryStreamAdapter == null)
			{
				s_typeOfMemoryStreamAdapter = typeof(MemoryStreamAdapter);
			}
			return s_typeOfMemoryStreamAdapter;
		}
	}

	internal static Type TypeOfUri
	{
		get
		{
			if (s_typeOfUri == null)
			{
				s_typeOfUri = typeof(Uri);
			}
			return s_typeOfUri;
		}
	}

	internal static Type TypeOfTypeEnumerable
	{
		get
		{
			if (s_typeOfTypeEnumerable == null)
			{
				s_typeOfTypeEnumerable = typeof(IEnumerable<Type>);
			}
			return s_typeOfTypeEnumerable;
		}
	}

	internal static Type TypeOfStreamingContext
	{
		get
		{
			if (s_typeOfStreamingContext == null)
			{
				s_typeOfStreamingContext = typeof(StreamingContext);
			}
			return s_typeOfStreamingContext;
		}
	}

	internal static Type TypeOfISerializable
	{
		get
		{
			if (s_typeOfISerializable == null)
			{
				s_typeOfISerializable = typeof(ISerializable);
			}
			return s_typeOfISerializable;
		}
	}

	internal static Type TypeOfIDeserializationCallback
	{
		get
		{
			if (s_typeOfIDeserializationCallback == null)
			{
				s_typeOfIDeserializationCallback = typeof(IDeserializationCallback);
			}
			return s_typeOfIDeserializationCallback;
		}
	}

	internal static Type TypeOfIObjectReference
	{
		get
		{
			if (s_typeOfIObjectReference == null)
			{
				s_typeOfIObjectReference = typeof(IObjectReference);
			}
			return s_typeOfIObjectReference;
		}
	}

	internal static Type TypeOfXmlFormatClassWriterDelegate
	{
		get
		{
			if (s_typeOfXmlFormatClassWriterDelegate == null)
			{
				s_typeOfXmlFormatClassWriterDelegate = typeof(XmlFormatClassWriterDelegate);
			}
			return s_typeOfXmlFormatClassWriterDelegate;
		}
	}

	internal static Type TypeOfXmlFormatCollectionWriterDelegate
	{
		get
		{
			if (s_typeOfXmlFormatCollectionWriterDelegate == null)
			{
				s_typeOfXmlFormatCollectionWriterDelegate = typeof(XmlFormatCollectionWriterDelegate);
			}
			return s_typeOfXmlFormatCollectionWriterDelegate;
		}
	}

	internal static Type TypeOfXmlFormatClassReaderDelegate
	{
		get
		{
			if (s_typeOfXmlFormatClassReaderDelegate == null)
			{
				s_typeOfXmlFormatClassReaderDelegate = typeof(XmlFormatClassReaderDelegate);
			}
			return s_typeOfXmlFormatClassReaderDelegate;
		}
	}

	internal static Type TypeOfXmlFormatCollectionReaderDelegate
	{
		get
		{
			if (s_typeOfXmlFormatCollectionReaderDelegate == null)
			{
				s_typeOfXmlFormatCollectionReaderDelegate = typeof(XmlFormatCollectionReaderDelegate);
			}
			return s_typeOfXmlFormatCollectionReaderDelegate;
		}
	}

	internal static Type TypeOfXmlFormatGetOnlyCollectionReaderDelegate
	{
		get
		{
			if (s_typeOfXmlFormatGetOnlyCollectionReaderDelegate == null)
			{
				s_typeOfXmlFormatGetOnlyCollectionReaderDelegate = typeof(XmlFormatGetOnlyCollectionReaderDelegate);
			}
			return s_typeOfXmlFormatGetOnlyCollectionReaderDelegate;
		}
	}

	internal static Type TypeOfKnownTypeAttribute
	{
		get
		{
			if (s_typeOfKnownTypeAttribute == null)
			{
				s_typeOfKnownTypeAttribute = typeof(KnownTypeAttribute);
			}
			return s_typeOfKnownTypeAttribute;
		}
	}

	internal static Type TypeOfDataContractAttribute
	{
		get
		{
			if (s_typeOfDataContractAttribute == null)
			{
				s_typeOfDataContractAttribute = typeof(DataContractAttribute);
			}
			return s_typeOfDataContractAttribute;
		}
	}

	internal static Type TypeOfDataMemberAttribute
	{
		get
		{
			if (s_typeOfDataMemberAttribute == null)
			{
				s_typeOfDataMemberAttribute = typeof(DataMemberAttribute);
			}
			return s_typeOfDataMemberAttribute;
		}
	}

	internal static Type TypeOfEnumMemberAttribute
	{
		get
		{
			if (s_typeOfEnumMemberAttribute == null)
			{
				s_typeOfEnumMemberAttribute = typeof(EnumMemberAttribute);
			}
			return s_typeOfEnumMemberAttribute;
		}
	}

	internal static Type TypeOfCollectionDataContractAttribute
	{
		get
		{
			if (s_typeOfCollectionDataContractAttribute == null)
			{
				s_typeOfCollectionDataContractAttribute = typeof(CollectionDataContractAttribute);
			}
			return s_typeOfCollectionDataContractAttribute;
		}
	}

	internal static Type TypeOfOptionalFieldAttribute
	{
		get
		{
			if (s_typeOfOptionalFieldAttribute == null)
			{
				s_typeOfOptionalFieldAttribute = typeof(OptionalFieldAttribute);
			}
			return s_typeOfOptionalFieldAttribute;
		}
	}

	internal static Type TypeOfObjectArray
	{
		get
		{
			if (s_typeOfObjectArray == null)
			{
				s_typeOfObjectArray = typeof(object[]);
			}
			return s_typeOfObjectArray;
		}
	}

	internal static Type TypeOfOnSerializingAttribute
	{
		get
		{
			if (s_typeOfOnSerializingAttribute == null)
			{
				s_typeOfOnSerializingAttribute = typeof(OnSerializingAttribute);
			}
			return s_typeOfOnSerializingAttribute;
		}
	}

	internal static Type TypeOfOnSerializedAttribute
	{
		get
		{
			if (s_typeOfOnSerializedAttribute == null)
			{
				s_typeOfOnSerializedAttribute = typeof(OnSerializedAttribute);
			}
			return s_typeOfOnSerializedAttribute;
		}
	}

	internal static Type TypeOfOnDeserializingAttribute
	{
		get
		{
			if (s_typeOfOnDeserializingAttribute == null)
			{
				s_typeOfOnDeserializingAttribute = typeof(OnDeserializingAttribute);
			}
			return s_typeOfOnDeserializingAttribute;
		}
	}

	internal static Type TypeOfOnDeserializedAttribute
	{
		get
		{
			if (s_typeOfOnDeserializedAttribute == null)
			{
				s_typeOfOnDeserializedAttribute = typeof(OnDeserializedAttribute);
			}
			return s_typeOfOnDeserializedAttribute;
		}
	}

	internal static Type TypeOfFlagsAttribute
	{
		get
		{
			if (s_typeOfFlagsAttribute == null)
			{
				s_typeOfFlagsAttribute = typeof(FlagsAttribute);
			}
			return s_typeOfFlagsAttribute;
		}
	}

	internal static Type TypeOfIXmlSerializable
	{
		get
		{
			if (s_typeOfIXmlSerializable == null)
			{
				s_typeOfIXmlSerializable = typeof(IXmlSerializable);
			}
			return s_typeOfIXmlSerializable;
		}
	}

	internal static Type TypeOfXmlSchemaProviderAttribute
	{
		get
		{
			if (s_typeOfXmlSchemaProviderAttribute == null)
			{
				s_typeOfXmlSchemaProviderAttribute = typeof(XmlSchemaProviderAttribute);
			}
			return s_typeOfXmlSchemaProviderAttribute;
		}
	}

	internal static Type TypeOfXmlRootAttribute
	{
		get
		{
			if (s_typeOfXmlRootAttribute == null)
			{
				s_typeOfXmlRootAttribute = typeof(XmlRootAttribute);
			}
			return s_typeOfXmlRootAttribute;
		}
	}

	internal static Type TypeOfXmlQualifiedName
	{
		get
		{
			if (s_typeOfXmlQualifiedName == null)
			{
				s_typeOfXmlQualifiedName = typeof(XmlQualifiedName);
			}
			return s_typeOfXmlQualifiedName;
		}
	}

	internal static Type TypeOfXmlSchemaType
	{
		get
		{
			if (s_typeOfXmlSchemaType == null)
			{
				s_typeOfXmlSchemaType = typeof(XmlSchemaType);
			}
			return s_typeOfXmlSchemaType;
		}
	}

	internal static Type TypeOfIExtensibleDataObject => s_typeOfIExtensibleDataObject ?? (s_typeOfIExtensibleDataObject = typeof(IExtensibleDataObject));

	internal static Type TypeOfExtensionDataObject => s_typeOfExtensionDataObject ?? (s_typeOfExtensionDataObject = typeof(ExtensionDataObject));

	internal static Type TypeOfISerializableDataNode
	{
		get
		{
			if (s_typeOfISerializableDataNode == null)
			{
				s_typeOfISerializableDataNode = typeof(ISerializableDataNode);
			}
			return s_typeOfISerializableDataNode;
		}
	}

	internal static Type TypeOfClassDataNode
	{
		get
		{
			if (s_typeOfClassDataNode == null)
			{
				s_typeOfClassDataNode = typeof(ClassDataNode);
			}
			return s_typeOfClassDataNode;
		}
	}

	internal static Type TypeOfCollectionDataNode
	{
		get
		{
			if (s_typeOfCollectionDataNode == null)
			{
				s_typeOfCollectionDataNode = typeof(CollectionDataNode);
			}
			return s_typeOfCollectionDataNode;
		}
	}

	internal static Type TypeOfXmlDataNode => s_typeOfXmlDataNode ?? (s_typeOfXmlDataNode = typeof(XmlDataNode));

	internal static Type TypeOfNullable
	{
		get
		{
			if (s_typeOfNullable == null)
			{
				s_typeOfNullable = typeof(Nullable<>);
			}
			return s_typeOfNullable;
		}
	}

	internal static Type TypeOfIDictionaryGeneric
	{
		get
		{
			if (s_typeOfIDictionaryGeneric == null)
			{
				s_typeOfIDictionaryGeneric = typeof(IDictionary<, >);
			}
			return s_typeOfIDictionaryGeneric;
		}
	}

	internal static Type TypeOfIDictionary
	{
		get
		{
			if (s_typeOfIDictionary == null)
			{
				s_typeOfIDictionary = typeof(IDictionary);
			}
			return s_typeOfIDictionary;
		}
	}

	internal static Type TypeOfIListGeneric
	{
		get
		{
			if (s_typeOfIListGeneric == null)
			{
				s_typeOfIListGeneric = typeof(IList<>);
			}
			return s_typeOfIListGeneric;
		}
	}

	internal static Type TypeOfIList
	{
		get
		{
			if (s_typeOfIList == null)
			{
				s_typeOfIList = typeof(IList);
			}
			return s_typeOfIList;
		}
	}

	internal static Type TypeOfICollectionGeneric
	{
		get
		{
			if (s_typeOfICollectionGeneric == null)
			{
				s_typeOfICollectionGeneric = typeof(ICollection<>);
			}
			return s_typeOfICollectionGeneric;
		}
	}

	internal static Type TypeOfICollection
	{
		get
		{
			if (s_typeOfICollection == null)
			{
				s_typeOfICollection = typeof(ICollection);
			}
			return s_typeOfICollection;
		}
	}

	internal static Type TypeOfIEnumerableGeneric
	{
		get
		{
			if (s_typeOfIEnumerableGeneric == null)
			{
				s_typeOfIEnumerableGeneric = typeof(IEnumerable<>);
			}
			return s_typeOfIEnumerableGeneric;
		}
	}

	internal static Type TypeOfIEnumerable
	{
		get
		{
			if (s_typeOfIEnumerable == null)
			{
				s_typeOfIEnumerable = typeof(IEnumerable);
			}
			return s_typeOfIEnumerable;
		}
	}

	internal static Type TypeOfIEnumeratorGeneric
	{
		get
		{
			if (s_typeOfIEnumeratorGeneric == null)
			{
				s_typeOfIEnumeratorGeneric = typeof(IEnumerator<>);
			}
			return s_typeOfIEnumeratorGeneric;
		}
	}

	internal static Type TypeOfIEnumerator
	{
		get
		{
			if (s_typeOfIEnumerator == null)
			{
				s_typeOfIEnumerator = typeof(IEnumerator);
			}
			return s_typeOfIEnumerator;
		}
	}

	internal static Type TypeOfKeyValuePair
	{
		get
		{
			if (s_typeOfKeyValuePair == null)
			{
				s_typeOfKeyValuePair = typeof(KeyValuePair<, >);
			}
			return s_typeOfKeyValuePair;
		}
	}

	internal static Type TypeOfKeyValuePairAdapter
	{
		get
		{
			if (s_typeOfKeyValuePairAdapter == null)
			{
				s_typeOfKeyValuePairAdapter = typeof(KeyValuePairAdapter<, >);
			}
			return s_typeOfKeyValuePairAdapter;
		}
	}

	internal static Type TypeOfKeyValue
	{
		get
		{
			if (s_typeOfKeyValue == null)
			{
				s_typeOfKeyValue = typeof(KeyValue<, >);
			}
			return s_typeOfKeyValue;
		}
	}

	internal static Type TypeOfIDictionaryEnumerator
	{
		get
		{
			if (s_typeOfIDictionaryEnumerator == null)
			{
				s_typeOfIDictionaryEnumerator = typeof(IDictionaryEnumerator);
			}
			return s_typeOfIDictionaryEnumerator;
		}
	}

	internal static Type TypeOfDictionaryEnumerator
	{
		get
		{
			if (s_typeOfDictionaryEnumerator == null)
			{
				s_typeOfDictionaryEnumerator = typeof(CollectionDataContract.DictionaryEnumerator);
			}
			return s_typeOfDictionaryEnumerator;
		}
	}

	internal static Type TypeOfGenericDictionaryEnumerator
	{
		get
		{
			if (s_typeOfGenericDictionaryEnumerator == null)
			{
				s_typeOfGenericDictionaryEnumerator = typeof(CollectionDataContract.GenericDictionaryEnumerator<, >);
			}
			return s_typeOfGenericDictionaryEnumerator;
		}
	}

	internal static Type TypeOfDictionaryGeneric
	{
		get
		{
			if (s_typeOfDictionaryGeneric == null)
			{
				s_typeOfDictionaryGeneric = typeof(Dictionary<, >);
			}
			return s_typeOfDictionaryGeneric;
		}
	}

	internal static Type TypeOfHashtable
	{
		[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
		get
		{
			if (s_typeOfHashtable == null)
			{
				s_typeOfHashtable = TypeOfDictionaryGeneric.MakeGenericType(TypeOfObject, TypeOfObject);
			}
			return s_typeOfHashtable;
		}
	}

	internal static Type TypeOfXmlElement
	{
		get
		{
			if (s_typeOfXmlElement == null)
			{
				s_typeOfXmlElement = typeof(XmlElement);
			}
			return s_typeOfXmlElement;
		}
	}

	internal static Type TypeOfXmlNodeArray
	{
		get
		{
			if (s_typeOfXmlNodeArray == null)
			{
				s_typeOfXmlNodeArray = typeof(XmlNode[]);
			}
			return s_typeOfXmlNodeArray;
		}
	}

	internal static Type TypeOfDBNull
	{
		get
		{
			if (s_typeOfDBNull == null)
			{
				s_typeOfDBNull = typeof(DBNull);
			}
			return s_typeOfDBNull;
		}
	}

	internal static Uri DataContractXsdBaseNamespaceUri
	{
		get
		{
			if (s_dataContractXsdBaseNamespaceUri == null)
			{
				s_dataContractXsdBaseNamespaceUri = new Uri("http://schemas.datacontract.org/2004/07/");
			}
			return s_dataContractXsdBaseNamespaceUri;
		}
	}

	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal static ClassDataContract CreateScriptObjectClassDataContract()
	{
		return new ClassDataContract(s_typeOfScriptObject);
	}

	internal static bool TypeOfScriptObject_IsAssignableFrom(Type type)
	{
		if (s_typeOfScriptObject != null)
		{
			return s_typeOfScriptObject.IsAssignableFrom(type);
		}
		return false;
	}
}
