using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace part_2_example
{



    class MyClass1
    {

        public string name;
        public int numIngredients;
        public double quantity;
        public string unit;
        public string recipeName;
        public double totalCalories = 0;
        public int steps;
        public string foodGroup;
        public double calories;
        public string description;

        Dictionary<string, List<Ingredient>> recipes = new Dictionary<string, List<Ingredient>>();

        // Create a new list to store the ingredients for the current recipe
        List<Ingredient> ingredients = new List<Ingredient>();

        public void Recipe()
        {
            // layout
            Console.WriteLine("***********************************");
            Console.WriteLine("INGREDIENTS AND STEPS FOR A RECIPE!");
            Console.WriteLine("***********************************");



            Dictionary<string, List<Ingredient>> recipes = new Dictionary<string, List<Ingredient>>();

            // Prompt the user to enter recipe names and ingredients
            Console.WriteLine("Enter recipe names and ingredients (press enter to exit): ");

            // Loop until the user presses enter
            while (true)
            {
                Console.Write("Enter recipe name: ");
                recipeName = Console.ReadLine();

                // If the user presses enter, exit the loop
                if (string.IsNullOrEmpty(recipeName))
                {
                    break;
                }

                // Create a new list to store the ingredients for the current recipe
                List<Ingredient> ingredients = new List<Ingredient>();

                Console.WriteLine("Enter the number of ingredients: ");
                numIngredients = int.Parse(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine("Enter the ingredient name: ");
                    name = Console.ReadLine();

                    Console.WriteLine("Enter the quantity: ");
                    quantity = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the unit of measurement: ");
                    unit = Console.ReadLine();

                    Console.WriteLine("Enter the number of steps: ");
                    steps = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the description on how to do it: ");
                    description = Console.ReadLine();

                    Console.WriteLine("Enter the number of Calories: ");
                    calories = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the name of the food group: ");
                    foodGroup = Console.ReadLine();




                    // Create a new Ingredient object with the entered information
                    Ingredient ingredient = new Ingredient(name, quantity, unit, steps, description, calories, foodGroup);

                    // Add the ingredient to the list
                    ingredients.Add(ingredient);
                }

                // Add the recipe and its ingredients to the dictionary
                recipes.Add(recipeName, ingredients);
            }


            // Print out the entered recipes and their ingredients
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("You entered the following recipes:");
            Console.WriteLine("----------------------------------");
            foreach (var recipe in recipes)
            {

                Console.WriteLine("Recipe: " + recipe.Key);
                Console.WriteLine();
                Console.WriteLine("Ingredients:");
                Console.WriteLine("------------");
                foreach (var ingredient in recipe.Value)
                {
                    Console.WriteLine("- " + ingredient.Name + ": " + ingredient.Quantity + " " + ingredient.Unit + " Steps:"  + ingredient.Steps + " " + ingredient.Description +" "+ ingredient.Calories);
                    totalCalories += ingredient.Calories;
                }
                Console.WriteLine();
                Console.WriteLine("Total Calories: " + totalCalories);

                if (totalCalories > 300)
                {
                    Console.WriteLine("WARNING: Total calories exceed 300!");
                }
            }
        }

        public void Scale()
        {
            Ingredient ingredient = new Ingredient(name, quantity, unit, steps, description, calories, foodGroup);

            recipes.Add(recipeName, ingredients);


            

    }

        public void Reset()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Reset quantity to original value");
            Console.WriteLine("2.Clear data");
            int opt = Convert.ToInt32(Console.ReadLine());


            for (int s = 0; s<numIngredients; s++)
            {
                // resets the ingredients to initial values
                if (opt == 1)
                {
                    foreach (var recipe in recipes)
                    {
                        Console.WriteLine("Recipe: " + recipe.Key);
                        Console.WriteLine("Ingredients:");
                        foreach (var ingredient in recipe.Value)
                        {
                            Console.WriteLine("- " + ingredient.Name + ": " + ingredient.Quantity + " " + ingredient.Unit + " Steps:"  + ingredient.Steps + " " + ingredient.Description +" "+ ingredient.Calories);

                        }
                        Console.WriteLine("2.Clear data");
                        opt = Convert.ToInt32(Console.ReadLine());

                    }
                }
                else
                {
                    recipes.Clear();
                    Console.WriteLine("You have cleared all recipes. Please enter new recipe!");
                    Recipe();

                }

            }
        }

    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Steps { get; set; }
        public string Description { get; set; }

        public double Calories { get; set; }

        public string FoodGroup { get; set; }

        public Ingredient(string name, double quantity, string unit, int steps, string description, double calories, string foodgroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Steps = steps;
            Description = description;
            Calories = calories;
            FoodGroup =foodgroup;

        }










        internal class Program
        {
            static void Main(string[] args)
            {

                MyClass1 obj = new MyClass1();
                obj.Recipe();
                obj.Scale();
                    obj.Reset();


            }
        }
    }

}
    }