using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene_Transitions
{
    public class Settings : MonoBehaviour
    { 
        public void Options()
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}