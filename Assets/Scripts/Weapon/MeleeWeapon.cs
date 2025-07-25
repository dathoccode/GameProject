using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private MeleeWeaponData meleeWeaponData;
    float angle;
    protected override void Start()
    {
        weaponData = meleeWeaponData;
        base.Start();
        
        InitializeComponents();
        InitializeData();
    }


    public override void Attack()
    {
        base.Attack();
        // Implement melee attack logic here
        // Logic: detect enemy in range(using weaponData.range), apply damage on enemies detected
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyController>().TakeDamage(damage, transform.position);
                
            }
        }
    }

    void Update()
    {

    }

    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        // Initialize melee weapon specific components
    }

    protected override void InitializeData()
    {
        base.InitializeData();
        
    }
}