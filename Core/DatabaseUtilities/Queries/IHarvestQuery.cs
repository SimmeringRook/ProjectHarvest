using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DatabaseUtilities
{
    public interface IHarvestQuery
    {
        void Insert(object itemToAdd);

        void Update(object itemToChange);

        void Remove(object itemToRemove);

        object Get(int itemID);
    }
}
