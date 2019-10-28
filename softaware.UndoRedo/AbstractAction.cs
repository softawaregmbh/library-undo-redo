using System;

namespace softaware.UndoRedo
{
    public abstract class AbstractAction : IAction
    {
        public AbstractAction()
        {
            this.State = ActionState.Done;
        }

        public ActionState State { get; protected set; }

        public void Do()
        {
            if (this.State == ActionState.Done)
            { 
                throw new InvalidOperationException("Action is already done.");
            }

            this.DoImplementation();

            this.State = ActionState.Done;
        }

        public void Undo()
        {
            if (this.State == ActionState.Undone)
            {
                throw new InvalidOperationException("Action is already undone.");
            }

            this.UndoImplementation();

            this.State = ActionState.Undone;
        }

        protected abstract void DoImplementation();
        protected abstract void UndoImplementation();
    }
}
