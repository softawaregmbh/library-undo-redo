using System.Collections.Generic;

namespace softaware.UndoRedo
{
    public class RemoveFromCollectionAction<T> : AbstractAction
    {
        protected IEnumerable<T> sourceCollection;
        protected ICollection<T> targetCollection;

        public RemoveFromCollectionAction(IEnumerable<T> source, ICollection<T> target, bool doImmediately)
        {
            this.sourceCollection = source;
            this.targetCollection = target;

            if (doImmediately) 
            {
                this.DoImplementation();
            }
        }

        protected override void DoImplementation()
        {
            foreach (var item in this.sourceCollection)
            {
                this.targetCollection.Remove(item);
            }
        }

        protected override void UndoImplementation()
        {
            foreach (var item in this.sourceCollection)
            {
                this.targetCollection.Add(item);
            }
        }
    }
}
