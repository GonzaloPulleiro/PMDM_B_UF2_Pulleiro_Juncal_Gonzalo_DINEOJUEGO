using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
   
    const float MIN_X = -8;
    const float MAX_X = 33;
    [SerializeField] float interval;
    [SerializeField] float delay;
    [SerializeField] GameObject enemy;

    void Start()
    {
        StartCoroutine("EnemySpawn");
    }

    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {
            //generamos nuevo enemigo
            Vector3 position = new Vector3(Random.Range(MIN_X, MAX_X), transform.position.y, 0);
            Instantiate(enemy, position, Quaternion.identity);

             interval = CalculaIntervalo();


            //hacemos una pausa
            yield return new WaitForSeconds(interval);
        }
    }

    float CalculaIntervalo()
    {
        float newInterval = interval - (interval * 0.25f);

        if(newInterval <= 0.60f)
        {
            newInterval = 0.60f;
        }

        return newInterval;
    }

   
}
