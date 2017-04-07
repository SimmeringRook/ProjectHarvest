using Core;
using Core.Utilities.Database.Queries.Tables;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client_Desktop.Extensions
{
    public class PlannedRecipeControl : FlowLayoutPanel
    {
        //public FlowLayoutPanel Container;
        public RecipeButton RecipeButton;
        private Button deleteButton;
        private Button ateButton;
        private HarvestForm mainForm;
        private DateTime dayplanned;
        private MealTime mealTime;        

        public PlannedRecipeControl(HarvestForm mainForm, Recipe selectedRecipe, DateTime dayplanned, MealTime mealTime)
        {
            this.mainForm = mainForm;
            this.dayplanned = dayplanned;
            this.mealTime = mealTime;

            //Container = new FlowLayoutPanel();
            this.Margin = new Padding(5, 2, 0, 2);
            this.AutoSize = true;
            this.BorderStyle = BorderStyle.FixedSingle;
            

            RecipeButton = new RecipeButton(selectedRecipe);
            this.Controls.Add(RecipeButton);

            deleteButton = newDeleteButton();
            this.Controls.Add(deleteButton);

            ateButton = newAteButton();
            this.Controls.Add(ateButton);

        }

        #region Delete Button
        private Button newDeleteButton()
        {
            Button delete = new Button();
            delete.Text = "X";
            delete.Size = new System.Drawing.Size(20, RecipeButton.Height);
            delete.Click += new EventHandler(deleteButton_Click);
            return delete;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Control parentOfParent = this.Parent;

            //Remove recipe from plan
            mainForm.RemoveRecipeFromThisWeek(this);

            RecipeButton = null;

            deleteButton = null;
            this.Controls.Clear();
            parentOfParent.Controls.Remove(this);

            using (HarvestTableUtility harvest = new HarvestTableUtility(new PlannedMealQuery()))
            {
                var recipesForDay = harvest.Get(dayplanned) as List<PlannedMeals>;

                foreach (var meal in recipesForDay)
                {
                    if (meal.MealTime.MealName.Equals(mealTime.MealName))
                    {
                        meal.MealEaten = true;
                        harvest.Remove(meal);
                    }
                }
            }
        }
        #endregion

        private Button newAteButton()
        {
            Button ate = new Button();
            ate.Text = "A";
            ate.Size = new System.Drawing.Size(20, RecipeButton.Height);
            ate.Click += new EventHandler(ateButton_Click);
            return ate;
        }




        private void ateButton_Click(object sender, EventArgs e)
        {
            string messageTitle = "";
            List<Inventory> pantry = new List<Inventory>();

            using (HarvestTableUtility harvest = new HarvestTableUtility(new InventoryQuery()))
            {
                var allInventories = harvest.Get(-1) as List<Inventory>;
                foreach (var ri in RecipeButton.Recipe.GetIngredients())
                {
                    foreach (var item in allInventories)
                    {
                        if (item.InventoryID == ri.InventoryID)
                        {
                            //Need to convert to same measurements before this subrtaction
                            item.Amount -= ri.Amount;
                            pantry.Add(item);
                        }
                    }
                }

                foreach (var item in pantry)
                {
                    harvest.Update(item);
                }

                harvest.HarvestQuery = new PlannedMealQuery();
                var recipesForDay = harvest.Get(dayplanned) as List<PlannedMeals>;

                foreach(var meal in recipesForDay)
                {
                    if (meal.MealTime.MealName.Equals(mealTime.MealName) && meal.RecipeID == RecipeButton.Recipe.RecipeID)
                    {
                        meal.MealEaten = true;
                        harvest.Update(meal);

                        if (MessageBox.Show("Remove from plan?", messageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            deleteButton_Click(sender, e);                            
                        }
                        else
                        {
                            RecipeButton.Enabled = false;
                            ateButton.Visible = false;
                        }

                        break;
                    }
                }                
            }            
        }

        internal void SetControlsForHasBeenEaten()
        {
            RecipeButton.Enabled = false;
            ateButton.Visible = false;
        }
    }
}
