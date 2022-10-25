using UnityEngine;

namespace Game.Scripts.Player
{
    public abstract class PlayerState
    {
        public PlayerController PlayerController;

        public PlayerState(PlayerController playerController)
        {
            PlayerController = playerController;
        }

        public abstract void Enter();
        public abstract void UpDate();
        public abstract void Exit();
    }
}
