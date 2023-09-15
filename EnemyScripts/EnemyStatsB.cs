using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsB : MonoBehaviour
{
    public float _maxHealth;
    public float _currHealth;
    public float speed;
    public float damage;

    [SerializeField] GameObject heart;

    public Transform player;
    private PlayerStats playerStats;
    private int eCount;
    public Vector2 distance;

    // Start is called before the first frame update
    void Start()
    { distance = transform.position;
        _maxHealth = 10f;
        _currHealth = _maxHealth;
        speed = 2f;
        damage = 1f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = player.gameObject.GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
    }

    public void TakeDamageEnemy(float damage)
    {
        _currHealth -= damage;
        Debug.Log("Enemy Health is: " + _currHealth);
    }

}
