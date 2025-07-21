using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KnockBackHandler : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isBeingKnockedBack = false;
    public void ApplyKnockBack(Vector2 sourcePosition)
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (transform.position - (Vector3)sourcePosition).normalized;
            rb.AddForce(direction * Constant.PUSH_BACK_FORCE, ForceMode2D.Impulse);
            StartCoroutine(KnockBackCoroutine(sourcePosition));
        }
    }

    private IEnumerator KnockBackCoroutine(Vector2 attackerPosition)
    {
        Vector2 knockbackDirection = (rb.position - attackerPosition).normalized;
        isBeingKnockedBack = true;
        rb.AddForce(knockbackDirection * Constant.PUSH_BACK_FORCE, ForceMode2D.Impulse);

        yield return new WaitForSeconds(Constant.PUSH_BACK_TIME);
        rb.linearVelocity = Vector2.zero; 
        isBeingKnockedBack = false; 
    }

}