using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.StructuralDesignPattern.Flyweight
{
    public class ShapeFactory
    {
        private static Dictionary<string, Shape> shapeMap = new Dictionary<string, Shape>();
        public static Shape GetShape(string shapeType)
        {
            Shape shape = null;
            if (shapeType.Equals("circle", StringComparison.InvariantCultureIgnoreCase))
            {
                if (shapeMap.TryGetValue("circle", out shape))
                {
                }
                else
                {
                    shape = new Circle();
                    shapeMap.Add("circle", shape);
                    Console.WriteLine(" Creating circle object with out any color in shapefactory \n");
                }
            }
            return shape;
        }
    }
}
