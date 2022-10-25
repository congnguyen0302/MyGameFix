using System;
using Game.Scripts.Enemy;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class AttackDamage : MonoBehaviour
    {
        public PlayerController playerController;
        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
        }
        public void FinishAttack()
        {
            if (playerController.rgb2D.velocity.magnitude > 0.1)
            {
                playerController.ChangeState(playerController.RunState);
            }
            else
            {
                playerController.ChangeState(playerController.IdleState);
            }
           // playerController.ChangeState(playerController.IdleState);
        }

        public void AttackEnemy()
        {
            var col = Physics2D.OverlapCircleAll(playerController.transform.position, 1);
            foreach (var collistion2D in col)
            {
                if (collistion2D.CompareTag("Enemy"))
                {
                    Vector2 dir = collistion2D.transform.position - playerController.transform.position;
                    if (dir.x * playerController.transform.right.x > 0)
                    {
                        HpEnemy hpEnemy = collistion2D.GetComponent<HpEnemy>();
                        if (hpEnemy != null)
                        {
                            hpEnemy.AttackDamage(PlayerController.Instance.attackDamage);
                        }
                    }
                }
            }
        }
    }
}
