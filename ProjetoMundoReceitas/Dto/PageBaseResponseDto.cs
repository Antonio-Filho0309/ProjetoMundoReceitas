namespace ProjetoLivrariaAPI.Models.Dtos
{
    public class PagedBaseResponseDto<T>
    {
        public PagedBaseResponseDto(int totalRegisters, List<T> data)
        {
            TotalRegisters = totalRegisters;
            Data = data;

        }

        public int TotalRegisters { get; private set; }
        public List<T> Data { get; private set; }

    }
}