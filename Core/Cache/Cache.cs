using Core.Adapters.Factories;
using Core.Utilities.Queries;
using System.ComponentModel;

namespace Core.Cache
{
    public class Cache<T> : BindingList<T>
    {
        internal Cache()
        {
            this.RaiseListChangedEvents = false;
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);

            using (HarvestEntitiesUtility harvest = new HarvestEntitiesUtility(this[e.NewIndex]))
            {
                if (e.ListChangedType == ListChangedType.ItemAdded)
                    harvest.Insert(this[e.NewIndex]);
                else if (e.ListChangedType == ListChangedType.ItemChanged)
                    harvest.Update(this[e.NewIndex]);
            }
        }

        protected override void RemoveItem(int index)
        {
            RaiseListChangedEvents = false;
            using (HarvestEntitiesUtility harvest = new HarvestEntitiesUtility(this[index]))
                harvest.Remove(this[index]);
            base.RemoveItem(index);
            RaiseListChangedEvents = true;
        }
    }
}
