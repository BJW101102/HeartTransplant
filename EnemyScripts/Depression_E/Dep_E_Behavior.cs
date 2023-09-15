using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dep_E_Behavior : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private int numDepE;
    PlayerStats playerStats;
    void Start()

    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = player.gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distance is: " + distance);
        if (distance <= 3)
        {
            DrainHealth(player);
        }
    }

    public void DrainHealth(Transform player)
    {
        playerStats._currPlayerHealth--;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamagePlayer(3);
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }

}
