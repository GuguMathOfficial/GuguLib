using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circle
{
    class Circle1 : Shape
    {
        public Circle1(double radius, double diametеr)

        : base(radius, diametеr,0) { }

        public override double Area()//намира лице чрез радиус
        {
                return Math.Round(PI * r * r, 2);
        }
        public double Perimeter()//намира периметър чрез радиус
        {
            return 2 * PI * r;
        }
        public  string AreaString()//намира лице чрез радиус и връща string с π
        {
            return (r * r).ToString() + "*π";
        }
        public  string PerimeterString()//намира периметър чрез радиус и връща string с π
        {
            return (2 * r).ToString() + "*π";
        }
        public double DtoR()//намира радиус от диаметър
        {
            return r = d / 2;
        }
        public double RtoD()//намира диаметър от радиус
        {
            return d = r * 2;
        }
        public string AreaDString()//намира лице чрез диаметър и връща стринг с PI
        {
            return ((d*d) / 4).ToString() + "*π";
        }
        public double AreaD()//намира лице чрез диаметър
        {
            return Math.Round((PI * (d*d)) / 4, 2);
        }
        public double PerimeterD()//намира периметър чрез диаметър
        {
            return PI * d;
        }
        public string PerimeterDString()//намира периметър чрез диаметър и връща string с π
        {
            return (d).ToString() + "*π";
        }
        public double АреаSektor(double O)//намира лице на сектор от окръжност
        {
            return Math.Round(O / 360 * PI * r * r, 2);
        }
        public string AreaSektorString(double O)//намира лице на сектор от окръжност и връща string + PI
        {
            return (Math.Round(O / 360 * r * r, 2)).ToString() + "*π";
        }
        public double AreatoR(double S)//намира радиус от лице ,като S е лицето
        {
            return Math.Round(r = Math.Sqrt(S / PI), 2);
        }
        public double PerimetertoR(double P)//намира радиус от периметър ,като Р е лицето
        {
            return Math.Round(r = P / (2 * PI), 2);
        }
        public double PerimetertoD(double P)//намира диаметър от периметър ,като P е лицето
        {
            return Math.Round(d = P / PI, 2);
        }
        public double AreatoD(double S)//намира диаметър от лице ,като S е лицето
        {
            return Math.Round(d = Math.Sqrt((4 * S) / PI), 2);
        }
        public void ReturnH(double hieght)
        {
            h = hieght;
        }
    }
}
