﻿using physNet.physBase.Collision;
using physNet.physUtil.MathObjects;

namespace physNet.physBase
{
    /// <summary>
    /// Any object which can collide implements this
    /// </summary>
    public interface ICollider
    {
        Vec2 Position { get; set; }
        Vec2 Velocity { get; set; }
        Vec2 Acceleration { get; set; }
        double Rotation { get; set; }
        double AngularVelocity { get; set; }

        Vec2 Support(Vec2 direction);

        Vec2 PartitionerBounds { get; }
        Vec2 BoundsCenter { get; }
    }
}
