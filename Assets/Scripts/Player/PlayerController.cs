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
    public int playerStatus { get; private set; }

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

    // Start is called before the first frame update
    void Start()
    {
        animationHandler = GetComponent<PlayerAnimationHandler>();
        knockBackHandler = GetComponent<KnockBackHandler>();
        rb = GetComponent<Rigidbody2D>();

        // Initialize player status
        playerStatus = Constant.PLAYER_STATUS_IDLE;
    }
    // Update is called once per frame
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
            playerStatus = Constant.PLAYER_STATUS_IDLE;
            return;
        }
        animationHandler.UpdateFacingDirection();
        playerStatus = Constant.PLAYER_STATUS_RUNNING;
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * InputManager.Instance.MoveInput);
    }

    public void Attack()
    {
        //TODO: call weapon attack method if currentWeapon is assigned
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
            playerStatus = Constant.PLAYER_STATUS_DEAD;
            // Handle player death logic here, e.g., play death animation, disable controls, etc.
        }

    }


    
}
