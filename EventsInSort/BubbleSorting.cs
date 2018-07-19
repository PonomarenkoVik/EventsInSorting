using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsInSort
{
    class BubbleSorting:Sorting
    {
        public BubbleSorting(int[] arr):base(arr)
        {
        }
   
        public override void Run()
        {
            BubblуOrdinarySort();
        }

        public override string ToString()
        {
            return "BubbleSorting";
        }

        private void BubblуOrdinarySort()
        {
            bool stop;          
            do
            {
                stop = true;
                var j = 0;           
                bool markChange;    
                do
                {
                    markChange = false;
                    for (int i = j; i < Arr.Length - 1; i++)
                    {
                        OnNextCompare(++NumberCompare);  //event
                        if (Arr[i] > Arr[i + 1])
                        {
                            OnNextMove(++NumberMove);  //event
                            int temp = Arr[i];
                            Arr[i] = Arr[i + 1];
                            Arr[i + 1] = temp;
                            markChange = true;
                        }
                    }
                    ++j;

                } while (markChange);

             
                for (int i = 0; i < Arr.Length - 1; i++)
                {
                    OnNextCompare(++NumberCompare);  // event
                    if (Arr[i] > Arr[i + 1])
                    {
                        stop = false;
                        break;
                    }
                }

            } while (!stop);
        }      
    }
}
