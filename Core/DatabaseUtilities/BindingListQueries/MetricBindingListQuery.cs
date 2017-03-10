using System.Data.Entity;

namespace Core.DatabaseUtilities.BindingListQueries
{
    public class MetricBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList()
        {
            using (HarvestEntities harvestDatabase = new HarvestEntities())
            {
                harvestDatabase.Metric.Load();
                return harvestDatabase.Metric.Local.ToBindingList();
            }
        }
    }
}
