using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
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