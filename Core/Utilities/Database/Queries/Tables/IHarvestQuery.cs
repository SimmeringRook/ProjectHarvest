using Core.Adapters.Database;

namespace Core.Utilities.Database.Queries.Tables
{
    internal interface IHarvestQuery
    {
        void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase);

        void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabas);

        void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabas);

        object Get(object itemID, HarvestDatabaseEntities HarvestDatabas);
    }
}
