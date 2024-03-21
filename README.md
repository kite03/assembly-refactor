<h1 align="center">assembly-refactor</h1>
Simple program that renames all classes, methods and fields in a .NET binary.

<div style="display:flex; justify-content:center;">
  <img src="https://github.com/kite03/assembly-refactor/assets/67329371/dd62c5c8-ae05-49d7-b4b7-ebf59976cd2d" alt="before" height="400"/>
  <img src="https://github.com/kite03/assembly-refactor/assets/67329371/4cd75aaa-2fe4-4bcf-a82b-086cbea600a5" alt="after" height="400"/>
</div>

## How to use (Unity games)
1. Download and run [IL2CppDumper](https://github.com/Perfare/Il2CppDumper) on your game of choice.
2. Modify the code in "Refactor.cs" to detect obfuscated names and then simply run ```AssemblyRefactor.exe C:/path/to/file/``` (or drag and drop the binary onto it)
3. The modified binary should appear in the same directory as the original.

### Why?
IL2Cpp has become a popular amongst game developers as a tool to "protect" their games. On top of using this, many developers have begun
obfuscating the code in their games in order to make it harder to reverse engineer.

I created this program to assist me in reversing these protected assemblies by making them more manageable and easier to read.

### Dependencies
[dnlib](https://github.com/0xd4d/dnlib), .NET module/assembly reader/writer library
