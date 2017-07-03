using System;
using System.Collections.Generic;
using physNet.physBase.Collision;
using physNet.physUtil.MathObjects;

namespace physNet_testing.DetectionTest
{
    class CollisionShapeTests
    {
        public static void BoxSupportTests()
        {
            CollisionShape cs1 = CollisionShape.CreateBox(new Vec2(1));

            Vec2 test1 = Vec2.XAxis;
            Vec2 test2 = Vec2.YAxis;
            Vec2 test3 = Vec2.One.normalized;
            Vec2 test4 = Vec2.fromAngle(3.1415926 * (1.0 / 4.0));
            Vec2 test5 = Vec2.fromAngle(3.1415926 * (3.0 / 4.0));
            Vec2 test6 = Vec2.fromAngle(3.1415926 * (5.0 / 4.0));
            Vec2 test7 = Vec2.fromAngle(3.1415926 * (7.0 / 4.0));

            Vec2 test8 = Vec2.fromAngle(3.1415926 * (1.0 / 6.0));
            Vec2 test9 = Vec2.fromAngle(3.1415926 * (5.0 / 6.0));
            Vec2 test10 = Vec2.fromAngle(3.1415926 * (7.0 / 6.0));
            Vec2 test11 = Vec2.fromAngle(3.1415926 * (11.0 / 6.0));

            Console.WriteLine(cs1.Support(test1, 0));
            Console.WriteLine(cs1.Support(test2, 0));
            Console.WriteLine(cs1.Support(test3, 0));
            Console.WriteLine(cs1.Support(test4, 0));
            Console.WriteLine(cs1.Support(test5, 0));
            Console.WriteLine(cs1.Support(test6, 0));
            Console.WriteLine(cs1.Support(test7, 0));
            Console.WriteLine(cs1.Support(test8, 0));
            Console.WriteLine(cs1.Support(test9, 0));
            Console.WriteLine(cs1.Support(test10, 0));
            Console.WriteLine(cs1.Support(test11, 0));

            Console.WriteLine();

            Console.WriteLine(cs1.Support(test1, Math.PI / 4));
            Console.WriteLine(cs1.Support(test2, Math.PI / 4));
            Console.WriteLine(cs1.Support(test3, Math.PI / 4));
            Console.WriteLine(cs1.Support(test4, Math.PI / 4));
            Console.WriteLine(cs1.Support(test5, Math.PI / 4));
            Console.WriteLine(cs1.Support(test6, Math.PI / 4));
            Console.WriteLine(cs1.Support(test7, Math.PI / 4));
            Console.WriteLine(cs1.Support(test8, Math.PI / 4));
            Console.WriteLine(cs1.Support(test9, Math.PI / 4));
            Console.WriteLine(cs1.Support(test10, Math.PI / 4));
            Console.WriteLine(cs1.Support(test11, Math.PI / 4));
        }

        public static void CircleSupportTests()
        {
            CollisionShape cs1 = CollisionShape.CreateCircle(3);
            Vec2 test1 = Vec2.XAxis;
            Vec2 test2 = Vec2.YAxis;
            Vec2 test3 = Vec2.One.normalized;
            Vec2 test4 = Vec2.fromAngle(3.1415926 * (1.0 / 4.0));
            Vec2 test5 = Vec2.fromAngle(3.1415926 * (3.0 / 4.0));
            Vec2 test6 = Vec2.fromAngle(3.1415926 * (5.0 / 4.0));
            Vec2 test7 = Vec2.fromAngle(3.1415926 * (7.0 / 4.0));

            Vec2 test8 = Vec2.fromAngle(3.1415926 * (1.0 / 6.0));
            Vec2 test9 = Vec2.fromAngle(3.1415926 * (5.0 / 6.0));
            Vec2 test10 = Vec2.fromAngle(3.1415926 * (7.0 / 6.0));
            Vec2 test11 = Vec2.fromAngle(3.1415926 * (11.0 / 6.0));

            Console.WriteLine(cs1.Support(test1, 0));
            Console.WriteLine(cs1.Support(test2, 0));
            Console.WriteLine(cs1.Support(test3, 0));
            Console.WriteLine(cs1.Support(test4, 0));
            Console.WriteLine(cs1.Support(test5, 0));
            Console.WriteLine(cs1.Support(test6, 0));
            Console.WriteLine(cs1.Support(test7, 0));
            Console.WriteLine(cs1.Support(test8, 0));
            Console.WriteLine(cs1.Support(test9, 0));
            Console.WriteLine(cs1.Support(test10, 0));
            Console.WriteLine(cs1.Support(test11, 0));
        }

        public static void PolySupportTests()
        {
            CollisionShape cs1;
            {
                List<Vec2> plist = new List<Vec2>();
                //not-so-regular hexagon
                plist.Add(new Vec2(1.5, 0));
                plist.Add(new Vec2(0.5, 1));
                plist.Add(new Vec2(-0.5, 1));
                plist.Add(new Vec2(-1.5, 0));
                plist.Add(new Vec2(-0.5, -1));
                plist.Add(new Vec2(0.5, -1));
                cs1 = CollisionShape.CreatePolygon(plist);
            }


            Vec2 test1 = Vec2.XAxis;
            Vec2 test2 = Vec2.YAxis;
            Vec2 test3 = Vec2.One.normalized;
            Vec2 test4 = Vec2.fromAngle(3.1415926 * (1.0 / 4.0));
            Vec2 test5 = Vec2.fromAngle(3.1415926 * (3.0 / 4.0));
            Vec2 test6 = Vec2.fromAngle(3.1415926 * (5.0 / 4.0));
            Vec2 test7 = Vec2.fromAngle(3.1415926 * (7.0 / 4.0));

            Vec2 test8 = Vec2.fromAngle(3.1415926 * (1.0 / 6.0));
            Vec2 test9 = Vec2.fromAngle(3.1415926 * (5.0 / 6.0));
            Vec2 test10 = Vec2.fromAngle(3.1415926 * (7.0 / 6.0));
            Vec2 test11 = Vec2.fromAngle(3.1415926 * (11.0 / 6.0));

            Console.WriteLine(cs1.Support(test1, 0));
            Console.WriteLine(cs1.Support(test2, 0));
            Console.WriteLine(cs1.Support(test3, 0));
            Console.WriteLine(cs1.Support(test4, 0));
            Console.WriteLine(cs1.Support(test5, 0));
            Console.WriteLine(cs1.Support(test6, 0));
            Console.WriteLine(cs1.Support(test7, 0));
            Console.WriteLine(cs1.Support(test8, 0));
            Console.WriteLine(cs1.Support(test9, 0));
            Console.WriteLine(cs1.Support(test10, 0));
            Console.WriteLine(cs1.Support(test11, 0));
        }

        public static void Main(string[] args)
        {
            PolySupportTests();
            Console.ReadLine();
        }
    }
}
