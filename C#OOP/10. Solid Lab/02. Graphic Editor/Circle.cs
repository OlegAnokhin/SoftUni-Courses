namespace P02.Graphic_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Circle");
        }
    }
}