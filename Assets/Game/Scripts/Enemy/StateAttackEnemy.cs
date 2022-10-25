using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class StateAttackEnemy : StateEnemy
    {
        public float AttackTime;
        public StateAttackEnemy(Enemy enemy) : base(enemy)
        {
            
        }
        public override void Enter()
        {
            Enemy.AttackEnemyAnim();
            AttackTime = 0;
        }
        public override void Update()
        {
            if (Enemy.target == null)
            {
                Enemy.ChangeState(Enemy.GoRightEnemy);
            }
            AttackTime += Time.deltaTime;
            if (AttackTime >= 1 / Enemy.speedAttack)
            {
                AttackTime = 0;
            }
        }

        public override void Exit()
        {
           
        }
    }
}
