using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heapsort
{
    //Ryan Clark
    //Heapsort practice
    class Heapsort
    {
        private List<int> x;

        public Heapsort(List<int> x)
        {
            this.count = x.Count;
            this.x = x;
        }

        internal void heapSort()
        {
            int end,temp;
            heapify();            // Build a heap 
            end = count - 1;
            while (end > 0)
            {
                temp =x[end];       //Takes the largest value of the heap puts it in the end of the list
                x[end]   =x[0];
                x[0] = temp;
                end = end - 1;
                siftDown(0,end);    //Fixes the heap so largest value is on top
            }
        }

        private void heapify()
        {
            int start = (count - 2) / 2;

            while( start>=0)
            {
                siftDown(start,count-1);
                start = start - 1;
            }
        }

        private void siftDown(int start,int end)
        {
            int root = start;
            int child,swap,temp;
            while (root*2+1<=end)                //While there is a child node of root
            {
                child = root * 2 + 1;
                swap = root;

                if(x[swap]<x[child]){    //If left child is greater      
                    swap = child;
                }
                if (child + 1 <= end && x[swap] < x[child + 1])  //If right child exists and is greater
                {
                    swap = child + 1;
                }
                if (swap != root)              //If a child node was greater make the swap
                {
                    temp = x[root];
                    x[root] = x[swap];
                    x[swap] = temp;
                    root = swap;               //To sift down the child node
                }
                else { return; }
            }
        }

        internal void Display()
        {
            foreach (int i in x)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }   
    
        public int count { get; set; }

       
    }




    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> x = new List<int>();
            for (int i = 0; i < 10; i++){ 
                x.Add(rand.Next(0, 100));
            }

            Heapsort test = new Heapsort(x);
            Console.WriteLine("Unsorted: ");
            test.Display();
            test.heapSort();
            Console.WriteLine("Sorted: ");
            test.Display();
        }
    }
}
