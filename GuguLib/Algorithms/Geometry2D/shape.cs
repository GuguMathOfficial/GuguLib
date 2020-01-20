using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circle
{
    abstract class Shape
    {
        private double radius;
        private double height;
        /// <summary>
        /// set Radius
        /// </summary>
        protected double R
        {
            set
            {
                if (value >= 0)
                { radius = value; }
            }
            get
            {
                return radius;
            }
        }
        /// <summary>
        /// set height
        /// </summary>
        protected double H
        {
            set
            {
                if (value >= 0)
                { height = value; }
            }
            get
            {
                return height;
            }
        }
        public const double PI = Math.PI;
        
        private Shape(double r,double h)
        {
            r = R;
            h = H;
        }
        public abstract double Area();
    }

}
