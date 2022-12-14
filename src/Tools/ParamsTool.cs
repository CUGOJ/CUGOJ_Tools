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
        {"c","connectionString"},
        {"debug","-debug"},
        {"mysql","mysql"},
        {"redis","redis"},
        {"rabbit","rabbit"},
        {"neo4j","neo4j"},
        {"trace","trace"},
        {"log","log"},
    };
    private static Dictionary<string, string> _baseArgs = new Dictionary<string, string>()
    {
        {"connectionString","connectionString"},
        {"c","connectionString"},
        {"debug","-debug"},
        {"mysql","mysql"},
        {"redis","redis"},
        {"rabbit","rabbit"},
        {"neo4j","neo4j"},
        {"trace","trace"},
        {"log","log"},
    };
    private static Dictionary<string, string> _gatewayArgs = new Dictionary<string, string>()
    {
        {"connectionString","connectionString"},
        {"c","connectionString"},
        {"debug","-debug"},
        {"mysql","mysql"},
        {"redis","redis"},
        {"rabbit","rabbit"},
        {"neo4j","neo4j"},
        {"trace","trace"},
        {"log","log"},
    };
    private static Dictionary<string, string> _judgerArgs = new Dictionary<string, string>()
    {
        {"connectionString","connectionString"},
        {"c","connectionString"},
        {"debug","-debug"},
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
            case ServiceTypeEnum.Gateway: keys = _gatewayArgs; break;
            case ServiceTypeEnum.Judger: keys = _judgerArgs; break;
            default:
                return new Dictionary<string, string>();
        }
        string? key = null;
        foreach (var arg in args)
        {
            if (arg == "-")
            {
                throw new Exception("??????????????????-");
            }
            if (arg.StartsWith('-'))
            {
                if (key != null)
                {
                    throw new Exception("???????????????:-" + key);
                }
                else
                {
                    if (!keys.TryGetValue(arg.Substring(1), out key))
                    {
                        throw new Exception("??????????????????" + arg);
                    }
                    if (key.StartsWith('-'))
                    {
                        key = key.Substring(1);
                        if (res.ContainsKey(key))
                        {
                            throw new Exception("??????????????????" + key);
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
                    throw new Exception("??????????????????" + key);
                }
                res[key] = arg;
                key = null;
            }
        }
        return res;
    }
}