# Setting Up a C# Class Managed DLL for Unity Project (Window Development)

# A. Setup Project
1. Install [Visual Studio 2017](https://visualstudio.microsoft.com/vs/older-downloads/) 
   (with *.Net Desktop Development tools*, *C# 4.6.1* and *Game development with Unity*) 
2. Install [Unity](https://unity3d.com/get-unity/download), and 
   [Mono](https://www.mono-project.com/download/stable/)
3. Create New Visual Studio Project
   - Select *File* > *New* > *Project*
   - On dialog, select `Visual C#` > `Class Library (.NET Framework)`
   - Setup *Name*, *Location*, and *Solution Name*
   - On Framework, Select `.NET Framework 4.6.1` (or Unity compatible version)
4. Add UnityEngine reference
   1. Select *Project* > *Add Reference*
   2. Select *Browse* > *Browse...*
   3. Browse to `\UNITYPATH\Editor\Data\Managed\UnityEngine.dll`
   4. On Solution Explorer, select *Reference* > `UnityEngine`, then go to 
      *Properties*, change *Copy Local* to `False`

# B. Setup Debug Environment
1. Add a new Unity Project
2. At Visual Studio, select *Project* > *$(ProjectName) Properties*
3. Go to *Build* tab, Select Configuration *Debug*
4. Select *Output* Path to `\UNITYPROJECTPATH\Assets\Debug` (or any name under assets)
5. Go to *Build Events* tab, on *Post-build event command line*, insert: 
   `"\MONOPATH\bin\pdb2mdb" $(TargetDir)$(TargetFileName)`
6. To debug, First build the project, then select *Debug* > `Attach Unity Debugger`
7. For VS Code debug:
   1. Install Debugger for Unity Extension
   2. On VS Code, Open directory containing .csproj
   3. Go to *Debug* tab, Setup *launch.json*
   4. Set the *Path* to `\UNITYPROJECTPATH\Library\EditorInstance.json`

# C. Setup Common Macro/Properties
1. Setup Properties XML file:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <MarcoName1>MarcoValue1</MarcoName1>
    <MarcoName2>MarcoValue2</MarcoName2>
    <DependentMarco3>$(MarcoValue2)Addon</DependentMarco3>
    ... 
    <MarcoNameN>MarcoValueN</MarcoNameN>
  </PropertyGroup>
</Project>
```
2. At `.csproj` file, add following line:
```xml
<Project ...>
  <Import ... />
  <!-- Add the following line -->
  <Import Project="Path\to\XmlFile" />
  ...
  <!-- And use MarcoName just like other marcos -->
    <HintPath>$(MarcoName1)...</HintPath>
  ...
</Project>
```


# D. Note
1. *Step A.4.4* prevent Visual Studio from copying UnityEngine.dll to output 
  directory, which is an unnessary and project corrupting step
2. `Mono` is needed to generate debug symbol for unity debugging (*Step B.5*)
3. Not sure if *$(TargetFileName)* refers to 1 or 1+ dll (*Step B.5*)
4. On *Step B.4*, one may also choose to use default output path and simlink it
   to project directory
5. Only Unity version >=2018 support C# with .NET Framework 4.6.1.
6. **(Unconfirmed)** It seems that managed DLL project can be complied with 1 
  Unity version and be compatibale with other version.
7. Setup is tested with 
   - Windows 10 Pro (Version 1809, OSBuild 17763.615)
   - Visual Studio 2017 (Version 15.9.14)
   - Mono (Version 6.0.0)
   - Unity (Version 2018.4.4f)

// 20190730_ll
