using UnityEngine.SceneManagement;

namespace MeowRescue.UI
{
    public class RestartButton : UI_Button
    {
        protected override void OnClick()
        {
            var scene = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(scene);
        }
    }
}