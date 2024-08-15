using System.Diagnostics;
using System.Text.Json;


namespace WebApplication_IT_Academy
{
    public class PerformanceStats
    {
        public int TotalCpuUtilizationPercentage { get; private set; }
        public int TotalOccupiedMemoryPercentage { get; private set; }
        public int TotalRunningProcessCount { get; private set; }

        public PerformanceStats()
        {
            TotalRunningProcessCount = Process.GetProcesses().Length;
            TotalCpuUtilizationPercentage = CpuUsage();
            TotalOccupiedMemoryPercentage = MemoryUsage();
        }

        private int CpuUsage()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            
            return (int)cpuCounter.NextValue();
        }

        private int MemoryUsage()
        {
            var _ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            return (int)_ramCounter.NextValue();
        }
    }
}
