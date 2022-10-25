using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class Bat2 : Enemy
    {
        protected override void Update()
        {
            base.Update();
            if (hpEnemy.currentHp <= 0)
            {
                ChangeState(DieEnemy);
            }
        }
    }
}
