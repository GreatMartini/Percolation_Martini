using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {   if(_open[i,j] == true){
                return true;
            }
            else{
                return false;
            }
        }

        public bool IsFull(int i, int j)
        {   if(_full[i,j] == true){
                return true;
            }
            else{
                return false;
            }
        }

        public bool Percolate()
        {   for(int j = 0; j < _size; j++){
                if(IsFull(_size-1, j) == true){
                    return true;
                }
            }
                return false;
        }

        public List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {   var voisins = new List <KeyValuePair<int, int>>();
            // Coin superieur gauche
            if(i == 0 && j == 0){
                voisins.Add(new KeyValuePair<int, int>(i + 1, j));
                voisins.Add(new KeyValuePair<int, int>(i, j + 1));
                return voisins;
            }
            
            // Coin supérieur droit
            else if(i == 0 && j == _size - 1){
                voisins.Add(new KeyValuePair<int, int>(i + 1, j));
                voisins.Add(new KeyValuePair<int, int>(i, j -1));
                return voisins;
            }
            // Coin inférieur droit  
            else if(i == _size - 1 && j == _size - 1){
                voisins.Add(new KeyValuePair<int, int>(i - 1, j));
                voisins.Add(new KeyValuePair<int, int>(i, j -1));
                return voisins;
            }

            // Coin inférieur gauche
            else if(i == _size - 1 && j == 0){
                voisins.Add(new KeyValuePair<int, int>(i - 1, j));
                voisins.Add(new KeyValuePair<int, int>(i, j + 1));
                return voisins;
            }

            // Bord supérieur
            else if(i == 0 && j > 0 && j < _size){
                voisins.Add(new KeyValuePair<int, int>(i + 1, j));
                voisins.Add(new KeyValuePair<int, int>(i, j + 1));
                voisins.Add(new KeyValuePair<int, int>(i, j - 1));
                return voisins;
            }
            
            // Bord gauche
            else if(j == 0 && i > 0 && i < _size){
                voisins.Add(new KeyValuePair<int, int>(i, j + 1));
                voisins.Add(new KeyValuePair<int, int>(i + 1, j));
                voisins.Add(new KeyValuePair<int, int>(i - 1, j));
                return voisins;
            }

            // Bord inférieur
            else if(i == _size - 1 && j > 0 && j < _size){
                voisins.Add(new KeyValuePair<int, int>(i - 1, j));
                voisins.Add(new KeyValuePair<int, int>(i, j + 1));
                voisins.Add(new KeyValuePair<int, int>(i, j - 1));
                return voisins;
            }

            // Bord droit
            else if(j == _size - 1 && i > 0 && i < _size){
                voisins.Add(new KeyValuePair<int, int>(i, j - 1));
                voisins.Add(new KeyValuePair<int, int>(i + 1, j));
                voisins.Add(new KeyValuePair<int, int>(i - 1, j));
                return voisins;
            }
         
            // Dans le domaine
            else/*(j < _size && j < 0 && i > 0 && i < _size)*/{
                voisins.Add(new KeyValuePair<int, int>(i, j - 1));
                voisins.Add(new KeyValuePair<int, int>(i, j + 1 ));
                voisins.Add(new KeyValuePair<int, int>(i + 1, j));
                voisins.Add(new KeyValuePair<int, int>(i - 1, j));
                return voisins;
            }
            //else{
            //    return null;
            //}
        }

        public void Open(int i, int j)
        {
            _open[i, j] = true;
            List<KeyValuePair<int, int>> voisins = CloseNeighbors(i,j);
            //List<KeyValuePair<int, int>> voisins1 = new List <KeyValuePair<int, int>>();
            //voisins1.Add(CloseNeighbors(i, j));
            foreach (var element in voisins){
                //Console.Write(element.key);
                int vi = element.Key;
                int vj = element.Value;
                if (IsFull(vi, vj) == true){        //La performance est de 2N**2
                    _full[vi, vj] = true;           // Ce cas a peu de chances de se produire 
                                                    // Car la fonction de densité de probabilité est de ds/s
                                                    // S étant la surface
                }
            }
        } 
    }
}
