using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace OOP_Laba4
{
    abstract class figura
    {
        protected string figuraName { set; get; }
        public figura(string name)
        {
            figuraName = name;
        }
        
    }

    partial class Rectangle : figura, IComparable<Rectangle>, IEnumerable
    {

        public int a { set; get; }
        public int b { set; get; }
        public Rectangle():this(0,0)
        { }
        public Rectangle(int A, int B) : base("Прямоугольник")
        {
            a = A;
            b = B;
        }
        public int CompareTo(Rectangle R)// показывает, расположен ли текущий экземпляр , после или на той же позиции в порядке сортировки что и другой объект
        {
            if (R == null) return 1;
            else
                return (a * b).CompareTo(R.a * R.b);
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public override string ToString() => figuraName + " " + a + "x" + b;
       
    }
}
