using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerEBehavior : MonoBehaviour


{

    [SerializeField] Transform player;
    [SerializeField] private int numDepE;

    PlayerStats playerStats;
    EnemyStats EnemyStats;
    EnemyMovement EnemyMovement;

    public float drainRateTimer = 500f;
    public float drainRate = 10f;
    private float screenX = 21.5f;
    private float screenY = 9.71f;





    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = player.gameObject.GetComponent<PlayerStats>();
        EnemyStats = GetComponent<EnemyStats>();
        EnemyMovement = GetComponent<EnemyMovement>();

        EnemyMovement.speed = 3;
        EnemyMovement.damage = 5;
        InvokeRepeating("getAngry", 1f, 10000f);
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distance is " + distance);
        if (distance < 100)
        {
            getAngry();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is hit: " + playerStats._currPlayerHealth);
            other.gameObject.GetComponent<PlayerStats>().TakeDamagePlayer(2f);
            Destroy(gameObject);
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
  
    public void getAngry()
    {

        // Instantiate(Emblem,new Vector2(22.84f,6.92f),Quaternion.identity);
        EnemyMovement.speed += 0.0020f;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") //change "Wall" to the tag of the object you want to collide with
        {
            Vector3 oppositeDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.rotation = Quaternion.LookRotation(oppositeDirection);
        }
    }


}

