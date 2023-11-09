using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public int wave;

    public GameData(LevelManager levelManager, EnemySpawner enemySpawner)
    {
        score = levelManager.score;
        wave = enemySpawner.currentWave;
    }
}
