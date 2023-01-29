using TextProcess.Backend.Domain.Entities;

namespace TextProcess.Backend.Domain.Services
{
    public interface IOrderProcessDomainService
    {
        IEnumerable<string> GetOrderedText(string textToOrder, OrderOptionEntity orderOption);
        TextStatisticsEntity GetStatistics(string textToAnalize);
    }
}