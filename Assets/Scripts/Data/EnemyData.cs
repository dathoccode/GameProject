using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Data/NewEnemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float enemyHealth;
    public float enemySpeed;
    public float enemyAttackDamage;
    public float enemyDefense;
    public Sprite enemySprite;
    public Animator enemyAnimator;
}
