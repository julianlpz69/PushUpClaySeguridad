using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Helpers
{
    public class Pager<T> where T : class
    {
        private List<CategoriaPersonaDto> listaCategoriaPersona;
        private int totalRegistros;


        public string Search { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int Total { get; private set; }
        public List<T> Registers { get; private set; }
        public Pager()
        {

        }

        public Pager(List<T> registers, int total, int pageIndex,int pageSize,string _search)
        {
            Registers = registers;
            Total = total;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Search = _search;
        }

        public Pager(List<CategoriaPersonaDto> listaCategoriaPersona, int totalRegistros, int pageIndex, int pageSize)
        {
            this.listaCategoriaPersona = listaCategoriaPersona;
            this.totalRegistros = totalRegistros;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }


        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(Total / (double)PageSize);
            }
        }
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}