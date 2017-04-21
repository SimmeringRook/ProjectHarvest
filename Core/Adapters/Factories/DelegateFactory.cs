using Core.Utilities.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Adapters.Factories
{
    internal class DelegateFactory
    {

        internal ObservableCollection<Objects.PlannedMeal> GetPlannedMealCache()
        {
            ObservableCollection<Objects.PlannedMeal> cache = new ObservableCollection<Objects.PlannedMeal>();

            cache.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(
                delegate (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action.Equals(System.Collections.Specialized.NotifyCollectionChangedAction.Add))
                    {
                        if (e.NewItems != null)
                        {
                            foreach (Objects.PlannedMeal newItem in e.NewItems)
                            {
                                
                                using (HarvestEntitiesUtility plannedTable = new HarvestEntitiesUtility(new PlannedMealQuery()))
                                    plannedTable.Update(PlannedMealFactory.Create_Database_From_Client(newItem));
                                if (cache.Contains(newItem) == false)
                                {
                                    cache.Add(newItem);
                                    //newItem.PropertyChanged += this
                                }
                                    
                            }
                        }
                    }
                    else if (e.Action.Equals(System.Collections.Specialized.NotifyCollectionChangedAction.Remove))
                    {
                        if (e.OldItems != null)
                        {
                            foreach (Objects.PlannedMeal oldItem in e.OldItems)
                            {
                                using (HarvestEntitiesUtility plannedTable = new HarvestEntitiesUtility(new PlannedMealQuery()))
                                    plannedTable.Remove(PlannedMealFactory.Create_Database_From_Client(oldItem));
                                cache.Remove(oldItem);
                            }
                        }
                    }
                });

            return cache;
        }


        
    }
}
