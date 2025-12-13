using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Unity'den sürükleyip bıraktığım referanslar.
    [Header("References")]
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject losePanel;
    
    //Skorun yazması gereken Text alanlarının referansları.
    [Header("Score Texts")]
    [SerializeField] TextMeshProUGUI gameScoreText;
    [SerializeField] TextMeshProUGUI startBestScoreText;
    [SerializeField] TextMeshProUGUI loseBestScoreText;
    [SerializeField] TextMeshProUGUI loseCurrentScoreText;

    public static UIManager instance;

    private void Awake() 
    {
        instance = this;
    }

    //Oyun başladığında standart olarak, Start Paneli gözükür ve ingame ile oyun sonu paneli devre dışı bırakılır.
    private void Start() 
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        losePanel.SetActive(false);
    }

    //Oyuncu ekrana tıkladığında ingame panel gelir, start paneli devre dışı kalır aynı zamanda, oyun sonu paneli yine devre dışı bırakılır.
    public void GameStartUI()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        losePanel.SetActive(false);
    }

    //Oyun kaybedildiğinde (Top aşağı düştüğünde) Oyun sonu paneli devreye girer ve ingame ile Start paneli kapanır.
    public void GameOverUI()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(false);
        losePanel.SetActive(true);
    }


    //Oyuncunun Yaptığı skor ve en yüksek skor, Ekrandaki UI Textlere yazdırılır.
    public void UpdateGameScore(int currentScore)
    {   
        gameScoreText.text = currentScore.ToString();
    }

    //En yüksek skor, hem start panelinde hemde oyun sonu panelinde güncellenir.
    public void UpdateBestScore(int bestScore)
    {
        startBestScoreText.text = "BEST SCORE: " + bestScore.ToString();
        loseBestScoreText.text = "BEST SCORE: " + bestScore.ToString();
    }

    //Oyun sonu ekranında skor yazılır.
    public void UpdateLoseScore(int score)
    {
        
        if(loseCurrentScoreText != null)
        {
            loseCurrentScoreText.text = "SCORE: " + score.ToString();
        }
    }
}
