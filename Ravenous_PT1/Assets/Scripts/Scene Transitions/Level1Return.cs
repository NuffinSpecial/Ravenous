using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene_Transitions
{
    public class Level1 : MonoBehaviour
    { 
        public void Return()
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
}