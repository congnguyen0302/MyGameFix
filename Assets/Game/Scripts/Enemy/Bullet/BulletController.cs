using UnityEngine;
namespace Game.Scripts.Enemy.Bullet
{
    public abstract class BulletController : MonoBehaviour
    {
        public Animator animator;
        public StateBullet CurrentState;
        
        public IdleBullet IdleBullet;
        public BustBullet BustBullet;
        
        public Vector3 velocity;
        public float speedBullet;
        public Transform target;
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Bust = Animator.StringToHash("Bust");
        protected virtual void Awake()
        {
          
            IdleBullet = new IdleBullet(this);
            BustBullet = new BustBullet(this);
        }
        protected virtual void Start()
        {
            ChangeState(IdleBullet);
        }

        protected virtual void Update()
        {
            transform.position += velocity * Time.deltaTime;
            CurrentState?.Update();
        }

        public void ChangeState(StateBullet newState)
        {
            if(newState==null){return;}
            if(newState == CurrentState){return;}
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
        }

        public void IdleBulletAnim()
        {
            animator.SetTrigger(Idle);
        }

        public void BustBulletAnim()
        {
            animator.SetTrigger(Bust);
        }
        public void TurnBackBullet()
        {
            var position = target.transform.position;
            var position1 = transform.position;
            velocity = (position - position1).normalized * speedBullet;
            var dir = position - position1;
            transform.right = Vector3.right * Mathf.Sign(dir.x);
            Destroy(gameObject,3);
        }
        
        public void DestroyBullet()
        {
            Destroy(gameObject);
        }
      

    }
}
