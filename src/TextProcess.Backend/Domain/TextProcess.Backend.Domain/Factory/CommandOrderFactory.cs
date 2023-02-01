using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Backend.Domain.Commands;

namespace TextProcess.Backend.Domain.Factory
{
    internal abstract class CommandOrderFactory
    {
        protected string TextToOrder { get; init; }

        protected CommandOrderFactory(string textToOrder) 
        {
            this.TextToOrder = textToOrder;
        }

        internal abstract CommandOrder CreateCommand();
    }
}
