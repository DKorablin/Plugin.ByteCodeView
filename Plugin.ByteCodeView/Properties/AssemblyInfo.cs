using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: Guid("229ecb2b-b6c7-46e3-b8b6-9bac932f0679")]
[assembly: System.CLSCompliant(false)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://dkorablin.ru/project/Default.aspx?File=112")]
#else

[assembly: AssemblyTitle("Plugin.ByteCodeView")]
[assembly: AssemblyDescription("Java ByteCode (JVM) viewer plugin")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Danila Korablin")]
[assembly: AssemblyProduct("Plugin.ByteCodeView")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2016-2022")]
#endif

/*
if $(ConfigurationName) == Release (
..\..\..\..\ILMerge.exe  "/out:$(ProjectDir)..\bin\$(TargetFileName)" "$(TargetPath)" "$(TargetDir)ByteCodeReader.dll" "/lib:..\..\..\SAL\bin"
)
*/