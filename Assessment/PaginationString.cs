using System.Collections.Generic;
using System.Linq;

namespace Assessment
{
    public class PaginationString : IPagination<string>
    {
        private readonly IEnumerable<string> data;
        private readonly int pageSize;
        private int currentPage;

        public PaginationString(string source, int pageSize, IElementsProvider<string> provider)
        {
            data = provider.ProcessData(source);           
            currentPage = 0;
            this.pageSize = pageSize;
        }
        public void FirstPage()
        {
            currentPage = 0;
        }

        public void GoToPage(int page)
        {
            if (page > Pages()) {
                throw new System.InvalidOperationException();
            }
            currentPage = page - 1;
            //throw new System.NotImplementedException();
        }

        public void LastPage()
        {
            currentPage = Pages() - 1;
            //throw new System.NotImplementedException();
        }

        public void NextPage()
        {
            currentPage++;
        }

        public void PrevPage()
        {
            currentPage--;
        }

        public IEnumerable<string> GetVisibleItems()
        {
            return data.Skip(currentPage*pageSize).Take(pageSize);
        }

        public string imprimir(string separador) {
            IEnumerable<string> lista = GetVisibleItems();
            return System.String.Join(separador, lista.ToArray()); 
        }
        public int CurrentPage()
        {
            return currentPage;
        }

        public int Pages()
        {
            //System.Diagnostics.Debug.Write("cantidad depaginas "+ (int)System.Math.Round((data.Count() / pageSize) + 0.5));
            //return System.Math.Ceiling( data.Count() / pageSize);
            return (int) System.Math.Round((data.Count() / pageSize)+0.5 );
            //throw new System.NotImplementedException();
        }
    }
}