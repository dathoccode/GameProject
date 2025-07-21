using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] WeaponData weaponData;
    private Animator animator;

    void Start()
    {
        InitializeData();
        InitializeComponents();
    }
    void Update()
    {
        // Update weapon state or handle input if necessary
    }

    public void Attack()
    {
        PlayAttackAnimation();
        // Implement attack logic here
        // Logic: detect enemy in range(using weaponData.range), apply damage on enemies detected
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger("IsAttack");
    }

    private void InitializeData()
    {
        if (weaponData == null)
        {
            Debug.LogError("WeaponData is not assigned in the inspector.");
            return;
        }

        // Set other weapon properties if needed
    }

    private void InitializeComponents()
    {
        animator = GetComponent<Animator>();

    }
}