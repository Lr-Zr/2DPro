using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoNextScene()
    {
        GameMgr3D_3.Instance.nextSceneName = "00_3D_3";
        SceneManager.LoadScene("Loading");
    }
}
