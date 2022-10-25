using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class StateGoRightEnemy : StateEnemy
    {
        public StateGoRightEnemy(Enemy enemy) : base(enemy)
        {
        }

        public override void Enter()
        {
            Enemy.RunEnemyAnim();
        }
        public override void Update()
        {
            Enemy.GotoRight();
            if (Enemy.transform.position.x >= Enemy.thePoint1.transform.position.x)
            {
                Enemy.ChangeState(Enemy.GoLeftEnemy);
            }
        }
        public override void Exit()
        {
            
        }
    }
}
