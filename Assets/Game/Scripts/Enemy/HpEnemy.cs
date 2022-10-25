
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Enemy
{
    public class HpEnemy : MonoBehaviour
    {
        public Slider hpSlider;
        public int currentHp;
        public int startHp;
        public GameObject obj;
        public ParticleSystem effect;
        public float showingTime = 3f;
        private Coroutine _hideMeCoroutine;
        private void Awake()
        {
            hpSlider.maxValue = startHp;
            hpSlider.value = startHp;
            currentHp = startHp;
            obj.SetActive(false);
            
        }
        public void AttackDamage(int damage)
        {
            obj.SetActive(true);
            currentHp -= damage;
            effect.Play();
            hpSlider.value = currentHp;
            if (_hideMeCoroutine == null)
            {
                _hideMeCoroutine = StartCoroutine(IEHideMe());
            }
            else
            {
                StopCoroutine(_hideMeCoroutine);
                _hideMeCoroutine = StartCoroutine(IEHideMe());
            }
            
        }

        private IEnumerator IEHideMe()
        {
            yield return new WaitForSeconds(showingTime);
            obj.SetActive(false);
            _hideMeCoroutine = null;
        }
    }
}
