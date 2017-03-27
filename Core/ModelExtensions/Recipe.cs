using Core.Utilities.Database.Queries.Tables;
using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Recipe : ICloneable
    {
        public List<Inventory> AssociatedInventoryItems = new List<Inventory>();
        private List<RecipeIngredient> _AssociatedIngredients = new List<RecipeIngredient>();
        public string RecipeCategory { get; set; }

        public Recipe(int id)
        {
            this.RecipeID = id;
            
        }

        public object Clone()
        {
            Recipe copy = (Recipe) this.MemberwiseClone();
            //Database Properties
            copy.RecipeID = this.RecipeID;
            copy.RecipeName = string.Copy(this.RecipeName);
            copy.Servings = this.Servings;
            copy.RCategory = string.Copy(this.RCategory);

            return copy;
        }

        public List<RecipeIngredient> GetIngredients()
        {
            if (_AssociatedIngredients.Count < 1)
            {
                var results = new List<RecipeIngredient>();
                using(HarvestTableUtility harvest = new HarvestTableUtility(new RecipeIngredientQuery()))
                {
                    results = harvest.Get(this.RecipeID) as List<RecipeIngredient>;
                    results.ForEach(item => { _AssociatedIngredients.Add((RecipeIngredient)item.Clone()); });
                }
            }
            return _AssociatedIngredients;
        }
        
        public List<Inventory> GetInventoryItems()
        {
            if (AssociatedInventoryItems.Count < 1)
            {
                var ingredients = GetIngredients();
                using (HarvestTableUtility harvest = new HarvestTableUtility(new InventoryQuery()))
                {
                    foreach (var ingredient in ingredients)
                    {
                        var item = harvest.Get(ingredient.InventoryID) as Inventory;
                        AssociatedInventoryItems.Add((Inventory)item.Clone());
                    }
                }
            }
            return AssociatedInventoryItems;
        }

        public override int GetHashCode()
        {
            return Utilities.General.HashGenerator.Hash(this.RecipeID, this.RecipeName, this.Servings);
        }
    }
}
