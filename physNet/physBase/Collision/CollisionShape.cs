using System.Collections.Generic;
using physNet.physUtil.MathObjects;

namespace physNet.physBase.Collision
{
    public enum ShapeType
    {
        Circle, Box, Polygon
    };

    public struct AABB
    {
        /// <summary>
        /// Half-width and Half-height of the box
        /// </summary>
        public Vec2 Bounds;
        /// <summary>
        /// The AABB's offset from the center of the collision shape
        /// </summary>
        public Vec2 Center;

        public AABB(Vec2 bounds, Vec2 center)
        {
            Bounds = bounds; Center = center;
        }
        public AABB(double boundsX, double boundsY, double centerX, double centerY)
        {
            Bounds = new Vec2(boundsX, boundsY);
            Center = new Vec2(centerX, centerY);
        }
    }

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

        public abstract AABB GetBounds(double rotation);

        public static CollisionShape CreateCircle(double radius) => new CircleCollision(radius);
        public static CollisionShape CreateBox(Vec2 halfDims) => new BoxCollision(halfDims);
        public static CollisionShape CreatePolygon(List<Vec2> points) => new PolygonCollision(points);
    }
}
