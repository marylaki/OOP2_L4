using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace OOP_Laba4
{

    class ColectionType<T>:IEnumerable where T : class
    {
        private List<T> _elem;//обобщенная колекция
        public ColectionType()
        {
            _elem = new List<T>();
        }
        public ColectionType(int n)
        {
            _elem = new List<T>(n);
        }
        public ColectionType(T[] array)
        {
            _elem = new List<T>(array);
        }
        public void Add(T item)//добавление элемента в конец спика
        {
            _elem.Add(item);
        }
        public void Insert(int i, T item)//втавить элемет по заданному индексу
        {
            try
            {
                if(i<0 || i>getCount()) throw new IndexOutOfRangeException();
                _elem.Insert(i, item);
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }
        }
        public void Clear()// удаление всего списка
        {
            _elem.Clear();
        }
        public void RemoveRang(int i1, int i2)// удаление элементов с i1 по i2
        {
            _elem.RemoveRange(i1, i2);
        }
        public void RemoveAt(int i)// удаление элемента i
        {
            _elem.RemoveAt(i);
        }
        public int getCount()//количество элементов
        {
            return _elem.Count;
        }
        public T this[int i]//индексатор
        {
            set
            {
                try
                {
                    if (i < 0 || i > getCount()) throw new IndexOutOfRangeException();
                    _elem[i] = (T)value;
                }
                catch (System.IndexOutOfRangeException e)
                {
                    Console.WriteLine("Error {0}", e.Message);
                }
            }
            get
            {
                try
                {
                    if (i < 0 || i > getCount()) throw new IndexOutOfRangeException();
                    return _elem[i];
                }
                catch (System.IndexOutOfRangeException e)
                {
                    Console.WriteLine("Error {0}", e.Message);
                    return null; 
                }
                
            }
        }
        public void Print()//вывод
        {
            Console.WriteLine("\nCollection type");
            for (int i = 0; i < _elem.Count; i++)
            {
                Console.WriteLine(_elem[i]);
            }
            Console.WriteLine("********************");
        }
        public void WriteToFile(string FileName)//Запись колекции в файл
        {
            Console.WriteLine("\nWrite to File");
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    sw.WriteLine("\nCollection Type");
                    foreach(T i in this)
                    {
                        sw.WriteLine(i);
                    }
                    sw.WriteLine("********************");
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
                Console.Write("Don't ");
            }
            finally
            {
                Console.WriteLine("sucsesfull\n");
            }
        }
        public void Sort()
        {
            _elem.Sort();
        }
        public IEnumerator GetEnumerator()//определение метода интерфейса IEnumarable. Чтобы работал foreach
        {
            return _elem.GetEnumerator();
        }
    }
}
