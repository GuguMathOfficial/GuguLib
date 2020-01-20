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
        private double diameter;
        private double height;
        protected double r
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
        protected double d
        {
            set
            {
                if (value >= 0)
                { diameter = value; }
            }
            get
            {
                return diameter;
            }
        }
        protected double h
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
        
        private Shape(double r, double d,double h)
        {
            this.r = r;
            this.d = d;
            this.h = h;
        }
        public abstract double Area();
    }

}
