using UnityEngine.SceneManagement;

namespace Services.Scene
{
    public class SceneLoader : ISceneLoader
    {
        public void Load(string sceneName) => 
            SceneManager.LoadScene(sceneName);
    }
}