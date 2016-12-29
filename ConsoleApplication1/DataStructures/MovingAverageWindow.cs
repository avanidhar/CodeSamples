using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
    class MovingAverageWindow
    {
        private double sum;
        public int WindowSize { get; set; }

        public Queue<double> Window { get; private set; }

        public double WindowAverage { get; private set; }

        public MovingAverageWindow(int windowSize) {
            this.WindowSize = windowSize;

            this.Window = new Queue<double>();
            this.sum = 0;
        }

        public void Add(double value)
        {
            if (this.Window.Count < this.WindowSize)
            {
                this.Window.Enqueue(value);
            }
            else if (this.Window.Count == this.WindowSize)
            {
                double removed = this.Window.Dequeue();
                this.Window.Enqueue(value);
                sum -= removed;
            }

            sum += value;
            this.WindowAverage = sum / this.Window.Count;
        }

        public double GetAverage()
        {
            return this.WindowAverage;
        }
    }
}
