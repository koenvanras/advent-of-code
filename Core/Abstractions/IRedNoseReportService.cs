namespace Core.Abstractions
{
    public interface IRedNoseReportService
    {
        bool IsSafe(List<int> report);
    }
}
