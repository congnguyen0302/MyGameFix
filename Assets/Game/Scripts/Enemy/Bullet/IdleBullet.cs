
namespace Game.Scripts.Enemy.Bullet
{
    public class IdleBullet :StateBullet
    {
        public IdleBullet(BulletController bulletController) : base(bulletController)
        {
        }

        public override void Enter()
        {
            BulletController.IdleBulletAnim();
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
