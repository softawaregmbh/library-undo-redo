using System.Collections.Generic;

namespace softaware.UndoRedo
{
    public class InsertInCollectionAction<T> : AbstractAction
    {
        protected IEnumerable<T> sourceCollection;
        protected ICollection<T> targetCollection;

        public InsertInCollectionAction(IEnumerable<T> source, ICollection<T> target, bool doImmediately)
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
                this.targetCollection.Add(item);
            }
        }

        protected override void UndoImplementation()
        {
            foreach (var item in this.sourceCollection)
            {
                this.targetCollection.Remove(item);
            }
        }
    }
}
