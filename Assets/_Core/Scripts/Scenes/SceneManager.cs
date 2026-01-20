namespace ColoredGess.Scenes
{
    using Singletons;
    
    public class SceneManager : MonoSingleton<SceneManager>
    {
        public void SwitchScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}