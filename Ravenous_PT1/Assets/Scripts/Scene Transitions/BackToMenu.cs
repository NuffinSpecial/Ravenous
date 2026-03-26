using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene_Transitions
{
    public class Exit : MonoBehaviour
    { 
        public void MainMenu()
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}