using UnityEngine;

public class HitController : MonoBehaviour
{
    const float DELAY = 0.5f;
    void Start()
    {
        Destroy(gameObject, DELAY);       
    }

}
