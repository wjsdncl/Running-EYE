using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text coin_Text;
    public Text score_Text;

    [SerializeField]
    static public float GroundSpeed = 15f;

    public GameObject EndPanel;

    public Text myCoin;
    public Text endScore;
    public Text bestScore;
    public Text newScore;

    private bool isGameStop = false;

    public Text countdownText = null;
    public float countdown = 0f;
    


    void Start()
    {
        ScoreManager.Instance.coin = PlayerPrefs.GetInt("MyCoin", 0);
        PlayerPrefs.Save();

        ScoreManager.Instance.score = 0;

        GroundSpeed = 15f;

        EndPanel.SetActive(false);

        coin_Text.text = ScoreManager.Instance.coin.ToString();
        score_Text.text = ScoreManager.Instance.score.ToString();
        

    }

    void Update()
    {
        coin_Text.text = ScoreManager.Instance.coin.ToString();
        score_Text.text = ScoreManager.Instance.score.ToString();
    }

    public void GoMain()
    {
        Time.timeScale = 1;
        GroundSpeed = 15f;
        SceneManager.LoadScene("01. Main");
    }

    public void ReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("02. Game");
    }

    public void Option()
    {
        
        if (!isGameStop)
        {
            Time.timeScale = 0f;
            isGameStop = true;

        }
        else
        {
            StartCoroutine(CountDown());

        }
        
    }

    IEnumerator CountDown()
    {
        countdownText.gameObject.SetActive(true);
        for(int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            //Debug.Log(i + "            카운트 다운");
            yield return new WaitForSecondsRealtime(1f);
        }

        countdownText.gameObject.SetActive(false);
        Time.timeScale = 1;
        isGameStop = false;
    }


    void GameOver()
    {
        GroundSpeed = 0;

        EndPanel.SetActive(true);

        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.score);
        PlayerPrefs.SetInt("MyCoin", ScoreManager.Instance.coin);

        if (ScoreManager.Instance.score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", ScoreManager.Instance.score);
            newScore.text = "NEW SCORE!";
        }

        
        myCoin.text = PlayerPrefs.GetInt("MyCoin").ToString();
        endScore.text = PlayerPrefs.GetInt("LastScore").ToString();
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
