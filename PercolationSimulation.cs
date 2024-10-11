using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {   
            PclData data = new PclData();
            double sum_fractions = 0;
            double sum_squares = 0;
            double fraction = 0;
            for(int i = 0; i < t; i++){
                fraction += PercolationValue(size);
                sum_fractions += sum_fractions;
                sum_squares += fraction*fraction;
            }
            double mean = sum_fractions/t;
            double mean_of_squares = sum_squares/t;
            double std_dev = Math.Sqrt(mean_of_squares - mean*mean);

            data.Mean = mean;
            data.StandardDeviation = std_dev;

            return data;
        }

        public double PercolationValue(int size)
        {   
            //try{
            Percolation grid = new Percolation(size);

            Random rnd = new Random();
            int open_count = 0;             //Nombre de sites ouverts
            int k = 0;                      //Nombre maximal d'itérations
                do{
                    k += 1;
                    int ni = rnd.Next(size);
                    int nj = rnd.Next(size);
                    if (grid.IsOpen(ni, nj) == false){
                        grid.Open(ni, nj);
                        open_count += 1;

                    }
                    else{
                        continue;
                    }
                    if(grid.Percolate() == true){
                        return open_count/(size*size);
                    }
                }
                while(grid.Percolate() == false && k < 100);
            //}
            //catch(ArgumentOutOfRangeException){}
            return 0;
        }
    }
}
