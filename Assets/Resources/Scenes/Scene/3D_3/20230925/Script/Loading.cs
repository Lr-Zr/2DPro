using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    //
    AsyncOperation async;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingNextScene(GameMgr3D_3.Instance.nextSceneName));  
    }

    // Update is called once per frame
    void Update()
    {
        DelayTime();
    }

    
    IEnumerator LoadingNextScene(string sceneName)
    {
        async=SceneManager.LoadSceneAsync(sceneName);   
        async.allowSceneActivation = false;//πŸ∑Œ æ¿¿Ã πŸ≤Ô¥Ÿ. (true)


        while (async.progress < 0.9f)
        {

            yield return true;

        }

        while(async.progress>=0.9f)
        {
            yield return new WaitForSeconds(0.1f);
            if(delayTime>2.0f)
            {
                break;
            }
        }
        async.allowSceneActivation = true;


            yield return true;
    }

    float delayTime = 0.0f;
    void DelayTime()
    {
        delayTime += Time.deltaTime;
    }
}
