using Serilog.Configuration;
using Serilog;
using Shortener.Api.Sinks;

namespace Shortener.Api.Extensions;

public static class CustomSinkExtensions
{
    public static LoggerConfiguration CustomSink(this LoggerSinkConfiguration loggerConfiguration)
    {
        return loggerConfiguration.Sink(new CustomSink());
    }
}
