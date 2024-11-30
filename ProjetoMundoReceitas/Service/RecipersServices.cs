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
            if (createRecipeDto.Image != null && createRecipeDto.Image.Length > 0)
            {

                using (var memoryStream = new MemoryStream())
                {
                    createRecipeDto.Image.CopyTo(memoryStream);
                    var imageBytes = memoryStream.ToArray();

                    createRecipeDto.Image = null;
                    var recipe = _mapper.Map<Recipe>(createRecipeDto);
                    recipe.Image = imageBytes;

                    _repo.Add(recipe);

                    return ResultService.Ok(createRecipeDto);
                }
            }
            else
            {
                // Caso não tenha imagem
                var recipe = _mapper.Map<Recipe>(createRecipeDto);
                _repo.Add(recipe);

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

