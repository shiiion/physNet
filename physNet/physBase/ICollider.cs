using physNet.physBase.Collision;
using physNet.physUtil.MathObjects;

namespace physNet.physBase
{
    public struct PhysData
    {
        /// <summary>
        /// Mass of the object (affects impulse)
        /// if Static is true, mass is treated as infinite
        /// </summary>
        public double Mass;

        /// <summary>
        /// Elasticity of the object
        /// 0 = no impulse
        /// (0, 1) = decreasing impulse
        /// 1 = full impulse
        /// (1, n) > incoming impulse
        /// </summary>
        public double Rebound;

        /// <summary>
        /// Coefficient of friction of the object
        /// </summary>
        public double Friction;

        public PhysData(double m, double r, double f)
        {
            Mass = System.Math.Max(0, m);
            Rebound = System.Math.Max(0, r);
            Friction = System.Math.Max(0, f);
        }
    }

    /// <summary>
    /// Any object which can collide implements this
    /// </summary>
    public interface ICollider : IPhysObject
    {
        /// <summary>
        /// Support function for this collider
        /// </summary>
        /// <param name="direction">Direction for the support point</param>
        /// <returns>Support point</returns>
        Vec2 Support(Vec2 direction);

        /// <summary>
        /// Support function for this collider over its entire movement
        /// </summary>
        /// <param name="direction">Direction for the support point</param>
        /// <returns></returns>
        Vec2 SupportSweep(Vec2 direction);

        /// <summary>
        /// Retrieves the bounding box for this collider
        /// </summary>
        AABB BoundingBox { get; }

        /// <summary>
        /// Generates a bounding box enclosing the entire movement of this collider
        /// </summary>
        AABB BoundingSweep { get; }

        /// <summary>
        /// Data which describes how collisions will be resolved with this collider
        /// </summary>
        PhysData BodyProperties { get; set; }

        /// <summary>
        /// True if the object is non-moving
        /// </summary>
        bool Static { get; set; }
    }
}
