using System;
using System.Collections.Generic;
using System.Text;
using physNet.physUtil.MathObjects;

namespace physNet.physBase.Collision
{
    internal class CircleCollision : CollisionShape
    {
        public double Radius { get; set; }

        public CircleCollision(double rad)
        {
            Radius = rad;
        }

        public override Vec2 Support(Vec2 direction)
        {
            Vec2 norm = direction.normalized();
            return norm * Radius;
        }
    }
}
