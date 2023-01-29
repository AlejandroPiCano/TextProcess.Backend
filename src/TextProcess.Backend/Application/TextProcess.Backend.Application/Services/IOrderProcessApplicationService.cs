using TextProcess.Backend.Application.DTOs;

namespace TextProcess.Backend.Application.Services
{
    /// <summary>
    /// The IOrderProcessApplicationService interface.
    /// </summary>
    public interface IOrderProcessApplicationService
    {
        /// <summary>
        /// The GetOrderedText method.
        /// </summary>
        /// <param name="textToOrder">The text to order.</param>
        /// <param name="orderOption">The order option.</param>
        /// <returns>The ordered words.</returns>
        IEnumerable<string> GetOrderedText(string textToOrder, OrderOptionDTO orderOption);

        /// <summary>
        /// The GetStatistics method.
        /// </summary>
        /// <param name="textToAnalize">The text to analize.</param>
        /// <returns>The TextStatisticsDTO.</returns>
        TextStatisticsDTO GetStatistics(string textToAnalize);
    }
}