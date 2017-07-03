using System;
using System.Collections.Generic;
using physNet.physBase.Collision;
using physNet.physUtil.MathObjects;

namespace physNet.physBase
{
    public class BaseObject : ICollider
    {
        public Vec2 Position { get; set; }
        public Vec2 Velocity { get; set; }
        public double Rotation { get; set; }
        public double AngularVelocity { get; set; }

        private CollisionShape bounds;

        /// <summary>
        /// Future unchecked position of object
        /// </summary>
        private Vec2 positionCache;
        /// <summary>
        /// Future unchecked rotation of object
        /// </summary>
        private double rotationCache;



        public Vec2 Support(Vec2 direction)
        {
            return Position + bounds.Support(direction, Rotation);
        }
        
        private Vec2 supportSweepFromCache(Vec2 direction)
        {
            Vec2 moveDelta = positionCache - Position;

            if(Math.Sign(direction.dot(moveDelta)) > 0)
            {
                return positionCache + bounds.Support(direction, rotationCache);
            }
            else
            {
                return Position + bounds.Support(direction, Rotation);
            }
        }
    }
}
