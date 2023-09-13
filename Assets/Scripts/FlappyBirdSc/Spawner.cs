using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject Item;

    public float interval = 2.0f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
           // transform.position = new Vector3(26, Random.Range(-5, 5), 0);
            Instantiate(wallPrefab,transform.position,transform.rotation);
            Instantiate(Item,transform.position,transform.rotation);

            yield return new WaitForSeconds(interval);//일정시간동안 기다렸다가 다시하라

        }
    }


}
