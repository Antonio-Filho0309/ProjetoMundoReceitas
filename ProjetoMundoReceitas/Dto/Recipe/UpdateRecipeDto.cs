namespace ProjetoMundoReceitas.Dto.Recipe
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string? Image { get; set; }
        public int RecipeAvaliation { get; set; }

        public string RecipeCust { get; set; }

        public string RecipeDescription { get; set; }

        public string RecipeIngredients { get; set; }

        public string RecipeMaterials { get; set; }

        public string RecipePreparation { get; set; }

        public int UserId { get; set; }

    }
}
