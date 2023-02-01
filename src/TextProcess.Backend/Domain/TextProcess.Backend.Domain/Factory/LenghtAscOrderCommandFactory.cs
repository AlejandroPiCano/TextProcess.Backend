using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Domain.Commands;

namespace TextProcess.Backend.Domain.Factory
{
    internal class LenghtAscOrderCommandFactory : CommandOrderFactory
    {
        public LenghtAscOrderCommandFactory(string textToOrder) : base(textToOrder)
        {
        }

        internal override CommandOrder CreateCommand()
        {
            return new LenghtAscOrderCommand(TextToOrder);
        }
    }
}
