using physNet.physUtil.MathObjects;

namespace physNet.physBase
{
    public interface IPhysObject
    {
        /// <summary>
        /// Position of the object
        /// </summary>
        Vec2 Position { get; set; }
        /// <summary>
        /// Velocity/direction of the object
        /// </summary>
        Vec2 Velocity { get; set; }
        /// <summary>
        /// Acceleration/velocity direction of the object
        /// </summary>
        Vec2 Acceleration { get; set; }
        /// <summary>
        /// Orientation of the object
        /// </summary>
        double Rotation { get; set; }
        /// <summary>
        /// Change in the orientation of the object
        /// </summary>
        double AngularVelocity { get; set; }

        /// <summary>
        /// True means the interface's data is valid and should be used.
        /// Otherwise, a simulation is still being ran, and the data 
        /// could be subject to change
        /// </summary>
        bool Validated { get; }

        void Simulate(double dt)
    }
}
