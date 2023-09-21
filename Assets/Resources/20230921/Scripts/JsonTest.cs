using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;



//���� Ŭ����
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
        playerInfoList.Add(new PlayerInfo(1, "�̸�1", 1001));
        playerInfoList.Add(new PlayerInfo(2, "�̸�2", 1002));
        playerInfoList.Add(new PlayerInfo(3, "�̸�3", 1003));
        playerInfoList.Add(new PlayerInfo(4, "�̸�4", 1004));
        playerInfoList.Add(new PlayerInfo(5, "�̸�5", 1005));

        JsonData infoJson = JsonMapper.ToJson(playerInfoList);//���� infojason�� ����



        File.WriteAllText(
            Application.dataPath + "/Resources/Data/PlayerInfoData.json"
            , infoJson.ToString()
            );//infojason���ִ°��� ����ȭ


    }
    //----------------------------------------------------------------------------------------------------------------------

    public void LoadPlayerInfo()
    {

        Debug.Log("LoadPlayerInfo()");
        if (File.Exists(Application.dataPath + "/Resources/Data/PlayerInfoData.json"))
        {

            string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerInfoData.json");//string���� �о�帲
            Debug.Log(jsonString); ;
            
            
            JsonData playerData=JsonMapper.ToObject(jsonString); //json������ ���Ŀ��� jsondata�� ������Ʈ�� ����


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
