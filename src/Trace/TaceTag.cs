namespace CUGOJ.CUGOJ_Tools.Trace;

[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Method)]
public class TagAttribute : Attribute
{
    private List<string> keys = new();
    private List<string> values = new();
    //tags请遵循 key=value的格式
    public void AddTags(Action<string, string> action)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            action(keys[i], values[i]);
        }
    }

    public TagAttribute(params string[] tags)
    {
        foreach (var tag in tags)
        {
            var buffer = tag.Split('=');
            if (buffer.Length != 2)
                continue;
            keys.Add(buffer[0].Trim());
            values.Add(buffer[1].Trim());
        }
    }

}