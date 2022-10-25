using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Player
{
    public class ExpPlayer : MonoBehaviour
    {
        public static ExpPlayer Instance;
        public TextMeshProUGUI text;
        public Slider slider;
        public int level;
        public int expMax;
        public int currentExp;

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
            level = 1;
            text.text = "Lv1";
            //slider.value = 0;
            expMax = 100;
        }

        private void Update()
        {
            slider.value = currentExp;
            slider.maxValue = expMax;
            if (currentExp >= slider.maxValue)
            {
                level++;
                currentExp = 0;
                expMax += 50;
                text.text = "Lv" + level.ToString();
                PlayerController.Instance.attackDamage += 2;
                PlayerController.Instance.hpPlayer.slider.maxValue += 50;
                PlayerController.Instance.hpPlayer.hpStart += 50;

            }
        }
        
    }
}
