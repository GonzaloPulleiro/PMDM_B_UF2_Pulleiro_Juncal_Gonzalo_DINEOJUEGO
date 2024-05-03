using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    [SerializeField] float duration;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine("StartNextLevel");
        }
    }

    IEnumerator StartNextLevel()
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            
            yield return null;
        }
        SceneManager.LoadScene(1);
    }


}
