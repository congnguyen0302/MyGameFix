using UnityEngine;
using UnityEngine.SceneManagement;
namespace Game.Scripts.Player.NextMap
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        public int currentLevelIndex = 0;
        public int oldCurrentLevelIndex;
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
            DontDestroyOnLoad(gameObject);
        }

        public void LoadNextScene(int newLevelIndex)
        {
            oldCurrentLevelIndex = currentLevelIndex;
            currentLevelIndex = newLevelIndex;
            SceneManager.LoadSceneAsync(currentLevelIndex);
            
        }
        
        
        
        
    }
}
