using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneLoader
    {
        public void Load(string _sceneName) => 
            SceneManager.LoadScene(_sceneName);
    }
}