using Game.Scripts.Enemy.Bullet;
using UnityEngine;

namespace Game.Scripts.Enemy.Map1
{
    public class DragonFire : Enemy
    {
        private DragonAttack _dragonAttack;
        protected override void Awake()
        {
            base.Awake();
            _dragonAttack = new DragonAttack(this);
            AttackEnemy = _dragonAttack;
        }

        protected override void Update()
        {
            base.Update();
            if (hpEnemy.currentHp <= 0)
            {
                ChangeState(DieEnemy);
                coin.SetActive(true);
                return;
            }
           
            TagPlayer();
        }
        public void InstantiateBullet()
        {
            BulletController bullet =
                Object.Instantiate(bulletController,startFire.transform.position, Quaternion.identity);
            bullet.target =target;
            bullet.TurnBackBullet();
        }

    }
}
