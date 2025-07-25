using UnityEngine;

public class PlayerAnimationHandler : AnimationHandler
{
    void Start()
    {
        base.animator = GetComponent<Animator>();
        base.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //handle player animation based on player status
        switch (PlayerController.Instance.PlayerStatus)
        {
            case Constant.PLAYER_STATUS_IDLE:
                PlayIdleAnimation();
                break;
            case Constant.PLAYER_STATUS_RUNNING:
                UpdateFacingDirection();
                PlayMoveAnimation();
                break;
            case Constant.PLAYER_STATUS_ATTACKING:
                PlayAttackAnimation();
                break;
        }
    }
}