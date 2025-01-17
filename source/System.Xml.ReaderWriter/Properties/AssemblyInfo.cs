using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Xml;
using System.Xml.Resolvers;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

[assembly: CLSCompliant(true)]
[assembly: AssemblyDefaultAlias("System.Xml.ReaderWriter")]
[assembly: AssemblyMetadata(".NETFrameworkAssembly", "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("System.Xml.ReaderWriter")]
[assembly: AssemblyFileVersion("6.0.21.52210")]
[assembly: AssemblyInformationalVersion("6.0.0+4822e3c3aa77eb82b2fb33c9321f923cf11ddde6")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.Xml.ReaderWriter")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("6.0.0.0")]
[assembly: TypeForwardedTo(typeof(ConformanceLevel))]
[assembly: TypeForwardedTo(typeof(DtdProcessing))]
[assembly: TypeForwardedTo(typeof(EntityHandling))]
[assembly: TypeForwardedTo(typeof(Formatting))]
[assembly: TypeForwardedTo(typeof(IApplicationResourceStreamResolver))]
[assembly: TypeForwardedTo(typeof(IHasXmlNode))]
[assembly: TypeForwardedTo(typeof(IXmlLineInfo))]
[assembly: TypeForwardedTo(typeof(IXmlNamespaceResolver))]
[assembly: TypeForwardedTo(typeof(NamespaceHandling))]
[assembly: TypeForwardedTo(typeof(NameTable))]
[assembly: TypeForwardedTo(typeof(NewLineHandling))]
[assembly: TypeForwardedTo(typeof(ReadState))]
[assembly: TypeForwardedTo(typeof(XmlKnownDtds))]
[assembly: TypeForwardedTo(typeof(XmlPreloadedResolver))]
[assembly: TypeForwardedTo(typeof(IXmlSchemaInfo))]
[assembly: TypeForwardedTo(typeof(ValidationEventArgs))]
[assembly: TypeForwardedTo(typeof(ValidationEventHandler))]
[assembly: TypeForwardedTo(typeof(XmlAtomicValue))]
[assembly: TypeForwardedTo(typeof(XmlSchema))]
[assembly: TypeForwardedTo(typeof(XmlSchemaAll))]
[assembly: TypeForwardedTo(typeof(XmlSchemaAnnotated))]
[assembly: TypeForwardedTo(typeof(XmlSchemaAnnotation))]
[assembly: TypeForwardedTo(typeof(XmlSchemaAny))]
[assembly: TypeForwardedTo(typeof(XmlSchemaAnyAttribute))]
[assembly: TypeForwardedTo(typeof(XmlSchemaAppInfo))]
[assembly: TypeForwardedTo(typeof(XmlSchemaAttribute))]
[assembly: TypeForwardedTo(typeof(XmlSchemaAttributeGroup))]
[assembly: TypeForwardedTo(typeof(XmlSchemaAttributeGroupRef))]
[assembly: TypeForwardedTo(typeof(XmlSchemaChoice))]
[assembly: TypeForwardedTo(typeof(XmlSchemaCollection))]
[assembly: TypeForwardedTo(typeof(XmlSchemaCollectionEnumerator))]
[assembly: TypeForwardedTo(typeof(XmlSchemaCompilationSettings))]
[assembly: TypeForwardedTo(typeof(XmlSchemaComplexContent))]
[assembly: TypeForwardedTo(typeof(XmlSchemaComplexContentExtension))]
[assembly: TypeForwardedTo(typeof(XmlSchemaComplexContentRestriction))]
[assembly: TypeForwardedTo(typeof(XmlSchemaComplexType))]
[assembly: TypeForwardedTo(typeof(XmlSchemaContent))]
[assembly: TypeForwardedTo(typeof(XmlSchemaContentModel))]
[assembly: TypeForwardedTo(typeof(XmlSchemaContentProcessing))]
[assembly: TypeForwardedTo(typeof(XmlSchemaContentType))]
[assembly: TypeForwardedTo(typeof(XmlSchemaDatatype))]
[assembly: TypeForwardedTo(typeof(XmlSchemaDatatypeVariety))]
[assembly: TypeForwardedTo(typeof(XmlSchemaDerivationMethod))]
[assembly: TypeForwardedTo(typeof(XmlSchemaDocumentation))]
[assembly: TypeForwardedTo(typeof(XmlSchemaElement))]
[assembly: TypeForwardedTo(typeof(XmlSchemaEnumerationFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaException))]
[assembly: TypeForwardedTo(typeof(XmlSchemaExternal))]
[assembly: TypeForwardedTo(typeof(XmlSchemaFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaForm))]
[assembly: TypeForwardedTo(typeof(XmlSchemaFractionDigitsFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaGroup))]
[assembly: TypeForwardedTo(typeof(XmlSchemaGroupBase))]
[assembly: TypeForwardedTo(typeof(XmlSchemaGroupRef))]
[assembly: TypeForwardedTo(typeof(XmlSchemaIdentityConstraint))]
[assembly: TypeForwardedTo(typeof(XmlSchemaImport))]
[assembly: TypeForwardedTo(typeof(XmlSchemaInclude))]
[assembly: TypeForwardedTo(typeof(XmlSchemaInference))]
[assembly: TypeForwardedTo(typeof(XmlSchemaInferenceException))]
[assembly: TypeForwardedTo(typeof(XmlSchemaInfo))]
[assembly: TypeForwardedTo(typeof(XmlSchemaKey))]
[assembly: TypeForwardedTo(typeof(XmlSchemaKeyref))]
[assembly: TypeForwardedTo(typeof(XmlSchemaLengthFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaMaxExclusiveFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaMaxInclusiveFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaMaxLengthFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaMinExclusiveFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaMinInclusiveFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaMinLengthFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaNotation))]
[assembly: TypeForwardedTo(typeof(XmlSchemaNumericFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaObject))]
[assembly: TypeForwardedTo(typeof(XmlSchemaObjectCollection))]
[assembly: TypeForwardedTo(typeof(XmlSchemaObjectEnumerator))]
[assembly: TypeForwardedTo(typeof(XmlSchemaObjectTable))]
[assembly: TypeForwardedTo(typeof(XmlSchemaParticle))]
[assembly: TypeForwardedTo(typeof(XmlSchemaPatternFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaRedefine))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSequence))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSimpleContent))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSimpleContentExtension))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSimpleContentRestriction))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSimpleType))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSimpleTypeContent))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSimpleTypeList))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSimpleTypeRestriction))]
[assembly: TypeForwardedTo(typeof(XmlSchemaSimpleTypeUnion))]
[assembly: TypeForwardedTo(typeof(XmlSchemaTotalDigitsFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaType))]
[assembly: TypeForwardedTo(typeof(XmlSchemaUnique))]
[assembly: TypeForwardedTo(typeof(XmlSchemaUse))]
[assembly: TypeForwardedTo(typeof(XmlSchemaValidationException))]
[assembly: TypeForwardedTo(typeof(XmlSchemaValidationFlags))]
[assembly: TypeForwardedTo(typeof(XmlSchemaValidator))]
[assembly: TypeForwardedTo(typeof(XmlSchemaValidity))]
[assembly: TypeForwardedTo(typeof(XmlSchemaWhiteSpaceFacet))]
[assembly: TypeForwardedTo(typeof(XmlSchemaXPath))]
[assembly: TypeForwardedTo(typeof(XmlSeverityType))]
[assembly: TypeForwardedTo(typeof(XmlTypeCode))]
[assembly: TypeForwardedTo(typeof(XmlValueGetter))]
[assembly: TypeForwardedTo(typeof(IXmlSerializable))]
[assembly: TypeForwardedTo(typeof(XmlAnyAttributeAttribute))]
[assembly: TypeForwardedTo(typeof(XmlAnyElementAttribute))]
[assembly: TypeForwardedTo(typeof(XmlAttributeAttribute))]
[assembly: TypeForwardedTo(typeof(XmlElementAttribute))]
[assembly: TypeForwardedTo(typeof(XmlEnumAttribute))]
[assembly: TypeForwardedTo(typeof(XmlIgnoreAttribute))]
[assembly: TypeForwardedTo(typeof(XmlNamespaceDeclarationsAttribute))]
[assembly: TypeForwardedTo(typeof(XmlRootAttribute))]
[assembly: TypeForwardedTo(typeof(XmlSchemaProviderAttribute))]
[assembly: TypeForwardedTo(typeof(XmlSerializerNamespaces))]
[assembly: TypeForwardedTo(typeof(XmlTextAttribute))]
[assembly: TypeForwardedTo(typeof(ValidationType))]
[assembly: TypeForwardedTo(typeof(WhitespaceHandling))]
[assembly: TypeForwardedTo(typeof(WriteState))]
[assembly: TypeForwardedTo(typeof(XmlAttribute))]
[assembly: TypeForwardedTo(typeof(XmlAttributeCollection))]
[assembly: TypeForwardedTo(typeof(XmlCDataSection))]
[assembly: TypeForwardedTo(typeof(XmlCharacterData))]
[assembly: TypeForwardedTo(typeof(XmlComment))]
[assembly: TypeForwardedTo(typeof(XmlConvert))]
[assembly: TypeForwardedTo(typeof(XmlDateTimeSerializationMode))]
[assembly: TypeForwardedTo(typeof(XmlDeclaration))]
[assembly: TypeForwardedTo(typeof(XmlDocument))]
[assembly: TypeForwardedTo(typeof(XmlDocumentFragment))]
[assembly: TypeForwardedTo(typeof(XmlDocumentType))]
[assembly: TypeForwardedTo(typeof(XmlElement))]
[assembly: TypeForwardedTo(typeof(XmlEntity))]
[assembly: TypeForwardedTo(typeof(XmlEntityReference))]
[assembly: TypeForwardedTo(typeof(XmlException))]
[assembly: TypeForwardedTo(typeof(XmlImplementation))]
[assembly: TypeForwardedTo(typeof(XmlLinkedNode))]
[assembly: TypeForwardedTo(typeof(XmlNamedNodeMap))]
[assembly: TypeForwardedTo(typeof(XmlNamespaceManager))]
[assembly: TypeForwardedTo(typeof(XmlNamespaceScope))]
[assembly: TypeForwardedTo(typeof(XmlNameTable))]
[assembly: TypeForwardedTo(typeof(XmlNode))]
[assembly: TypeForwardedTo(typeof(XmlNodeChangedAction))]
[assembly: TypeForwardedTo(typeof(XmlNodeChangedEventArgs))]
[assembly: TypeForwardedTo(typeof(XmlNodeChangedEventHandler))]
[assembly: TypeForwardedTo(typeof(XmlNodeList))]
[assembly: TypeForwardedTo(typeof(XmlNodeOrder))]
[assembly: TypeForwardedTo(typeof(XmlNodeReader))]
[assembly: TypeForwardedTo(typeof(XmlNodeType))]
[assembly: TypeForwardedTo(typeof(XmlNotation))]
[assembly: TypeForwardedTo(typeof(XmlOutputMethod))]
[assembly: TypeForwardedTo(typeof(XmlParserContext))]
[assembly: TypeForwardedTo(typeof(XmlProcessingInstruction))]
[assembly: TypeForwardedTo(typeof(XmlQualifiedName))]
[assembly: TypeForwardedTo(typeof(XmlReader))]
[assembly: TypeForwardedTo(typeof(XmlReaderSettings))]
[assembly: TypeForwardedTo(typeof(XmlResolver))]
[assembly: TypeForwardedTo(typeof(XmlSecureResolver))]
[assembly: TypeForwardedTo(typeof(XmlSignificantWhitespace))]
[assembly: TypeForwardedTo(typeof(XmlSpace))]
[assembly: TypeForwardedTo(typeof(XmlText))]
[assembly: TypeForwardedTo(typeof(XmlTextReader))]
[assembly: TypeForwardedTo(typeof(XmlTextWriter))]
[assembly: TypeForwardedTo(typeof(XmlTokenizedType))]
[assembly: TypeForwardedTo(typeof(XmlUrlResolver))]
[assembly: TypeForwardedTo(typeof(XmlValidatingReader))]
[assembly: TypeForwardedTo(typeof(XmlWhitespace))]
[assembly: TypeForwardedTo(typeof(XmlWriter))]
[assembly: TypeForwardedTo(typeof(XmlWriterSettings))]
[assembly: TypeForwardedTo(typeof(IXPathNavigable))]
[assembly: TypeForwardedTo(typeof(XmlCaseOrder))]
[assembly: TypeForwardedTo(typeof(XmlDataType))]
[assembly: TypeForwardedTo(typeof(XmlSortOrder))]
[assembly: TypeForwardedTo(typeof(XPathExpression))]
[assembly: TypeForwardedTo(typeof(XPathItem))]
[assembly: TypeForwardedTo(typeof(XPathNamespaceScope))]
[assembly: TypeForwardedTo(typeof(XPathNavigator))]
[assembly: TypeForwardedTo(typeof(XPathNodeIterator))]
[assembly: TypeForwardedTo(typeof(XPathNodeType))]
[assembly: TypeForwardedTo(typeof(XPathResultType))]
[assembly: TypeForwardedTo(typeof(IXsltContextFunction))]
[assembly: TypeForwardedTo(typeof(IXsltContextVariable))]
[assembly: TypeForwardedTo(typeof(XslCompiledTransform))]
[assembly: TypeForwardedTo(typeof(XsltArgumentList))]
[assembly: TypeForwardedTo(typeof(XsltCompileException))]
[assembly: TypeForwardedTo(typeof(XsltContext))]
[assembly: TypeForwardedTo(typeof(XsltException))]
[assembly: TypeForwardedTo(typeof(XsltMessageEncounteredEventArgs))]
[assembly: TypeForwardedTo(typeof(XsltMessageEncounteredEventHandler))]
[assembly: TypeForwardedTo(typeof(XslTransform))]
[assembly: TypeForwardedTo(typeof(XsltSettings))]
[module: SkipLocalsInit]
