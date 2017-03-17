using System;

namespace Core.DatabaseUtilities.BindingListQueries
{
    public class HarvestBindingListUtility : IDisposable
    {
        public IHarvestBindingList HarvestBindingList { get; set; }
        
        public HarvestBindingListUtility(IHarvestBindingList harvestBindingList)
        {
            HarvestBindingList = harvestBindingList;
        }

        public object GetBindingList()
        {
            return HarvestBindingList.GetBindingList();
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
