using UnityEngine;

namespace Game.Scripts.Player.PlayerCoin
{
    public class Coin : MonoBehaviour
    {
        public int coinOld;
        public void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                coinOld++;
                GetCoin.Coin.CoinNew(coinOld);
                Destroy(gameObject);
            }
        }
        
    }
}
