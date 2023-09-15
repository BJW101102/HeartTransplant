using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float bulletHealth;
    private Transform player;
    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (bulletHealth == 0)
        {
            Destroy(gameObject);
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("E"))
        {
            Debug.Log("Hit an enemy");
            other.gameObject.GetComponent<EnemyStatsB>().TakeDamageEnemy(damage);
            bulletHealth = 0;
            Destroy(gameObject);
        }

    }
}
