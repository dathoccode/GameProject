using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //handle player animation based on player status
        switch (PlayerController.Instance.playerStatus)
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

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("IsAttack");
    }

    public void PlayIdleAnimation()
    {
        animator.SetBool("IsRun", false);
    }

    public void PlayMoveAnimation()
    {
        
        animator.SetBool("IsRun", true);
    }

    public void UpdateFacingDirection()
    {
        if (InputManager.Instance.MoveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (InputManager.Instance.MoveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}