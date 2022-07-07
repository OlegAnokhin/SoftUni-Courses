namespace Shapes
{
    public abstract class Shape : IDrawable
    {
        public string Name { get; protected set; }
        protected Shape(string name)
        {
            this.Name = name;
        }
        public virtual void Draw()
        {
            System.Console.WriteLine("Default Impl of Draw");
        }
    }
}
