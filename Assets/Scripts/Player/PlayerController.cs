using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Singleton instance
    public static PlayerController Instance { get; private set; }

    // Handlers
    private KnockBackHandler knockBackHandler;
    private PlayerAnimationHandler animationHandler;
    [SerializeField] private StatBarHandler healthBar;
    [SerializeField] private StatBarHandler manaBar;

    //movement variables
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;
    
    // Status variables
    public int PlayerStatus { get; private set; }
    public float MaxHealth { get; private set; }
    public float MaxMana { get; private set; }

    // Attack variables
    [SerializeField] Weapon currentWeapon;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        InitializeComponents();
        InitializeData();
    }

    private void InitializeData()
    {
        //this is temporary data initialization, it should be stored in database or scriptable object
        MaxHealth = 100f; 
        MaxMana = 50f;

        PlayerStatus = Constant.PLAYER_STATUS_IDLE;
        healthBar.SetValue(MaxHealth);
        manaBar.SetValue(MaxMana);
    }

    private void InitializeComponents()
    {
        animationHandler = GetComponent<PlayerAnimationHandler>();
        knockBackHandler = GetComponent<KnockBackHandler>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        if (InputManager.Instance.IsAttackPressed) Attack();
    }

    private void Move()
    {
        if (knockBackHandler.isBeingKnockedBack) return;
        if (InputManager.Instance.MoveInput == Vector2.zero)
        {
            PlayerStatus = Constant.PLAYER_STATUS_IDLE;
            return;
        }
        animationHandler.UpdateFacingDirection();
        PlayerStatus = Constant.PLAYER_STATUS_RUNNING;
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * InputManager.Instance.MoveInput);
    }

    public void Attack()
    {
        if(currentWeapon == null)
        {
            Debug.LogWarning("No weapon assigned for attack.");
            return;
        }
        currentWeapon.Attack();
    }

    public void TakeDamage(float damage, Vector2 source)
    {
        healthBar.UpdateValue(-damage);
        knockBackHandler.ApplyKnockBack(source);
        if (healthBar.currentValue <= 0)
        {
            PlayerStatus = Constant.PLAYER_STATUS_DEAD;
            // Handle player death logic here, e.g., play death animation, disable controls, etc.
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Weapon is set to " + collision.gameObject.name);
            SetWeapon(collision.gameObject.GetComponent<Weapon>());
        }
    }

    void SetWeapon(Weapon newWeapon)
    {
        this.currentWeapon = newWeapon;
    }
    
}
