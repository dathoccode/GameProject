using UnityEngine;

public class RangedWeapon : Weapon
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private RangedWeaponData rangedWeaponData;
    Bullet bullet;

    protected override void Start()
    {
        weaponData = rangedWeaponData;
        base.Start();

        bullet = bulletPrefab.GetComponent<Bullet>();
        
        InitializeComponents();
        InitializeData();
    }
    void Update()
    {

    }
    public override void Attack()
    {
        base.Attack();
        //instantiate bullet on the right site of the rangedd weapon
        GameObject bulletObject = Instantiate(bulletPrefab, new Vector2(transform.position.x + 0.2f, transform.position.y), Quaternion.identity);
        bulletObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * bulletObject.GetComponent<Bullet>().speed;
    }
}