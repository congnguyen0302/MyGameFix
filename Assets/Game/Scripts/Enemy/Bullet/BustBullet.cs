using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Enemy.Bullet
{
    public class BustBullet : StateBullet
    {
        public BustBullet(BulletController bulletController) : base(bulletController)
        {
        }

        public override void Enter()
        {
            BulletController.BustBulletAnim();
        }

        public override void Update()
        {
           
        }

        public override void Exit()
        {
            
        }
    }
}
