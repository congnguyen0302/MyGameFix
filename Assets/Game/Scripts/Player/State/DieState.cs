using UnityEngine;

namespace Game.Scripts.Player.State
{
    public class DieState : PlayerState
    {
        public DieState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            PlayerController.playerAnimation.PlayerDie();
            PlayerController.gameObject.layer = LayerMask.NameToLayer("Enemy");
            PlayerController.hpPlayer.hpCurrent = 0;
            PlayerController.hpPlayer.slider.value = 0;
            PlayerController.hpPlayer.text.text = "0";
        }

        public override void UpDate()
        {
            PlayerController.NeverDie();
        }
        public override void Exit()
        {
            
        }
    }
}
