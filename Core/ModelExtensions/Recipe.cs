using Core.DatabaseUtilities.Queries;
using System.Collections.Generic;

namespace Core
{
    public partial class Recipe
    {
        public List<Inventory> AssociatedInventoryItems = new List<Inventory>();
        public List<RecipeIngredient> AssociatedIngredients = new List<RecipeIngredient>();
        public string RecipeCategory { get; set; }

        public void PopulateGUIProperties()
        {
            using (HarvestUtility harvest = new HarvestUtility(new RecipeCategoryQuery()))
            {
                this.RecipeCategory = (harvest.Get(this.RecipeID) as RecipeClass).RCategory;

                harvest.HarvestQuery = new RecipeIngredientQuery();
                this.AssociatedIngredients = (harvest.Get(this.RecipeID) as List<RecipeIngredient>);

                harvest.HarvestQuery = new InventoryQuery();
                foreach (RecipeIngredient ingredient in this.AssociatedIngredients)
                {
                    Inventory item = (harvest.Get(ingredient.InventoryID) as Inventory);
                    ingredient.Inventory = item;
                    this.AssociatedInventoryItems.Add(item);
                }
            }
        }
    }
}
