using System;
using System.Linq;
using Assessment;

namespace AssessmentConsole
{
    public class App
    {
        string separador;
            
        public bool ProcessOption(string option) 
        {
            if (option == "1")
            {
                StartPagination();
                return false;
            }
            return true;
        }

        private void StartPagination()
        {
            string option = GetOption(
                @"Pagination commands\n
                1. Source data
                0. Back
                ");
             if (option == "1")
            {
                ProcessPagination();
            }
        }

        private void ProcessPagination()
        {
            string option = GetOption(
                @"Type: \n
                1. Comma separated data(,)
                2. Pipe separated data(|)
                3. Space separated data( )
                0. Go Back
                ");
            if (option == "1" || option == "2" || option == "3")
            {
                if (option == "1") { separador = ",";  }
                else if (option == "2") { separador = "|";  }
                else { separador = " "; }

                string data = GetOption("Source data");
                NavigateData(data, option);
            } 
        }

        private void NavigateData(string data, string option)
        {
            string pageSize = GetOption("Type the Page size");
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(data, int.Parse(pageSize), provider);
            DoNavigation(pagination);
        }

        private void DoNavigation(IPagination<string> pagination)
        {
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("Current Page:" + pagination);
                 string option = GetOption(
                @"Type: \n
                1. First page
                2. Next page
                3. Previous page
                4. Last page
                5. Go to page
                0. Go Back
                ");
                if (option == "1")
                {
                    pagination.FirstPage();
                    Console.WriteLine(pagination.imprimir(separador));
                } else if (option == "2") 
                {
                    pagination.NextPage();
                    Console.WriteLine(pagination.imprimir(separador));
                }
                else if (option == "3")
                {
                    pagination.PrevPage();
                    Console.WriteLine(pagination.imprimir(separador));
                }
                else if (option == "4")
                {
                    pagination.LastPage();
                    Console.WriteLine(pagination.imprimir(separador));
                }
                else if (option == "5")
                {
                    int op = int.Parse( GetOption("Introduzca numero de pagina :"));
                    pagination.GoToPage(op);
                    Console.WriteLine(pagination.imprimir(separador));
                }
                else if (option == "0")
                {
                    exit = true;
                }
            }
    
        }

        

        private string GetOption(string message)
        {
            Console.WriteLine(message);
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}