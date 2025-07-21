using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    EnemyController enemyController;

    //support patrolling
    [SerializeField] float patrolRange = 5f; // Range for patrolling
    private Vector2 basePoint; // Point to return to after patrolling
    private Vector2 patrolPoint; // Random point within patrol range

    // support detecting player
    [SerializeField] float detectionRange = 5f;
    [SerializeField] float chasingRange = 10f; // only chase player within this range
    Transform player;
    void Start()
    {
        enemyController = GetComponent<EnemyController>();

        //this need change if there are multiple players
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // intialize attributes
        basePoint = transform.position;
        patrolPoint = transform.position;
    }

    void Update()
    {
        DetectPlayer();
        EnemyPatrol();
    }

    private void EnemyPatrol()
    {
        // If player is detected, stop patrolling
        if (enemyController.enemyStatus == Constant.ENEMY_STATUS_CHASING)
        {
            patrolPoint = basePoint;
            return;
        }
        //get random point within patrol range
        if (basePoint == null)
        {
            basePoint = transform.position;
        }
        //generate new random point if patrolPoint is null or too close to current position
        if (patrolPoint == null || Vector2.Distance(enemyController.rb.position, patrolPoint) < 0.1f)
        {
            patrolPoint = basePoint + Random.insideUnitCircle * patrolRange;
        }

        // Move towards the random point
        Vector2 direction = (patrolPoint - enemyController.rb.position).normalized;
        enemyController.Move(direction);
    }

    private void DetectPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            enemyController.enemyStatus = Constant.ENEMY_STATUS_CHASING;
            Vector2 direction = (player.position - transform.position).normalized;
            enemyController.Move(direction);
        }

        //give up chasing if player is too far away or get too far from base point
        if (Vector2.Distance(transform.position, player.position) > detectionRange || Vector2.Distance(player.position, basePoint) >= chasingRange)
        {
            enemyController.enemyStatus = Constant.ENEMY_STATUS_PATROLLING;
        }
    }
}