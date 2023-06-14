

namespace SfmlAppLib
{
    public static class Geometry
    {
        public class VectorFloat
        {
            public Vector2f VecCoords { get; protected set; }
            public VectorFloat()
            {

            }
            public VectorFloat(Vector2f vector1, Vector2f vector2)
            {
                VecCoords = new(vector1.X-vector2.X, vector1.Y-vector2.Y);
            }
            public double Dlina()
            {
                return Math.Pow(VecCoords.X, 2)+Math.Pow(VecCoords.Y, 2);
            }
            public double Angle(VectorFloat vector1)
            {
                return Math.Acos((this*vector1)/(Dlina()*vector1.Dlina()));
            }
            public static double operator *(VectorFloat one, VectorFloat two)
            {
                return one.VecCoords.X*two.VecCoords.X+one.VecCoords.Y*two.VecCoords.Y;
            }
            public void SetVec(Vector2f vector1, Vector2f vector2)
            {
                VecCoords = new(vector1.X-vector2.X, vector1.Y-vector2.Y);
            }

        }
        public static double Dlina(Vector2f point1, Vector2f point2)
        {
            return Math.Sqrt(Math.Pow(point1.X-point2.X, 2)+Math.Pow(point1.Y-point2.Y, 2));
        }
        public static double Angle(Vector2f point1, Vector2f point2)
        {
            Vector2f b = new(6, 2000);
            Vector2f b1 = new(8, 2000);
            return (new VectorFloat(point1, point2)*new VectorFloat(b, b1)) /(Dlina(point1, point2)*Dlina(b, b1));
        }
    }
}
