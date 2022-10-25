using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Player
{
    public class HpPlayer : MonoBehaviour
    {
        public Slider slider;
        public int hpStart;
        public int hpCurrent;
        public ParticleSystem effect;
        public TextMeshProUGUI text;
        [HideInInspector] public PlayerController playerController;

        private void Awake()
        {
            slider.maxValue = hpStart;
            slider.value = hpStart;
            hpCurrent = hpStart;
            playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            text.text = hpCurrent.ToString()+" / "+hpStart.ToString();
            
        }
        public void AttackDamagePlayer(int damage)
        {
            hpCurrent -= damage;
            slider.value = hpCurrent;
            effect.Play();
            playerController.ChangeState(playerController.HitState);
        }

        public void FinishHitState()
        {
            playerController.ChangeState(playerController.IdleState);
        }

        public void SetHp(int newHp)
        {
            hpCurrent = newHp;
            slider.value = hpCurrent;
        }

        public void SetMaxHp(int maxHp)
        {
            hpStart = maxHp;
            slider.maxValue = hpStart;
        }
    }
}
