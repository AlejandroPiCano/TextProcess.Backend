using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Domain.Commands;

namespace TextProcess.Backend.Domain.Factory
{
    internal class AlphabeticAscOrderCommandFactory : CommandOrderFactory
    {
        public AlphabeticAscOrderCommandFactory(string textToOrder) : base(textToOrder)
        {
        }

        internal override CommandOrder CreateCommand()
        {
            return new AlphabeticAscOrderCommand(TextToOrder);
        }
    }
}
