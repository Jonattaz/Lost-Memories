using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Enemy
{
    // Game object que representa o tiro do Patrol
    public GameObject bulletPrefab;

    // Variável que representa a taxa de tiro do Patrol
    public float fireRate;

    // Tranform que representa onde o tiro será spawnado
    public Transform shotSpawner;

    // Variável que controla quando o Patrol irá atirar novamente
    private float nextFire;

    // Reference to waypoints
    public List<Transform> points;

    // The int value for next point index
    public int nextID = 0;

    // The value of that applies to ID for changing
    int idChangeValue = 1;

    // Speed of movement
    public float patrolSpeed = 2;


    private void Start()
    {
        attack = false;
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        Movement();

        if (targetDistance < 0)
        {
            if (!facingRight)
            {
                Flip();
            }
        }
        else
        {
            if (facingRight)
            {
                Flip();
            }
        }

    }


    // Método que controla o tiro
    public void Shooting()
    {
        GameObject tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        if (!facingRight)
        {
            tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);

        }
    }

    // Controla os comportamentos de movimentação drone
    void Movement()
    {
        if (Mathf.Abs(targetDistance) < attackDistance)
        {
            attack = true;
        }
       

        if (!attack)
        {
            // Get the next point transform
            Transform goalPoint = points[nextID];

            // Flip the enemy transform to look into the point's direction
            if (goalPoint.transform.position.x > transform.position.x)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) ;

            // Move the enemy towards the goal point
            transform.position = Vector2.MoveTowards(transform.position,
                goalPoint.position, patrolSpeed * Time.deltaTime);


            // Check the distance between enemy and goal point to trigger next point
            if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
            {
                // Check if we are at the end of the line (make change -1)
                if (nextID == points.Count - 1)
                    idChangeValue = -1;

                // Check if we are at the start of the line (make the change +1)
                if (nextID == 0)
                    idChangeValue = 1;

                //Apply the change on the nextID
                nextID += idChangeValue;


            }
        }

        if (attack)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            if (Mathf.Abs(targetDistance) < attackDistance && Time.time > nextFire)
            {
                if (attack)
                {
                    Shooting();
                    nextFire = Time.time + fireRate;
                }
            }

        }

    }

}
