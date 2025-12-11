using UnityEngine;

public class PlatformCounter : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncreaseScore();
        }
    }
}
