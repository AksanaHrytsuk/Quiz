using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Tasks", menuName = "Tasks", order = 0)]
public class Tasks : ScriptableObject
{
  public Sprite question;
  public string [] buttons = new string[4];
  public int correctAnsver;

  public int[] fiftyFifty = new int [2];
}
