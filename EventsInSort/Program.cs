using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsInSort
{
    class Program
    {
        static readonly Random RanNumber = new Random();
        static void Main(string[] args)
        {
            int[] arr = new int[1000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = RanNumber.Next(0, 10000);
            }

            BubbleSorting bubble = new BubbleSorting(arr);
            InsertionSorting insertionSorting = new InsertionSorting(arr);
            CocktailSorting cocktailSorting = new CocktailSorting(arr);
            Sorting[] sortings = new Sorting[10];
            sortings[0] = bubble;
            sortings[1] = insertionSorting;
            sortings[2] = cocktailSorting;


            Analyzer analyzer = new Analyzer(sortings);
            analyzer.Run();
            ShowResult(analyzer);
        }

        private static void ShowResult(Analyzer analyzer)
        {
            for (int i = 0; i < analyzer.Sortings.Length; i++)
            {
                if (analyzer.Sortings[i] != null)
                {
                    Console.WriteLine("{0}. Sorting: {1,17}  number of comparisons: {2}  number of movements: {3}",i+1, analyzer.Sortings[i], analyzer.NumberCompare[i], analyzer.NumberMove[i]); 
                }
                else
                {
                    break;
                }       
            }
            Console.ReadKey();
        }
    }
}
