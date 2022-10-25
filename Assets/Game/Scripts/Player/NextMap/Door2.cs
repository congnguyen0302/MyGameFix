using UnityEngine;

namespace Game.Scripts.Player.NextMap
{
    public class Door2 : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                LevelManager.Instance.LoadNextScene(LevelManager.Instance.currentLevelIndex - 1);
            }
        }
    }
}
