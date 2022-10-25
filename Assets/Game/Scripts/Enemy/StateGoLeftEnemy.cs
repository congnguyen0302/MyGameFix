
namespace Game.Scripts.Enemy
{
    public class StateGoLeftEnemy : StateEnemy
    {
        public StateGoLeftEnemy(Enemy enemy) : base(enemy)
        {
        }

        public override void Enter()
        {
           Enemy.RunEnemyAnim();
        }

        public override void Update()
        {
            Enemy.GotoLeft();
            if (Enemy.transform.position.x <= Enemy.thePoint2.transform.position.x)
            {
                Enemy.ChangeState(Enemy.GoRightEnemy);
            }
        }

        public override void Exit()
        {
            
        }
    }
}
