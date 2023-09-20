using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.UIElements;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject overmenu;
    public GameObject item;
    public GameObject score;
    public GameObject score2;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMgr3D_3.Instance.cnt<=0)
        {
            if(Time.timeScale>0)
            {
                Time.timeScale = 0f;
                overmenu.SetActive(true);
                score.SetActive(false);
                player.GetComponent<AudioListener>().enabled = false;   
            }
          

        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            GameMgr3D_3.Instance.score += 666* GameMgr3D_3.Instance.cnt;
            GameMgr3D_3.Instance.cnt = 0;
        }
        item.GetComponent<TextMeshProUGUI>().text = "ITEM \n" + string.Format("{0:D2}", GameMgr3D_3.Instance.cnt);
        score.GetComponent<TextMeshProUGUI>().text = "SCORE \n" + string.Format("{0:D6}", GameMgr3D_3.Instance.score);
        score2.GetComponent<TextMeshProUGUI>().text = "SCORE \n" + string.Format("{0:D6}", GameMgr3D_3.Instance.score);

    }

    void onStart()
    {
        Time.timeScale = 1.0f;
        startmenu.SetActive(false);
        score.SetActive(true);
        item.SetActive(true);
        
    }
    void onReset()
    {
       
        Time.timeScale = 0f;
        startmenu.SetActive(true);
        score.SetActive(false);
        GameMgr3D_3.Instance.ChangeScene("00_3D_3");

    }
}
