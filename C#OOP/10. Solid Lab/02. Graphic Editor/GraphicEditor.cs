namespace P02.Graphic_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            shape.Draw();
        }
    }
}