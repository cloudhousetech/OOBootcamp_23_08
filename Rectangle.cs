/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp
{
    // Understands a 4-sided polygon with sides at right angles


    public class Rectangle //: IOoBootCamp
    {
        private readonly double _width;
        private readonly double _height;

        public Rectangle(double width, double height)
        {
            if (height <= 0 || width <= 0) throw new ArgumentException("Invalid dimension(s)");
            _width = width;
            _height = height;
        }

        public double Area()
        {
            return _height * _width;
        }

        public double Perimeter()
        {
            return 2 * (_height + _width);
        }

        public bool IsSquare()
        {
            return _width == _height;
        }

        //public static  IOoBootCamp Largest(IOoBootCamp[] rectangles)
        //{
        //    int indexLargest = -1;
        //    int largestArea = 0;
        //    foreach (Rectangle rectangle in rectangles)
        //    {
        //        if(rectangle.Area();
        //    }
        //    return new Rectangle(1, 1);
        //}
    }

    //public class ComputeLargest : IOoBootCamp
    //{
    //    public IOoBootCamp Largest(IOoBootCamp[] rectangle)
    //    {
    //        return new Rectangle(1, 1);
    //    }
    //}
    
}
