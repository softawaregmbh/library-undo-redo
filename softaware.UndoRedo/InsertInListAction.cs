using System.Collections.Generic;

namespace softaware.UndoRedo
{
    public class InsertInListAction<T> : InsertInCollectionAction<T>
    {
        protected int index;

        public InsertInListAction(IEnumerable<T> source, IList<T> target, int index, bool doImmediately)
            : base(source, target, false)
        {
            this.index = index;

            if (doImmediately)
            {
                this.DoImplementation();
            }
        }

        protected override void DoImplementation()
        {
            int i = 0;
            foreach (var item in this.sourceCollection)
            {
                ((IList<T>)this.targetCollection).Insert(this.index + i, item);
                i++;
            }
        }
    }
}
