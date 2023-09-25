using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEditor;                  //<< editor menu;
using UnityEditor.SceneManagement;//<< scene


public class Menu2023 : MonoBehaviour
{
    //메뉴 추가 
    [MenuItem("Menu2023/Clear PlayerPrefs")]
    private static void Clear_PlayerPrefsAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear_PlayerPrefsAll");
    }


    [MenuItem("Menu2023/SubMenu/Select")]
    private static void SubMenu_Select()
    {
        Debug.Log("Sub Menu 1 - Select");
    }

    ///핫키
    ///%-CTRL
    ///#-SHIFT
    ///&-ALT
    [MenuItem("Menu2023/SubMenu/HotKey Test 1 %#[")]
    private static void SubMenu_HotKey()
    {

        Debug.Log("SubMenu_HotKey : CTRL + SHIFT + [");
    }



    [MenuItem("Assets/Load Selected Scene")]
    private static void LoadSelectedScene()
    {
        var selected = Selection.activeObject;//현재 메뉴가 활성된 오브젝트가 넘어온다.
        Debug.Log("1"+selected);
        Debug.Log("2"+AssetDatabase.GetAssetPath(selected));
        if (EditorApplication.isPlaying)
            EditorSceneManager.LoadScene(AssetDatabase.GetAssetPath(selected));
        else
            EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selected));
    }
}
