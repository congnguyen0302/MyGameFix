
namespace Game.Scripts.Enemy.Bullet.BulletDragon
{
    public class BulletIdleDragon :IdleBullet
    {
        public BulletIdleDragon(BulletController bulletController) : base(bulletController)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            BulletController.IdleBulletAnim();
        }
    }
}
