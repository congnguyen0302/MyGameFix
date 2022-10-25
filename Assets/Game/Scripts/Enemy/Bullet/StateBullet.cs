using UnityEngine;

namespace Game.Scripts.Enemy.Bullet
{
    public abstract class StateBullet
    {
        public BulletController BulletController;

        public StateBullet(BulletController bulletController)
        {
            BulletController = bulletController;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();

    }
}
