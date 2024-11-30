namespace ProjetoMundoReceitas.Models
{
    public class Recipe
    {
        public Recipe() { }

        public Recipe(int id, string recipeName, byte[] image, string recipeCust, string recipeDescription, List<string> recipeIngredients, List<string> recipeMaterials, List<string> recipePreparation, int userId)
        {
            Id = id;
            RecipeName = recipeName;
            RecipeCust = recipeCust;
            Image = image;
            RecipeDescription = recipeDescription;
            RecipeIngredients = recipeIngredients;
            RecipeMaterials = recipeMaterials;
            RecipePreparation = recipePreparation;
            UserId = userId;
        }

        public int Id { get; set; }
        public string RecipeName { get; set; }

        public byte[]? Image { get; set; } = null;

        public int RecipeAvaliation { get; set; }

        public string RecipeCust { get; set; }

        public string RecipeDescription { get; set; }

        public List<string> RecipeIngredients { get; set; }

        public List<string> RecipeMaterials { get; set; }

        public List<string> RecipePreparation { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
