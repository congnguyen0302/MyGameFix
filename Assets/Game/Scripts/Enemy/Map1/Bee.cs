namespace Game.Scripts.Enemy.Map1
{
    public class Bee : Enemy
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
