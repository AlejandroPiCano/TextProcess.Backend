using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Domain.Entities;

namespace TextProcess.Backend.Domain.Services
{
    public class OrderProcessDomainService : IOrderProcessDomainService
    {
        public IEnumerable<string> GetOrderedText(string textToOrder, OrderOptionEntity orderOption)
        {
            return Enumerable.Empty<string>();
        }

        public TextStatisticsEntity GetStatistics(string textToAnalize)
        {
            return new TextStatisticsEntity(0, 0, 0);
        }
    }
}
