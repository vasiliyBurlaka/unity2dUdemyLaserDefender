using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float TotalScore = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public float GetScore() {
        return TotalScore;
    }

    public void AddPoints(float Points) {
        TotalScore += Points;
    }

    public void ResetScore()
    {
        TotalScore = 0;
    }
}
