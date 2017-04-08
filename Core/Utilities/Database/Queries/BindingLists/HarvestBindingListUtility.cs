using System;

namespace Core.Utilities.Database.Queries.BindingLists
{
    internal class HarvestBindingListUtility : IDisposable
    {
        private Adapters.Database.HarvestDatabaseEntities _HarvestDatabase;
        internal IHarvestBindingList HarvestBindingList { get; set; }

        internal HarvestBindingListUtility(IHarvestBindingList harvestBindingList)
        {
            _HarvestDatabase = new Adapters.Database.HarvestDatabaseEntities();
            HarvestBindingList = harvestBindingList;
        }

        internal object GetBindingList()
        {
            return HarvestBindingList.GetBindingList(_HarvestDatabase);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~HarvestBindingListUtility() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
