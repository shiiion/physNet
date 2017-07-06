using System;
using physNet.physUtil.MathObjects;

namespace physNet.physBase.Collision
{
    internal class BoxCollision : CollisionShape
    {

        public Vec2 HalfDimensions { get; set; }
        public override ShapeType Shape => ShapeType.Box;

        public BoxCollision(Vec2 halfDims)
        {
            HalfDimensions = halfDims;
        }

        public override AABB GetBounds(double rotation)
        {
            Vec2 r1 = HalfDimensions.rotate(rotation);
            Vec2 r2 = new Vec2(HalfDimensions.x, -HalfDimensions.y).rotateThis(rotation);

            double bX = Math.Max(Math.Abs(r1.x), Math.Abs(r2.x));
            double bY = Math.Max(Math.Abs(r1.y), Math.Abs(r2.y));

            return new AABB(bX, bY, 0, 0);
        }

        public override Vec2 Support(Vec2 direction, double rotation)
        {
            direction.normThis();
            Vec2 dw = new Vec2(HalfDimensions.x, 0).rotateThis(rotation);
            if(Math.Sign(direction.dot(dw)) < 0)
            {
                dw = -dw;
            }

            Vec2 dh = new Vec2(0, HalfDimensions.y).rotateThis(rotation);
            if(Math.Sign(direction.dot(dh)) < 0)
            {
                dh = -dh;
            }

            return dw + dh;
        }
    }
}
