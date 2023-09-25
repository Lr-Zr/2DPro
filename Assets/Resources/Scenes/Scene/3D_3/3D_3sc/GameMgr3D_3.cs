using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr3D_3 : MonoBehaviour
{
    private static GameMgr3D_3 sInstance;
    public int cnt = 101;
    public int score = 0;

    public static GameMgr3D_3 Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("_GameMgr3D_3");
                sInstance = newGameObj.AddComponent<GameMgr3D_3>();
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
        cnt = 101;
        score = 0;
    }



    public string nextSceneName;
}
