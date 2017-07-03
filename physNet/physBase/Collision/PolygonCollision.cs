using System;
using System.Collections.Generic;
using physNet.physUtil.MathObjects;

namespace physNet.physBase.Collision
{
    internal class PolygonCollision : CollisionShape
    {
        private List<Vec2> points;
        public override ShapeType Shape { get { return ShapeType.Polygon; } }

        public PolygonCollision(List<Vec2> points)
        {
            this.points = points;
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
