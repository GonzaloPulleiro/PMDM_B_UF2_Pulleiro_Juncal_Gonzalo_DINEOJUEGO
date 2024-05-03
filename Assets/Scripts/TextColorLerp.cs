using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorLerp : MonoBehaviour
{
    
    [SerializeField] Text msg;
    [SerializeField] Text msg2;
    [SerializeField] float duration;

    void Start()
    {
        StartCoroutine("ChangeColor");
    }

    IEnumerator ChangeColor()
    {
        float t = 0;
        while(t < duration)
        {
            t += Time.deltaTime;
            msg.color = Color.Lerp(Color.black, Color.white, t/duration);
            msg2.color = Color.Lerp(Color.white, Color.red, t/duration);

            yield return null;
        }
        StartCoroutine("ChangeColor");
    }
}
