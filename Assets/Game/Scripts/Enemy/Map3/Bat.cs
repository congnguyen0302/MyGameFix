
namespace Game.Scripts.Enemy
{
    public class Bat : Enemy
    {
        protected override void Awake()
        {
            base.Awake();
            ChangeState(GoRightEnemy);
        }

        protected override void Update()
        {
            base.Update();
            if (hpEnemy.currentHp <= 0)
            {
                ChangeState(DieEnemy);
            }
        }
    }
}
