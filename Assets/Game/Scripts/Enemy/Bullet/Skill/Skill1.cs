using System;
using DG.Tweening;
using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Enemy.Bullet.Skill
{
    public class Skill1 :BulletController
    {
        private Tweener _tweener;
        protected override void Update()
        {
            base.Update();
           
        }

        public void DoAnimation()
        {
            Color color = Color.white;
            color.a = 0;
            var spriteRenderer = GetComponent<SpriteRenderer>();
            _tweener = spriteRenderer.DOColor(color, 2).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                HpEnemy hpEnemy = col.GetComponent<HpEnemy>();
                if (hpEnemy != null)
                {
                    hpEnemy.AttackDamage(15);
                    _tweener.Kill();
                    Destroy(gameObject);
                }
              
            }
        }
    }
}
