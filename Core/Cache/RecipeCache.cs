using Core.Utilities.Queries;
using System.ComponentModel;

namespace Core.Cache
{
    public class RecipeCache<Recipe> : BindingList<Adapters.Objects.Recipe>
    {
        internal RecipeCache()
        {
            this.RaiseListChangedEvents = false;
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);

            RecipeQuery recipeQuery = new RecipeQuery();
            recipeQuery.Cache = this as RecipeCache<Adapters.Objects.Recipe>;
            using (HarvestEntitiesUtility harvest = new HarvestEntitiesUtility(recipeQuery))
            {
                if (e.ListChangedType == ListChangedType.ItemAdded)
                    harvest.Insert(this[e.NewIndex]);
                else if (e.ListChangedType == ListChangedType.ItemChanged)
                    harvest.Update(this[e.NewIndex]);
            }
            recipeQuery = null;
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
