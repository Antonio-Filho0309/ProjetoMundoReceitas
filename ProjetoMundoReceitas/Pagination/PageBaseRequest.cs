namespace ProjetoMundoReceitas.Pagination
{
    public class PageBaseRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderByProperty { get; set; }
        public PageBaseRequest()
        {
            Page = 1;
            PageSize = 5;
            OrderByProperty = "Id";
        }
    }
}
