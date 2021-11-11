using System;

namespace Area_calculator
{
    abstract class Shape
    {
        public abstract double CalculateArea();

    }

    class Rectaingle : Shape
    {
        private double side1;
        private double side2;
        public Rectaingle() { }
        public Rectaingle(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }
        public override double CalculateArea()
        {
            double area = this.side1 * this.side2;
            return area;
        }
    }
    class Triangle : Shape
    {
        private double tside1;
        private double tside2;
        private double tside3;
        public Triangle() { }
        public Triangle(double tside1, double tside2, double tside3)
        {
            this.tside1 = tside1;
            this.tside2 = tside2;
            this.tside3 = tside3;
        }
        public override double CalculateArea()
        {
            double s = Convert.ToDouble((this.tside1 + this.tside2 + this.tside3) / 2);
            double area = Convert.ToDouble(Math.Sqrt(s * (s - this.tside1) * (s - this.tside2) * (this.tside3)));
            return area;
        }

    }
    class Circle : Shape
    {
        private double radius;
        public Circle() { }
        public Circle(double r)
        {
            this.radius = r;

        }
        public override double CalculateArea()
        {
            double area = (double)(Math.Pow(this.radius, 2) * Math.PI);
            return area;
        }
    }

    class App
    {
        static void Main()
        {
            char figure;
            char state = 'y';
            Console.WriteLine("Hello, I can calculate the Area of several geometric figures");
            while (state == 'y')
            {
                Console.WriteLine("What figure do you wish to calculate. C=cercle , T=triangle, R=rectangle");
                figure = Convert.ToChar(Console.ReadLine());
                //We must select the right constructor according the figure selected

                //circle
                if (figure == 'C' || figure == 'c')
                {
                    double radius;
                    Console.WriteLine("Cercle selected");
                    Console.WriteLine("Please provide me the variables needed");
                    //We ask for radius
                    Console.WriteLine("What is your radius?");
                    radius = Convert.ToDouble(Console.ReadLine());
                    Shape circle = new Circle(radius);
                    Console.WriteLine("The area is equal to {0}", circle.CalculateArea());
                }
                //rectangle
                else if (figure == 'R' || figure == 'r')
                {
                    double side1, side2;
                    Console.WriteLine("Rectangle selected");
                    Console.WriteLine("Please provide me the variables needed");
                    //We ask for both sides needed
                    Console.WriteLine("What is your 1st side?");
                    side1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("What is your 2nd side?");
                    side2 = Convert.ToDouble(Console.ReadLine());
                    Shape square = new Rectaingle(side1, side2);
                    Console.WriteLine("The area is equal to {0}", square.CalculateArea());
                }

                //triangle
                else if (figure == 'T' || figure == 't')
                {
                    double a, b, c;
                    Console.WriteLine("Triangle selected");
                    Console.WriteLine("Please provide me the variables needed");
                    //We ask for 3 sides
                    Console.WriteLine("Side 1");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Side 2");
                    b = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Side 3");
                    c = Convert.ToDouble(Console.ReadLine());
                    Shape triangle = new Triangle(a, b, c);
                    Console.WriteLine("The area is equal to {0}", triangle.CalculateArea());
                }
                else
                {
                    Console.WriteLine("please enter valid character");
                }

                Console.WriteLine("Do you wish to continue calculating? y/n");
                state = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
