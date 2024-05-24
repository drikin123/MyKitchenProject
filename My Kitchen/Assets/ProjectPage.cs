using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectPage : MonoBehaviour
{
    // Start is called before the first frame update
    public void ClickMenu()
    {
        
         SceneManager.LoadSceneAsync("MainMenu");
          
    }


    public void Click3D()
    {

        SceneManager.LoadSceneAsync("ConceptionPage");

    }

}
