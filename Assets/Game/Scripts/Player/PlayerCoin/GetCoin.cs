using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Player.PlayerCoin
{
    public class GetCoin : MonoBehaviour
    {
        public static GetCoin Coin;
        public TextMeshProUGUI text;
        public int getCoin;

        private void Awake()
        {
            if (Coin == null)
            {
                Coin = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void CoinNew(int coinNew)
        {
            getCoin += coinNew;
            text.text = getCoin.ToString();
        }
    }
}
