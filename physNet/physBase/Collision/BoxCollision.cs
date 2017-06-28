using System;
using physNet.physUtil.MathObjects;

namespace physNet.physBase.Collision
{
    internal class BoxCollision : CollisionShape
    {
        public Vec2 HalfDimensions { get; set; }
        public double Rotation { get; set; }


        public BoxCollision(Vec2 halfDims, double rotation)
        {
            HalfDimensions = halfDims;
            Rotation = rotation;
        }

        public override Vec2 Support(Vec2 direction)
        {
            Vec2 unrotated = direction.rotate(-Rotation);
            Vec2 heightScale = unrotated * HalfDimensions.y;
            Vec2 widthScale = unrotated * HalfDimensions.x;
        }

        public override Vec3 SweptSupport(Vec2 direction, double sweepLength)
        {
            Vec3 unrotatedSweep = new Vec3()
        }
    }
}
