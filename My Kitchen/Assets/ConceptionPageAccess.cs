using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConceptionPageAccesss : MonoBehaviour
{

    public void ClickConception()
    {
        SceneManager.LoadSceneAsync("ConceptionPage");
    }


}
