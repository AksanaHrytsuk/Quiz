using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
  int activeTask;
  [Header("Elements")]
  public Image heart1;
  public Image heart2;
  public Image heart3;
  public Image question; //картинка-вопрос
  public Button[] buttons; //кнопка-ответ

  public Button fiftyFifty;

  [Header("Config")]
  public List<Tasks> activeTasks;
  


  // Start is called before the first frame update
  void Start()
  {
    DontDestroyOnLoad(gameObject);
    getRandomTask();
    fillButtons(activeTask);

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void RemoveTask(int index){
    activeTasks.RemoveAt(index);
  }

  void getRandomTask(){
    activeTask = Random.Range(0,activeTasks.Count);
  }

  void fillButtons(int taskNumber)
  {
    for (int i = 0; i < 4; i++)
    {
      buttons[i].GetComponentInChildren<Text>().text = activeTasks[taskNumber].buttons[i];
    }
  }



  public void SwitchOffBtn(int[] index) //кнопка 50/50 вызывает данную функцию. 
  {
    foreach (int i in index)
    {
      buttons[i].gameObject.SetActive(false);
    }
  }
  public void SwitchOffHeart1() // выключает  первое сердце-жизнь
  {
    heart1.gameObject.SetActive(false);
  }
  public void SwitchOffHeart2()
  {
    heart1.gameObject.SetActive(false);
  }
  public void SwitchOffHeart3()
  {
    heart1.gameObject.SetActive(false);
  }
  public void NextScene(string sceneName) //загрузчик сцен
  {
    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
  }
}
