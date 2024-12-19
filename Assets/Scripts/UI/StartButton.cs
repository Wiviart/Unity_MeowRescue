using MeowRescue.UI;
using MeowRescue.Utilities;

public class StartButton : UI_Button
{
    protected override void OnClick()
    {
        Observer.Instance.GameStart();
        gameObject.SetActive(false);
    }
}