using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject targetGameObject;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = targetGameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (target.position - transform.position).normalized * moveSpeed;
    }
}
