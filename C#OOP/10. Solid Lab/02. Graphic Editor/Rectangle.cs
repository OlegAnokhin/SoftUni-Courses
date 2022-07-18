namespace P02.Graphic_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Rectangle");
        }
    }
}