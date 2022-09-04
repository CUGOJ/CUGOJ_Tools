using System.Text.RegularExpressions;
namespace CUGOJ.CUGOJ_Tools.Tools;

public static class CommonTools
{
    public static long Unix()
    {
        return (long)(DateTime.Now - DateTime.UnixEpoch).TotalSeconds;
    }
    public static long UnixMili()
    {
        return (long)(DateTime.Now - DateTime.UnixEpoch).TotalMilliseconds;
    }
    public static long UnixNano()
    {
        return (long)(DateTime.Now - DateTime.UnixEpoch).TotalMilliseconds * 1000000;
    }
    public static bool IsUrl(string str)
    {
        try
        {
            string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
            return Regex.IsMatch(str, Url);
        }
        catch (Exception)
        {
            return false;
        }
    }
}