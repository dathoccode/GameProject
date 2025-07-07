using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        // Implement damage logic here
        Debug.Log("Enemy took " + damage + " damage.");
        // You can also add health reduction logic, animations, etc.
    }
}