using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Scripts/Core/ScriptableObject/ScoreData")]
public class ScoreManager : ScriptableObject
{
    public int score;
    public int highScore;
    

    public void ScoreReset()
    {
        score = 0;
    }
    
    public void CheckHighscore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

    public void GetHighscore()
    {
        highScore = PlayerPrefs.GetInt("highscore", highScore);
    }
    
}