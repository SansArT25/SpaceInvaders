using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private int kills, points, lives, highScore, shots;
    [SerializeField] private GameObject player;
    private bool playing;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public int Kills { get => kills; set => kills = value; }
    public int Points { get => points; set => points = value; }
    public int Lives { get => lives; set => lives = value; }
    public int HighScore { get => highScore; set => highScore = value; }
    public bool Playing { get => playing; set => playing = value; }
    public int Shots { get => shots; set => shots = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        kills = 0;
        points = 0;
        lives = 3;
        playing = false;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void Restart()
    {
        if (points > highScore)
        {
            PlayerPrefs.SetInt("HighScore", points);
            SceneManager.LoadScene(0);
        }
    }

    public void LoseLife()
    {
        lives--;
        CanvasManager.Instance.LoseLife();
        player.transform.position = new Vector3(-2.3f, player.transform.position.y, player.transform.position.z);
        if(lives == 0)
        {
            player.SetActive(false);
            playing = false;
        }
    }
}