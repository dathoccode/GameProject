using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Singleton instance
    public static PlayerController Instance { get; private set; }

    //controll variables
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Camera mainCamera;
    Rigidbody2D rb;

    //Animation variables
    PlayerAnimationController animationController;

    // Status variables
    PlayerStatController statController{ get; set; }
    public int playerStatus { get; private set; }

    // Attack variables
    float attackRange = 1.5f;
    public int pushBackForce = 4;
    LayerMask enemyLayer;

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
        animationController = GetComponent<PlayerAnimationController>();
        rb = GetComponent<Rigidbody2D>();
        statController = GetComponent<PlayerStatController>();

        // Initialize player status
        playerStatus = Constant.PLAYER_STATUS_IDLE;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        Move();
        CameraFollow();
    }

    void Update()
    {
        if (InputManager.Instance.IsAttackPressed) Attack();
    }

    private void CameraFollow()
    {
        if (mainCamera != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = mainCamera.transform.position.z;
            mainCamera.transform.position = newPosition;
        }
    }

    private void Move()
    {
        if(playerStatus == Constant.PLAYER_STATUS_KNOCKBACK) return;
        if (InputManager.Instance.MoveInput == Vector2.zero)
        {
            playerStatus = Constant.PLAYER_STATUS_IDLE;
            return;
        }
        animationController.UpdateFacingDirection();
        playerStatus = Constant.PLAYER_STATUS_RUNNING;
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * InputManager.Instance.MoveInput);
    }

    public void Attack()
    {
        playerStatus = Constant.PLAYER_STATUS_ATTACKING;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in enemies)
        {
            // Assuming the enemy has a method to take damage
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(10); // Example damage value
            }
        }
    }

    public void TakeDamage(float damage, Vector2 source)
    {
        statController.healthBar.ChangeCurrentValue(-damage);
        if (statController.healthBar.currentValue <= 0)
        {
            playerStatus = Constant.PLAYER_STATUS_DEAD;
            // Handle player death logic here, e.g., play death animation, disable controls, etc.
        }
        StartCoroutine(KnockBack(source));
    }

    private IEnumerator KnockBack(Vector2 source)
    {
        Vector2 knockbackDirection = (rb.position - source).normalized;

        // Player cant move or attack while being knocked back
        playerStatus = Constant.PLAYER_STATUS_KNOCKBACK;
        InputManager.Instance.ResetMoveInput();

        //make player be pushed back when taking damage
        rb.AddForce(knockbackDirection * pushBackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        rb.linearVelocity = Vector2.zero; // Reset velocity after knockback
        playerStatus = Constant.PLAYER_STATUS_IDLE; // Reset status after knockback
    }
}
