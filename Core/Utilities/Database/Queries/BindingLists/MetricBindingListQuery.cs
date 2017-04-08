using System.Data.Entity;

namespace Core.Utilities.Database.Queries.BindingLists
{
    internal class MetricBindingListQuery : IHarvestBindingList
    {
        public object GetBindingList(Adapters.Database.HarvestDatabaseEntities _HarvestDatabase)
        {
            _HarvestDatabase.Metric.Load();
            return _HarvestDatabase.Metric.Local.ToBindingList();
        }
    }
}
