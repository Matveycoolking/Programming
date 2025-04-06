using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programming.Model.Enums;

namespace Programming.Model
{
    public static class CollisionManager
    {
        public static bool IsCollision(Rectangle rectangle1, Rectangle rectangle2)
        {
            return Math.Abs(rectangle1.Center.X - rectangle2.Center.X) < (rectangle1.Width / 2 + rectangle2.Width / 2) &&
              Math.Abs(rectangle1.Center.Y - rectangle2.Center.Y) < (rectangle1.Height / 2 + rectangle2.Height / 2);
        }
        internal static bool IsCollision(Ring ring1, Ring ring2)
        {
            double distanceX = ring1.Center.X - ring2.Center.X;
            double distanceY = ring1.Center.Y - ring2.Center.Y;
            double distanceSquared = distanceX * distanceX + distanceY * distanceY;
            double radiusSum = ring1.OuterRadious + ring2.OuterRadious;

            return distanceSquared < (radiusSum * radiusSum);
        }
    }
}
