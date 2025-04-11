using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject collectablePrefab;
    public int initialAmount = 5;

    public float minX = -8f, maxX = 8f;
    public float minY = -4f, maxY = 4f;

    void Start()
    {
        for (int i = 0; i < initialAmount; i++)
        {
            SpawnCollectable();
        }
    }

    public void SpawnCollectable()
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(collectablePrefab, randomPos, Quaternion.identity);
    }
}