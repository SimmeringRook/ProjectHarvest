using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client_Desktop.Helpers;
using Core;

namespace Client_Desktop
{
    public partial class GroceryList : Form
    {
        private List<PlannedMealDay> plannedMealsForTheWeek;
        private List<RecipeIngredient> _ingredients = new List<RecipeIngredient>();
        private int numberOfRows;

        

        public GroceryList(List<PlannedMealDay> plannedMealsForTheWeek)
        {
            this.plannedMealsForTheWeek = plannedMealsForTheWeek;
            InitializeComponent();
            getIngredients();
            
        }

        public void getIngredients()
        {
            numberOfRows = groceryTableLayout.RowCount - 1;
            foreach (var plan in plannedMealsForTheWeek)
            {
                foreach (KeyValuePair<MealTime, List<Recipe>> keyValuePair in plan.MealsPlanned)
                    foreach (Recipe recipe in keyValuePair.Value)
                    {
                        buildRow();
                    }                
            }
        }

        public void buildRow()
        {
            
            IngredientInformation rowToBeAdded = new IngredientInformation();
            groceryTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));


            groceryTableLayout.Controls.Add(rowToBeAdded.NameLabel, 0, numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Type, 1, numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Quantity, 2, numberOfRows);
            groceryTableLayout.Controls.Add(rowToBeAdded.Selected, 3, numberOfRows);

            numberOfRows++;
        }
    }
}
