using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SpawnCloud : MonoBehaviour
{
    public GameObject cloud;

    public float interval = 0.2f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            // transform.position = new Vector3(26, Random.Range(-5, 5), 0);
            Instantiate(cloud, transform.position, transform.rotation);
           
            yield return new WaitForSeconds(interval);//일정시간동안 기다렸다가 다시하라

        }
    }
}
