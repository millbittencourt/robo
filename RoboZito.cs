using Robocode;
using System.Drawing;

namespace Mille
{
    class RoboZito : Robot
    {
        public override void Run()
        {
            SetAllColors(Color.MediumPurple);
            // SetColors(Color.AliceBlue, Color.BlueViolet, Color.DarkSalmon);
            BulletColor.Equals(Color.Red);

            TurnLeft(Heading - 90);

            while (true)
            {
                Ahead(4000);

                TurnRight(90);
                TurnGunRight(RadarHeading);
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            Fire(Rules.MAX_BULLET_POWER);
            //smartFire(e.Distance);
        }

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            TurnLeft(90);
            Ahead(5000);
        }

        public void smartFire(double robotDistance)
        {
            if (Energy < 15)
                Fire(1);
            else if (robotDistance > 200)
                Fire(2);
            else
                Fire(Rules.MAX_BULLET_POWER);
        }
    }
}
