using Game.Scripts.Enemy.Bullet;
using UnityEngine;

namespace Game.Scripts.Player.State
{
    public class Skill1State :PlayerState
    {
        public Skill1State(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            PlayerController.playerAnimation.PlayerSkill1();
        }

        public override void UpDate()
        {
            
        }

        public override void Exit()
        {
          
        }
        
    }
}
