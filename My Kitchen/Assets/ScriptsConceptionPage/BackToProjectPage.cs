using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToProjectPage : MonoBehaviour
{
    public void  ClickMenu()
    {
        SceneManager.LoadSceneAsync("ProjectPage");
    }
}
