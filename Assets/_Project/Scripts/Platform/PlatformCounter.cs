using UnityEngine;

public class PlatformCounter : MonoBehaviour
{
    // Platform'un çarpışma kutusuna bir obje girerse ve...
    public void OnCollisionEnter(Collision collision)
    {   
        //O objenin Tag'ı "Player" ise, Skor artar.
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncreaseScore();
        }
    }
}
