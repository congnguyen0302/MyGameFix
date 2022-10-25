using UnityEngine;

namespace Game.Scripts.Player.State
{
    public class RunState : PlayerState
    {
        public RunState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            PlayerController.playerAnimation.PlayerRun();
        }

        public override void UpDate()
        {
            if (PlayerController.rgb2D.velocity.magnitude <= 0.01)
           {
               PlayerController.ChangeState(PlayerController.IdleState);
           }
            PlayerController.HorizontalHandle();
            PlayerController.PlayerJump();
            PlayerController.PlayerAttack();
            PlayerController.Skill1();
        }

        public override void Exit()
        {
            //todo
        }
    }
}
