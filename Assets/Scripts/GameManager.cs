using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;//씬매니저 사용하기위함

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

        //혹시 발생 대비;
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
        //인덱스로 처리
        int scene = changeScene++ % 2;
        // string sceneName = string.Format("Scene_ {0:2d}", scene);
        SceneManager.LoadScene(scene);
        print("이거 왜 변경 안됌/");
    }
    public void ChangeScene(string sceneName)
    {
        //씬이름으로 처리
        SceneManager.LoadScene(sceneName);
    }



}
