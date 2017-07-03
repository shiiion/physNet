using System;

namespace physNet.physUtil.MathObjects
{
    public struct Vec3
    {
        public double x, y, z;

        public static readonly Vec3 Zero = new Vec3();
        public static readonly Vec3 One = new Vec3(1);

        public Vec3(double x, double y, double z) { this.x = x; this.y = y; this.z = z; }
        public Vec3(Vec2 xy, double z) { x = xy.x; y = xy.y; this.z = z; }
        public Vec3(double x, Vec2 yz) { this.x = x; y = yz.x; z = yz.y; }
        public Vec3(double xyz) { x = xyz; y = xyz; z = xyz; }

        public bool isNormal
        {
            get { return MathUtil.Compare(mag2, 1, 0.0001); }
        }

        public double dot(Vec3 other) => x * other.x + y * other.y + z * other.z;

        public double mag2 => dot(this);

        public double mag => Math.Sqrt(dot(this));

        public Vec3 project(Vec3 onto)
        {
            double projScalar = dot(onto) / onto.mag;
            return onto * projScalar;
        }

        public double angleBetween(Vec3 other)
        {
            double mt = mag, mo = other.mag;
            return Math.Acos(dot(other) / (mt * mo));
        }

        public Vec3 normalized() => this / mag;

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }


        #region Self-Modifiers

        public void set(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }

        public Vec3 addThis(Vec3 other)
        {
            x += other.x; y += other.y; z += other.z;
            return this;
        }

        public Vec3 subThis(Vec3 other)
        {
            x -= other.x; y -= other.y; z -= other.z;
            return this;
        }

        public Vec3 mulThis(double scalar)
        {
            x *= scalar; y *= scalar; z *= scalar;
            return this;
        }

        public Vec3 divthis(double scalar)
        {
            x /= scalar; y /= scalar; z /= scalar;
            return this;
        }

        public Vec3 normThis()
        {
            double m = mag;
            x /= m; y /= m;
            return this;
        }

        public Vec3 projectThis(Vec3 onto)
        {
            Vec3 projection = project(onto);
            x = projection.x; y = projection.y; z = projection.z;
            return this;
        }

        #endregion


        #region Operators

        public static Vec3 operator +(Vec3 a, Vec3 b)
        {
            return new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vec3 operator -(Vec3 a, Vec3 b)
        {
            return new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vec3 operator *(Vec3 a, double b)
        {
            return new Vec3(a.x * b, a.y * b, a.z * b);
        }

        public static Vec3 operator *(double a, Vec3 b)
        {
            return new Vec3(a * b.x, a * b.y, a * b.z);
        }

        public static Vec3 operator *(Vec3 a, Vec3 b)
        {
            return new Vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Vec3 operator /(Vec3 a, double b)
        {
            return a * (1f / b);
        }

        public static Vec3 operator -(Vec3 negate)
        {
            return new Vec3(-negate.x, -negate.y, -negate.z);
        }

        #endregion


        #region Swizzles

        public Vec2 xy => new Vec2(x, y);
        public Vec2 xz => new Vec2(x, z);
        public Vec2 yz => new Vec2(y, z);
        public Vec2 yx => new Vec2(y, x);
        public Vec2 zx => new Vec2(z, x);
        public Vec2 zy => new Vec2(z, y);

        #endregion
    }
}