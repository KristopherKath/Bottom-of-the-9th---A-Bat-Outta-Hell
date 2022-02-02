using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHealth;
    int health;
    public float bulletCooldown;
    float bulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && bulletTimer <=0)
        {
            health -= 1;
            print(health);
            bulletTimer = bulletCooldown;
        }
    }
}
