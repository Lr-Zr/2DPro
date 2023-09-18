using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr3D_2 : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameMgr3D_2 sInstance;
    public int changeScene = 0;
    
    public static GameMgr3D_2 Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("_GameMgr3D_2");
                sInstance = newGameObj.AddComponent<GameMgr3D_2>();
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

    }
}
