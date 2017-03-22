namespace Core.Utilities.Database.Queries.Tables
{
    public interface IHarvestQuery
    {
        void Insert(object itemToAdd, HarvestEntities HarvestDatabase);

        void Update(object itemToChange, HarvestEntities HarvestDatabas);

        void Remove(object itemToRemove, HarvestEntities HarvestDatabas);

        object Get(object itemID, HarvestEntities HarvestDatabas);
    }
}
