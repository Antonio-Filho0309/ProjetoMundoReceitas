namespace ProjetoMundoReceitas.Models
{
    public class Recipe
    {
        public Recipe() { }

        public Recipe(int id, string recipeName, string recipeCust, string recipeDescription, string recipeIngredients, string recipeMaterials, string recipePreparation, int userId)
        {
            Id = id;
            RecipeName = recipeName;
            RecipeCust = recipeCust;
            RecipeDescription = recipeDescription;
            RecipeIngredients = recipeIngredients;
            RecipeMaterials = recipeMaterials;
            RecipePreparation = recipePreparation;
            UserId = userId;
        }

        public int Id { get; set; }
        public string RecipeName { get; set; }

        public string RecipeImage { get; set; }

        public int RecipeAvaliation { get; set; }

        public string RecipeCust { get; set; }

        public string RecipeDescription { get; set; }

        public string RecipeIngredients { get; set; }

        public string RecipeMaterials { get; set; }

        public string RecipePreparation { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


    }
}
