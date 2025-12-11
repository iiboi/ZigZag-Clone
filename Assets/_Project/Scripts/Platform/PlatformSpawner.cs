using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject platformPrefab;

    [Header("Settings")]
    [SerializeField] private float offset = 2.5f;
    [SerializeField] private Vector3 lastPos;

    int spawnCount = 0;

    private void Start() 
    {
        for (int i = 0; i < 30; i++)
        {
            PlatformSpawn();
            
        }
    }
    public void PlatformSpawn()
    {
        int direction;

        if (spawnCount < 5)
        {
            direction = 1;
        }
        else
        {
            direction = Random.Range(0, 2);
        }

        if(direction == 0)
        {
            lastPos.x += offset;
        }
        else
        {
            lastPos.z += offset;
        }
        
        Instantiate(platformPrefab, lastPos, Quaternion.identity);
        
        spawnCount++;
    }
}