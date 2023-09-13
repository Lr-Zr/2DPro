using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//씬매니저 사용하기위함
using UnityEngine.SubsystemsImplementation;

public class GameMgr2D : MonoBehaviour
{

    private static GameMgr2D sInstance;
    public int changeScene = 0;
    public int score = 0;
    public int playerHP = 100;
    public bool onred = true;
    public static GameMgr2D Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("_GameMgr2D");
                sInstance = newGameObj.AddComponent<GameMgr2D>();
            }
            
            return sInstance;
        }
    }


    private void Awake()
    {

        //혹시 발생 대비;
        if (sInstance != null && sInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sInstance = this;
        DontDestroyOnLoad(this.gameObject);

    }


    
    public void ChangeScene(string sceneName)
    {
        //씬이름으로 처리
        SceneManager.LoadScene(sceneName);
        if(playerHP<=0)
        {
            playerHP = 100;
        }
    }


}
