using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenu : MonoBehaviour
{
    public int score;
    public int wave;

    public void OnPlayButton()
    {
        //isMenuOpen = !isMenuOpen;
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void LoadButton()
    {
        GameData data = SaveSystem.LoadScore();

        score = data.score;
        wave = data.wave;

        Debug.Log("Score: " + score);
        Debug.Log("Current Wave: " + wave);

        //SceneManager.LoadScene(1);
    }

    public void SaveButton()
    {
        SaveSystem.SaveGame(LevelManager.main, EnemySpawner.main);
    }
}
