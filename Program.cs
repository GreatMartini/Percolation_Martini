using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Erreur dans la propagation, la propagation n'est pas bien implémentée:
// Pas de gravité
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
            simulation = sim.MeanPercolationValue(size, t);
            Console.Write($"{simulation.Mean} {simulation.StandardDeviation} ");

            
            // Keep the console window open
            
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
