using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//���Ŵ��� ����ϱ�����
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

        //Ȥ�� �߻� ���;
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
        //���̸����� ó��
        SceneManager.LoadScene(sceneName);
        if(playerHP<=0)
        {
            playerHP = 100;
        }
    }


}
