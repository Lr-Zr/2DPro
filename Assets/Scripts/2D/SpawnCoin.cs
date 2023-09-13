using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject Coin;
    public float interval = 3.0f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(Coin, transform.position, transform.rotation);

            yield return new WaitForSeconds(interval);//일정시간동안 기다렸다가 다시하라

        }
    }
}
