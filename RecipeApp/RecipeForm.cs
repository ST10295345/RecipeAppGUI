using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RecipeApp
{
    public partial class RecipeForm : Form
    {
        private Dictionary<string, Recipe> recipes = new Dictionary<string, Recipe>();

        public RecipeForm()
        {
            InitializeComponent();
        }

        private void AddRecipeButton_Click(object sender, EventArgs e)
        {
            // AddRecipe code here



        }

        private void DeleteRecipeButton_Click(object sender, EventArgs e)
        {
            // DeleteRecipe code here

            static void DeleteRecipe(Dictionary<string, Recipe> recipes)
            {
                Console.Write("Enter the name of the recipe you want to delete: ");
                string recipeName = Console.ReadLine();

                if (recipes.ContainsKey(recipeName))
                {
                    recipes.Remove(recipeName);
                    Console.WriteLine($"Recipe '{recipeName}' has been deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Recipe '{recipeName}' not found.");
                }
            }

        }

        private void ScaleRecipeButton_Click(object sender, EventArgs e)
        {
            // ScaleRecipe code here
        }

        private void DisplayRecipeButton_Click(object sender, EventArgs e)
        {
            // DisplayRecipe code here
        }

        private void FilterRecipesButton_Click(object sender, EventArgs e)
        {
            // FilterRecipes code here
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    // Recipe class (unchanged)
    class Recipe
    {
        // Recipe class code here
    }
}
