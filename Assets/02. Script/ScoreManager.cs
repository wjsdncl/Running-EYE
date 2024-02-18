using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
        static ScoreManager instance;

    public static ScoreManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
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

    public int coin;

    public int score = 0;

    public float score_Timer = 0;

    public bool gameOver = false;

    void Start()
    {
        gameObject.SetActive(true);
        score = 0;
    }

    void Update()
    {
        score_Timer += Time.deltaTime * 10;
        score = (int)score_Timer;
    }

    void GameOver()
    {
        this.gameObject.SetActive(false);
    }
}
