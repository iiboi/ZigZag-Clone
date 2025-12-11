using UnityEngine;

public class PlatformSpawnController : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<PlatformSpawner>().PlatformSpawn();
            Invoke(nameof(PlatformFall), 1f);
            Invoke(nameof(PlatformDestroy), 2.5f);
        }

    }

    private void PlatformFall()
    {
        rb.isKinematic = false;
    }

    private void PlatformDestroy()
    {
        Destroy(gameObject);
    }
}