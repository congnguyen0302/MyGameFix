using UnityEngine;

namespace Game.Scripts.Player.State
{
    public class AttackState :PlayerState
    {
        public AttackState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            PlayerController.playerAnimation.PlayerAttack();
        }

        public override void UpDate()
        {
            PlayerController.Skill1();
        }

        public override void Exit()
        {
            
        }
    }
}
