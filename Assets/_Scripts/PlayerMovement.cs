using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audio;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {
        if (GameControler.gameOver) return;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameControler.gameOver) return;
        if (other.tag == "Coletavel")
        {
            audio.Play();
            GameControler.AddScore(1);
            Destroy(other.gameObject);
            
            FindObjectOfType<CollectableSpawner>().SpawnCollectable();
        }
    }
}
