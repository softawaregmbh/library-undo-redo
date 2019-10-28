using System;
using System.Threading.Tasks;

namespace softaware.UndoRedo
{
    public abstract class AsyncAction : IAction
    {
        public ActionState State { get; protected set; }

        public ActionState ActionState { get; private set; }

        public async Task DoAsync()
        {
            if (this.State == ActionState.Done)
            { 
                throw new InvalidOperationException("Action is already done.");
            }

            await this.DoImplementation();

            this.State = ActionState.Done;
        }

        public async Task UndoAsync()
        {
            if (this.State == ActionState.Undone)
            {
                throw new InvalidOperationException("Action is already undone.");
            }

            await this.UndoImplementation();

            this.State = ActionState.Undone;
        }

        async void IAction.Do()
        {
            await this.DoAsync();
        }

        async void IAction.Undo()
        {
            await this.UndoAsync();
        }

        protected abstract Task DoImplementation();
        protected abstract Task UndoImplementation();
    }
}
