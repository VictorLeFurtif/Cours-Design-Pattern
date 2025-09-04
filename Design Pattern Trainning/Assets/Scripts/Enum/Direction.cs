using System.Numerics;

namespace Enum
{
    public enum Direction
    {
        Front,
        Back,
        Left,
        Right
    }

    public class DirectionDepedencies
    {
        public static Direction GetDirectionByVectorInput(Vector2 _vector)
        {
            Direction result = Direction.Front;
            
            if (_vector.X > 0.9)
            {
                result = Direction.Front;
            }

            else if (_vector.X < -0.9)
            {
                result = Direction.Back;
            }
            
            else if (_vector.Y > 0.9)
            {
                result = Direction.Right;
            }
            
            else if (_vector.Y < -0.9)
            {
                result = Direction.Left;
            }

            return result;
        }
    }
}