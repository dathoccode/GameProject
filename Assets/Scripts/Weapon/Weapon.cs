using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    private Animator animator;
    //properties
    public string weaponName;
    public float damage;
    public float range;
    public float attackSpeed;
    public Sprite weaponSprite;

    protected virtual void Start()
    {
        InitializeData();
        InitializeComponents();
    }
    void Update()
    {
        // Update weapon state or handle input if necessary
    }

    public  virtual void Attack()
    {
        PlayAttackAnimation();
        // Implement attack logic here
        // Logic: detect enemy in range(using weaponData.range), apply damage on enemies detected
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
        // Set other weapon properties if needed
    }

    protected virtual void InitializeComponents()
    {
        animator = GetComponent<Animator>();

    }
}