using UnityEngine;

public class EnemyAnimationHandler : AnimationHandler
{
    EnemyController enemyController;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyController = GetComponent<EnemyController>();
    }

    void Update()
    {
        //handle enemy animation based on enemy status
        switch (enemyController.enemyStatus)
        {
            case Constant.ENEMY_STATUS_IDLE:
                PlayIdleAnimation();
                break;
            case Constant.ENEMY_STATUS_PATROLLING:
            case Constant.ENEMY_STATUS_CHASING:
                UpdateFacingDirection();
                PlayMoveAnimation();
                break;
            case Constant.ENEMY_STATUS_ATTACKING:
                PlayAttackAnimation();
                break;
        }
    }
}
