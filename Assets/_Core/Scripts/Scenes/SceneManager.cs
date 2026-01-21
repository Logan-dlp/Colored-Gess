using UnityEngine;

namespace ColoredGess.Scenes
{
    using Singletons;
    
    public class SceneManager : MonoSingleton<SceneManager>
    {
        public void SwitchScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        public void OpenLink(string URL)
        {
            Application.OpenURL(URL);
        }
    }
}