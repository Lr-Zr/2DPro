using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{

    Text titletext = null;
    InputField inputtext = null;
    Toggle toggleBgm = null;
    public GameObject radioGroupObj = null;

    Toggle[] togglRadio;

    // Start is called before the first frame update

    void Start()
    {
        titletext = GetComponentInChildren<Text>();
        inputtext = GetComponentInChildren<InputField>();
        toggleBgm = GetComponentInChildren<Toggle>();
        titletext.text = "뷁";
        togglRadio = radioGroupObj.GetComponentsInChildren<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void onClickOk()
    {
        titletext.text = "Ok";
    }

    void onClickCancle()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void onTextChanged()
    {

        titletext.text = inputtext.text;
    }

    void onTextEndEdit()
    {
        titletext.text = inputtext.text;
    }


    public void onToggleBGM()
    {


        if (toggleBgm.isOn)
        {
            Debug.Log("bgm on");
        }
        else
        {

            Debug.Log("bgm off");
        }
    }

    public void onToggleRadio()
    {
        if (togglRadio == null) return;

        if (togglRadio[0].isOn)
        {
            Debug.Log("1번 선택");
        }
        else if (togglRadio[1].isOn)
        {
            Debug.Log("2번 선택");
        }
    }
}
