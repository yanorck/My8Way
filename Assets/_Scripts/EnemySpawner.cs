using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public LayerMask avoidCollisionWith;

    public float spawnRadius = 6f;
    public float baseInterval = 3f;
    public float minInterval = 0.8f;
    public float difficultyScale = 30f;

    public int maxEnemies = 10;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (GameControler.gameOver) return;
        
        int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (currentEnemies >= maxEnemies) return;

        float elapsedTime = TimerManager.GetFinalTime();
        float dynamicInterval = Mathf.Max(minInterval, baseInterval - (elapsedTime / difficultyScale));

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + dynamicInterval;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = GetValidSpawnPosition();
        if (spawnPos == Vector2.zero)
        {
            Debug.LogWarning("Nenhuma posição válida encontrada.");
            return;
        }

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        EnemyFollow follow = newEnemy.GetComponent<EnemyFollow>();
        follow.player = player;

        if (Random.value < 0.3f)
        {
            follow.speed = Random.Range(3.5f, 5f);
            follow.selfDestruct = true;
        }
        else
        {
            follow.speed = Random.Range(1f, 2f);
            follow.selfDestruct = false;
        }
    }

    Vector2 GetValidSpawnPosition()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector2 tryPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;
            Collider2D overlap = Physics2D.OverlapCircle(tryPos, 0.6f, avoidCollisionWith);
            if (overlap == null)
                return tryPos;
        }
        return Vector2.zero;
    }
}
