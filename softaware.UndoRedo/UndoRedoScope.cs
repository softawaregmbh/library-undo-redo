using System.Collections.Generic;

namespace softaware.UndoRedo
{
    public class UndoRedoScope : AbstractAction, IAction
    {
        private Stack<IAction> undoActions;
        private Stack<IAction> redoActions;
        private bool canAddActions;

        public UndoRedoScope()
        {
            this.undoActions = new Stack<IAction>();
            this.redoActions = new Stack<IAction>();
            this.canAddActions = true;
        }

        public bool CanUndo
        {
            get { return this.undoActions.Count > 0; }
        }

        public bool CanRedo
        {
            get { return this.redoActions.Count > 0; }
        }

        public new void Undo()
        {
            if (this.CanUndo)
            {
                this.canAddActions = false;
                var action = this.undoActions.Pop();
                action.Undo();
                this.redoActions.Push(action);
                this.canAddActions = true;
            }
        }

        public void Redo()
        {
            if (this.CanRedo)
            {
                this.canAddActions = false;
                var action = this.redoActions.Pop();
                action.Do();
                this.undoActions.Push(action);
                this.canAddActions = true;
            }
        }

        public void AddAction(IAction action)
        {
            if (this.canAddActions)
            {
                this.undoActions.Push(action);
                this.redoActions.Clear();
            }
        }

        public void Reset(bool undo)
        {
            if (undo)
            {
                while (this.CanUndo) 
                { 
                    this.Undo();
                }
            }
            else 
            {
                this.undoActions.Clear();
            }

            this.redoActions.Clear();
        }

        void IAction.Do()
        {
            this.Do();
        }

        void IAction.Undo()
        {
            this.Undo();
        }

        protected override void DoImplementation()
        {
            while (this.CanRedo)
            {
                this.Redo();
            }
        }

        protected override void UndoImplementation()
        {
            while (this.CanUndo)
            {
                this.Undo();
            }
        }
    }
}
