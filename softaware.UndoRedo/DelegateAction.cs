using System;

namespace softaware.UndoRedo
{
    public class DelegateAction : AbstractAction
    {
        private Action doImplementation;
        private Action undoImplementation;

        public DelegateAction(Action doImplementation, Action undoImplementation)
        {
            this.doImplementation = doImplementation;
            this.undoImplementation = undoImplementation;
        }

        protected override void DoImplementation()
        {
            this.doImplementation();
        }

        protected override void UndoImplementation()
        {
            this.undoImplementation();
        }
    }
}
