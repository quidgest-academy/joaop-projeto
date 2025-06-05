using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace CSGenio.core.di
{
    public interface IMetricsOtlp {
        IDisposable RecordTime(string metricName, TagList tags, string unit = null, string description = null);
        IDisposable RecordTime(string metricName, List<KeyValuePair<string, object>> tags, string unit = null, string description = null);
        void RegisterTime<T>(string metricName, T time, TagList tags, string unit = null, string description = null) where T : struct;
        void IncrementCounter(string metricName, int incrementValue, TagList tags, string unit = null, string description = null);
        void IncrementCounter(string metricName, int incrementValue, List<KeyValuePair<string, object>> tags, string unit = null, string description = null);
    }
}