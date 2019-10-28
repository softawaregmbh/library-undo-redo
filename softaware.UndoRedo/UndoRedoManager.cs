using System.Collections.Generic;
using System.Linq;

namespace softaware.UndoRedo
{
    public class UndoRedoManager
    {
        private Stack<UndoRedoScope> scopes = new Stack<UndoRedoScope>();

        public UndoRedoScope CurrentScope 
        {
            get { return this.scopes.Peek(); }
        }

        public bool HasScope 
        {
            get { return this.scopes.Any(); } 
        }

        public void OpenNewScope()
        {
            this.scopes.Push(new UndoRedoScope());
        }

        public void CloseCurrentScope(bool addToOuterScope)
        {
            var manager = this.scopes.Pop();
            if (addToOuterScope && this.HasScope)
            {
                this.CurrentScope.AddAction(manager);
            }
        }
    }
}
