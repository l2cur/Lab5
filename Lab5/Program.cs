using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Programm
    {
        static void Main()
        {
            MyMatrix obj = new MyMatrix(6, 6);
            obj.Show();

            obj.min = 0;
            obj.max = 9;
            obj.Fill();
            obj.Show();

            obj.ChangeSize(7, 7);
            obj.ShowPartialy(0, 7, 0, 7);
        }
    }
    public class MyMatrix
    {
        public int min { get; set; } = 0;
        public int max { get; set; } = 99;
        private int _row, _columns;
        private int[,] _mas;
        public MyMatrix(int a, int b)
        {
            _row = a;
            _columns = b;
            Random rand = new Random();
            _mas = new int[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    _mas[i, j] = rand.Next(min, max);
                }
            }
        }
        public void Fill()
        {
            Random rand = new Random();
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    this[i, j] = rand.Next(min, max);
                }
            }
        }
        public MyMatrix ChangeSize(int a, int b)
        {
            MyMatrix obj = new MyMatrix(a, b);
            if (obj._row > this._row || obj._columns > this._columns)
            {
                Random rand = new Random();
                if (obj._row > this._row && obj._columns > this._columns)
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            obj[i, j] = rand.Next(min, max);
                        }
                    }
                    for (int i = 0; i < _row; i++)
                    {
                        for (int j = 0; j < _columns; j++)
                        {
                            obj[i, j] = this[i, j];
                        }
                    }
                }
                else if (obj._row > this._row)
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            obj[i, j] = rand.Next(min, max);
                        }
                    }
                    for (int i = 0; i < _row; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            obj[i, j] = this[i, j];
                        }
                    }
                }
                else if (obj._columns > this._columns)
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            obj[i, j] = rand.Next(min, max);
                        }
                    }
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < _columns; j++)
                        {
                            obj[i, j] = this[i, j];
                        }
                    }
                }
            }
            else for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        obj[i, j] = this[i, j];
                    }
                }
            this._row = obj._row;
            this._columns = obj._columns;
            this._mas = obj._mas;
            return this;

        }
        public void ShowPartialy(int row_start, int row_end, int columns_start, int columns_end)
        {
            Console.WriteLine();
            for (int i = row_start; i < row_end; i++)
            {
                for (int j = columns_start; j < columns_end; j++)
                {
                    string obj = this[i, j].ToString();
                    Console.Write(obj.PadRight(max.ToString().Length + 3));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void Show()
        {
            Console.WriteLine();
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    string obj = this[i, j].ToString();
                    Console.Write(obj.PadRight(max.ToString().Length + 3));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public int get_row()
        {
            return _row;
        }
        public int get_columns()
        {
            return _columns;
        }
        public int this[int row, int columns]
        {
            get
            {
                return _mas[row, columns];
            }
            set
            {
                _mas[row, columns] = value;
            }
        }
    }
}
