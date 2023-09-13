using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//씬매니저 사용하기위함

public class GameMgr2D : MonoBehaviour
{

    private static GameMgr2D sInstance;
    public int changeScene = 0;
    private static GameMgr2D Instance
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


    public void ChangeScene()
    {
        //인덱스로 처리
        int scene = changeScene++ % 2;
        SceneManager.LoadScene(scene);
       
    }
    public void ChangeScene(string sceneName)
    {
        //씬이름으로 처리
        SceneManager.LoadScene(sceneName);
    }


}
