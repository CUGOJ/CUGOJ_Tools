using Serilog.Sinks.Loki.Labels;
namespace CUGOJ.CUGOJ_Tools.Log;

public class LogLabelProvider : ILogLabelProvider
{
    public IList<LokiLabel> GetLabels()
    {
        return new List<LokiLabel>
        {
            new LokiLabel("IP",Context.Context.ServiceBaseInfo.ServiceIP),
            new LokiLabel("Env",Context.Context.ServiceBaseInfo.Env),
            new LokiLabel("ServiceID",Context.Context.ServiceBaseInfo.ServiceID),
            new LokiLabel("ServiceName",Context.Context.ServiceName)
        };
    }
}