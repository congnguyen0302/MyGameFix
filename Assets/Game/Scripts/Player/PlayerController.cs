using System;
using System.Collections.Generic;
using Game.Scripts.Enemy.Bullet;
using Game.Scripts.Enemy.Bullet.Skill;
using Game.Scripts.Player.NextMap;
using Game.Scripts.Player.PlayerCoin;
using Game.Scripts.Player.State;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;
        public PlayerAnimation playerAnimation;
        public PlayerState CurrentState;
        public List<Mission.Mission> missions;
        [HideInInspector] public Vector3 velocity;
        [HideInInspector] public Rigidbody2D rgb2D;
        [HideInInspector] public ExpPlayer expPlayer;
        
        public float speedPlayer;
        public float jumpPlayer;
        public int attackDamage;

        public IdleState IdleState;
        public RunState RunState;
        public JumpState JumpState;
        public AttackState AttackState;
        public Skill1State Skill1State;
        public HitState HitState;
        public DieState DieState;

        [HideInInspector] public HpPlayer hpPlayer;
        public BulletController bulletController;
        public GameObject skill1;
        public Action<Collision2D> OnCollision2D;
        public Transform neverDie;

        public Transform oldPos;
        public Transform newPos;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
            neverDie.position = transform.position;
            gameObject.layer = LayerMask.NameToLayer("Player");
            playerAnimation = GetComponent<PlayerAnimation>();
            hpPlayer = GetComponent<HpPlayer>();
            rgb2D = GetComponent<Rigidbody2D>();
            expPlayer = GetComponent<ExpPlayer>();
            IdleState = new IdleState(this);
            RunState = new RunState(this);
            JumpState = new JumpState(this);
            AttackState = new AttackState(this);
            Skill1State = new Skill1State(this);
            HitState = new HitState(this);
            DieState = new DieState(this);
        }

        private void Start()
        {
            LoadData();
            ChangeState(IdleState);
        }
        private void Update()
        {
            if (hpPlayer.hpCurrent <= 0)
            {
                ChangeState(DieState);
            }

            if (Input.GetKey(KeyCode.Z))
            {
                NewGame();
            }
            CurrentState?.UpDate();
        }

        private void OnDestroy()
        {
            SaveData();
        }

        public void ChangeState(PlayerState newState)
        {
            if (newState==null){return;}
            if(newState==CurrentState){return;}
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
        }
        public void HorizontalHandle()
        {
            var horizontal = 0;
            if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1;
            }
           else if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1;
            }
            else
            {
                horizontal = 0;
            }

            if (horizontal != 0)
            {
                transform.forward = horizontal * Vector3.forward;
            }

            velocity = rgb2D.velocity;
            velocity.x = horizontal * speedPlayer;
            rgb2D.velocity = velocity;
        }
        public void PlayerJump()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                ChangeState(JumpState);
            }
        }
        public void OnCollisionEnter2D(Collision2D col)
        {
            OnCollision2D?.Invoke(col);
        }

        public void PlayerAttack()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeState(AttackState);
            }
        }
        public void Skill1()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                ChangeState(Skill1State);
            }
        }

        public void NeverDie()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                transform.position = neverDie.position;
                hpPlayer.hpCurrent = hpPlayer.hpStart;
                hpPlayer.hpStart = hpPlayer.hpCurrent;
                ChangeState(IdleState);
            }
        }
        public void InstantiateSkill1()
        { 
            BulletController bullet = Instantiate(bulletController,skill1.transform.position, quaternion.identity);
            bullet.velocity.x = transform.right.x * bulletController.speedBullet;
            bullet.transform.right = transform.right;
            (bullet as Skill1)?.DoAnimation();
            
           // bullet.transform.DOScale(Vector3.one * 1.1f, 0.99f)
                //.SetEase(Ease.OutQuad);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("currentHp",hpPlayer.hpCurrent);
            PlayerPrefs.SetString("textHp",hpPlayer.text.text);
            PlayerPrefs.SetInt("hpStart",hpPlayer.hpStart);
            
            PlayerPrefs.SetInt("coinOld",GetCoin.Coin.getCoin);
            PlayerPrefs.SetString("textCoin",GetCoin.Coin.text.text);
            
            PlayerPrefs.SetInt("exp",ExpPlayer.Instance.currentExp);
            PlayerPrefs.SetString("textExp",ExpPlayer.Instance.text.text);
            PlayerPrefs.SetInt("expMax",ExpPlayer.Instance.expMax);
            PlayerPrefs.SetInt("level",ExpPlayer.Instance.level);
            
            PlayerPrefs.SetInt("attackDamage",attackDamage);
        }

        public void LoadData()
        {
            int hp = PlayerPrefs.GetInt("currentHp", hpPlayer.hpStart);
            hpPlayer.hpCurrent = hp;
            hpPlayer.SetHp(hp);
            int hpNew = PlayerPrefs.GetInt("hpStart", hpPlayer.hpStart);
            hpPlayer.SetMaxHp(hpNew);
            string textHp = PlayerPrefs.GetString("textHp",hpPlayer.text.text);
            hpPlayer.text.text = textHp;
            
            int coinNew = PlayerPrefs.GetInt("coinOld",GetCoin.Coin.getCoin);
            GetCoin.Coin.getCoin = coinNew;
            string textCoin = PlayerPrefs.GetString("textCoin",GetCoin.Coin.text.text);
            GetCoin.Coin.text.text = textCoin;
            
            int exp = PlayerPrefs.GetInt("exp",ExpPlayer.Instance.currentExp);
            ExpPlayer.Instance.currentExp = exp;
            string textExp = PlayerPrefs.GetString("textExp", ExpPlayer.Instance.text.text);
            ExpPlayer.Instance.text.text = textExp;
            int expMax = PlayerPrefs.GetInt("expMax", ExpPlayer.Instance.expMax);
            ExpPlayer.Instance.expMax = expMax;
            int level = PlayerPrefs.GetInt("level", ExpPlayer.Instance.level);
            ExpPlayer.Instance.level = level;
            
            int atkDamage = PlayerPrefs.GetInt("attackDamage",attackDamage);
            attackDamage = atkDamage;
        }

        public void NewGame()
        {
            hpPlayer.hpCurrent = 1000;
            hpPlayer.hpStart = 1000;
            ExpPlayer.Instance.level = 1;
            ExpPlayer.Instance.text.text = "Lv1";  
            ExpPlayer.Instance.currentExp = 0;
            ExpPlayer.Instance.expMax = 100;
            GetCoin.Coin.getCoin = 0;
            GetCoin.Coin.text.text = "0";
        }

        public void ResetPos()
        {
            if (LevelManager.Instance.currentLevelIndex < LevelManager.Instance.oldCurrentLevelIndex)
            {
                transform.position = oldPos.transform.position;
            }
            else if (LevelManager.Instance.currentLevelIndex > LevelManager.Instance.oldCurrentLevelIndex)
            {
                transform.position = newPos.transform.position;
            }
        }

    }
}
