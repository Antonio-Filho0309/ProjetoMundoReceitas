using AutoMapper;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoMundoReceitas.Dto.Recipe;
using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Models.FilterDb;
using ProjetoMundoReceitas.Repositories;
using ProjetoMundoReceitas.Repositories.Interface;
using ProjetoMundoReceitas.Service.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoMundoReceitas.Service
{
    public class RecipersServices : IRecipeService
    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _repo;
        private readonly IUserRepository _userRepo;

        public RecipersServices(IMapper mapper, IRecipeRepository repo, IUserRepository userRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _userRepo = userRepo;
        }
        public async Task<ResultService<CreateRecipeDto>> CreateAsync(CreateRecipeDto createRecipeDto)
        {
            if (!string.IsNullOrEmpty(createRecipeDto.Image))
            {
                // Verifica se a imagem é uma string base64 e converte para byte[]
                byte[] imageBytes;

                // Verifica se a string é uma base64 (comum em imagens codificadas)
                if (createRecipeDto.Image.StartsWith("data:image"))
                {
                    // Remove o prefixo "data:image/jpeg;base64," ou similar
                    var base64Data = createRecipeDto.Image.Substring(createRecipeDto.Image.IndexOf(',') + 1);
                    imageBytes = Convert.FromBase64String(base64Data);
                }
                else
                {
                    // Caso contrário, trata como se a imagem fosse base64 simples
                    imageBytes = Convert.FromBase64String(createRecipeDto.Image);
                }

                // Remove a imagem do DTO para evitar problemas com a serialização
                createRecipeDto.Image = null;

                // Mapeia o DTO para a entidade Recipe
                var recipe = _mapper.Map<Recipe>(createRecipeDto);
                recipe.Image = imageBytes; // Atribui os bytes da imagem à propriedade Image da entidade

                // Adiciona a receita no repositório
                await _repo.Add(recipe);

                return ResultService.Ok(createRecipeDto);
            }
            else
            {
                // Caso não tenha imagem
                var recipe = _mapper.Map<Recipe>(createRecipeDto);
                await _repo.Add(recipe);

                return ResultService.Ok(createRecipeDto);
            }
        }


        public async Task<ResultService> Delete(int id)
        {
            var recipe = await _repo.GeRecipersById(id);
            if (recipe == null)
                return ResultService.Fail("Receita não encontrada");
            var bookAssociation = await _userRepo.GetUserById(id);

            await _repo.Delete(recipe);
            return ResultService.Ok("Receita deletada com Sucesso");
        }

        public async Task<ResultService<ICollection<Recipe>>> GetAllAsync()
        {
            var recipe = await _repo.GetAllRecipers();
            return ResultService.Ok(_mapper.Map<ICollection<Recipe>>(recipe));
        }

        public async Task<ResultService<PagedBaseResponseDto<Recipe>>> GetPagedAsync(FilterDb filterDb)
        {
            var recipePaged = await _repo.GetPagedAsync(filterDb);
            var result = new PagedBaseResponseDto<Recipe>(recipePaged.TotalRegisters, _mapper.Map<List<Recipe>>(recipePaged.Data));
            return ResultService.Ok(result);
        }

        public async Task<ResultService> UpdateAsync(UpdateRecipeDto updateRecipeDto)
        {
            // Verificar se a receita existe no banco de dados
            var existingRecipe = await _repo.GeRecipersById(updateRecipeDto.Id);
            if (existingRecipe == null)
            {
                return ResultService.Fail("Receita não encontrada.");
            }

            // Atualizar os campos da receita existente com os valores do DTO
            existingRecipe.RecipeName = updateRecipeDto.RecipeName;
            existingRecipe.RecipeAvaliation = updateRecipeDto.RecipeAvaliation;
            existingRecipe.RecipeCust = updateRecipeDto.RecipeCust;
            existingRecipe.RecipeDescription = updateRecipeDto.RecipeDescription;
            existingRecipe.RecipeIngredients = updateRecipeDto.RecipeIngredients;
            existingRecipe.RecipeMaterials = updateRecipeDto.RecipeMaterials;
            existingRecipe.RecipePreparation = updateRecipeDto.RecipePreparation;
            existingRecipe.UserId = updateRecipeDto.UserId;

            // Se houver uma imagem nova, trate ela
            if (updateRecipeDto.Image != null && updateRecipeDto.Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await updateRecipeDto.Image.CopyToAsync(memoryStream);
                    existingRecipe.Image = memoryStream.ToArray();
                }
            }

            // Atualiza a receita no repositório
            _repo.Update(existingRecipe);

            // Retorna um resultado de sucesso
            return ResultService.Ok("Receita atualizada com sucesso.");
        }
    }
    }

