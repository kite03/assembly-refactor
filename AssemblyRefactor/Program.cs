using dnlib.DotNet;

namespace AssemblyRefactor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Provide the path to the assembly to refactor");
                return;
            }

            string inputFilePath = args[0];

            ModuleDefMD module = ModuleDefMD.Load(inputFilePath);
            Refactor.RefactorAssembly(module);

            string directory = Path.GetDirectoryName(inputFilePath);
            string filename = Path.GetFileNameWithoutExtension(inputFilePath);
            string extension = Path.GetExtension(inputFilePath);

            string output = Path.Combine(directory, $"{filename}_refactored{extension}");

            Console.WriteLine($"Constructing new assembly at: {output}");
            module.Write(output);
            Console.WriteLine($"Done!");
        }
    }
}
