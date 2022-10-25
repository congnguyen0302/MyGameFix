
namespace Game.Scripts.Enemy.Map3
{
    public class Skeleton :Enemy
    {
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();
            if (hpEnemy.currentHp <= 0)
            {
                ChangeState(DieEnemy);
                return;
            }
            TagPlayer();

        }
    }
}
