namespace ProjetoMundoReceitas.Dto.Recipe
{
    public class CreateRecipeDto
    {
        public string RecipeName { get; set; }
        public int RecipeAvaliation { get; set; }

        public string RecipeCust { get; set; }

        public string RecipeDescription { get; set; }

        public List<string> RecipeIngredients { get; set; }

        public List<string> RecipeMaterials { get; set; }

        public List<string> RecipePreparation { get; set; }

        public int UserId { get; set; }

        public IFormFile? Image { get; set; }

    }
}
