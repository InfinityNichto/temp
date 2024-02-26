using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace System.Drawing;

public class RectangleConverter : TypeConverter
{
	private static readonly string[] s_propertySort = new string[4] { "X", "Y", "Width", "Height" };

	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return base.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
	{
		if (!(destinationType == typeof(InstanceDescriptor)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		if (value is string text)
		{
			string text2 = text.Trim();
			if (text2.Length == 0)
			{
				return null;
			}
			if (culture == null)
			{
				culture = CultureInfo.CurrentCulture;
			}
			char separator = culture.TextInfo.ListSeparator[0];
			string[] array = text2.Split(separator);
			int[] array2 = new int[array.Length];
			TypeConverter converterTrimUnsafe = TypeDescriptor.GetConverterTrimUnsafe(typeof(int));
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = (int)converterTrimUnsafe.ConvertFromString(context, culture, array[i]);
			}
			if (array2.Length != 4)
			{
				throw new ArgumentException(System.SR.Format(System.SR.TextParseFailedFormat, "text", text2, "x, y, width, height"));
			}
			return new Rectangle(array2[0], array2[1], array2[2], array2[3]);
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		if (destinationType == null)
		{
			throw new ArgumentNullException("destinationType");
		}
		if (value is Rectangle rectangle)
		{
			if (destinationType == typeof(string))
			{
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}
				string separator = culture.TextInfo.ListSeparator + " ";
				TypeConverter converterTrimUnsafe = TypeDescriptor.GetConverterTrimUnsafe(typeof(int));
				string[] value2 = new string[4]
				{
					converterTrimUnsafe.ConvertToString(context, culture, rectangle.X),
					converterTrimUnsafe.ConvertToString(context, culture, rectangle.Y),
					converterTrimUnsafe.ConvertToString(context, culture, rectangle.Width),
					converterTrimUnsafe.ConvertToString(context, culture, rectangle.Height)
				};
				return string.Join(separator, value2);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				ConstructorInfo constructor = typeof(Rectangle).GetConstructor(new Type[4]
				{
					typeof(int),
					typeof(int),
					typeof(int),
					typeof(int)
				});
				if (constructor != null)
				{
					return new InstanceDescriptor(constructor, new object[4] { rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height });
				}
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext? context, IDictionary propertyValues)
	{
		if (propertyValues == null)
		{
			throw new ArgumentNullException("propertyValues");
		}
		object obj = propertyValues["X"];
		object obj2 = propertyValues["Y"];
		object obj3 = propertyValues["Width"];
		object obj4 = propertyValues["Height"];
		if (obj == null || obj2 == null || obj3 == null || obj4 == null || !(obj is int) || !(obj2 is int) || !(obj3 is int) || !(obj4 is int))
		{
			throw new ArgumentException(System.SR.PropertyValueInvalidEntry);
		}
		return new Rectangle((int)obj, (int)obj2, (int)obj3, (int)obj4);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext? context)
	{
		return true;
	}

	[RequiresUnreferencedCode("The Type of value cannot be statically discovered. The public parameterless constructor or the 'Default' static field may be trimmed from the Attribute's Type.")]
	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object? value, Attribute[]? attributes)
	{
		PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Rectangle), attributes);
		return properties.Sort(s_propertySort);
	}

	public override bool GetPropertiesSupported(ITypeDescriptorContext? context)
	{
		return true;
	}
}