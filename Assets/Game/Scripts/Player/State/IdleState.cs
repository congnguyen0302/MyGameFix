using Game.Scripts.Enemy;
using UnityEngine;

namespace Game.Scripts.Player.State
{
    public class IdleState :PlayerState
    {
        public IdleState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
           PlayerController.playerAnimation.PlayerIdle();
           PlayerController.gameObject.layer = LayerMask.NameToLayer("Player");
        }

        public override void UpDate()
        {
            if (PlayerController.rgb2D.velocity.magnitude > 0.1)
           { 
               PlayerController.ChangeState(PlayerController.RunState);
           } 
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
