using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResalt : MonoBehaviour
{
    public Image[] hearts;
    public Text lastLives;
    // Start is called before the first frame update
    void Start()
    {
        Quiz image1 = FindObjectOfType<Quiz>();
        int live = image1.lives; 
        lastLives.text = "You have: "  + live  + " lives";
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i + 1 > live)
            {
                hearts[i].gameObject.SetActive(false);
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
