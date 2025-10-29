using System;
using Plugin.ByteCodeView.Properties;

namespace Plugin.ByteCodeView
{
	/// <summary>Application Constants</summary>
	internal static class Constant
	{
		/// <summary>Name of the binary file loaded from memory</summary>
		public const String BinaryFile = "Binary";

		/// <summary>Get the header name</summary>
		/// <param name="type">Header type</param>
		/// <returns>Header name</returns>
		public static String GetHeaderName(ClassItemType type)
		{
			switch(type)
			{
			case ClassItemType.Tables: return Resources.Section_Tables;
			case ClassItemType.Attributes: return Resources.Section_Attributes;
			case ClassItemType.AttributesPool: return Resources.Section_AttributesPool;
			case ClassItemType.ClassFile: return Resources.Section_ClassFile;
			case ClassItemType.ConstantPool: return Resources.Section_ConstantPool;
			case ClassItemType.Fields: return Resources.Section_Fields;
			case ClassItemType.Methods: return Resources.Section_Methods;
			case ClassItemType.Interfaces: return Resources.Section_Interfaces;
			default:
				throw new NotSupportedException();
			}
		}
	}
}