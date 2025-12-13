using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject platformPrefab;

    [Header("Settings")]
    [SerializeField] private float offset = 2.5f;
    [SerializeField] private Vector3 lastPos;

    int spawnCount = 0;


    //Start'da döngüyle oyun başlar başlamaz 30 adet platform oluşturulur.
    private void Start() 
    {   //Platform Oluşturma döngüsü.
        for (int i = 0; i < 30; i++)
        {
            PlatformSpawn();
            
        }
    }


    public void PlatformSpawn()
    {
        int direction;
        
        //Oluşturulan ilk 5 platformun aynı yönde olması için Yön değişkeni 5. Platforma kadar aynı yönde oluşturulur.
        if (spawnCount < 5)
        {
            direction = 1;
        }
        else
        {   
            //Onun dışında, Yön değişkeni hep 0(Düz) ile 1(Sağ) arasında rastgele oluşturulur.
            direction = Random.Range(0, 2);
        }

        if(direction == 0)
        {   
            //Objenin x yönündeki son pozisyonuna objenin offset'i (Boyutu) eklenir.
            //Bunun sebebi, halihazırda spawnlanan objenin spawnlanacak objenin alanını kapatmaması (Üst üste binmemesi) içindir.
            lastPos.x += offset;
        }
        else
        {   
            //Yukarıdaki işlemin aynısı.
            lastPos.z += offset;
        }
        //Hayatımda ilk defa Instantiate kullandım. Oluşturulacak objenin referansı, Son pozisyonu, ve yönü girilerek obje inşa edilir. 
        Instantiate(platformPrefab, lastPos, Quaternion.identity);
        
        spawnCount++;
    }
}