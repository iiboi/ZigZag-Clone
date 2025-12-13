using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    //Unity'den sürükleyip bıraktığım referanslar. 
    [Header("References")]
    [SerializeField] BallMovement ballMovement;
    [SerializeField] UIManager uIManager;
    int score = 0;
    int speedLevel = 1;

    const string SAVE_KEY = "BestScore";

    public bool isGameOver = false;
    public bool isGameStarted = false;

    public static GameManager instance;

    //Oyun açıldığında henüz oyun başlamadığı için garantilemek adına burada da Oyunun başladığını false yapıyorum.
    private void Awake()
    {
        instance = this;

        isGameStarted = false;
    }

    //Oyun başlangıçta yapılmış en yüksek skoru ekrana yazdırır.
    private void Start() 
    {
        int savedScore = PlayerPrefs.GetInt(SAVE_KEY, 0);

        uIManager.UpdateBestScore(savedScore);

    }

    //Aynı fonksiyon PlatformCounter Scriptinde de çağırılır. Oyuncu bir blokla çarpıştığı anda, Skor artar.
    public void IncreaseScore()
    {
        score++;
        // Debug.Log($"Score: {score}");

        uIManager.UpdateGameScore(score);
        //Oyuncunun skoru her 50 olduğunda hızı artar.
        if (score % 50 == 0)
        {
            ballMovement.IncreaseSpeed();
            
            Debug.Log($"Speed Level: {speedLevel}");
            speedLevel++;
        }
    }

    //Oyun başladığında çalışır.
    public void GameStart()
    {
        isGameStarted = true;
        //Hangi UI'ın çalışması gerektiğini kontrol eder.
        uIManager.GameStartUI();
        //Topun hareket etmesini sağlar.
        ballMovement.StartMove();
    }

    //Oyun bittiğinde. (Top aşağı düştüğünde) çalışır.
    public void GameOver()
    {
        if (isGameOver == true)
        {
            return;
        }

        isGameOver = true;
        //Oyuncunun yaptığı en yüksek skoru kaydeder.
        int bestScore = PlayerPrefs.GetInt(SAVE_KEY, 0);

        //Eğer oyuncunun skoru En yüksek skordan daha büyükse, skoru, en yüksek skor olarak belirler.
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(SAVE_KEY, score);

            bestScore = score;
        }
        //Oyuncunun Yaptığı skor ve en yüksek skor, Ekrandaki UI Textlere yazdırılır.
        uIManager.UpdateBestScore(bestScore);
        uIManager.UpdateLoseScore(score);
        //Hangi UI'ın çalışması gerektiğini kontrol eder. 
        uIManager.GameOverUI();
    }    
    
    //Oyun yeniden başlatılır. Oyuncu, oyun sonu ekranında "Retry" Butonuna tıkladığında çalışır.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Oyun kapanır. Oyuncu, oyun sonu ekranında "Quit" Butonuna tıkladığında çalışır.
    public void QuitGame()
    {
        Application.Quit();
    }
}
