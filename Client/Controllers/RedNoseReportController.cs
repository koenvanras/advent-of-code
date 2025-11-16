using Core.Abstractions;
using Core.Services;

namespace Client.Controllers
{
    public class RedNoseReportController
    {
        private readonly IRedNoseReportService _redNoseReportService;

        public RedNoseReportController(IRedNoseReportService redNoseReportService)
        {
            _redNoseReportService = redNoseReportService;
        }

        public int GetSafeReportCount()
        {
            // Declare and initialize the lists to safe reports
            List<List<int>> reports = File.ReadLines("./2024_2.txt")
                                .Select(line => line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToList())
                                .ToList();

            var result = 0;

            foreach (var report in reports)
            {
                var isSafe = _redNoseReportService.IsSafe(report);

                if (isSafe)
                    result++;
            }

            Console.WriteLine($"Safe reports: {result}");

            return result;
        }
    }
}
