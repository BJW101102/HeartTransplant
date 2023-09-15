using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anx2Behavior : MonoBehaviour


{

    [SerializeField] Transform player;
    [SerializeField] private int numDepE;
    [SerializeField] GameObject heart;
    [SerializeField] GameObject Emblem;

    PlayerStats playerStats;
    EnemyStats EnemyStats;
    EnemyMovement EnemyMovement;
    public float drainRateTimer = 500f;
    public float drainRate = 10f;



    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("DogTrainer").transform;
        playerStats = player.gameObject.GetComponent<PlayerStats>();
        EnemyStats = GetComponent<EnemyStats>();
        EnemyMovement = GetComponent<EnemyMovement>();

        EnemyMovement.damage = 5;
        float rand = Random.Range(5, 7);
        EnemyMovement.speed = rand;
        InvokeRepeating("drainSpeed", 1f, 1000f);
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < 50)
        {
            drainSpeed();
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamagePlayer(0.25f);
            playerStats.speed = playerStats.maxSpeed;
            Destroy(gameObject);
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
            Instantiate(heart, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        Debug.Log("Player is here: " + player.position);
    }
    public void drainSpeed()
    {
        if (playerStats.speed < 0)
        {
            playerStats.speed = 3;
            CancelInvoke("drainSpeed");
        }
        // Instantiate(Emblem,new Vector2(22.84f,6.92f),Quaternion.identity);
        playerStats.speed -= 0.0020f;
        Debug.Log("Speed is now:  " + playerStats.speed);

    }
}
