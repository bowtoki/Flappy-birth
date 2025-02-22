using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Sprite> Medalsprite=new List<Sprite>();
    public Image MedalImage;
    public GameObject RankBoard;
    public GameObject tipObject;
    public bool IsDead=false;
    public int score=0;
    public int bestScore=0;
    public float delay=2f;
    public Text scoreText;
    public Text currentText;
    public Text bestScoreText;
    private void Awake()
    {
        instance=this;
    }
    void Start()
    {
        RankBoard=GameObject.FindWithTag("Dialog");
        tipObject=GameObject.Find("TipObject");
        RankBoard.SetActive(false);
        scoreText.text=score.ToString();
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        bestScoreText.text=PlayerPrefs.GetInt("bestScore", 0).ToString();
    }
    void Update()
    {
        checkScore();
        scoreText.text=score.ToString();
    }
    public void AddScore()
    {
        score++;
    }
    public void checkScore()
    {
        if(score>50 && score<=100)
        {
            MedalImage.sprite=Medalsprite[1];
            delay=1.5f;
        }
        else if(score>100)
        {
            MedalImage.sprite=Medalsprite[2];
            delay=1.0f;
        }
        else if(score>500)
        {
            MedalImage.sprite=Medalsprite[3];
            delay=1.0f;
        }
        else
        {
            if(score>10)
            {
                MedalImage.sprite=Medalsprite[0];
            }
            else
            {
                MedalImage.sprite=null;
            }
            delay=2.0f;
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void RankBoardDialog()
    {
        RankBoard.SetActive(true);
    }
    public void OK()
    {
        RankBoard.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void MenuGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}
