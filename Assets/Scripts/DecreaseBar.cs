using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Image))]
public class DecreaseBar : MonoBehaviour
{
    public static float countDown;
    private float countDown_aux;
    public Text displayCount;

    public GameObject timeBar;
    public GameObject backTimeBar;

    public GameObject player;

    private Image decreaseBar;

    // Use this for initialization
    void Start()
    {
        countDown = float.Parse(Parameters.countDown);
        countDown_aux = countDown;

        decreaseBar = timeBar.GetComponent<Image>();

        timeBar.SetActive(false);
        backTimeBar.SetActive(false);

        displayCount.text = "";
    }

    void Update()
    {
        if(PressController.state == PressController.gameState.duringCicle)
        {
            timeBar.SetActive(true);
            backTimeBar.SetActive(true);
            if (Input.GetButton("Jump"))
            {
                if (countDown >= 0.0f)
                {
                    countDown -= Time.deltaTime;
                    decreaseBar.rectTransform.sizeDelta = new Vector2(countDown / countDown_aux * 175, 10);
                    displayCount.text = countDown.ToString("F2");
                }
                else
                {
                    countDown = countDown_aux;
                    decreaseBar.rectTransform.sizeDelta = new Vector2(175, 10);
                }
            }
        }
        else if(PressController.state == PressController.gameState.newCicle)
        {
            displayCount.text = "0.00";
            decreaseBar.rectTransform.sizeDelta = new Vector2(175, 10);
            timeBar.SetActive(false);
            backTimeBar.SetActive(false);
            countDown = countDown_aux;
            displayCount.text = "";
        }
    }
}
