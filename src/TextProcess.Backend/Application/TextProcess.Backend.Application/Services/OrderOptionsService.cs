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
    /// The OrderOptions service.
    /// </summary>
    public class OrderOptionsService: IOrderOptionsService
    {
        private readonly IRepository<OrderOptionEntity> orderOptionsRepository;

        /// <summary>
        /// The OrderOptions service constructor
        /// </summary>
        /// <param name="orderOptionsRepository"></param>
        public OrderOptionsService(IRepository<OrderOptionEntity> orderOptionsRepository)
        {
            this.orderOptionsRepository = orderOptionsRepository;
        }

        /// <summary>
        /// The GetOrderOptions method.
        /// </summary>
        /// <returns>A task of a order options IEnumerable.</returns>
        public async Task<IEnumerable<string>> GetOrderOptions()
        {
            var orderOptions = await orderOptionsRepository.GetAllAsync();

            return orderOptions.Select(orderOption => orderOption.ToString());
        }
    }
}
