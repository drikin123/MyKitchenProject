using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  

    public void ClickRegister()

    {
        SceneManager.LoadSceneAsync("RegisterPage");
    }


    public void ClickSetting()
    {
        SceneManager.LoadSceneAsync("SettingsPage");
    }
}
