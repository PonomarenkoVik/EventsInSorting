using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsInSort
{
    class Analyzer
    {
        public Analyzer(Sorting[] sortings)
        {
            Sortings = (Sorting[]) sortings.Clone();
            NumberCompare = new int[Sortings.Length];
            NumberMove = new int[Sortings.Length];
        }

        public Sorting[] Sortings { get; private set; }
        public int[] NumberCompare { get; private set; }
        public int[] NumberMove { get; private set; }

        public void Run()
        {
            for (int i = 0; i < Sortings.Length; i++)
            {
                if (Sortings[i] != null)
                {
                    _currentIndex = i;
                    Sortings[i].NextCompare += CountCompare;
                    Sortings[i].NextMove += CountMove;
                    Sortings[i].Run();  
                }
                else
                {
                    break;
                }            
            }
        }

        private void CountCompare(object sender, NextEventArgs args)
        {
            NumberCompare[_currentIndex] = args.Oper;
        }

        private void CountMove(object sender, NextEventArgs args)
        {
            NumberMove[_currentIndex] = args.Oper;
        }

        private int _currentIndex;
    }
}
