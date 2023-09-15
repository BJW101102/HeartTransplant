using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anx1Behavior : MonoBehaviour


{

    [SerializeField] Transform player;
    [SerializeField] private int numDepE;
    [SerializeField] GameObject Anx2;
    [SerializeField] GameObject heart;


    PlayerStats playerStats;
    EnemyStats EnemyStats;
    EnemyMovement EnemyMovement;

    private float damage = 5;
    private float xPosition, yPosition, distance, drainRate;


    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("DogTrainer").transform;
        playerStats = player.gameObject.GetComponent<PlayerStats>();
        EnemyStats = GetComponent<EnemyStats>();
        EnemyMovement = GetComponent<EnemyMovement>();
        EnemyMovement.speed = 3;
        EnemyMovement.damage = 5;
        drainRate = 0.10f;





    }


    void Update()
    {
        dropHealth();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamagePlayer(damage);
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
    public void dropHealth()
    {
        if (EnemyStats._currHealth <= 0)
        {
            // Instantiate(heart, transform.position, transform.rotation);
            Destroy(gameObject);
            Instantiate(Anx2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
        Debug.Log("Player is here: " + player.position);
    }

}
