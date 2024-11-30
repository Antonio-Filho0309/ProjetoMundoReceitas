﻿using System;
namespace ProjetoMundoReceitas.Pagination
{
    public class PageBaseResponse<T>
    {
        public List<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }

    }
}
