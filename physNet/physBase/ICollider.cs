using physNet.physBase.Collision;

namespace physNet.physBase
{
    interface ICollider
    {
        CollisionShape ColliderBounds { get; set; }
    }
}
