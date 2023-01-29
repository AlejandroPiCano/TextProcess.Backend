using TextProcess.Backend.Domain.Entities;
using TextProcess.Backend.Domain.Services;

namespace TextProcess.Backend.Infrastructure
{

    public class OrderOptionsRepository : IRepository<OrderOptionEntity>
    {
        private IEnumerable<OrderOptionEntity> orderOptions;

        public Task<IEnumerable<OrderOptionEntity>> GetAllAsync()
        {
            return GetAllOrderOptionsAsync();
        }

        public async Task<OrderOptionEntity> GetAsync(int id)
        {
            await GetAllOrderOptionsAsync();

            return orderOptions.FirstOrDefault(orderOption => (int)orderOption == id);
        }

        private Task<IEnumerable<OrderOptionEntity>> GetAllOrderOptionsAsync()
        {
            if (orderOptions == null)
            {
                orderOptions = Enum.GetValues<OrderOptionEntity>();
            }

            return Task.FromResult(orderOptions);
        }
    }
}