using System;
using physNet.physUtil.MathObjects;

namespace physNet.physBase.Collision
{
    internal class CircleCollision : CollisionShape
    {

        public double Radius { get; set; }
        public override ShapeType Shape { get { return ShapeType.Circle; } }

        public CircleCollision(double rad)
        {
            Radius = rad;
        }

        public override AABB GetBounds(double rotation)
        {
            return new AABB(new Vec2(Radius), Vec2.Zero);
        }

        public override Vec2 Support(Vec2 direction, double rotation)
        {
            direction.normThis();
            return direction * Radius;
        }
    }
}
