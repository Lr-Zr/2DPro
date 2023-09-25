using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditor.SceneManagement;
public class CheatWindow : EditorWindow
{
    string[] cheatList = new string[]
    {
        "치트",             //:0
        "골드 생성",         //:1
        "포인트 생성"        //:2
    };

    static int selectIndex = 0;





    int getInt = 0;
    string getString = "";


    [MenuItem("Menu2023/CheatMenu/치트 명령창", false, 0)]
    static public void OpenCheatWindow()
    {
        CheatWindow getWindow = EditorWindow.GetWindow<CheatWindow>(false, "Cheat Window", true);
    }



    private void OnGUI()
    {
        GUILayout.Space(10f);
        //선택된 값에 대한 리턴
        int getIndex = EditorGUILayout.Popup(selectIndex, cheatList, GUILayout.MaxWidth(200.0f));
        if (selectIndex != getIndex)
        {
            selectIndex = getIndex;
        }

        string cheatText = "";
        //[
        GUILayout.BeginHorizontal(GUILayout.MaxWidth(300f));

        //:cheat key 입력
        if (selectIndex == 0)
        {
            GUILayout.Label("치트키 입력", GUILayout.Width(70.0f));
            getString = EditorGUILayout.TextField(getString, GUILayout.Width(100.0f));
            cheatText = string.Format("치트키:{0}", getString);

        }
        else if (selectIndex == 1)
        {
            GUILayout.Label("골드", GUILayout.Width(70f));
            getString = EditorGUILayout.TextField(getInt.ToString(), GUILayout.Width(100.0f));
            int.TryParse(getString, out getInt);

            cheatText = string.Format("골드:{0}", getInt);

        }
        else if (selectIndex == 2)
        {
            GUILayout.Label("포인트", GUILayout.Width(70f));
            getString = EditorGUILayout.TextField(getInt.ToString(), GUILayout.Width(100.0f));
            int.TryParse(getString, out getInt);

            cheatText = string.Format("포인트:{0}", getInt);
        }

        GUILayout.EndHorizontal();
        //]세트로 써야함;



        GUILayout.Space(20f);
        //----------------------------------------------------------------------------------
        GUILayout.BeginHorizontal(GUILayout.MaxWidth(800f));
        {

            GUILayout.BeginVertical(GUILayout.MaxWidth(300f));
            {
                //#####################################################################################
                GUILayout.BeginHorizontal(GUILayout.MaxWidth(300f));
                {
                    if (GUILayout.Button("\n적용\n", GUILayout.Width(100f)))
                    {
                        if (EditorApplication.isPlaying
                            && EditorSceneManager.GetActiveScene().name != "Title")//실행중일때만 
                        {
                            getInt = 0;
                            getString = "";
                            // 실제 작동
                            Debug.Log(cheatText);
                        }
                    }
                }
                GUILayout.EndHorizontal();
                //#####################################################################################
                GUILayout.BeginHorizontal(GUILayout.MaxWidth(300f));
                {
                    if (GUILayout.Button("\n백그라운드\n", GUILayout.Width(100f)))
                    {
                        Application.runInBackground = true;

                    }
                    if (GUILayout.Button("\n백그라운드\n실행 안함", GUILayout.Width(100f)))
                    {
                        Application.runInBackground = false;

                    }
                }
                GUILayout.EndHorizontal();
                //#####################################################################################
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndHorizontal();
    }
}
