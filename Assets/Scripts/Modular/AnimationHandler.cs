using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
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

    public void PlayMoveAnimation()
    {

        animator.SetBool("IsRun", true);
    }
    
    public void UpdateFacingDirection()
    {
        if (InputManager.Instance.MoveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (InputManager.Instance.MoveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}