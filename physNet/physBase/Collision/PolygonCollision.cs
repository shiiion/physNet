using System;
using System.Collections.Generic;
using physNet.physUtil.MathObjects;

namespace physNet.physBase.Collision
{
    internal class PolygonCollision : CollisionShape
    {
        private List<Vec2> points;
        public override ShapeType Shape => ShapeType.Polygon;

        public PolygonCollision(List<Vec2> points)
        {
            this.points = points;
        }


        public override AABB GetBounds(Vec2 center, double rotation)
        {
            //try cache AABB by rotation to save time? benchmark it
            double lX;double lY = lX = double.PositiveInfinity;
            double gX;double gY = gX = double.NegativeInfinity;

            foreach(Vec2 point in points)
            {
                if (point.x < lX) lX = point.x;
                if (point.x > gX) gX = point.x;
                if (point.y < lY) lY = point.y;
                if (point.y > gY) gY = point.y;
            }
            return new AABB(new Vec2(gX - lX, gY - lY),
                center + new Vec2((gX + lX) / 2, (gY + lY) / 2));
        }

        public override Vec2 Support(Vec2 direction, double rotation)
        {
            Vec2 unrotated = direction.rotate(-rotation).normalized;
            double maxDot = double.NegativeInfinity;
            Vec2 maxPoint = Vec2.Zero;

            foreach(Vec2 point in points)
            {
                double temp;
                if((temp = unrotated.dot(point)) > maxDot)
                {
                    maxDot = temp;
                    maxPoint = point;
                }
            }
            return maxPoint.rotate(rotation);
        }
    }
}
