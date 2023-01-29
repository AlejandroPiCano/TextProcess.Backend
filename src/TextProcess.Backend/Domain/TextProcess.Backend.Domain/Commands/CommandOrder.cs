using System.Dynamic;

namespace TextProcess.Backend.Domain.Commands
{
    /// <summary>
    /// The CommandOrder abstact class.
    /// </summary>
    internal abstract class CommandOrder
    {
        protected IEnumerable<string> words;

        protected CommandOrder(string textToOrder) 
        {
            GetWords(textToOrder);
        }

        internal abstract IEnumerable<string> Sort();

        internal abstract IEnumerable<string> UndoSort();

        private void GetWords(string textToOrder)
        {
            words = textToOrder.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}