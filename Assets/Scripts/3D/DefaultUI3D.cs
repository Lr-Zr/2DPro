using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
public class DefaultUI3D : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject overMenu;
    public GameObject TimeText;
    public TextMeshProUGUI resultTime;
    float time = 0;
    bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        print(GameMgr3D.Instance.cnt);
        if (play)
        {

            time += Time.deltaTime;
           TimeText.GetComponent<TextMeshProUGUI>().text= TimeSpan.FromSeconds(time).ToString("mm\\:ss\\:ff");
            

            if(GameMgr3D.Instance.cnt>=5)
            {
                print("done");
                play = false; 
                Time.timeScale = 0f;
                TimeText.SetActive(false);
                overMenu.SetActive(true);
                resultTime.text= TimeSpan.FromSeconds(time).ToString("mm\\:ss\\:ff"); 
            }
        }
    }

    void onStart()
    {
        Time.timeScale = 1f;
        startmenu.SetActive(false);
        TimeText.SetActive(true);
        play = true;
    }

    void onReset()
    {
        GameMgr3D.Instance.ChangeScene("00_3D");
    }



}
