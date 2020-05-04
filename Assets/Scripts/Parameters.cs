using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public Text count;

public class Parameters : MonoBehaviour
{
    public static string countDown;

    void OnEnable()
    {
        //countDown = "1";
        var input = gameObject.GetComponent<InputField>();
        //var se = new InputField.SubmitEvent();
        //se.AddListener(SubmitName);
        //input.onEndEdit = se;
        countDown = input.text;
        //or simply use the line below,
        input.onEndEdit.AddListener(SubmitName);  // This also works
        //countDown = count.text.ToString();
    }

    private void SubmitName(string arg0)
    {
        countDown = arg0;
    }
}
