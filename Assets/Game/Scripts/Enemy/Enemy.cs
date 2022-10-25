using Game.Scripts.Enemy.Bullet;
using Game.Scripts.Player;
using Unity.Mathematics;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

namespace Game.Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        protected StateEnemy CurrentState;
        public EnemyType enemyType;
        public ParticleSystem effect;
        public int damageAttack;
        public Animator animator;
        public int expEnemy;
        
        public StateAttackEnemy AttackEnemy;
        public StateDieEnemy DieEnemy;
        public StateGoLeftEnemy GoLeftEnemy;
        public StateGoRightEnemy GoRightEnemy;
        public StateRunFast RunFastEnemy;
        
        public float speedEnemy;
        public Transform thePoint1;
        public Transform thePoint2;
        public float enemyRange;
        public Transform target;
        public float speedAttack;
        
        public HpEnemy hpEnemy;
        public Transform startFire;
        public GameObject obj;
        public BulletController bulletController;
        public GameObject coin;
        
        
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int RunFast = Animator.StringToHash("RunFast");

        protected virtual void Awake()
        {
            animator = GetComponent<Animator>();
            AttackEnemy = new StateAttackEnemy(this);
            DieEnemy = new StateDieEnemy(this);
            GoLeftEnemy = new StateGoLeftEnemy(this);
            GoRightEnemy = new StateGoRightEnemy(this);
            RunFastEnemy = new StateRunFast(this);
        }

        protected virtual void Start()
        {
            ChangeState(GoRightEnemy);
        }

        protected virtual void Update()
        {
            CurrentState?.Update();
        }

        public void ChangeState(StateEnemy newState)
        {
            if (newState == null)
            {
                return;
            }

            if (newState == CurrentState)
            {
                return;
            }

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
        }

        public void GotoLeft()
        {
            var transform1 = transform;
            transform1.position += Vector3.left * (speedEnemy * Time.deltaTime);
            transform1.forward = -1 * Vector3.forward;
        }
        public void GotoRight()
        {
            var transform1 = transform;
            transform1.position += Vector3.right * (speedEnemy * Time.deltaTime);
            transform1.forward = 1 * Vector3.forward;
        }
        public void RunEnemyAnim()
        {
            animator.SetTrigger(Run);
        }
        public void AttackEnemyAnim()
        {
           animator.SetTrigger(Attack);
        }
        public void DieEnemyAnim()
        {
            animator.SetTrigger(Die);
        }

        public void RunFastAnim()
        {
            animator.SetTrigger(RunFast);
        }
        public void TurnBack()
        {
            var dir = target.transform.position - transform.position;
            transform.right = Vector3.right * Mathf.Sign(dir.x);
        }
        public void TagPlayer()
        {
            var col = Physics2D.OverlapCircleAll(transform.position, enemyRange);
            Transform targetemp = null;
            foreach (var collisions in col)
            {
                if (collisions.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    targetemp = collisions.transform;
                }
                target = targetemp;
                if (target != null)
                {
                    ChangeState(AttackEnemy);
                    TurnBack();
                }
            }
        }
        public void HideEnemy()
        {
            obj.SetActive(false);
        }
        public void DamagePlayer()
        {
           
            if (PlayerController.Instance.hpPlayer != null)
            { 
                PlayerController.Instance.hpPlayer.AttackDamagePlayer(damageAttack);
                //effect.Play();
            }
        }
        public void GetCoin()
        {
            Object Getcoin = Instantiate(coin,transform.position,quaternion.identity);
        }
        public virtual void GetXp()
        {
            PlayerController.Instance.expPlayer.currentExp+=expEnemy;
        }

        public enum EnemyType
        {
            None,
            FireDragon
        }
        
    }
}
