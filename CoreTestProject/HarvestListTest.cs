using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Adapters.Objects;
using Core.Cache;

namespace CoreTestProject
{
    [TestClass]
    public class HarvestListTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expected = 1;
            Cache<Inventory> inventoryTestCache = new Cache<Inventory>();

            inventoryTestCache.RaiseListChangedEvents = true;

            inventoryTestCache.Add(new Inventory());

            inventoryTestCache[0].ID = -5;

            

            inventoryTestCache.Insert(0, new Inventory());

            inventoryTestCache[1].ID = -3;

            

            var temp = inventoryTestCache[1];
            inventoryTestCache[1] = inventoryTestCache[0];
            inventoryTestCache[0] = temp;

            
        }
    }
}
