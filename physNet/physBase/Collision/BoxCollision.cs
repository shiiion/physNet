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
            direction.normThis();
            double boxCornerDist = HalfDimensions.mag;
            Vec2 unrotated = direction.rotate(-Rotation) * boxCornerDist;
            
            if(Math.Abs(unrotated.x) > HalfDimensions.x)
            {
                double theta = unrotated.angleBetween(Vec2.XAxis);
                double hypLength = HalfDimensions.x / Math.Cos(theta);
                return direction * hypLength;
            }
            else if(Math.Abs(unrotated.y) > HalfDimensions.y)
            {
                double theta = unrotated.angleBetween(Vec2.YAxis);
                double hypLength = HalfDimensions.x / Math.Cos(theta);
                return direction * hypLength;
            }
            else
            {
                return direction * boxCornerDist;
            }
        }

        public override Vec3 SweptSupport(Vec2 direction, Vec3 sweepDelta)
        {
            return new Vec3();
            //Vec3 unrotatedSweep = new Vec3()
        }
    }
}
