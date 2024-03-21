using dnlib.DotNet;
using System.Text.RegularExpressions;

namespace AssemblyRefactor
{
    internal class Refactor
    {
        // whatever method you use to detect obfuscated names
        private static bool ShouldRename(string name)
        {
            // Generic A-Z Detection
            Regex regex = new Regex(@"[a-zA-Z0-9_.]+");
            return !regex.IsMatch(name);

            // VRChat
            // return name.Any(c => "ÌÍÎÏ".Contains(c));

            // Rename everything
            // return true;
        }

        private static void ProcessParameter(ParamDef parameter, ref int count)
        {
            if (ShouldRename(parameter.Name))
            {
                parameter.Name = $"p{count++}";
            }
        }

        private static void RenameEntity(IMemberDef entity, ref int count)
        {
            if (!ShouldRename(entity.Name)) 
            {
                Console.WriteLine($"Skipping {entity.Name}");
                return;
            }

            Console.WriteLine(entity.GetType().Name);

            string typeName = entity.GetType().Name.Replace("DefMD", "").ToLower();
            string originalName = entity.Name;
            entity.Name = $"{typeName}_{count++}";

            Console.WriteLine($"{originalName} -> {entity.Name}");
        }

        public static void RefactorAssembly(ModuleDefMD module)
        {
            int typeCount = 1;
            int methodCount = 1;
            int fieldCount = 1;
            int eventCount = 1;
            int nestedTypeCount = 1;

            foreach (var typeDef in module.GetTypes())
            {
                RenameEntity(typeDef, ref typeCount);

                foreach (var method in typeDef.Methods)
                {
                    RenameEntity(method, ref methodCount);

                    int parameterCount = 1;
                    foreach (var parameter in method.ParamDefs)
                    {
                        ProcessParameter(parameter, ref parameterCount);
                    }
                }

                foreach (var field in typeDef.Fields)
                {
                    RenameEntity(field, ref fieldCount);
                }

                foreach (var eventDef in typeDef.Events)
                {
                    RenameEntity(eventDef, ref eventCount);
                }

                foreach (var nestedType in typeDef.NestedTypes)
                {
                    RenameEntity(nestedType, ref nestedTypeCount);
                }
            }
        }
    }
}
