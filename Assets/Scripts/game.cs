using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class game : MonoBehaviour
{                     
    float time, time1=0, time2=0, time3=0;
    int min1, min2, min3;
    GameObject objP, obj1, obj2;
    Text t1, t2, t3;

    GUIStyle style = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        style.normal.textColor = Color.yellow;
      
        objP = GameObject.Find("Player");
        obj1 = GameObject.Find("Car1");
        obj2 = GameObject.Find("Car2");
        t1.text = TimeSpan.FromSeconds(time1).ToString("mm\\:ss\\:ff");
        t2.text = TimeSpan.FromSeconds(time2).ToString("mm\\:ss\\:ff");
        t3.text = TimeSpan.FromSeconds(time3).ToString("mm\\:ss\\:ff");

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.start)
        {
            time += Time.deltaTime;
        }
        if (objP.GetComponent<carMove>().Lap == 3)
        {
            if (time1 == 0)
            {

                time1 = time;

            }
        }

        if (obj1.GetComponent<carRaycast>().Lap == 3)
        {

            if (time2 == 0)
            { 
                time2 = time;

            }
        }

        if (obj2.GetComponent<carRaycast>().Lap == 3)
        {

            if (time3 == 0)
            {
                time3 = time;

            }
        }


    }
    private void OnGUI()
    {

        GUILayout.Label("시간");

        style.normal.textColor = Color.yellow;
        style.fontSize = 40;
        GUI.TextArea(
           new Rect(50, 5, 400, 40), getParseTime(time),style);

        if(objP.GetComponent<carMove>().Lap==3)
        {

            style.normal.textColor = Color.red;
        }
        else
        {

        style.normal.textColor = Color.green;
        }
        GUI.TextArea(
            new Rect(10, 40, 400, 40), "P Lap " + objP.GetComponent<carMove>().Lap + " time : " +getParseTime(time1), style);
        if (obj1.GetComponent<carMove>().Lap == 3)
        {

            style.normal.textColor = Color.red;
        }
        else
        {

            style.normal.textColor = Color.green;
        }
        GUI.TextArea(
            new Rect(10, 90, 400, 40), "1 Lap " + obj1.GetComponent<carMove>().Lap + " time : "+getParseTime(time2), style);
        if (obj2.GetComponent<carMove>().Lap == 3)
        {

            style.normal.textColor = Color.red;
        }
        else
        {

            style.normal.textColor = Color.green;
        }
        GUI.TextArea(
            new Rect(10, 140, 400, 40), "2 Lap " + obj2.GetComponent<carMove>().Lap + " time : " + getParseTime(time3), style);

        if(objP.GetComponent<carRaycast>().Lap == 3&&obj1.GetComponent<carRaycast>().Lap == 3&&obj2.GetComponent<carRaycast>().Lap == 3)
        {

            
            if (GUI.Button(new Rect(10, 200, 100, 30), "다시하기"))
            {
                GameManager.Instance.ChangeScene("03_Test_Start");

            }
            GameManager.Instance.start = false;

        }

        if(!GameManager.Instance.start&&time==0)
        {
            if (GUI.Button(new Rect(10, 200, 100, 30), "시작하기"))
            {

                GameManager.Instance.ChangeScene("03_Test");
                GameManager.Instance.start = true;
            }
        }
        


    }
    public string getParseTime(float time)
    {
        string t = TimeSpan.FromSeconds(time).ToString("mm\\:ss\\:ff");
        string[] tokens = t.Split(':');
        return tokens[0] + ":" + tokens[1] + ":" + tokens[2];
    }

}
