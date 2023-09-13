using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;

public class FlappyGame : MonoBehaviour
{

    GUIStyle style = new GUIStyle();

    int Score = 0;
    int life = 3;
    float time = 5;
    int cnt = 5;

    bool timeon=false;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        if (GameManager.Instance.changeScene == 0)
        {
            if (!timeon&&GUI.Button(new Rect(100, 200, 200, 30), "Start"))
            {
             
                Score = 0;
                time = 0;
                cnt = 5;
                life = 3;
                timeon = true;
            }

            if (timeon)
            {
                time += Time.deltaTime;
                style.normal.textColor = Color.black;
                style.fontSize = 60;

                GUI.TextArea(
               new Rect(300, 200, 200, 50), "" + (int)(cnt - time), style);

                if(time>=5)
                {

                    GameManager.Instance.changeScene++;
                    GameManager.Instance.ChangeScene("01_Play");
                    timeon = false; 
                }
            }
        }

        else if (GameManager.Instance.changeScene == 1)
        {
            style.normal.textColor = Color.yellow;
            style.fontSize = 40;
            GUI.TextArea(
            new Rect(100, 5, 200, 50), "Score :  " + Score, style);
            GUI.TextArea(
           new Rect(500, 5, 200, 50), "Life :  " + life, style);

            if (life == 0)
            {

                GameManager.Instance.changeScene++;
            }
        }
        else if (GameManager.Instance.changeScene == 2)
        {
            style.normal.textColor = Color.yellow;
            style.fontSize = 60;
            GUI.TextArea(
            new Rect(100, 100, 200, 50), "Score :  " + Score, style);
            GUI.TextArea(
           new Rect(300, 100, 200, 50), "Life :  " + life, style);


        }
    }
    public void AddScore() { Score += 100; }
    public void Sublife() { life--; }
    public float GetTime() { return time; }
}