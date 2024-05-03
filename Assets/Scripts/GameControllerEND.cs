using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class GameControllerEND : MonoBehaviour
{
    [SerializeField] Text txtScore;
    
    //int finalScore;


    private void Start() {
        
        //finalScore.text = "YOUR FINAL SCORE IS: " + GameController.instance.score;
        txtScore.text = "YOUR FINAL SCORE IS: " + GameController.instance.score;
    }



}
