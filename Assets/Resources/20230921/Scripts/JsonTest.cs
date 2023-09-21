using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;



//정보 클래스
public class PlayerInfo
{
    public int ID;
    public string Name;
    public double Gold;
    

    public PlayerInfo(int  id,string name, double gold)
    {
        ID = id;
        Name = name;    
        Gold = gold;
    }
}

public class JsonTest : MonoBehaviour
{
    public List<PlayerInfo> playerInfoList =new List<PlayerInfo>();

    // Start is called before the first frame update
    void Start()
    {
        //SavePlayerInfo();
        LoadPlayerInfo();
    }

    //----------------------------------------------------------------------------------------------------------------------
    public void SavePlayerInfo()
    {
        Debug.Log("SavePlayerInfo()");
        playerInfoList.Add(new PlayerInfo(1, "이름1", 1001));
        playerInfoList.Add(new PlayerInfo(2, "이름2", 1002));
        playerInfoList.Add(new PlayerInfo(3, "이름3", 1003));
        playerInfoList.Add(new PlayerInfo(4, "이름4", 1004));
        playerInfoList.Add(new PlayerInfo(5, "이름5", 1005));

        JsonData infoJson = JsonMapper.ToJson(playerInfoList);//정보 infojason에 저장



        File.WriteAllText(
            Application.dataPath + "/Resources/Data/PlayerInfoData.json"
            , infoJson.ToString()
            );//infojason에있는것을 파일화


    }
    //----------------------------------------------------------------------------------------------------------------------

    public void LoadPlayerInfo()
    {

        Debug.Log("LoadPlayerInfo()");
        if (File.Exists(Application.dataPath + "/Resources/Data/PlayerInfoData.json"))
        {

            string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerInfoData.json");//string으로 읽어드림
            Debug.Log(jsonString); ;
            
            
            JsonData playerData=JsonMapper.ToObject(jsonString); //json데이터 형식에서 jsondata인 오브젝트를 형성


            ParsingJsonPlayerInfo(playerData);


        }

        

    }


    private void ParsingJsonPlayerInfo(JsonData data)
    {
        Debug.Log("ParsingJsonPlayerInfo()");

        for(int i=0; i<data.Count; i++)
        {
            print(data[i]["ID"].ToString() + ","
                + data[i]["Name"] + ","
                + data[i]["Gold"]
                );

            int id = (int)data[i]["ID"];
            print(id.ToString());
            string name = (string)data[i]["Name"];
            print(name);
            double gold = (double)data[i]["Gold"];
            print(gold.ToString());
        }
    }
    //----------------------------------------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        
    }


}
