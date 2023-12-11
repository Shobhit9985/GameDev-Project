using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private float Waited = 0;
    private int CurrentOption = 0;
    private string[] TutorialOptions = { 
        "Press the W key to move forward", 
        "Press the A key to move to the left", 
        "Press the D key to move to the right", 
        "Press the S key to move backward", 
        "Press the LEFT SHIFT key while moving forward to sprint", 
        "Press the SPACE key to jump" ,
        "Press the G key to equip your weapon",
        "Press Left Click to shoot",
        "Press the R key to reload your weapon",
        "Congratulations you have finished the tutorial"
    };

    public TMP_Text TutorialText;
    // Start is called before the first frame update
    void Start()
    {
        TutorialText.text = TutorialOptions[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w") && TutorialText.text == TutorialOptions[0])
        {
            CurrentOption++;
            TutorialText.text = TutorialOptions[CurrentOption];
        }
        else if (Input.GetKeyDown("a") && TutorialText.text == TutorialOptions[1])
        {
            CurrentOption++;
            TutorialText.text = TutorialOptions[CurrentOption];
        }
        else if (Input.GetKeyDown("d") && TutorialText.text == TutorialOptions[2])
        {
            CurrentOption++;
            TutorialText.text = TutorialOptions[CurrentOption];
        }
        else if (Input.GetKeyDown("s") && TutorialText.text == TutorialOptions[3])
        {
            CurrentOption++;
            TutorialText.text = TutorialOptions[CurrentOption];
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && TutorialText.text == TutorialOptions[4])
        {
            CurrentOption++;
            TutorialText.text = TutorialOptions[CurrentOption];
        }
        else if (Input.GetKeyDown("space") && TutorialText.text == TutorialOptions[5])
        {
            CurrentOption++;
            TutorialText.text = TutorialOptions[CurrentOption];
        }
        else if (Input.GetKeyDown("g") && TutorialText.text == TutorialOptions[6])
        {
            CurrentOption++;
            TutorialText.text = TutorialOptions[CurrentOption];
        }
        else if (Input.GetMouseButtonDown(0) && TutorialText.text == TutorialOptions[7])
        {
            CurrentOption++;
            TutorialText.text = TutorialOptions[CurrentOption];
        }
        else if (Input.GetKeyDown("r") && TutorialText.text == TutorialOptions[8])
        {
            CurrentOption++;
            TutorialText.text = TutorialOptions[CurrentOption];
        }
        else if (TutorialText.text == TutorialOptions[9])
        {
            if (Waited > 1.00f)
            {
                TutorialText.alpha -= Time.deltaTime;
            }else if (TutorialText.alpha <= 0)
            {
                TutorialText.text = "";
            }
            else
            {
                Waited += Time.deltaTime;
            }
        }
    }
}
