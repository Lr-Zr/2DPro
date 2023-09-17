using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obj;

    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(obj, transform.position, transform.rotation);
            yield return new WaitForSeconds(5f);
        }

    }
}
