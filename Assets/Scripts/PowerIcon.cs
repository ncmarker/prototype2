using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerIcon : MonoBehaviour
{
    [SerializeField] private string powerType; // "Bullet" or "Radius"

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                if (powerType == "Bullet")
                {
                    player.ActivateBulletPower();
                }
                else if (powerType == "Radius")
                {
                    player.ActivateRadiusPower();
                }
            }

            Destroy(gameObject); // Destroy the icon after the player picks it up
        }
    }
}
