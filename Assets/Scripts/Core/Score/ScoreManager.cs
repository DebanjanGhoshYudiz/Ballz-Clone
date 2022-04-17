using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Scripts/Core/ScriptableObject/ScoreData")]
public class ScoreManager : ScriptableObject
{
    public int score;

    public void ScoreReset()
    {
        score = 0;
    }
}
