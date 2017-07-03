using System.Collections.Generic;
using physNet.physUtil.MathObjects;

namespace physNet.physBase.Collision
{
    public enum ShapeType
    {
        Circle, Box, Polygon
    };

    public abstract class CollisionShape
    {
        /// <summary>
        /// Returns support function result for this shape
        /// </summary>
        /// <param name="direction">Directional vector</param>
        /// <param name="rotation">Rotation of shape in radians</param>
        /// <returns></returns>
        public abstract Vec2 Support(Vec2 direction, double rotation);
        public abstract ShapeType Shape { get; }

        public static CollisionShape CreateCircle(double radius) => new CircleCollision(radius);
        public static CollisionShape CreateBox(Vec2 halfDims) => new BoxCollision(halfDims);
        public static CollisionShape CreatePolygon(List<Vec2> points) => new PolygonCollision(points);
    }
}
