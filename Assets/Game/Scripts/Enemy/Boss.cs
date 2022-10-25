using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class Boss : Enemy
    {
        protected override void Update()
        {
            base.Update();
            var col = Physics2D.OverlapCircleAll(transform.position, enemyRange);
            Transform targetemp = null;
            foreach (var collisions in col)
            {
                if (collisions.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    targetemp = collisions.transform;
                }
                target = targetemp;
                if (target != null)
                {
                  
                }
            }
        }
    }
}
