using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Data/NewWeapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float range;
    public float attackSpeed;
    public Sprite weaponSprite;
}