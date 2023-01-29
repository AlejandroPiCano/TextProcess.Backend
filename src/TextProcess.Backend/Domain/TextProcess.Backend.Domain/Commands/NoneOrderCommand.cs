using System.Collections.Immutable;

namespace TextProcess.Backend.Domain.Commands
{
    /// <summary>
    /// The NoneOrderCommand class.
    /// </summary>
    internal class NoneOrderCommand : CommandOrder
    {
        public NoneOrderCommand(string textToOrder) : base(textToOrder)
        {
        }

        internal override IEnumerable<string> Sort()
        {
            return this.words;
        }

        internal override IEnumerable<string> UndoSort()
        {
            return this.words;
        }
    }
}