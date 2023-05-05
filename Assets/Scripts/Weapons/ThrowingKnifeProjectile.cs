using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeProjectile : MonoBehaviour
{

    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 5;

    float ttl = 6f; //variable to destroy knives after 6 seconds

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if(dir_x < 0) //transforms the knife to "go" in the direction of travel
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1; 
            transform.localScale = scale;   
        }
    }

    bool hitDetected = false; //bool to check if enemy is hit

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Time.frameCount % 2 == 0) //makes knife skip doing checks every frame to free up processing, in this case every 2 frames
        {

            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f); //creates a cirlce collider on the knife to connect with other colliders

            foreach (Collider2D c in hit) //checks if enemy has the "enemy" script and deals damage if it does
            {
                IDamagable enemy = c.GetComponent<IDamagable>();
                if (enemy != null) //if is enemy calls the TakeDamage method to damage the enemy
                {
                    PostDamage(damage, transform.position); //post damage message when knife hits enemy
                    enemy.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if (hitDetected == true) //destroys knife if hit detected
            {
                Destroy(gameObject);
           
            }
        }

        //destroy knives after 6 seconds
        ttl -= Time.deltaTime;
        if(ttl < 0f)
        {
            Destroy(gameObject);
        }
    }

    public void PostDamage(int damage, Vector3 worldPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), worldPosition);
    }
}
