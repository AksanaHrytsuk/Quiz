using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoaderScene : MonoBehaviour
{
   public void NextScene(string sceneName) //загрузчик сцен
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
       public void ExitGame()
    {
        Application.Quit();
    }
}
