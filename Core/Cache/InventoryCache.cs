using Core.Utilities.Queries;
using System.ComponentModel;

namespace Core.Cache
{
    public class InventoryCache<Inventory> : BindingList<Adapters.Objects.Inventory>
    {
        internal InventoryCache()
        {
            this.RaiseListChangedEvents = false;
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            this.RaiseListChangedEvents = false;
            base.OnListChanged(e);
            InventoryQuery inventoryQuery = new InventoryQuery();
            using (HarvestEntitiesUtility harvest = new HarvestEntitiesUtility(inventoryQuery))
            {
                if (e.ListChangedType == ListChangedType.ItemAdded)
                    harvest.Insert(this[e.NewIndex]);
                else if (e.ListChangedType == ListChangedType.ItemChanged)
                    harvest.Update(this[e.NewIndex]);
            }
            inventoryQuery = null;
            this.RaiseListChangedEvents = true;
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

