using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    const float DESTROY_HEIGHT = -12;
    [SerializeField] float speed;
     
    void Update()
    {
        //transformar el objeto
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(transform.position.x < DESTROY_HEIGHT)
            Destroy(gameObject);
    }

}
