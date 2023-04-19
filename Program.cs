using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_08._04._23
{
    class Piece:IDisposable
    {
        public string name { get; set; }
        public string autor { get; set; }
        public string genre { get; set;}
        public int year { get; set; }

        public Piece(string name, string autor, string genre, int year)
        {
            this.name = name;
            this.autor = autor;
            this.genre = genre;
            this.year = year;
        }

        public override string ToString()
        {
            return $"Name: {name}, Autor: {autor}, Genre: {autor}, Year: {year}";
        }
        public void Dispose()
        {
            Console.WriteLine("the dispose method for the Piece class has completed");
        }

        ~Piece() 
        {
            Console.WriteLine("The finalizer for the Piece class has completed");
        }
    }

    enum Type
    {
        Grocery, Hardware, Clothes, Shoes
    }
    class Shop: IDisposable
    {
        public string name { get; set; }
        public string adress { get; set; }

        public Type shopType { get; set; }

        public Shop(string name, string adress, Type shopType)
        {
            this.name = name;
            this.adress = adress;
            this.shopType = shopType;
        }

        public void Dispose() 
        {
            Console.WriteLine("Shop has disposed");
        }

        ~Shop() { Console.WriteLine("Shop has finalized"); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Piece myPiece = new Piece("Crazy day", "Unknown", "comedy", 2023);
            Console.WriteLine(myPiece.ToString());
            myPiece.Dispose();
            myPiece.name= "Very Crazy Day";
            Console.WriteLine(myPiece.ToString());

            GC.Collect();
            Console.WriteLine();
            
            using (Shop firstShop = new Shop("My first shop", "Odesa, Ukraine", Type.Grocery))
            {
                Console.WriteLine($"Name:{firstShop.name}, Adress: {firstShop.adress}, Type: {firstShop.shopType}");
            }
        }
    }
}
