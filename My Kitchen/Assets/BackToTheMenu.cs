using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackToTheMenu : MonoBehaviour
{
    public void  ClickMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
