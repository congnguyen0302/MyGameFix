
using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Enemy.Bullet.BulletDragon
{
    public class BulletDragon :BulletController
    {
        private BulletIdleDragon _bulletIdleDragon;
        private BulletBustDragon _bulletBustDragon;
        protected override void Awake()
        {
            base.Awake();
            _bulletIdleDragon = new BulletIdleDragon(this);
            _bulletBustDragon = new BulletBustDragon(this);
            BustBullet = _bulletBustDragon;
            IdleBullet = _bulletIdleDragon;
        }
        protected override void Start()
        {
            base.Start();
            ChangeState(IdleBullet);
        }

        protected override void Update()
        {
            base.Update();
            transform.position += velocity * Time.deltaTime;
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                HpPlayer hpPlayer = col.GetComponent<HpPlayer>();
                if (hpPlayer != null)
                { 
                    hpPlayer.AttackDamagePlayer(10);
                }
                ChangeState(BustBullet);
            }
            else
            {
                Destroy(gameObject,4);
            }

        }
        
    }
}
