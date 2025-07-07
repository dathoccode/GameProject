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

    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("IsAttack");
    }

    public void PlayIdleAnimation()
    {
        animator.SetBool("IsRun", false);
    }

    public void PlayMoveAnimation(Vector2 direction)
    {
        animator.SetBool("IsRun", true);
    }

    public void UpdateFacingDirection(float directionX)
    {
        if (directionX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (directionX < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}