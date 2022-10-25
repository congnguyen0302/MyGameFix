
using UnityEngine;

namespace Game.Scripts.Player.State
{
    public class JumpState : PlayerState
    {
        public Vector2 Velocity;
        public JumpState(PlayerController playerController) : base(playerController)
        {
            PlayerController.OnCollision2D += collision2D =>
            {
             PlayerController.ChangeState(PlayerController.IdleState);
            };
        }

        public override void Enter()
        {
            PlayerController.playerAnimation.PlayerJump();
            Velocity = PlayerController.rgb2D.velocity;
            Velocity.y = PlayerController.jumpPlayer;
            PlayerController.rgb2D.velocity = Velocity;
        }

        public override void UpDate()
        {
           PlayerController.HorizontalHandle();
           PlayerController.PlayerJump();
           PlayerController.PlayerAttack();
           PlayerController.Skill1();
        }

        public override void Exit()
        {
            
        }
    }
}
