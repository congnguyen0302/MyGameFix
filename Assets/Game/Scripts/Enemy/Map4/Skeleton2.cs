
namespace Game.Scripts.Enemy.Map4
{
    public class Skeleton2 : Enemy
    {
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
