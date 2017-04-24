using Core.Adapters.Database;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Core.Adapters.Factories;
using Core.Cache;

namespace Core.Utilities.Queries
{
    internal class RecipeQuery : IHarvestQuery
    {
        public RecipeCache<Adapters.Objects.Recipe> Cache;

        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Recipe.Load();

            if ((int)itemID == -1)
            {
                RecipeCache<Adapters.Objects.Recipe> allRecipes = new RecipeCache<Adapters.Objects.Recipe>();
                foreach (Recipe databaseRecipe in HarvestDatabase.Recipe.ToList())
                    allRecipes.Add(RecipeFactory.Create_Client_From_Database(databaseRecipe));
                allRecipes.RaiseListChangedEvents = true;
                return allRecipes;
            }
            else
            {
                Recipe dbRecipe = HarvestDatabase.Recipe.SingleOrDefault(inventory => inventory.RecipeID.Equals((int)itemID));
                return dbRecipe;
            }
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            Recipe recipe = RecipeFactory.Create_Database_From_Client(itemToRemove as Adapters.Objects.Recipe);

            HarvestDatabase.RecipeIngredient.Load();
            List<RecipeIngredient> allRecipeIngredientsThatUseItem = HarvestDatabase.RecipeIngredient.Where(ri => ri.RecipeID == recipe.RecipeID).ToList();

            foreach (RecipeIngredient recipeIngredient in allRecipeIngredientsThatUseItem)
                HarvestDatabase.RecipeIngredient.Remove(recipeIngredient);
            allRecipeIngredientsThatUseItem = null;

            HarvestDatabase.Recipe.Load();
            Recipe recipeToDelete = HarvestDatabase.Recipe.Single(r => r.RecipeID == recipe.RecipeID);
            HarvestDatabase.Recipe.Remove(recipeToDelete);

            HarvestDatabase.SaveChanges();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Recipe.Load();

            Adapters.Objects.Recipe clientRecipe = itemToChange as Adapters.Objects.Recipe;
            Recipe databaseRecipe = RecipeFactory.Create_Database_From_Client(clientRecipe);

            HarvestDatabase.Recipe.AddOrUpdate(databaseRecipe);
            HarvestDatabase.SaveChanges();
        }

        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            Cache.RaiseListChangedEvents = false;
            HarvestDatabase.Recipe.Load();

            Adapters.Objects.Recipe clientRecipe = itemToAdd as Adapters.Objects.Recipe;
            

            Recipe databaseRecipe = RecipeFactory.Create_Database_From_Client(clientRecipe);
            HarvestDatabase.Recipe.AddOrUpdate(databaseRecipe);
            HarvestDatabase.SaveChanges();

            clientRecipe.ID = _GetNextID(HarvestDatabase);

            //var justCreated = HarvestDatabase.Recipe.OrderByDescending(r => r.RecipeID).First();
            
            Cache.RaiseListChangedEvents = true;
        }

        private int _GetNextID(HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Recipe.Load();
            //if (HarvestDatabase.Recipe.Count() == 0)
            //    return 1;
            var lastRecipe = HarvestDatabase.Recipe.OrderByDescending(r => r.RecipeID).First();
                return lastRecipe.RecipeID;
        }
    }
}