using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


public class ButtonController : MonoBehaviour
{
   public Text timeText;
   public RequestServerTime rst;

   public void SetText(string text)
   {
      timeText.text = text;
   } 
   
   
}
