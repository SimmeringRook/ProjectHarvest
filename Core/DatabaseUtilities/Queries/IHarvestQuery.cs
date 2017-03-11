namespace Core.DatabaseUtilities.Queries
{
    public interface IHarvestQuery
    {
        void Insert(object itemToAdd);

        void Update(object itemToChange);

        void Remove(object itemToRemove);

        object Get(int itemID);
    }
}
