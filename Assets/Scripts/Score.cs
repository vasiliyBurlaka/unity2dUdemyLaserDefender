using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float TotalScore = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(FindObjectsOfType(GetType()).Length);
        if (FindObjectsOfType(GetType()).Length > 1) {
            Debug.Log("OK, its not one!");
            Debug.Log(FindObjectsOfType(GetType()).Length);
            Destroy(gameObject);
        } else {
            Debug.Log("DontDestroyOnLoad");
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
