using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//���Ŵ��� ����ϱ�����

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

        //Ȥ�� �߻� ���;
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
        //�ε����� ó��
        int scene = changeScene++ % 2;
        SceneManager.LoadScene(scene);
       
    }
    public void ChangeScene(string sceneName)
    {
        //���̸����� ó��
        SceneManager.LoadScene(sceneName);
    }


}
