using System.Reflection;

namespace softaware.UndoRedo
{
    public class EditPropertyAction<T> : AbstractAction
    {
        private object source;
        private PropertyInfo property;
        private T oldValue;
        private T newValue;

        public EditPropertyAction(object source, string propertyName, T oldValue, T newValue)
        {
            this.source = source;
            this.property = source.GetType().GetProperty(propertyName);
            this.oldValue = oldValue;
            this.newValue = newValue;
            this.State = ActionState.Done;
        }

        protected override void DoImplementation()
        {
            this.property.SetValue(this.source, this.newValue, null);
        }

        protected override void UndoImplementation()
        {
            this.property.SetValue(this.source, this.oldValue, null);
        }
    }
}
