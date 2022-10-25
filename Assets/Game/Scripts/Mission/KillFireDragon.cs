
using Tool;
namespace Game.Scripts.Mission
{
    public class KillFireDragon : Mission
    {
        public Enemy.Enemy.EnemyType monsterType;
        public override void Awake()
        {
            base.Awake();
            this.RegisterListener(EventID.EnemyDie, (monsterSender, param) =>
            {
                var enemy = monsterSender as Enemy.Enemy;
                if (enemy != null && enemy.enemyType == monsterType)
                {
                    DoneAPart();
                }
            });
        }
    }
}
