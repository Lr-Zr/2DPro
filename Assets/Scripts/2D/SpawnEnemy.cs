using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float interval = 7.0f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, transform.rotation);

            yield return new WaitForSeconds(interval);//�����ð����� ��ٷȴٰ� �ٽ��϶�

        }
    }
}
