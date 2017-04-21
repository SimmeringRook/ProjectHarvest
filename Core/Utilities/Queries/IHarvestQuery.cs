using Core.Adapters.Database;

namespace Core.Utilities.Queries
{
    internal interface IHarvestQuery
    {
        void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase);

        void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase);

        void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase);

        object Get(object itemID, HarvestDatabaseEntities HarvestDatabase);
    }
}
