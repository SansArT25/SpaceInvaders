using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    private static CanvasManager instance;
    [SerializeField] private TextMeshProUGUI points, highScore, kills, lives;
    [SerializeField] private Slider rush, swipe;
    [SerializeField] private GameObject intro, live1, live2, gameOver;
    [SerializeField] private PlayerShoot times;

    public static CanvasManager Instance
    {
        get { return instance; }
    }

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
        highScore.text = GameManager.Instance.HighScore.ToString();
        lives.text = GameManager.Instance.Lives.ToString();
    }

    void Update()
    {
        points.text = GameManager.Instance.Points.ToString();
        kills.text = GameManager.Instance.Kills.ToString();
        lives.text = GameManager.Instance.Lives.ToString();
        rush.value = 30 - times.TimeRush;
        swipe.value = 60 - times.TimeSwipe;
    }

    public void LoseLife()
    {
        if(live2.activeInHierarchy)
        {
            live2.SetActive(false);
        }
        else if(live1.activeInHierarchy)
        {
            live1.SetActive(false);
        }
        else
        {
            gameOver.SetActive(true);
        }
        lives.text = GameManager.Instance.Lives.ToString();
        if(GameManager.Instance.Lives == 0)
        {
            gameOver.SetActive(true);
        }
    }
}
