using Client.Controllers;
using Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        // Build the host with DI
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddCoreServices();
                services.AddScoped<DistanceController>();
                services.AddScoped<SimilarityController>();
                services.AddScoped<RedNoseReportController>();
            })
            .Build();

        #region 2024 - Day One

        // 2024 - Day One - Part 1: Calculate total distance
        Console.WriteLine("2024 - Day One - Part 1: Calculate total distance");
        var distanceController = host.Services.GetRequiredService<DistanceController>();
        var totalDistance = distanceController.CalculateTotalDistance();

        // 2024 - Day One - Part 2: Calculate similarity score
        Console.WriteLine("\n2024 - Day One - Part 2: Calculate similarity score");
        var similarityController = host.Services.GetRequiredService<SimilarityController>();
        var similarityScore = similarityController.CalculateSimilarityScore();

        #endregion

        #region 2024 - Day Two

        // 2024 - Day Two - Part 1: Calculate safe reports
        Console.WriteLine("\n2024 - Day Two - Part 1: Calculate safe reports");
        var redNoseReportController = host.Services.GetService<RedNoseReportController>();
        var safeReports = redNoseReportController.GetSafeReportCount();

        #endregion

        Console.ReadLine();
    }
}