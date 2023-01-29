using System.Collections.Immutable;

namespace TextProcess.Backend.Domain.Commands
{
    /// <summary>
    /// The AlphabeticDescOrderCommand class.
    /// </summary>
    internal class AlphabeticDescOrderCommand : CommandOrder
    {
        public AlphabeticDescOrderCommand(string textToOrder) : base(textToOrder)
        {
        }

        internal override IEnumerable<string> Sort()
        {
            return this.words.OrderByDescending(w => w).ToImmutableList();
        }

        internal override IEnumerable<string> UndoSort()
        {
            return this.words;
        }
    }
}