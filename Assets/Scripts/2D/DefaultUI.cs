using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DefaultUI : MonoBehaviour
{
    public GameObject popupObj = null;
    public TextMeshProUGUI scoreText = null;
    public GameObject End = null;

    bool over = false;
    // Start is called before the first frame update
    void Start()
    {
        if (popupObj)
        {
            popupObj.SetActive(false);

        }
        over = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Score Ç¥½Ã
        scoreText.text = "SCORE\n" + string.Format("{0:D6}", GameMgr2D.Instance.score);
        if (GameMgr2D.Instance.playerHP <= 0&&!over)
        {
            Time.timeScale = 0f;
            End.SetActive(true);
            over = true;
        }
    }
    void onPupup()
    {
        if(!popupObj) { return; }


        if(popupObj.activeSelf)
        {
            popupObj.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            popupObj.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    void onStart()
    {
        GameMgr2D.Instance.ChangeScene("00_2D");
        Time.timeScale = 1f;
    }

    void onEnd()
    {
        GameMgr2D.Instance.ChangeScene("00_Start");
    }
}
