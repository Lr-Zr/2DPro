using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


[System.Serializable]
public class SaveInformation
{
    public string Name;
    public float posX;
    public float posY;
    public float posZ;
}

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        SaveLoad_Test();
    }

    // Update is called once per frame
    private void SaveLoad_Test()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (PlayerPrefs.HasKey("ID"))
            {
                //id가 있다면 
                string getId = PlayerPrefs.GetString("ID");
                Debug.Log(string.Format("ID : {0}", getId));

            }
            else
            {
                Debug.Log("ID : 없음");
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            string setId = "2023inha";
            PlayerPrefs.SetString("ID", setId);
            Debug.Log("Saved ID : " + setId);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

            PlayerPrefs.SetInt("Score", 33);
            PlayerPrefs.SetFloat("Exp", 44.4f);

            int getScore = 0;
            if (PlayerPrefs.HasKey("Score"))
            {
                getScore = PlayerPrefs.GetInt("Score");

            }
            float getExp = 0f;
            if (PlayerPrefs.HasKey("Exp"))
            {
                getExp = PlayerPrefs.GetFloat("Exp");

            }

            Debug.Log("Score : " + getScore.ToString());
            Debug.Log("Exp : " + getExp.ToString());

        }


        ///////////////////////////////////
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveBinary();
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            //default 값 지정
            String getID = PlayerPrefs.GetString("ID2", "NONE");//값이 있으면 ID2, 없으면 "NONE";
            int getScore = PlayerPrefs.GetInt("Score2", 100);
            float getExp = PlayerPrefs.GetFloat("Exp2", 100f);

            Debug.Log(getID);
            Debug.Log(getScore);
            Debug.Log(getExp);
        }
    }


    void SaveBinary()
    {
        //>>>
        SaveInformation setInfo = new SaveInformation();
        setInfo.Name = "2023Inha";
        setInfo.posX = 0f;
        setInfo.posY = 4.5f;
        setInfo.posZ = 5.5f;
        Debug.Log(setInfo);
        //<<<



        //>>> save
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memStream = new MemoryStream();

        formatter.Serialize(memStream, setInfo);
        byte[] bytes = memStream.GetBuffer();

        String memStr = Convert.ToBase64String(bytes);
        Debug.Log(memStr);
        PlayerPrefs.SetString("SaveInformation", memStr);
        //<<<save



        //>>>load
        String getInfo = PlayerPrefs.GetString("SaveInformation");
        Debug.Log(getInfo);


        byte[] getBytes = Convert.FromBase64String(getInfo);

        MemoryStream getMemStream = new MemoryStream(getBytes);

        BinaryFormatter formatter2 = new BinaryFormatter();
        SaveInformation getInformation = (SaveInformation)formatter2.Deserialize(getMemStream);

        Debug.Log(getInformation.Name + " " + getInformation.posX + " " + getInformation.posY + " ");
        //<<<load


    }
}
