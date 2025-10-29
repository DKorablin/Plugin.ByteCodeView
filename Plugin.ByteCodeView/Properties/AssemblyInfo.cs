using System.Reflection;
using System.Runtime.InteropServices;

[assembly: Guid("229ecb2b-b6c7-46e3-b8b6-9bac932f0679")]
[assembly: System.CLSCompliant(false)]

[assembly: AssemblyDescription("Java ByteCode (JVM) viewer plugin")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2016-2025")]

/*
if $(ConfigurationName) == Release (
..\..\..\..\ILMerge.exe  "/out:$(ProjectDir)..\bin\$(TargetFileName)" "$(TargetPath)" "$(TargetDir)ByteCodeReader.dll" "/lib:..\..\..\SAL\bin"
)
*/