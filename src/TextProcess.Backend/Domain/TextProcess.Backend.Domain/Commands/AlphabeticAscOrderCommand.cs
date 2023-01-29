using System.Collections.Immutable;

namespace TextProcess.Backend.Domain.Commands
{
    /// <summary>
    /// The AlphabeticAscOrderCommand class.
    /// </summary>
    internal class AlphabeticAscOrderCommand : CommandOrder
    {
        public AlphabeticAscOrderCommand(string textToOrder) : base(textToOrder)
        {
        }

        internal override IEnumerable<string> Sort()
        {
            return this.words.OrderBy(w => w).ToImmutableList();
        }

        internal override IEnumerable<string> UndoSort()
        {
            return this.words;
        }
    }
}