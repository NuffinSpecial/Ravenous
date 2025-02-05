using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene_Transitions
{
    public class Settings2 : MonoBehaviour
    { 
        public void Back()
        {
            SceneManager.LoadSceneAsync(4);
        }
    }
}