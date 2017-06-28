using System;
using System.Collections.Generic;
using System.Text;
using physNet.physUtil.MathObjects;

namespace physNet.physBase.Collision
{
    public abstract class CollisionShape
    {
        public abstract Vec2 Support(Vec2 direction);

        public static CollisionShape CreateCircle(double radius) => new CircleCollision(radius);
        public static CollisionShape CreateBox(Vec2 halfDims, double rotation) 
            => new BoxCollision(halfDims, rotation);
    }
}
