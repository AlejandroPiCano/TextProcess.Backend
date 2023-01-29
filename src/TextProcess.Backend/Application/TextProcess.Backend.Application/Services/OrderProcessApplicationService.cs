using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Application.DTOs;
using TextProcess.Backend.Domain.Entities;
using TextProcess.Backend.Domain.Services;

namespace TextProcess.Backend.Application.Services
{
    /// <summary>
    /// The OrderProcessApplicationService class.
    /// </summary>
    public class OrderProcessApplicationService : IOrderProcessApplicationService
    {
        private readonly IOrderProcessDomainService orderProcessDomainService;

        /// <summary>
        /// The OrderProcessApplicationService constructor.
        /// </summary>
        /// <param name="orderProcessDomainService"></param>
        public OrderProcessApplicationService(IOrderProcessDomainService orderProcessDomainService)
        {
            this.orderProcessDomainService = orderProcessDomainService;
        }

        /// <summary>
        /// The GetOrderedText method.
        /// </summary>
        /// <param name="textToOrder">The text to order.</param>
        /// <param name="orderOption">The order option.</param>
        /// <returns>The ordered words.</returns>
        public IEnumerable<string> GetOrderedText(string textToOrder, OrderOptionDTO orderOption)
        {
            if (string.IsNullOrEmpty(textToOrder))
            {
                throw new ArgumentException($"Argument {nameof(textToOrder)} is null or empty");
            }

            return orderProcessDomainService.GetOrderedText(textToOrder, (OrderOptionEntity)orderOption);
        }

        /// <summary>
        /// The GetStatistics method.
        /// </summary>
        /// <param name="textToAnalize">The text to analize.</param>
        /// <returns>The TextStatisticsDTO.</returns>
        public TextStatisticsDTO GetStatistics(string textToAnalize)
        {           
            if (string.IsNullOrEmpty(textToAnalize))
            {
                throw new ArgumentException($"Argument {nameof(textToAnalize)} is null or empty");
            }

            TextStatisticsDTO defaultResult = new TextStatisticsDTO(0, 0, 0);
            var textStatistics = orderProcessDomainService.GetStatistics(textToAnalize);

            return textStatistics != null ? new TextStatisticsDTO(textStatistics.HyphensQuantity, textStatistics.WordQuantity, textStatistics.SpacesQuantity) : defaultResult;
        }
    }
}
