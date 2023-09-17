using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr3D : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameMgr3D sInstance;
    public int changeScene = 0;
    public int cnt=0;

   public static GameMgr3D Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("_GameMgr2D");
                sInstance = newGameObj.AddComponent<GameMgr3D>();
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
        cnt = 0;
    }
}
