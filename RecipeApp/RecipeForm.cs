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

            static void AddRecipe(Dictionary<string, Recipe> recipes)
            {
                Console.Write("Enter the name of the recipe: ");
                string recipeName = Console.ReadLine();

                Recipe recipe = new Recipe();
                recipe.Name = recipeName;

                Console.Write("Please enter the number of ingredients in your recipe: ");
                int numIngredients = int.Parse(Console.ReadLine());

                for (int i = 1; i <= numIngredients; i++)
                {
                    Console.Write($"Please enter the name of ingredient {i}: ");
                    string name = Console.ReadLine();

                    Console.Write($"Please enter the amount of ingredient {i} you want: ");
                    double amount = double.Parse(Console.ReadLine());

                    Console.Write($"Please enter the unit of measurement for ingredient {i}: ");
                    string unit = Console.ReadLine();

                    recipe.AddIngredient($"Ingredient {i}: {amount} {unit} {name}");
                }

                while (true)
                {
                    Console.Write("Would you like to enter a step? (y/n): ");
                    string choice = Console.ReadLine().ToLower();

                    if (choice == "y")
                    {
                        Console.Write($"Enter step {recipe.recipeData.Count - numIngredients + 1}: ");
                        string stepDescription = Console.ReadLine();

                        recipe.AddStep($"Step {recipe.recipeData.Count - numIngredients + 1}: {stepDescription}");
                    }
                    else if (choice == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }

                Console.Write("Enter the number of calories in the recipe: ");
                int calories = int.Parse(Console.ReadLine());

                recipe.SetCalories(calories);

                recipes.Add(recipeName, recipe);
                Console.WriteLine($"Recipe '{recipeName}' has been added successfully.");
            }

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

            static void ScaleRecipe(Dictionary<string, Recipe> recipes)
            {
                Console.Write("Enter the name of the recipe you want to scale: ");
                string recipeName = Console.ReadLine();

                if (recipes.ContainsKey(recipeName))
                {
                    Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
                    double factor = double.Parse(Console.ReadLine());

                    Recipe recipe = recipes[recipeName];
                    recipe.ScaleRecipe(factor);
                    Console.WriteLine($"Recipe '{recipeName}' has been scaled by a factor of {factor}.");
                }
                else
                {
                    Console.WriteLine($"Recipe '{recipeName}' not found.");
                }
            }

        }

        private void DisplayRecipeButton_Click(object sender, EventArgs e)
        {
            // DisplayRecipe code here

            static void DisplayRecipe(Dictionary<string, Recipe> recipes)
            {
                Console.Write("Enter the name of the recipe you want to display: ");
                string recipeName = Console.ReadLine();

                if (recipes.ContainsKey(recipeName))
                {
                    Recipe recipe = recipes[recipeName];
                    recipe.DisplayRecipe();

                    Console.WriteLine($"Calories: {recipe.Calories}");

                    if (recipe.Calories > 300)
                    {
                        Console.WriteLine("This recipe has more than 300 calories.");
                    }
                }
                else
                {
                    Console.WriteLine($"Recipe '{recipeName}' not found.");
                }
            }

        }

        private void FilterRecipesButton_Click(object sender, EventArgs e)
        {
            // FilterRecipes code here

            static void FilterRecipes(Dictionary<string, Recipe> recipes)
            {
                Console.WriteLine("Filter Options:");
                Console.WriteLine("1. Filter by ingredient");
                Console.WriteLine("2. Filter by food group");
                Console.WriteLine("3. Filter by maximum calories");

                Console.Write("Enter your choice (1-3): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        FilterByIngredient(recipes);
                        break;
                    case 2:
                        FilterByFoodGroup(recipes);
                        break;
                    case 3:
                        FilterByMaxCalories(recipes);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }





        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

     
    // Recipe class
    class Recipe
    {
        public List<string> recipeData = new List<string>();
        private double scalingFactor = 1.0;
        public int Calories { get; private set; }

        public string Name { get; set; }

        public void AddIngredient(string ingredient)
        {
            recipeData.Add(ingredient);
        }

        public void AddStep(string step)
        {
            recipeData.Add(step);
        }

        public void SetCalories(int calories)
        {
            Calories = calories;
        }

        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n***** The Recipe App *****\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"           \"{Name}\"");
            Console.ResetColor();
            Console.WriteLine("____________________________\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("           **Ingredients**");
            Console.ResetColor();

            foreach (var item in recipeData)
            {
                if (item.StartsWith("Ingredient"))
                {
                    Console.WriteLine($"\"{item}\"");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("           **Steps**");
            Console.ResetColor();
            foreach (var item in recipeData)
            {
                if (item.StartsWith("Step"))
                {
                    Console.WriteLine($"\"{item}\"");
                }
            }
        }

        public void ScaleRecipe(double factor)
        {
            scalingFactor = factor;
        }

        public void ResetScalingFactor()
        {
            scalingFactor = 1.0;
        }

        public void ClearRecipe()
        {
            recipeData.Clear();
            scalingFactor = 1.0;
        }
    }
}
