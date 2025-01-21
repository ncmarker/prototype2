using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject Player1 = players[0];
        GameObject Player2 = players[1];
        
        float distancePlayer1 = Vector3.Distance(Player1.transform.position, transform.position);
        float distancePlayer2 = Vector3.Distance(Player2.transform.position, transform.position);
        //Debug.Log(distancePlayer1 + " " + distancePlayer2);
        if (distancePlayer1 <= distancePlayer2){
            target = Player1.transform;
        }
        else {
            target = Player2.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (target.position - transform.position).normalized * moveSpeed;
    }
}
