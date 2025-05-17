using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public GameObject settingPanel; 

    public void ShowSetting()
    {
        settingPanel.SetActive(true);
    }

    public void HideSetting()
    {
        settingPanel.SetActive(false);
    }
}
