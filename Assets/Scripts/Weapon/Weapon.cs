using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;

    //components
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    //properties
    public string weaponName;
    public float damage;
    public float range;
    public float attackSpeed;
    public Sprite weaponSprite;

    protected bool isCoolingDown;
    protected float cooldownTimer;


    protected virtual void Start()
    {
        InitializeComponents();
        InitializeData();
    }
    void Update()
    {
        // Update weapon state or handle input if necessary
        if (isCoolingDown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f) isCoolingDown = false;
        }
    }

    public virtual void Attack()
    {
        PlayAttackAnimation();
        Cooldown();
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger("IsAttack");
    }

    protected virtual void InitializeData()
    {
        if (weaponData == null)
        {
            Debug.LogError("WeaponData is not assigned in the inspector.");
            return;
        }
        weaponName = weaponData.weaponName;
        damage = weaponData.damage;
        range = weaponData.range;
        attackSpeed = weaponData.attackSpeed;
        weaponSprite = weaponData.weaponSprite;

        //set default values
        spriteRenderer.sprite = weaponSprite;
        cooldownTimer = 0;
        isCoolingDown = false;
    }

    protected virtual void InitializeComponents()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Cooldown()
    {
        cooldownTimer = 1f / attackSpeed;
        isCoolingDown = true;
    }

}