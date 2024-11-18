using System;
using Plugin.ByteCodeView.Properties;

namespace Plugin.ByteCodeView
{
	/// <summary>Константы приложения</summary>
	internal static class Constant
	{
		/// <summary>Наименование бинарного файла загруженного из памяти</summary>
		public const String BinaryFile = "Binary";

		/// <summary>Получить наименование заголовка</summary>
		/// <param name="type">Тип заголовка</param>
		/// <returns>Наименование заголовка</returns>
		public static String GetHeaderName(ClassItemType type)
		{
			switch(type)
			{
			case ClassItemType.Tables:					return Resources.Section_Tables;
			case ClassItemType.Attributes:				return Resources.Section_Attributes;
			case ClassItemType.AttributesPool:			return Resources.Section_AttributesPool;
			case ClassItemType.ClassFile:				return Resources.Section_ClassFile;
			case ClassItemType.ConstantPool:			return Resources.Section_ConstantPool;
			case ClassItemType.Fields:					return Resources.Section_Fields;
			case ClassItemType.Methods:					return Resources.Section_Methods;
			case ClassItemType.Intrefaces:				return Resources.Section_Interfaces;
			default:
				throw new NotSupportedException();
			}
		}
	}
}