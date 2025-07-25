using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Handlers
    KnockBackHandler knockBackHandler;
    StatBarHandler healthBar;

    //Data
    [SerializeField] EnemyData enemyData;

    //components
    public Rigidbody2D rb;

    // Enemy attributes
    float attackDamage;
    float defense;
    float maxHealth; // Maximum health of the enemy
    public float moveSpeed;
    public int enemyStatus;


    void Start()
    {
        InitializeComponents();
        InitializeData();
    }

    void Update()
    {

    }

    public void TakeDamage(float damage, Vector2 source)
    {
        // Implement damage logic here
        healthBar.UpdateValue(-damage);
        knockBackHandler.ApplyKnockBack(source);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(Constant.COLLIDER_DAMAGE, transform.position);
            TakeDamage(Constant.COLLIDER_DAMAGE, other.transform.position);
        }
    }

    public void Move(Vector2 direction)
    {
        if (knockBackHandler.isBeingKnockedBack) return;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void InitializeComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar = transform.Find("HealthBar").GetComponent<StatBarHandler>();
        knockBackHandler = GetComponent<KnockBackHandler>();
        if(knockBackHandler == null)
        {
            Debug.LogError("KnockBackHandler component is missing on " + gameObject.name);
        }
    }

    private void InitializeData()
    {
        // Initialize enemy attributes from EnemyData
        maxHealth = enemyData.enemyHealth;
        moveSpeed = enemyData.enemySpeed;
        attackDamage = enemyData.enemyAttackDamage;
        defense = enemyData.enemyDefense;


        GetComponent<SpriteRenderer>().sprite = enemyData.enemySprite;
        healthBar.SetValue(maxHealth);
        enemyStatus = Constant.ENEMY_STATUS_IDLE;
    }

}