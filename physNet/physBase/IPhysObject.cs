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
        /// Velocity of the object
        /// </summary>
        Vec2 Velocity { get; set; }
        /// <summary>
        /// Acceleration of the object
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

        /// <summary>
        /// Tell the object that the simulation tick is beginning
        /// </summary>
        /// <param name="dt">time slice of current frame</param>
        void SimulationBegin(double dt);

        /// <summary>
        /// Tell the object that the simulation tick is ending
        /// </summary>
        void SimulationEnd();
    }
}
