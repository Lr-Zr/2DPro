using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
           // GameManager.Instance.ChangeScene();
        }

        if (Input.GetMouseButton(1))
        {
            if (GameManager.Instance.changeScene == 0)
            {
                GameManager.Instance.changeScene++;
                GameManager.Instance.ChangeScene("99_End");

            }
            else if (GameManager.Instance.changeScene == 1)
            {
                GameManager.Instance.changeScene++;
                GameManager.Instance.ChangeScene("04_Col");
            }
        }
    }

    private void OnGUI()//���� ������ �䱸�ϴ� �κп����� ������� ����
    {
        if (GUI.Button(new Rect(100, 200, 200, 30), "�� ����"))
        {

            if (GameManager.Instance.changeScene == 0)
            {
                GameManager.Instance.changeScene++;
                GameManager.Instance.ChangeScene("99_End");

            }
            else if (GameManager.Instance.changeScene == 1)
            {
                GameManager.Instance.changeScene++;
                GameManager.Instance.ChangeScene("04_Col");
            }
        }
    }
}
