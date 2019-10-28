namespace softaware.UndoRedo
{
    public interface IAction
    {
        ActionState State { get; }
        void Do();
        void Undo();
    }
}
