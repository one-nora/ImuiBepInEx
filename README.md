# ImuiBepInEx
A Unity modding library for making Imui into a plugin.

## What is [Imui](https://github.com/vape/Imui)?
Imui is a Immediate mode GUI framework made specifically for Unity. Written in pure C#, has zero per-frame allocations, is somewhat performant, has no external dependencies, and works on basically any platform that Unity supports and that has either a touchscreen or mouse and keyboard. A WebGL demo can be seen [here](https://vape.github.io/imui_demo_080/).

# Building the project
The project is game dependant, so this library isn't just ready out of the box.
But building it is easy.

## Building the source
First of all we need to set the paths.

1. Create a new file called "ImuiBepInEx.csproj.user" in the same directory as the "ImuiBepInEx.csproj" file.
2. Inside paste this code
```
<Project>
  <PropertyGroup>
    <UnityGameDataDir>C:\Program Files (x86)\Steam\steamapps\common\<UNITY_GAME_NAME>\<UNITY_GAME_NAME>_Data\</UnityGameDataDir>
  </PropertyGroup>
</Project>
```
3. Replace the "<UNITY_GAME_NAME>" part with your unity game.
4. Now, open the "ImuiBepInEx.csproj" file, and locate the line that says
``` 
<PackageReference Include="UnityEngine.Modules" Version="2022.3.62">
```
5. Replace the Version with your Unity game version (you can see this by right clicking and seeing the properties of the .exe located in the unity game folder)
	5.1 You can see this by right clicking on the .exe located in the unity game folder, and click on Properties and details.
6. If your unity game version is much different than 2022.2 then go to
```
<DefineConstants>ENABLE_INPUT_SYSTEM;UNITY_2022_2_OR_NEWER</DefineConstants>
```
And replace ```UNITY_2022_2_OR_NEWER``` with ```UNITY_2021_3_OR_NEWER``` or ```UNITY_6000_0_OR_NEWER```

7. While we are at it, if your game has no Unity.InputSystem.dll (Located inside <UNITY_GAME_NAME>_Data/Managed/), remove ```ENABLE_INPUT_SYSTEM```
And remove
```
    <Reference Include="Unity.InputSystem.dll">
      <HintPath>$(UnityGameDataDir)Managed/Unity.InputSystem.dll</HintPath>
      <Private>false</Private>
      <CopyLocal>false</CopyLocal>
    </Reference>
```
8. Now that we have setup up our project, open it.
9. If all went well you should be able to build it.


## Building the bundle
If you are having issues with the bundle, then you may need to rebuild it.
1. Make a new Unity project in the desired version.
2. Add the contents of the UnityAssets folder of this repository directly into the Assets folder of your project.
3. Go to Window -> Raw Asset Bundle Exporter
4. Write "imuiassetbundle" in bundles to build, then click on "Open export folder" and select the "ImuiBepInEx/Assets/" folder.
5. Click on "Build raw asset bundles", once it finishes exporting go back to "ImuiBepInEx/Assets/"
6. Remove any file that isnt named "ImuiAssetBundle", there should only remain 1 file.
7. Done!

# Examples of use

```
TODO:
```

# Updating
Let's say that a new release of Imui is out, how do I update this project?
Well, here's how.

1. Download [Imui](https://github.com/vape/Imui).
2. Copy over all the files inside "Runtime/Scripts/".
3. Paste them into the project.
4. Open the project, it's time to fix things
- Find all references to "Resources.Load" and replace them with "AssetManager.LoadAsset".
- Find all references to "Resources.UnloadAsset" and comment them out
- If ImUnityScrollUtility is giving you an error, just comment it out.
5. Done!

If you want to update the assets, its the same as before, only that now instead of using UnityAssets you are using "Runtime/Resources"
1. Make a new unity project on your desired version.
2. Copy the assets from Runtime/Resources into the Assets folder
3. It should look like "ProjectRoot/Assets/Imui/"
4. For each asset set the new assetbundle label
	4.1 On the inspector tab, after selecting an asset, on the bottom of it will appear a Asset Labels section
	4.2 Click on the dropdown, click on new, and name the new Asset Label "imuiassetbundle"
5. Once every asset has the same label, go to Window->Raw Asset Bundle Exporter 
	5.1 If you don't see this tab, remember to add the "UnityAssets/Editor/RawBundleExporter.cs" script into "Assets/Editor"
6. Write "imuiassetbundle" in bundles to build, then click on "Open export folder" and select the "ImuiBepInEx/Assets/" folder.
5. Click on "Build raw asset bundles", once it finishes exporting go back to "ImuiBepInEx/Assets/"
6. Remove any file that isnt named "ImuiAssetBundle", there should only remain 1 file.
7. Done!

