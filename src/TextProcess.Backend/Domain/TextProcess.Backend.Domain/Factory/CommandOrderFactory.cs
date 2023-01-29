using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Domain.Commands;
using TextProcess.Backend.Domain.Entities;

namespace TextProcess.Backend.Domain.Factory
{
    /// <summary>
    /// The command order factory class.
    /// </summary>
    internal class CommandOrderFactory
    {
        internal static CommandOrder GetCommand(string textToOrder, OrderOptionEntity orderOption)
        {
            switch (orderOption)
            {
                case OrderOptionEntity.AlphabeticAsc:
                    return new AlphabeticAscOrderCommand(textToOrder);
                case OrderOptionEntity.AlphabeticDesc:
                    return new AlphabeticDescOrderCommand(textToOrder);
                case OrderOptionEntity.LenghtAsc:
                    return new LenghtAscOrderCommand(textToOrder);
                default:
                    return new NoneOrderCommand(textToOrder);
            }
        }
    }
}
