using System.Collections;
using UnityEngine;

public class BulletPower : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootInterval = 0.5f;
    [SerializeField] private float bulletSpeed = 10f;

    private bool isActive = false;

    private void Start() 
    {
        isActive = false;
    }

    public void ActivatePower()
    {
        if (!isActive)
        {
            isActive = true;
            StartCoroutine(ShootBullets());
        }
    }

    public void DeactivatePower()
    {
        if (isActive)
        {
            isActive = false;
            StopAllCoroutines();
        }
    }

    private IEnumerator ShootBullets()
    {
        while (isActive)
        {
            // Shoot bullets from the left and right of the player
            ShootBullet(Vector3.left); 
            ShootBullet(Vector3.right); 

            yield return new WaitForSeconds(shootInterval);
        }
    }

    private void ShootBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

        Destroy(bullet, 5f);
    }
}
