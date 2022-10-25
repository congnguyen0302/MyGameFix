using Tool;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class StateDieEnemy :StateEnemy
    {
        public StateDieEnemy(Enemy enemy) : base(enemy)
        {
        }

        public override void Enter()
        {
            Enemy.PostEvent(EventID.EnemyDie);
            Enemy.DieEnemyAnim();
            Enemy.SendMessage("GetXp");
        }

        public override void Update()
        {
           
        }

        public override void Exit()
        {
            
        }
    }
}
