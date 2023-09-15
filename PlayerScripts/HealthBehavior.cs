using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour

{
    public Transform player;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("DogTrainer"))
        {
            other.gameObject.GetComponent<PlayerStats>().Heal();
            Destroy(gameObject);
        }
    }
}
