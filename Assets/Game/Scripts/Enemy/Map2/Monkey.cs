
using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Enemy.Map2
{
    public class Monkey : Enemy
    {
        private MonkeyAttack _monkeyAttack;
       
        protected override void Awake()
        {
            base.Awake();
            _monkeyAttack = new MonkeyAttack(this);
            AttackEnemy = _monkeyAttack;
            ChangeState(GoRightEnemy);
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
            if (hpEnemy.currentHp <= 0)
            {
                ChangeState(DieEnemy);
                return;
            }
            TagPlayer();
            
        }

       
    }
}
