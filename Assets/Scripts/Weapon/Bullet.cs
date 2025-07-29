using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float duration = 2f;
    public float damage = 1f;

    SpriteRenderer bulletSpriteRenderer;
    void Start()
    {
        bulletSpriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision entered");
        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage, transform.position);
        }
        //Destroy the bullet on collision with any object
        Destroy(gameObject);
    }
}