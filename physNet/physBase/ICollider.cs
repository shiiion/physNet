using physNet.physBase.Collision;
using physNet.physUtil.MathObjects;

namespace physNet.physBase
{
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
        /// Width and height of the enclosing AABB
        /// </summary>
        Vec2 PartitionerBounds { get; }
        /// <summary>
        /// Center of the enclosing AABB
        /// </summary>
        Vec2 BoundsCenter { get; }

    }
}
