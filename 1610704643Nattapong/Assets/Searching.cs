using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Searching : MonoBehaviour
{
    public InputField inputField;
    public Text textInterface1;
    public Text textInterface2;
    public Text textInterface3;
    public Text textInterface4;
    public Text textInterface5;
    public Text textResult;
    bool checkText;
    string inputText;

    void Start()
    {

    }


    void Update()
    {
        //inputText = inputField.text;
    }

    public void FindText()
    {
        inputText = inputField.text;
        if (inputText == textInterface1.text)
        {
            checkText = true;
            check();
        }
        else if(inputText == textInterface2.text)
        {
            checkText = true;
            check();
        }
        else if (inputText == textInterface3.text)
        {
            checkText = true;
            check();
        }
        else if (inputText == textInterface4.text)
        {
            checkText = true;
            check();
        }
        else if (inputText == textInterface5.text)
        {
            checkText = true;
            check();
        }
        else
        {
            checkText = false;
            check();
        }
    }
    void check()
    {
        if(checkText == true)
        {
            textResult.text = inputText + " is found";
        }
        else
        {
            textResult.text = inputText + " is not found";
        }
    }
}
