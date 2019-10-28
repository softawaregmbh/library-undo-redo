using System;
using System.Threading.Tasks;

namespace softaware.UndoRedo
{
    public class AsyncDelegateAction : AsyncAction
    {
        private Func<Task> doImplementation;
        private Func<Task> undoImplementation;

        public AsyncDelegateAction(Func<Task> doImplementation, Func<Task> undoImplementation)
        {
            this.doImplementation = doImplementation;
            this.undoImplementation = undoImplementation;
        }

        protected override Task DoImplementation()
        {
            return this.doImplementation();
        }

        protected override Task UndoImplementation()
        {
            return this.undoImplementation();
        }
    }
}
