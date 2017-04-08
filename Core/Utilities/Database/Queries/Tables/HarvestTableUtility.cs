using System;

namespace Core.Utilities.Database.Queries.Tables
{
    internal class HarvestTableUtility : IDisposable
    {
        private Adapters.Database.HarvestDatabaseEntities _HarvestDatabase;
        internal IHarvestQuery HarvestQuery { get; set; }

        internal HarvestTableUtility(IHarvestQuery harvestQuery)
        {
            _HarvestDatabase = new Adapters.Database.HarvestDatabaseEntities();
            HarvestQuery = harvestQuery;
        }

        internal void Insert(object itemToAdd)
        {
            HarvestQuery.Insert(itemToAdd, _HarvestDatabase);
        }

        internal void Update(object itemToChange)
        {
            HarvestQuery.Update(itemToChange, _HarvestDatabase);
        }

        internal void Remove(object itemToRemove)
        {
            HarvestQuery.Remove(itemToRemove, _HarvestDatabase);
        }

        internal object Get(object itemID)
        {
            return HarvestQuery.Get(itemID, _HarvestDatabase);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    HarvestQuery = null;
                    _HarvestDatabase.Dispose();
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion

    }
}
