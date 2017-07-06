using System;
using System.Collections.Generic;
using physNet.physBase.Collision;
using physNet.physUtil.MathObjects;

namespace physNet.physBase
{
    internal struct MoveResult
    {
        public Vec2 Pos, Vel;
        public double Rot;

        public MoveResult(Vec2 p, Vec2 v, double r)
        {
            Pos = p; Vel = v; Rot = r;
        }
    }

    public class BaseCollider : ICollider
    {
        public Vec2 Position { get; set; }
        public Vec2 Velocity { get; set; }
        public Vec2 Acceleration { get; set; }
        public double Rotation { get; set; }
        public double AngularVelocity { get; set; }
        public PhysData BodyProperties { get; set; }
        public bool Static { get; set; }
        public bool Validated { get; private set; }

        public AABB BoundingBox
        {
            get
            {
                AABB baseBox = bounds.GetBounds(Rotation);
                return new AABB(baseBox.Bounds, baseBox.Center + Position);
            }
        }

        public AABB BoundingSweep
        {
            get
            {
                AABB baseBox = bounds.GetBounds(Rotation);
                Vec2 sweepBounds = (InitialMove.Pos - Position).abs / 2;
                Vec2 sweepCenter = (InitialMove.Pos - Position) / 2;
                return new AABB(baseBox.Bounds + sweepBounds, baseBox.Center + sweepCenter);
            }
        }

        private CollisionShape bounds;

        //Data pertaining to simulation begin
        internal MoveResult InitialMove { get; private set; }
        private double deltaTime;
        //
        internal MoveResult FinalMove { get; set; }

        public Vec2 Support(Vec2 direction)
        {
            return Position + bounds.Support(direction, Rotation);
        }
        
        public Vec2 SupportSweep(Vec2 direction)
        {
            Vec2 moveDelta = InitialMove.Pos - Position;

            if(Math.Sign(direction.dot(moveDelta)) > 0)
            {
                return InitialMove.Pos + bounds.Support(direction, InitialMove.Rot);
            }
            else
            {
                return Position + bounds.Support(direction, Rotation);
            }
        }

        public void SimulationBegin(double dt)
        {
            //dirty data
            Validated = false;

            deltaTime = dt;
            Vec2 pc = Position + (Velocity * dt);
            Vec2 vc = Velocity + (Acceleration * dt);
            double rc = Rotation + (AngularVelocity * dt);

            InitialMove = new MoveResult(pc, vc, rc);
        }

        public void SimulationEnd()
        {
            Position = FinalMove.Pos;
            Velocity = FinalMove.Vel;
            Rotation = FinalMove.Rot;

            //clean data
            Validated = true;
        }
    }
}
