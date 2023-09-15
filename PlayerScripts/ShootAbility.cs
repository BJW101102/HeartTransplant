using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour

{
    [SerializeField] Transform _pivotPoint;
    [SerializeField] Transform _firePoint;
    public float offset = 50;
    private float cooldown;
    [SerializeField] GameObject Bullet;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _pivotPoint.position;
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        _pivotPoint.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);


        if (Input.GetKeyDown(KeyCode.Q) && !(cooldown > 0))
        {
            Shoot();
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        cooldown = 0.2f;
        Instantiate(Bullet, _firePoint.position, _firePoint.rotation);
    }


    
}


