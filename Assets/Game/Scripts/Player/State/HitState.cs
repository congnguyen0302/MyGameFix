using UnityEngine;

namespace Game.Scripts.Player.State
{
    public class HitState : PlayerState
    {
        public HitState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            PlayerController.playerAnimation.PlayerHit();
        }

        public override void UpDate()
        {
            PlayerController.HorizontalHandle();
            PlayerController.PlayerAttack();
            PlayerController.PlayerJump();
            PlayerController.Skill1();
        }

        public override void Exit()
        {
            
        }
    }
}
