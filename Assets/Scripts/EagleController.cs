using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    const float DESTROY_WIDTH = -2.35f;

    [SerializeField] float speed;
    [SerializeField] GameController game;
    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < DESTROY_WIDTH)
        {
            Destroy(gameObject);
        }
    }



}
