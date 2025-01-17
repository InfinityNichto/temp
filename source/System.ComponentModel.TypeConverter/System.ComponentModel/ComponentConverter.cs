using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

public class ComponentConverter : ReferenceConverter
{
	public ComponentConverter(Type type)
		: base(type)
	{
	}

	[RequiresUnreferencedCode("The Type of value cannot be statically discovered. The public parameterless constructor or the 'Default' static field may be trimmed from the Attribute's Type.")]
	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
	{
		return TypeDescriptor.GetProperties(value, attributes);
	}

	public override bool GetPropertiesSupported(ITypeDescriptorContext? context)
	{
		return true;
	}
}
