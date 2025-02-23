using System.Reflection;
using System.Runtime.InteropServices;

[assembly: Guid("229ecb2b-b6c7-46e3-b8b6-9bac932f0679")]
[assembly: System.CLSCompliant(false)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://dkorablin.ru/project/Default.aspx?File=112")]
#else

[assembly: AssemblyDescription("Java ByteCode (JVM) viewer plugin")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2016-2025")]
#endif

/*
if $(ConfigurationName) == Release (
..\..\..\..\ILMerge.exe  "/out:$(ProjectDir)..\bin\$(TargetFileName)" "$(TargetPath)" "$(TargetDir)ByteCodeReader.dll" "/lib:..\..\..\SAL\bin"
)
*/