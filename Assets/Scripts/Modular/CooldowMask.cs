using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CooldownMask : MonoBehaviour
{
    public Image image;
    bool isOnCooldown { set; get; }
    private float cooldownDuration;
    private float cooldownTimer;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (isOnCooldown == true)
        {
            cooldownTimer -= Time.deltaTime;
            image.fillAmount = cooldownTimer / cooldownDuration;
            if (cooldownTimer <= 0f)
            {
                isOnCooldown = false;
            }
        }
    }

    public void TriggerCooldown(float duration)
    {
        if (isOnCooldown) return;

        isOnCooldown = true;
        cooldownDuration = duration;
        cooldownTimer = duration;
        image.fillAmount = 1f;
    }

}