using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = 10;
            int t = 100;
            PercolationSimulation sim = new PercolationSimulation();
            PclData simulation = new PclData();
            //try{
            simulation = sim.MeanPercolationValue(size, t);
            Console.Write($"{simulation.Mean} {simulation.StandardDeviation} ");
            //}
            //catch(ArgumentOutOfRangeException){}

            
            // Keep the console window open
            
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
