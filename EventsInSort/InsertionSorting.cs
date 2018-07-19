using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsInSort
{
    class InsertionSorting:Sorting
    {
        public InsertionSorting(int[] arr):base(arr)
        {
           
        }

        public override void Run()
        {
            OrdinarySortingByInsertion();
        }


        public override string ToString()
        {
            return "InsertionSorting";
        }

        private void OrdinarySortingByInsertion()
        {
            for (int i = 1; i < Arr.Length; i++)
            {
                int temp = Arr[i];
                int j = i;
                while (j > 0 && Arr[j - 1] > temp)
                {
                    Arr[j] = Arr[j - 1];
                    --j;
                    OnNextCompare(++NumberCompare);  //event
                    OnNextMove(++NumberMove);  //event
                }
                Arr[j] = temp;
                OnNextMove(++NumberMove);  //event;
            }
        }   
    }
}
