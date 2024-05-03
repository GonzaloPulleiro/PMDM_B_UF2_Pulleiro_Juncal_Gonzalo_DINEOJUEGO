using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class GameController : MonoBehaviour
{

    const string DATA_FILE = "data.json";

    const int LIVES = 3;

    public static GameController instance;

    [SerializeField] Text txtScore;
    [SerializeField] Text txtHScore;
    [SerializeField] Text txtMessage;
    [SerializeField] Image[] imgLives;
    [SerializeField] AudioClip sfxGameOver;
    [SerializeField] float duration;

    public int score;
    int lives = LIVES;

    bool gameOver;
    bool paused;
    bool active;

    GameData gameData;
    AudioSource sfx;

    public bool isGameOver() { return gameOver; }

    public bool isGamePaused() { return paused; }


    public static GameController GetInstance() { return instance; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        gameData = LoadData();
        sfx = GetComponent<AudioSource>();
    }

    GameData LoadData()
    {
        if (File.Exists(DATA_FILE))
        {
            string fileText = File.ReadAllText(DATA_FILE);
            return JsonUtility.FromJson<GameData>(fileText);
        }
        else
        {
            return new GameData();
        }
    }

    void SaveData()
    {
        //creamos representación JSON de gameData
        string json = JsonUtility.ToJson(gameData);

        //volcar datos en archivo
        File.WriteAllText(DATA_FILE, json);
    }
    public void UpdateScore(int points)
    {
        score += points;

        if (score > gameData.hscore)
        {
            gameData.hscore = score;
        }
    }


    public void LoseLife()
    {
        lives--;

        if (lives == 0)
        {
            sfx.clip = sfxGameOver;
            sfx.Play();
            GameOver();
            StartCoroutine("NextScene");
        }

    }


    void GameOver()
    {
        gameOver = true;

        Time.timeScale = 0;

        Camera.main.GetComponent<AudioSource>().Stop();

        SaveData();

    }

    private void OnGUI()
    {
        //activar iconos vidas
        for (int i = 0; i < imgLives.Length; i++)
        {
            imgLives[i].enabled = i < lives - 1;
        }

        //mostrar puntuación
        txtScore.text = string.Format("{0, 3:D3}", score);

        //mostrar puntuación máxima
        txtHScore.text = string.Format("{0, 3:D3}", gameData.hscore);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (paused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
            else if (Input.GetKeyDown(KeyCode.F1))
                Time.timeScale /= 1.25f;
            else if (Input.GetKeyDown(KeyCode.F2))
                Time.timeScale *= 1.25f;
            else if (Input.GetKeyDown(KeyCode.F3))
                Time.timeScale = 1;
        }
        else if (gameOver)
        {
            ResumeSinSonido();
        }
    }
    void PauseGame()
    {
        paused = true;
        Camera.main.GetComponent<AudioSource>().Pause();

        txtMessage.text = "PAUSED\nPRESS 'P' TO RESUME";

        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        paused = false;
        Camera.main.GetComponent<AudioSource>().Play();

        txtMessage.text = "";
        Time.timeScale = 1;
    }

    void ResumeSinSonido()
    {
        paused = false;

        txtMessage.text ="";
        Time.timeScale = 1;
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(2);
        ResumeGame();
    }
}
