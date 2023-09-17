using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    MeshRenderer m_Renderer;
    float hp = 100;
    public Image imgHP;
    bool stop=false;
    int cnt;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        imgHP.fillAmount = (float)hp / 100f;
        if (hp <= 0&&!stop)
        {
            stop = true;
            GameMgr3D.Instance.cnt++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ESword")
        {
        

            hp -= 20;
            

            // Get the current materials.
            Material[] currentMaterials = m_Renderer.materials;

            if (currentMaterials.Length > 0)
            {
                print("Material");
                // Create a new array that is one element smaller than the current array.
                Material[] newMaterials = new Material[currentMaterials.Length - 1];

                // Copy all elements except the first one from the old array to the new array.
                for (int i = 0; i < newMaterials.Length; i++)
                {
                    newMaterials[i] = currentMaterials[i];
                }

                // Assign the new array to the materials property of the MeshRenderer.
                m_Renderer.materials = newMaterials;
            }
        }
    }
}
