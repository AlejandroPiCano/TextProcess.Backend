using System.Collections.Immutable;

namespace TextProcess.Backend.Domain.Commands
{
    /// <summary>
    /// The LenghtAscOrderCommand class.
    /// </summary>
    internal class LenghtAscOrderCommand : CommandOrder
    {
        public LenghtAscOrderCommand(string textToOrder) : base(textToOrder)
        {
        }

        internal override IEnumerable<string> Sort()
        {
            return this.words.OrderBy(w => w.Length).ToImmutableList();
        }

        internal override IEnumerable<string> UndoSort()
        {
            return this.words;
        }
    }
}