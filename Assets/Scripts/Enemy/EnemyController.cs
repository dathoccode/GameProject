using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    StatBar healthBar;
    [SerializeField]EnemyData enemyData;

    //components
    public Rigidbody2D rb;

    // Enemy attributes
    float collideDamage; // Damage dealt on collision with player
    float attackDamage;
    float defense;
    float maxHealth; // Maximum health of the enemy
    public  float moveSpeed;
    public int status = Constant.ENEMY_STATUS_PATROLLING;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        InitializeComponents();
        InitializeData();
        

        healthBar = transform.Find("HealthBar").GetComponent<StatBar>();
        healthBar.SetValue(maxHealth); // Set initial health value
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        // Implement damage logic here
        // You can also add health reduction logic, animations, etc.
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(collideDamage, this.transform.position);
        }
    }

    private void InitializeComponents()
    {
        // Get the EnemyData from the Resources folder
        if (enemyData == null)
        {
            return;
        }
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void InitializeData()
    {
        // Initialize enemy attributes from EnemyData
        maxHealth = enemyData.enemyHealth;
        moveSpeed = enemyData.enemySpeed;
        collideDamage = enemyData.enemyCollideDamage;
        attackDamage = enemyData.enemyAttackDamage;
        defense = enemyData.enemyDefense;

        // Set the sprite for the enemy
        GetComponent<SpriteRenderer>().sprite = enemyData.enemySprite;
    }
}