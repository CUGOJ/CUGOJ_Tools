using CUGOJ.RPC.Gen.Base;

namespace CUGOJ.CUGOJ_Tools.Tools;
public static class ParamsTool
{
    private static Dictionary<string, string> _coreArgs = new Dictionary<string, string>()
    {
        {"localhost" ,"-localhost"},
        {"local","-localhost"},
        {"lo","-localhost"},
        {"trace","trace"},
        {"t","trace"},
        {"log","log"},
        {"l","log"},
        {"port","port"},
        {"p","port"},
        {"env","env"},
        {"e","env"},
        {"mysql","mysql"},
        {"redis","redis"},
        {"rabbit","rabbit"},
        {"neo","neo"}
    };
    private static Dictionary<string, string> _authenticationArgs = new Dictionary<string, string>()
    {
        {"connectionString","connectionString"},
        {"c","connectionString"}
    };
    private static Dictionary<string, string> _baseArgs = new Dictionary<string, string>()
    {
        {"connectionString","connectionString"},
        {"c","connectionString"},
        {"debug","-debug"},
        {"mysql","mysql"},
        {"neo4j","neo4j"}
    };
    public static Dictionary<string, string> ParseArgs(string[] args, ServiceTypeEnum type)
    {
        Dictionary<string, string> res = new();
        Dictionary<string, string>? keys;
        switch (type)
        {
            case ServiceTypeEnum.Core: keys = _coreArgs; break;
            case ServiceTypeEnum.Authentication: keys = _authenticationArgs; break;
            case ServiceTypeEnum.Base: keys = _baseArgs; break;
            default:
                return new Dictionary<string, string>();
        }
        string? key = null;
        foreach (var arg in args)
        {
            if (arg == "-")
            {
                throw new Exception("未知的参数键-");
            }
            if (arg.StartsWith('-'))
            {
                if (key != null)
                {
                    throw new Exception("缺失参数值:-" + key);
                }
                else
                {
                    if (!keys.TryGetValue(arg.Substring(1), out key))
                    {
                        throw new Exception("未知的参数键" + arg);
                    }
                    if (key.StartsWith('-'))
                    {
                        key = key.Substring(1);
                        if (res.ContainsKey(key))
                        {
                            throw new Exception("重复设置参数" + key);
                        }
                        res[key] = "true";
                        key = null;
                    }
                }
            }
            else
            {
                if (key == null)
                {
                    key = "main";
                }
                if (res.ContainsKey(key))
                {
                    throw new Exception("重复设置参数" + key);
                }
                res[key] = arg;
                key = null;
            }
        }
        return res;
    }
}