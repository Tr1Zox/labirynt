using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace labirynt
{
    internal class Labyrint
    {
        private char[,] mapa;
        public char[,] Mapa
        {
            get { return mapa; }
            set { }
        }
        private enum PointType
        {
            Empty = 'O',
            Wall = '+',
            Path = '*'
        }
        private string name;
        public string Name{
            get { return name; }
            set { }
        }

        public Labyrint(){
            int x, y;

            Console.Clear();
            Console.WriteLine("------ Tworzenie ------");
            Console.Write("Podaj nazwe: ");
            name = Console.ReadLine();

            while (true){
                Console.Write("Podaj liczbe wierszy (1 - 100): ");
                try { x = Convert.ToInt32(Console.ReadLine()); }
                catch{
                    Console.WriteLine("Podano nieprawidłową wartość...");
                    continue;
                }
                if (x <= 0 || x > 100){
                    Console.WriteLine("Podano nieprawidłową wartość...");
                    continue;
                }
                break;
            }

            while (true){
                Console.Write("Podaj liczbe kolumn (1 - 100): ");
                try { y = Convert.ToInt32(Console.ReadLine()); }
                catch{
                    Console.Write("Podano nieprawidłową wartość...");
                    continue;
                }
                if (y <= 0 || y > 100){
                    Console.Write("Podano nieprawidłową wartość...");
                    continue;
                }
                break;
            }

            Generator(x, y);
        }

        private void Generator(int x, int y){
            mapa = new char[x + 2, y + 2];

            for (int i = 0; i < mapa.GetLength(0); i++){
                for (int j = 0; j < mapa.GetLength(1); j++){
                    if ((j == 0 || j == mapa.GetLength(1) - 1) && (i == 0 || i == mapa.GetLength(0) - 1)){
                        mapa[i, j] = '+';
                    }
                    else if (j == 0 || j == mapa.GetLength(1) - 1){
                        mapa[i, j] = '|';
                    }
                    else if (i == 0 || i == mapa.GetLength(0) - 1){
                        mapa[i, j] = '-';
                    }
                    else {
                        mapa[i, j] = 'o';
                    }
                }
            }
        }

        public void Wyświetlacz(){
            for(int x = 0; x <= mapa.GetLength(0); x++){
                for (int y = 0; y < mapa.GetLength(1); y++){
                    if (x == mapa.GetLength(0)){
                        if (y > 0 && y < mapa.GetLength(1) - 1){
                            Console.Write(y + " ");
                        }
                        else{
                            Console.Write("  ");
                        }
                    }
                    else{
                        Console.Write(mapa[x, y] + " ");
                    }
                }
                if (x > 0 && x < mapa.GetLength(0) - 1){
                    Console.WriteLine(x);
                }
                else{
                    Console.WriteLine();
                }
            }
        }

        public void Zmień()
        {
            int x, y;
            char symbol;

            while (true){
                Console.Write("Podaj index wiersza:");
                try { x = Convert.ToInt32(Console.ReadLine()); }
                catch{
                    Console.WriteLine("Podano nieprawidłowy index...");
                    continue;
                }
                if (x <= 0 || x > mapa.GetLength(0) - 1){
                    Console.WriteLine("Podano nieprawidłowy index...");
                    continue;
                }
                break;
            }

            while (true){
                Console.Write("Podaj index kolumny: ");
                try { y = Convert.ToInt32(Console.ReadLine()); }
                catch{
                    Console.Write("Zła wartość!");
                    continue;
                }
                if (y <= 0 || y > mapa.GetLength(1) - 1){
                    Console.Write("Zła wartość!");
                    continue;
                }
                break;
            }

            while (true){
                Console.Write("Podaj symbol O - puste, + - sciana, * - scierzka :");
                symbol = Console.ReadKey().KeyChar;
                if (!Enum.IsDefined(typeof(PointType), (PointType)symbol)){
                    Console.WriteLine();
                    Console.WriteLine("Zły znak!");
                    continue;
                }
                Console.WriteLine();
                break;
            }mapa[x, y] = symbol;
        }
    }
}
