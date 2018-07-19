using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsInSort
{
     class NextEventArgs : EventArgs
	{
        public NextEventArgs(int i)
        {
            Oper = i;
        }

		// данные, описывающие событие
        public int Oper { get; private set; }
	}

    delegate void NextOperation(object sender, NextEventArgs args);




    abstract class Sorting
    {
        protected Sorting(int[] arr)
        {
            Arr = (int[]) arr.Clone();
            NumberCompare = 0;
            NumberMove = 0;
        }
        public int[] Arr { get; protected set; }

        public abstract void Run ();

        public event NextOperation NextCompare
        {
            add
            {
                _nextComp += value;
            }
            remove
            {
                _nextComp -= value;
            }
        }

        public event NextOperation NextMove
        {
            add
            {
                _nextMove += value;
            }
            remove
            {
                _nextMove -= value;
            }
        }

        protected void OnNextCompare(int oper)
        {
            if (_nextComp != null)
            {
                _nextComp(this, new NextEventArgs(oper));
            }
        }

        protected void OnNextMove(int oper)
        {
            if (_nextMove != null)
            {
                _nextMove(this, new NextEventArgs(oper));
            }
        }

        NextOperation _nextComp;
        NextOperation _nextMove;

        protected int NumberCompare;
        protected int NumberMove;
        

    }
}
