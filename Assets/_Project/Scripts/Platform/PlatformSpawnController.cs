using UnityEngine;

public class PlatformSpawnController : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    //Top(Oyuncu) Platformu terkettiği anda, Yeni Platform oluşturulur. 
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<PlatformSpawner>().PlatformSpawn();
            //Platform 1 saniye sonra düşmeye başlar.
            Invoke(nameof(PlatformFall), 0.4f);
            //Platform 2.5 saniye sonra yok edilir.
            Invoke(nameof(PlatformDestroy), 1.6f);
        }

    }

    //Platformun düşmesi için Kinematic'i devre dışı bırakır. 
    private void PlatformFall()
    {
        rb.isKinematic = false;
    }

    //Platformu yok eder. 
    private void PlatformDestroy()
    {
        Destroy(gameObject);
    }
}