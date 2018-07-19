using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsInSort
{
    class CocktailSorting:Sorting
    {
        public CocktailSorting(int[] arr):base(arr)
        {
        }

        public override void Run()
        {
            CocktailSort();
        }


        public override string ToString()
        {
            return "CocktailSorting";
        }

        private void CocktailSort()
        {
            int[] array1,
                  array2;
            ArrayDivide(Arr, out array1, out array2);
            OrdinarySortingByInsertion(array1);
            OrdinarySortingByInsertion(array2);
            ArrayCombine(Arr, array1, array2);
        }



        private  void ArrayDivide(int[] arr, out int[] arr1, out int[] arr2)
        {
            arr1 = new int[arr.Length / 2];
            arr2 = new int[arr.Length - arr.Length / 2];

            int size = arr.Length;
            for (int i = 0; i < size / 2; i++)
            {
                arr1[i] = arr[i];
                OnNextMove(++NumberMove);  //event
            }
            for (int i = size / 2; i < size; i++)
            {
                arr2[i - size / 2] = arr[i];
                OnNextMove(++NumberMove);  //event
            }
        }

        private void ArrayCombine(int[] arr, int[] array1, int[] array2)
        {

            int size = arr.Length,
                size1 = array1.Length,
                size2 = array2.Length,
                j = 0,
                k = 0;

            for (int i = 0; i < size; i++)
            {
                OnNextCompare(++NumberCompare);  //event
                if (j < size1 && k < size2)
                {
                    OnNextCompare(++NumberCompare);  //event
                    if (array1[j] < array2[k])
                    {
                        arr[i] = array1[j++];
                        OnNextCompare(++NumberCompare);  //event
                    }
                    else
                    {
                        arr[i] = array2[k++];
                        OnNextCompare(++NumberCompare);  //event
                    }
                }
                else
                {
                    OnNextCompare(++NumberCompare);  //event
                    if (j >= size1)
                    {
                        for (int l = k; l < size2; l++)
                        {
                            arr[l + size1] = array2[l];
                            OnNextMove(++NumberMove);  //event
                        }
                    }
                    else
                    {
                        for (int l = j; l < size1; l++)
                        {
                            arr[l + size2] = array1[l];
                            OnNextMove(++NumberMove);  //event
                        }
                    }
                }
            }
        }


        private void OrdinarySortingByInsertion(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i;
                while (j > 0 && array[j - 1] > temp)
                {
                    array[j] = array[j - 1];
                    --j;
                    OnNextCompare(++NumberCompare);  //event
                    OnNextMove(++NumberMove);  //event
                }
                array[j] = temp;
                OnNextMove(++NumberMove);  //event;
            }
        }   
    }
}
