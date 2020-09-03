using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
    public AudioSource music;
    public static GuiManager instance;
    public Text scoreText;

    
    [SerializeField]
    private GameObject menuPanel, gamePanel, gameOverPanel, carPanel, car1;
    [SerializeField]
    private Text gameoverScore, gameoverHighscore;
    [SerializeField]
    private GameObject[] lifes;

    private bool gameStarted = false, gameOver = false;
    private bool replay = false;

    public GameObject Car;


    public Text policeText;
    public Text totalTraveledText;

    private float score = 0;
    public float scoreTotal;
    public int deathCounter = 0;
    private int carSelected = 1;
    public float highScore;
    public static float highScoreNew;

    public Camera cameraShop;
    private float distance;
    public float Score { get { return score; } set { score = value; } }
    public bool GameStarted { get { return gameStarted; } set { gameStarted = value; } }
    public bool GameOver { get { return gameOver; } set { gameOver = value; } }

    void Start()
    {
        score = 0;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("ScoreTotal"))
        {
            scoreTotal = PlayerPrefs.GetFloat("ScoreTotal");
        }
        if (PlayerPrefs.HasKey("DeathCounter"))
        {
            deathCounter  = PlayerPrefs.GetInt("DeathCounter");
        }

        if (PlayerPrefs.HasKey("Replay"))
        {
            if (PlayerPrefs.GetString("Replay") == "true")
            {
                replay = true;
                PlayerPrefs.SetString("Replay", "false");
            }
        }



        if (replay == true)
        {
            PlayButton();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    void Update()
    {
        if(gameStarted == false || gameOver == true)
        {
            return;
        }
        distance = Car.GetComponent<PlayerController>().distanceTravelled;
        distance = Mathf.Round(distance * 1f) / 1f;

        score = distance;
        scoreText.text = "" + score + " m";
        policeText.text = "Cops destroyed: " + Damage.policeCarsDestroyed;
        highScoreNew = PlayerPrefs.GetFloat("HighScore");

        CarManagement();
    }
    public void PlayButton()
    {

        Car.SetActive(true);
        gameStarted = true;
        music.Play();
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        carPanel.SetActive(false);
        cameraShop.depth = 0;

    }

    public void ReplayButton()
    {

        PlayerPrefs.SetString("Replay", "true");
        HomeButton();
        carSelected = PlayerPrefs.GetInt("CarSelected");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CarButton()
    {
        //Selector.carSelected = 1;
        menuPanel.SetActive(false);
        carPanel.SetActive(true);
        cameraShop.depth = 2;

        totalTraveledText.text = "Traveled: " + scoreTotal + " m";
    }
    public void BackButton()
    {
        carPanel.SetActive(false);
        menuPanel.SetActive(true);
        cameraShop.depth = 0;
    }

    public void GameOverMethod()
    {
        gameOver = true;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        gameoverScore.text = "Score: " + score + " m";
        if (deathCounter >= 6)
        {
            AdScript.showAd();
            deathCounter = 0;
        }
        deathCounter++;
        PlayerPrefs.SetInt("DeathCounter", deathCounter);
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        gameoverHighscore.text = "High score: " + highScore + " m";
        scoreTotal = scoreTotal + score;
        PlayerPrefs.SetFloat("ScoreTotal", scoreTotal);
    }
    public void CarManagement()
    {
        if (PlayerPrefs.HasKey("CarSelected"))
        {
            carSelected = PlayerPrefs.GetInt("CarSelected");
        }
        Transistor.car1.SetActive(false);
        Transistor.car2.SetActive(false);
        Transistor.car3.SetActive(false);
        Transistor.car4.SetActive(false);
        Transistor.car5.SetActive(false);
        Transistor.car6.SetActive(false);
        Transistor.car7.SetActive(false);
        Transistor.car8.SetActive(false);
        Transistor.car9.SetActive(false);
        Transistor.car10.SetActive(false);
        Transistor.car11.SetActive(false);
        Transistor.car12.SetActive(false);
        Transistor.car13.SetActive(false);
        Transistor.car14.SetActive(false);
        Transistor.car15.SetActive(false);
        Transistor.car16.SetActive(false);
        Transistor.car17.SetActive(false);
        Transistor.car18.SetActive(false);
        Transistor.car19.SetActive(false);
        Transistor.car20.SetActive(false);
        Transistor.car21.SetActive(false);
        Transistor.car22.SetActive(false);
        Transistor.car23.SetActive(false);
        Transistor.car24.SetActive(false);
        Transistor.car25.SetActive(false);
        Transistor.car26.SetActive(false);
        Transistor.car27.SetActive(false);
        Transistor.car28.SetActive(false);
        Transistor.car29.SetActive(false);
        Transistor.car30.SetActive(false);
        Transistor.car31.SetActive(false);

        if (carSelected == 1)
            Transistor.car1.SetActive(true);
        else Transistor.car1.SetActive(false);
        if (carSelected == 2)
            Transistor.car2.SetActive(true);
        if (carSelected == 3)
            Transistor.car3.SetActive(true);
        if (carSelected == 4)
            Transistor.car4.SetActive(true);
        if (carSelected == 5)
            Transistor.car5.SetActive(true);
        if (carSelected == 6)
            Transistor.car6.SetActive(true);
        if (carSelected == 7)
            Transistor.car7.SetActive(true);
        if (carSelected == 8)
            Transistor.car8.SetActive(true);
        if (carSelected == 9)
            Transistor.car9.SetActive(true);
        if (carSelected == 10)
            Transistor.car10.SetActive(true);
        if (carSelected == 11)
            Transistor.car11.SetActive(true);
        if (carSelected == 12)
            Transistor.car12.SetActive(true);
        if (carSelected == 13)
            Transistor.car13.SetActive(true);
        if (carSelected == 14)
            Transistor.car14.SetActive(true);
        if (carSelected == 15)
            Transistor.car15.SetActive(true);
        if (carSelected == 16)
            Transistor.car16.SetActive(true);
        if (carSelected == 17)
            Transistor.car17.SetActive(true);
        if (carSelected == 18)
            Transistor.car18.SetActive(true);
        if (carSelected == 19)
            Transistor.car19.SetActive(true);
        if (carSelected == 20)
            Transistor.car20.SetActive(true);
        if (carSelected == 21)
            Transistor.car21.SetActive(true);
        if (carSelected == 22)
            Transistor.car22.SetActive(true);
        if (carSelected == 23)
            Transistor.car23.SetActive(true);
        if (carSelected == 24)
            Transistor.car24.SetActive(true);
        if (carSelected == 25)
            Transistor.car25.SetActive(true);
        if (carSelected == 26)
            Transistor.car26.SetActive(true);
        if (carSelected == 27)
            Transistor.car27.SetActive(true);
        if (carSelected == 28)
            Transistor.car28.SetActive(true);
        if (carSelected == 29)
            Transistor.car29.SetActive(true);
        if (carSelected == 30)
            Transistor.car30.SetActive(true);
        if (carSelected == 31)
            Transistor.car31.SetActive(true);
    }
    public void ResetCars()
    {

    }
}
