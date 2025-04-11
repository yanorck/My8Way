using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 1.5f;
    public bool selfDestruct = false;
    private float timer = 0f;

    void Start()
    {
        if (selfDestruct)
        {
            Destroy(gameObject, 2f);
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
            
            if (direction.x > 0)
                transform.localScale = new Vector3(-1, 1, 1); // pedala robinho
            else if (direction.x < 0)
                transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameControler.ForceGameOver();
        }
    }
}