//dotnet tool install -g dotnet-script

using Internal;

string GetNamespace(string filePath)
{
    var lines = File.ReadAllLines(filePath);
    var ns = lines.FirstOrDefault(x => x.StartsWith("namespace"));
    if (ns != null)
    {
        return ns + ";";
    }
    throw new Exception("未知的命名空间");
}

string GetClassName(string filePath)
{
    var lines = File.ReadAllLines(filePath);
    foreach (var x in lines)
    {
        if (x.Trim().StartsWith("public partial class"))
            return x.Trim().Split(' ')[3];
    }
    throw new Exception("未知的类名");
}

void RemoveBase(string filePath)
{
    var lines = File.ReadAllLines(filePath);
    File.WriteAllText(filePath, string.Join("\n", lines.Where(x => x.Trim() != "private global::CUGOJ.RPC.Gen.Base.@Base _Base;").ToList()));
}

void DfsFiles(string currentDirectory)
{
    // Console.WriteLine(currentDirectory);
    if (!Directory.Exists(currentDirectory))
    {
        return;
    }
    var dir = new DirectoryInfo(currentDirectory);
    dir.GetDirectories().ToList().ForEach(x => DfsFiles(x.FullName));
    dir.GetFiles().ToList().ForEach(x =>
    {
        // Console.WriteLine(x.Name);
        if (x.Name.EndsWith("Request.cs"))
        {
            // Console.WriteLine(currentDirectory + "/" + x.Name.Substring(0, x.Name.Length - 3) + "Ext.cs");
            using var file = File.Create(currentDirectory + "/" + x.Name.Substring(0, x.Name.Length - 3) + "Ext.cs");
            // Console.WriteLine(GetNamespace(x.FullName) + " " + GetClassName(x.FullName));
            using var writer = new StreamWriter(file);
            writer.WriteLine(GetNamespace(x.FullName));
            writer.WriteLine("public partial class " + GetClassName(x.FullName) + " : CUGOJ.CUGOJ_Tools.RPC.BaseRequest");
            writer.WriteLine("{");
            writer.WriteLine("  private global::CUGOJ.RPC.Gen.Base.@Base _Base = CUGOJ.CUGOJ_Tools.RPC.RPCTools.NewBase();");
            writer.WriteLine("}");
            RemoveBase(x.FullName);
        }
        else if (x.Name.EndsWith("Response.cs"))
        {
            using var file = File.Create(currentDirectory + "/" + x.Name.Substring(0, x.Name.Length - 3) + "Ext.cs");
            using var writer = new StreamWriter(file);
            writer.WriteLine(GetNamespace(x.FullName));
            writer.WriteLine("public partial class " + GetClassName(x.FullName) + " : CUGOJ.CUGOJ_Tools.RPC.BaseResponse");
            writer.WriteLine("{");
            writer.WriteLine("");
            writer.WriteLine("}");
        }
    });
}

DfsFiles("./src/gen-netstd");