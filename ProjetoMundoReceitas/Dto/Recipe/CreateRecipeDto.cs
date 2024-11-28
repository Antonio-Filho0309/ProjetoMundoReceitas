namespace ProjetoMundoReceitas.Dto.Recipe
{
    public class CreateRecipeDto
    {
        public string RecipeName { get; set; }
        public int RecipeAvaliation { get; set; }

        public string RecipeCust { get; set; }

        public string RecipeDescription { get; set; }

        public string RecipeIngredients { get; set; }

        public string RecipeMaterials { get; set; }

        public string RecipePreparation { get; set; }

        public int UserId { get; set; }

    }
}
