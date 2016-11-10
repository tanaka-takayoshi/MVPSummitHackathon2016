using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //DEBUG
        Console.WriteLine(string.Join(",", args));
        Console.WriteLine(Directory.GetCurrentDirectory());
        //END DEBUG
        var type = args.Length >= 1 ? args[0] : "cs";
        var name = args.Length >= 2 ? args[1] : null;

        switch (type)
        {
            case "cs":
                GenerateCsFile(name);
                break;
            case "if":
                GenerateInterfaceFile(name);
                break;
            default:
                break;
        }
     }

    private static void GenerateCsFile(string name)
    {
        var path = Path.GetExtension(name) != ".cs" ? name + ".cs" : name;
        path = Path.Combine(Directory.GetCurrentDirectory(), path);
        if (File.Exists(path))
        {
            Console.WriteLine($"{path} is existing. Do nothing.");
            return;
        }
        var dir = Path.GetDirectoryName(path);
        //Debug
        Console.WriteLine($"Dir: {dir}");       
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        using (var writer = File.CreateText(path))
        {
            var className = Path.GetFileNameWithoutExtension(path);
            writer.Write($@"using System;
using System.IO;
using System.Linq;

namespace Example
{{
    class {className}
    {{

    }}
}}");
        }
        Console.WriteLine($"Added class to {path}");
    }

    private static void GenerateInterfaceFile(string name)
    {
        var path = Path.GetExtension(name) != ".cs" ? name + ".cs" : name;
        path = Path.Combine(Directory.GetCurrentDirectory(), path);
        if (File.Exists(path))
        {
            Console.WriteLine($"{path} is existing. Do nothing.");
            return;
        }
        var dir = Path.GetDirectoryName(path);
        //Debug
        Console.WriteLine($"Dir: {dir}");
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        using (var writer = File.CreateText(path))
        {
            var className = Path.GetFileNameWithoutExtension(path);
            writer.Write($@"using System;
using System.IO;
using System.Linq;

namespace Example
{{
    interface {className}
    {{

    }}
}}");
            Console.WriteLine($"Added interface to {path}");
        }
    }
    
}

