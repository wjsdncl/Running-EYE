using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameManager GM;

    public Text myCoin;
    public Text endScore;
    public Text bestScore;

    public GameObject MainPanel;
    public GameObject CharPanel;
    public GameObject LbPanel;
    public GameObject OptionPanel;

    void Start() {
        myCoin.text = PlayerPrefs.GetInt("MyCoin").ToString();
        endScore.text = PlayerPrefs.GetInt("LastScore").ToString();
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        //PlayerPrefs.DeleteAll();


    }
    
    public void Start_Btn()
    {
        SceneManager.LoadScene("02. Game");
    }
    public void Characters_Btn()
    {
        MainPanel.SetActive(false);
        CharPanel.SetActive(true);
    }
    public void Leaderboards_Btn()
    {
        MainPanel.SetActive(false);
        LbPanel.SetActive(true);
    }
    public void Option_Btn()
    {
        MainPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }
    public void Quit_Btn()
    {
        Application.Quit();
    }

    public void X_Btn()
    {
        CharPanel.SetActive(false);
        LbPanel.SetActive(false);
        OptionPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
}
