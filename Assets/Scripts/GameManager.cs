using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;//���Ŵ��� ����ϱ�����

using UnityEngine.SubsystemsImplementation;


public class GameManager : MonoBehaviour
{
    
    private static GameManager sInstance;
    // Start is called before the first frame update
    
    public static GameManager Instance 
    {
        get {
            if(sInstance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                sInstance=newGameObject.AddComponent<GameManager>();

            }
            return sInstance;
        } 
    }
    
    public int changeScene = 0;
    public bool start=false;
    private void Awake()
    {

        //Ȥ�� �߻� ���;
        if (sInstance!=null&&sInstance !=this)
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
        // string sceneName = string.Format("Scene_ {0:2d}", scene);
        SceneManager.LoadScene(scene);
        print("�̰� �� ���� �ȉ�/");
    }
    public void ChangeScene(string sceneName)
    {
        //���̸����� ó��
        SceneManager.LoadScene(sceneName);
    }



}
