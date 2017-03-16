namespace Core.DatabaseUtilities
{
    public interface IHarvestQuery
    {
        void Insert(object itemToAdd);

        void Update(object itemToChange);

        void Remove(object itemToRemove);

        object Get(object itemID);
    }
}
