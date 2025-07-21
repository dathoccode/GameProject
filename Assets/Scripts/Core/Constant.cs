using UnityEngine;

public class Constant : MonoBehaviour
{
    //Player Status
    public const int PLAYER_STATUS_IDLE = 0;
    public const int PLAYER_STATUS_RUNNING = 1;
    public const int PLAYER_STATUS_ATTACKING = 2;
    public const int PLAYER_STATUS_DEAD = 3;

    //Enemy Status
    public const int ENEMY_STATUS_IDLE = 0;
    public const int ENEMY_STATUS_PATROLLING = 1;
    public const int ENEMY_STATUS_CHASING = 2;
    public const int ENEMY_STATUS_ATTACKING = 3;

    //CONSTANT VALUES
    public const float PUSH_BACK_FORCE = 4f;
    public const float PUSH_BACK_TIME = 0.3f; // Duration of knockback effect
    public const float COLLIDER_DAMAGE = 10f; // Damage dealt on collision with player

}