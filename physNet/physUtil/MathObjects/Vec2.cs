using System;

namespace physNet.physUtil.MathObjects
{
    public struct Vec2
    {
        public double x, y;

        public static readonly Vec2 Zero = new Vec2();
        public static readonly Vec2 One = new Vec2(1);
        public static readonly Vec2 YAxis = new Vec2(0, 1);
        public static readonly Vec2 XAxis = new Vec2(1, 0);

        public Vec2(double x, double y) { this.x = x; this.y = y; }
        public Vec2(double xy) { x = xy; y = xy; }
        
        public static Vec2 fromAngle(double angle)
        {
            return new Vec2(Math.Cos(angle), Math.Sin(angle));
        }

        public bool isNormal
        {
            get { return MathUtil.Compare(mag2, 1, 0.0001); }
        }

        public double dot(Vec2 other) => x * other.x + y * other.y;

        public double mag2 => dot(this);

        public double mag => Math.Sqrt(dot(this));

        public Vec2 project(Vec2 onto)
        {
            double projScalar = dot(onto) / onto.mag;
            return onto * projScalar;
        }

        public double angleBetween(Vec2 other)
        {
            double mt = mag, mo = other.mag;
            return Math.Acos(dot(other) / (mt * mo));
        }

        public Vec2 rotate(double angle)
        {
            double sin = Math.Sin(angle), cos = Math.Cos(angle);
            //xr = x * a - y * b
            //yr = x * b + y * a
            return new Vec2(x * cos - y * sin, x * sin + y * cos);
        }

        public Vec2 perpendicular => new Vec2(y, -x);

        public Vec2 normalized => this / mag;

        public override string ToString()
        {
            return $"({Math.Round(x, 10)}, {Math.Round(y, 10)})";
        }

        #region Self-Modifiers

        public void set(double x, double y)
        {
            this.x = x; this.y = y;
        }

        public Vec2 addThis(Vec2 other)
        {
            x += other.x; y += other.y;
            return this;
        }

        public Vec2 subThis(Vec2 other)
        {
            x -= other.x; y -= other.y;
            return this;
        }

        public Vec2 mulThis(double scalar)
        {
            x *= scalar; y *= scalar;
            return this;
        }

        public Vec2 divthis(double scalar)
        {
            x /= scalar; y /= scalar;
            return this;
        }

        public Vec2 rotateThis(double angle)
        {
            double sin = Math.Sin(angle), cos = Math.Cos(angle);
            double xOld = x, yOld = y;
            x = xOld * cos - yOld * sin;
            y = xOld * sin + yOld * cos;
            return this;
        }

        public Vec2 perpendicularThis()
        {
            double xTemp = x;
            x = y; y = -xTemp;
            return this;
        }

        public Vec2 normThis()
        {
            double m = mag;
            x /= m; y /= m;
            return this;
        }

        public Vec2 projectThis(Vec2 onto)
        {
            Vec2 projection = project(onto);
            x = projection.x; y = projection.y;
            return this;
        }

        #endregion


        #region Operators

        public static Vec2 operator +(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x + b.x, a.y + b.y);
        }

        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x - b.x, a.y - b.y);
        }

        public static Vec2 operator *(Vec2 a, double b)
        {
            return new Vec2(a.x * b, a.y * b);
        }

        public static Vec2 operator *(double a, Vec2 b)
        {
            return new Vec2(a * b.x, a * b.y);
        }

        public static Vec2 operator *(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x * b.x, a.y * b.y);
        }

        public static Vec2 operator /(Vec2 a, double b)
        {
            return a * (1f / b);
        }

        public static Vec2 operator -(Vec2 negate)
        {
            return new Vec2(-negate.x, -negate.y);
        }

        #endregion
    }
}