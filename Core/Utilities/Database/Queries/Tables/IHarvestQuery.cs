namespace Core.Utilities.Database.Queries.Tables
{
    public interface IHarvestQuery
    {
        void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase);

        void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabas);

        void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabas);

        object Get(object itemID, HarvestDatabaseEntities HarvestDatabas);
    }
}
