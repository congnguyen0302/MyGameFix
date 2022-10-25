namespace Game.Scripts.Enemy.Bullet.BulletDragon
{
    public class BulletBustDragon : BustBullet
    {
        public BulletBustDragon(BulletController bulletController) : base(bulletController)
        {
        }

        public override void Enter()
        {
            base.Enter();
            BulletController.BustBulletAnim();
        }
    }
}
