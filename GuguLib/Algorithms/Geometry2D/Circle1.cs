using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circle
{
    class Circle1 : Shape
    {
        public Circle1(double radius)

        : base(radius,0) { }

        /// <summary>
        /// find Area
        /// </summary>
        
        public override double Area()
        {
                return Math.Round(PI * R * R, 2);
        }

        /// <summary>
        /// find Perimeter
        /// </summary>
        
        public double Perimeter()
        {
            return 2 * PI * R;
        }

        /// <summary>
        /// Find Area and return String + *π"
        /// </summary>
        
        public string AreaString()
        {
            return (R * R).ToString() + "*π";
        }

        /// <summary>
        /// find Area Sektor
        /// O is central angle
        /// </summary>
        /// <param name="O"></param>
        public double АреаSektor(double O)
        {
            return Math.Round(O / 360 * PI * R * R, 2);
        }
    }
}
