using Core.Abstractions;

namespace Core.Services
{
    public class RedNoseReportService : IRedNoseReportService
    {
        public bool IsSafe(List<int> report)
        {
            var result = false;

            var badLevelCount = GetReportBadLevelCount(report);
            if (badLevelCount > 0)
                return false;

            result = ReportIsAscOrDesc(report);

            return result;
        }

        private int GetReportBadLevelCount(List<int> report)
        {
            var result = 0;

            for (int i = 1; i < report.Count; i++)
            {
                var diff = report[i] - report[i - 1];
                var absDiff = Math.Abs(diff);

                // Step size must be between 1 and 3
                if (absDiff < 1 || absDiff > 3)
                    result++;
            }

            return result;
        }

        private bool ReportIsAscOrDesc(List<int> report)
        {
            bool ascending = true;
            bool descending = true;

            for (int i = 1; i < report.Count; i++)
            {
                int diff = report[i] - report[i - 1];
                
                // Track order direction
                if (diff > 0)
                    descending = false;
                else if (diff < 0)
                    ascending = false;
            }

            return ascending || descending;
        }
    }
}
