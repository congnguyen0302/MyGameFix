using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Animator animator;
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Skill1 = Animator.StringToHash("Skill1");
        private static readonly int Hit = Animator.StringToHash("Hit");

        public void PlayerRun()
        {
            animator.SetTrigger(Run);
        }

        public void PlayerAttack()
        {
            animator.SetTrigger(Attack);
        }

        public void PlayerIdle()
        {
            animator.SetTrigger(Idle);
        }

        public void PlayerDie()
        {
            animator.SetTrigger(Die);
        }

        public void PlayerJump()
        {
            animator.SetTrigger(Jump);
        }

        public void PlayerSkill1()
        {
            animator.SetTrigger(Skill1);
        }

        public void PlayerHit()
        {
            animator.SetTrigger(Hit);
        }
    }
}
