using MeowRescue.Utilities;
using UnityEngine.SceneManagement;

public class RestartButton : UI_Button
{
    protected override void OnClick()
    {
        var scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(scene);
    }
}