using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Application.DTOs;

namespace TextProcess.Backend.Application.Services
{
    /// <summary>
    /// The IOrderOptionsService interface.
    /// </summary>
    public interface IOrderOptionsService
    {
        /// <summary>
        /// The GetOrderOptions method.
        /// </summary>
        /// <returns>A task of a order options IEnumerable.</returns>
        Task<IEnumerable<string>> GetOrderOptions();
    }
}
