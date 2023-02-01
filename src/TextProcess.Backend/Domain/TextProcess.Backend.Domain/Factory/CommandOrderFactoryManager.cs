using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Domain.Commands;
using TextProcess.Backend.Domain.Entities;

namespace TextProcess.Backend.Domain.Factory
{
    /// <summary>
    /// The command order factory class.
    /// </summary>
    internal static class CommandOrderFactoryManager
    {
        private static Type defaultCommand = typeof(NoneOrderCommandFactory);

        private static Dictionary<OrderOptionEntity, Type> orderOptionsCommandsDictionary = new Dictionary<OrderOptionEntity, Type>()
        {
            {OrderOptionEntity.AlphabeticAsc, typeof(AlphabeticAscOrderCommandFactory) },
            {OrderOptionEntity.AlphabeticDesc, typeof(AlphabeticDescOrderCommandFactory) },
            {OrderOptionEntity.LenghtAsc, typeof(LenghtAscOrderCommandFactory) },
            {OrderOptionEntity.None, typeof(NoneOrderCommandFactory) }
        };

        internal static CommandOrder GetCommandOrder(string textToOrder, OrderOptionEntity orderOption)
        {
            var type = orderOptionsCommandsDictionary.ContainsKey(orderOption) ? orderOptionsCommandsDictionary[orderOption] : defaultCommand;
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
            CommandOrderFactory factory = ctor.Invoke(new object[] { textToOrder }) as CommandOrderFactory;

            return factory.CreateCommand();
        }
    }
}
