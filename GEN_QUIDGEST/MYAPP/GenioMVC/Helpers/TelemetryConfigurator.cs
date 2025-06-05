using CSGenio.core.di;
using CSGenio.core.logger;
using GenioMVC.Metrics;
using log4net.Config;
using log4net;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Diagnostics.Metrics;
using CSGenio.framework;

namespace GenioMVC.Helpers
{
    public static class TelemetryConfigurator
    {
        public static void ConfigureTelemetry(this IServiceCollection services, TelemetryConfiguration telemetryConfig, ILoggingBuilder loggingBuilder)
        {
            string serviceName = (telemetryConfig != null && !string.IsNullOrEmpty(telemetryConfig.TelemetryAlias))
                ? telemetryConfig.TelemetryAlias
                : $"{Configuration.Program} - {Configuration.Application.Id}";

            // Configure Metrics
            ConfigureMetrics(services, telemetryConfig, serviceName);
            
            // Configure Logging
            ConfigureLogging(loggingBuilder, telemetryConfig, serviceName);

            // Configure Tracing
            ConfigureTracing(services, telemetryConfig, serviceName);
        }

        private static void ConfigureLogging(ILoggingBuilder loggingBuilder, TelemetryConfiguration telemetryConfig, string serviceName)
        {
            if (telemetryConfig != null && telemetryConfig.LoggerType == TelemetryConfiguration.LoggerConfigType.OTLP)
            {
                loggingBuilder.AddOpenTelemetry(options =>
                {
                    options.IncludeScopes = true;
                    options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName, Configuration.GenioVersion));
                    options.AddOtlpExporter(otlpOptions => otlpOptions.Endpoint = new Uri(telemetryConfig.CollectorAddress));
                });
            }
            else
            {
                var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("web.config"));
            }
        }

        private static void ConfigureMetrics(IServiceCollection services, TelemetryConfiguration telemetryConfig, string serviceName)
        {
            if (telemetryConfig == null)
            {
                GenioDI.MetricsOtlp = new MetricsOtlpImpl();
                return;
            }
            
            Meter mainMeter = new Meter("MainMeter");

            services.AddOpenTelemetry().WithMetrics(options =>
            {
                options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName, Configuration.GenioVersion));
                options.AddMeter(mainMeter.Name);
                options.AddOtlpExporter(otlpOptions => otlpOptions.Endpoint = new Uri(telemetryConfig.CollectorAddress));

                // Asp .Netcore builtin metrics
                if (telemetryConfig.EnableInternalMetrics)
                {
                    options.AddAspNetCoreInstrumentation();
                    options.AddRuntimeInstrumentation();
                    options.AddProcessInstrumentation();
                }
            });

            GenioDI.MetricsOtlp = new MetricsOtlpImpl(mainMeter);
        }

        private static void ConfigureTracing(IServiceCollection services, TelemetryConfiguration telemetryConfig, string serviceName)
        {
            if (telemetryConfig == null || !telemetryConfig.EnableTracing) return;

            services.AddOpenTelemetry().WithTracing(builder =>
            {
                builder.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName, Configuration.GenioVersion));
                builder.AddAspNetCoreInstrumentation(options =>
                {
                    options.EnrichWithHttpResponse = (activity, httpResponse) =>
                    {
                        var request = httpResponse.HttpContext.Request;

                        foreach (var routeVal in request.RouteValues)
                            activity.SetTag($"http.route.{routeVal.Key}", routeVal.Value.ToString());

                        foreach (var queryVal in request.Query)
                            activity.SetTag($"http.query.{queryVal.Key}", queryVal.Value.ToString());

                        activity.DisplayName = $"{request.Method} {request.Scheme} {request.Path}";

                        activity.SetTag("user.username", httpResponse.HttpContext.User.Identity.Name);
                        activity.SetTag("user.ip_address", httpResponse.HttpContext.GetIpAddress());
                    };
                })
                .AddHttpClientInstrumentation()
                .AddSource("ClientSide.Telemetry")
                .AddOtlpExporter(otlpOptions => otlpOptions.Endpoint = new Uri(telemetryConfig.CollectorAddress));
            });
        }
    }
}
