using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    public class MetricBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList(HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.Metric.Load();
            return _HarvestDatabase.Metric.Local.ToBindingList();
        }
    }
}
