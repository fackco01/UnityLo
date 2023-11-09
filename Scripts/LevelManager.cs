using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("Attributes")]
    [SerializeField] private int playerHeart = 5;
    [SerializeField] private TextMeshProUGUI heartText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject loseGame;

    public Transform startPoint;
    public Transform[] path;

    public int currency;
    public int score;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        loseGame.SetActive(false);
        currency = 100;
    }

    void Update()
    {
        scoreText.text = score.ToString("D5");
        heartText.text = playerHeart.ToString();
        if (playerHeart <= 0)
        {
            loseGame.SetActive(true);
            Time.timeScale = 0;
            //SaveSystem.SaveGame(this, EnemySpawner.main);
            //SceneManager.LoadScene(0);
        }
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }


    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You don't have enough money");
            return false;
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public bool Heart(int amount)
    {
        if (amount <= playerHeart)
        {
            playerHeart -= amount;
            return true;
        }
        else { return false; }
    }
}
