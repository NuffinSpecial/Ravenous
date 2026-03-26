using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene_Transitions
{
    public class MainTitle : MonoBehaviour
    { 
        public void PlayGame()
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
}
