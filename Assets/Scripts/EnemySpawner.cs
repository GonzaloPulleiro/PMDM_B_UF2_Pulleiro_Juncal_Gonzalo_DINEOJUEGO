using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //especificamos la posicion de cada enemigo, por eso creo serializefield pos.
    [SerializeField] float POS;
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
            Vector3 position = new Vector3(POS, transform.position.y, 0);
            Instantiate(enemy, position, Quaternion.identity);

            //hacemos una pausa
            yield return new WaitForSeconds(interval);
        }
    }
}
