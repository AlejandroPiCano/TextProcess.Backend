using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Domain.Entities;
using TextProcess.Backend.Domain.Factory;

namespace TextProcess.Backend.Domain.Services
{
    /// <summary>
    /// The OrderProcessDomainService class.
    /// </summary>
    public class OrderProcessDomainService : IOrderProcessDomainService
    {
        /// <summary>
        /// The GetOrderedText method
        /// </summary>
        /// <param name="textToOrder">The text to order</param>
        /// <param name="orderOption">The order option enum.</param>
        /// <returns>The ordered words.</returns>
        public IEnumerable<string> GetOrderedText(string textToOrder, OrderOptionEntity orderOption)
        {            
            var command = CommandOrderFactory.GetCommand(textToOrder, orderOption);

            return command.Sort();
        }

        /// <summary>
        /// The 
        /// </summary>
        /// <param name="textToAnalize">The text to analize.</param>
        /// <returns>The statistics.</returns>
        public TextStatisticsEntity GetStatistics(string textToAnalize)
        {
            return new TextStatisticsEntity(0, 0, 0);
        }
    }
}
