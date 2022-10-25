using UnityEngine;

namespace Game.Scripts.Enemy
{
    public abstract class StateEnemy
    {
        public Enemy Enemy;

        public StateEnemy(Enemy enemy)
        {
            Enemy = enemy;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
        
    }
}
