using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 8f;

    private Rigidbody rb;

    private bool isMovingForward = true;

    //Rigidbody referansı tanımlanır.
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }


    //Hız Denklemi.
    public void StartMove()
    {
        rb.linearVelocity = Vector3.forward * speed;
    }
    private void Update()
    {   

        //Değişken false ise, oyuncu topu kontrol edemez.
        if (GameManager.instance.isGameStarted == false)
        {
            return;
        }

        //Top platformdan düştükten sonra -2 yüksekliğine geldiğinde, Oyun bitti fonksiyonu GameManager'dan çağırılır.
        if (transform.position.y < -2)
        {
            GameManager.instance.GameOver();
        }

        //Oyun Top aşağı düştüyse, Oyuncu topun kontrolünü kaybeder. 
        if (GameManager.instance.isGameOver == true)
        {
            return;
        }

        //Eğer topun yüksekliği 0.75'den büyükse onu 0.75'e sabitler. Bunu topun ufak ufak zıplamalar yapması yüzünden yazdım.
        if (transform.position.y > 0.75)
        {
            Vector3 tempPos = transform.position;
            tempPos.y = 0.75f;
            transform.position = tempPos;    
        }
        
        //Oyuncu Mouse Sol Tık'a bastığında / Ekrana dokunduğunda çalışır.
        if (Input.GetMouseButtonDown(0))
        {
            Movement();
        }

    }

    //Topun nasıl hareket edeceği tanımlanır. 
    private void Movement()
    {
        if(isMovingForward)
        {
            rb.linearVelocity = Vector3.right * speed;

            isMovingForward = false;
        }
        else
        {
            rb.linearVelocity = Vector3.forward * speed;

            isMovingForward = true;
        }
    }

    //Hız artırmak için yapılan hesaplama.
    public void IncreaseSpeed()
    {
        speed += 1.5f;

        Debug.Log($"New Speed: {speed}");
    }
}