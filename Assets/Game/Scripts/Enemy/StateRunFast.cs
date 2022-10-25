using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class StateRunFast : StateEnemy
    {
        public StateRunFast(Enemy enemy) : base(enemy)
        {
        }

        public override void Enter()
        {
            Enemy.RunFastAnim();
        }
        public override void Update()
        {
            
        }

        public override void Exit()
        {
           
        }
    }
}
