using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    int activeTask;
    int lives = 3;

    [Header("Elements")]
    public Image[] hearts;
    public Image question; //картинка-вопрос
    public Button[] buttons; //кнопка-ответ

    [Header("Config")]
    public List<Tasks> taskList;

    // Start is called before the first frame update
    void Start()
    {
        // DontDestroyOnLoad(gameObject);
        getRandomTask();
        FillButtons();
        UpdateQuestion();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RemoveTask()
    {
        taskList.RemoveAt(activeTask);
    }

    void getRandomTask()
    {
        activeTask = Random.Range(0, taskList.Count);
    }

    void LoadNextLevel()
    {
        RemoveTask();
        getRandomTask();
        FillButtons();
        UpdateQuestion();
        ActivateButtons();
    }
    void FillButtons()
    {
        for (int i = 0; i < 4; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = taskList[activeTask].buttons[i];
        }
    }
    public void SwitchOffHearts()
    {
        hearts[lives - 1].gameObject.SetActive(false);
        lives--;
        //
    }
    void UpdateQuestion()
    {
        question.sprite = taskList[activeTask].question;
    }

    bool IsCorrect(int btnIndex)
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

    void GameOver()
    {
        if (lives == 0)
        {
            NextScene("GameOverScene");
        }
        else
        {
            LoadNextLevel();
        }
    }

    void Win()
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

    IEnumerator Wait(int btnIndex)
    {
        buttons[taskList[activeTask].correctAnsver - 1].GetComponent<Image>().color = Color.blue;
        yield return new WaitForSeconds(1);
        buttons[taskList[activeTask].correctAnsver - 1].GetComponent<Image>().color = Color.white;
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
            buttons[i].gameObject.SetActive(true);
        }
    }
    public void FiftyFifty()
    {
        for (int i = 0; i <= 2; i++)
        {
            buttons[taskList[activeTask].fiftyFifty[i] - 1].gameObject.SetActive(false);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void NextScene(string sceneName) //загрузчик сцен
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
