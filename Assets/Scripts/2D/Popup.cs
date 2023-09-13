using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{

    public GameObject text = null;
    // Start is called before the first frame update
    void Start()
    {
        text.GetComponent<Text>().text = "”î";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void onClickOk()
    {
        text.GetComponent<Text>().text = "OK";
    }

    void onClickCancle()
    {
        gameObject.SetActive(false);
    }
}
