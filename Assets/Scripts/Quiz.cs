using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    int activeTask;
    int lives = 3; //count жизней

    [Header("Elements")]
    public Image[] hearts; // массисв сердец-жизней типа Image
    public Image question; //картинка-вопрос
    public Button[] buttons; //кнопка-ответ, массив

    [Header("Config")]
    public List<Tasks> taskList; 

    // Start is called before the first frame update
    void Start()
    {
        // DontDestroyOnLoad(gameObject);
        getRandomTask(); 
        FillButtons(); // 
        UpdateQuestion(); 
    }
    public void RemoveTask()
    {
        taskList.RemoveAt(activeTask); // удаляет эктив таск из листа Тасков
    }

    void getRandomTask()  //  выбирает рандомно таск в листе тасков от 0 до количества тасков в листе
    {
        activeTask = Random.Range(0, taskList.Count);
    }

    void LoadNextLevel() // загрузка Таска со всеми его компонентами
    {
        RemoveTask();
        getRandomTask();
        FillButtons();
        UpdateQuestion();
        ActivateButtons();
    }
    void FillButtons() 
    {
        // Присвоение текста кнопке данными из активного таска
        for (int i = 0; i < 4; i++) 
        {
            buttons[i].GetComponentInChildren<Text>().text = taskList[activeTask].buttons[i];
        }
    }
    public void SwitchOffHearts() 
    {
        hearts[lives - 1].gameObject.SetActive(false); //выключает сердце-жизнь, -1 так как счёт начинается с 1
        lives--; // индекс массива сердец, уменьшает count lives на 1 при выключении C-Ж

    }
    void UpdateQuestion() // обновляет картинку-вопрос в завис. от активного Таска
    {
        question.sprite = taskList[activeTask].question;
    }

    bool IsCorrect(int btnIndex) //
    {
        if (btnIndex == taskList[activeTask].correctAnsver)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void GameOver() // Загружает сцену GameOverScene, если идекс жизней == 0
    {
        if (lives == 0)
        {
            NextScene("GameOverScene");
        }
        else
        {
            LoadNextLevel(); // 
        }
    }

    void Win() //загружает сцену WinScene, когда остается один Таск в листе тасков
    {
        if (taskList.Count == 1) 
        {
            NextScene("WinScene");
        }
        else
        {
            LoadNextLevel();
        }
    }

    IEnumerator Wait(int btnIndex) // таймаут
    {
        buttons[taskList[activeTask].correctAnsver - 1].GetComponent<Image>().color = Color.blue; //если кнопка нажата с правильным ответом - меняется цвет на синий
        yield return new WaitForSeconds(1); // таймер в 1 сек
        buttons[taskList[activeTask].correctAnsver - 1].GetComponent<Image>().color = Color.white; // после таймаута, цвет меняется на белый
        CheckAnsver(btnIndex);
    }
    public void CheckAnsver(int btnIndex)
    {

        if (IsCorrect(btnIndex))
        {
            Win();
        }
        else
        {
            SwitchOffHearts();
            GameOver();
        }
    }
    public void OnClick(int btnIndex)
    {
        StartCoroutine(Wait(btnIndex));
    }

    void ActivateButtons()
    {
        for (int i = 0; i < 4; i++)
        {
            buttons[i].gameObject.SetActive(true); // включает баттоны 
        }
    }
    public void FiftyFifty()
    {
        for (int i = 0; i <= 2; i++)
        {
            buttons[taskList[activeTask].fiftyFifty[i] - 1].gameObject.SetActive(false);
        }
    }
     public void NextScene(string sceneName) //загрузчик сцен
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
