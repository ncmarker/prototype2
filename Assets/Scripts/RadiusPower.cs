using System.Collections;
using UnityEngine;

public class RadiusPower : MonoBehaviour
{
    [SerializeField] private float radius = 2f; 
    [SerializeField] private float damageInterval = 0.5f; 
    [SerializeField] private GameObject radiusPrefab;

    private bool isActive = false;
    private GameObject activeRadius;

    private void OnDrawGizmos()
    {
        // Draw the radius in the editor so we can test
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        // Keep the radius centered on the player 
        if (isActive && activeRadius != null)
        {
            activeRadius.transform.position = transform.position;
        }
    }

    public void ActivatePower()
    {
        if (!isActive)
        {
            isActive = true;
            activeRadius = Instantiate(radiusPrefab, transform.position, Quaternion.identity);
            StartCoroutine(ApplyRadiusEffect());
        }
    }

    public void DeactivatePower()
    {
        if (isActive)
        {
            isActive = false;
            StopAllCoroutines(); 

            if (activeRadius) Destroy(activeRadius);
        }
    }

    // kills enemies within the radius
    private IEnumerator ApplyRadiusEffect()
    {
        while (isActive)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Destroy(collider.gameObject); 
                }
            }

            yield return new WaitForSeconds(damageInterval); 
        }
    }
}
