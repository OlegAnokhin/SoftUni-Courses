namespace P02.Graphic_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Square");
        }
    }
}