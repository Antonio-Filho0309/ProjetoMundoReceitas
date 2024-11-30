namespace ProjetoMundoReceitas.Dto
{
    public class PageBaseResponseDto<T>
    {
        public PageBaseResponseDto(int totalRegister, List<T> data)
        {
            TotalRegister = totalRegister;
            Data = data;
        }

        public int TotalRegister {  get; private set; }
        public List<T> Data { get; private set; }

    }
}
