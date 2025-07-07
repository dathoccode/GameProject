using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //controll variables
    [SerializeField] Joystick joystick;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Camera mainCamera;
    Rigidbody2D rb;

    //Animation variables
    PlayerAnimationController animationController;

    // Status variables
    public StatController statController;

    // Attack variables
    float attackRange = 1.5f;
    LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<PlayerAnimationController>();
        rb = GetComponent<Rigidbody2D>();
        statController = GetComponent<StatController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CameraFollow();
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
        Vector2 direction = joystick.Direction;
        if(direction.x == 0f)
        {
            animationController.PlayIdleAnimation();
            return;
        }
        animationController.UpdateFacingDirection(direction.x);
        animationController.PlayMoveAnimation(direction);
        rb.MovePosition(rb.position + direction * Time.deltaTime * moveSpeed);
    }

    public void Attack()
    {
        animationController.PlayAttackAnimation();
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
}
