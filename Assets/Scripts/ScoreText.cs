using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TextMeshProUGUI scoreTextComponent;
    Score gameScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreTextComponent = GetComponent<TextMeshProUGUI>();
        gameScore = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextComponent.text = GetScoreWithZeros();
    }

    // Get formated score with zeros
    private string GetScoreWithZeros()
    {
        if (gameScore == null) {
            gameScore = FindObjectOfType<Score>();
        }
        string scoreText = gameScore.GetScore().ToString();
        int scoreTextLength = 8;
        int zeroCount = scoreTextLength - scoreText.Length;
        for(int zeroCounter = 0; zeroCounter < zeroCount; zeroCounter++) {
            scoreText = "0" + scoreText;
        }
        return scoreText;
    }
}
