using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] float cruiseSpeed = 1f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float decceleration = 1f;
    [SerializeField] float stabilisation = 1f;
    [SerializeField] bool controled = true;
    [SerializeField] int ControlScheme = 0;
    [SerializeField] Projectile bullet;
    [SerializeField] float firerate = 1f;
    [HideInInspector] Vector2 currentTarget;
    private bool allowFire = true;


    PlayerInput input;                      //The current inputs for the player
    BoxCollider2D bodyCollider;             //The collider component
    Rigidbody2D rigidBody;					//The rigidbody component
    float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
        input.Instance.OnMovementPointSet += Input_OnMovementPointSet;
    }

    private void Input_OnMovementPointSet(object sender, PlayerInput.OnMovementPointSetEventArgs e)
    {
        currentTarget = e.movePoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (controled)
        {
            switch (ControlScheme)
            {
                case 0:
                    WASDMovement();
                    break;
                case 1:
                    FollowMovement();
                    break;
                case 2:
                    PointMovement();
                    break;
            }
        }
        StartCoroutine(Shoot());
    }
    void WASDMovement()
    {
        float rotation = input.horizontal;
        float throttle = cruiseSpeed * input.throttle;
        if (throttle > 0)
        {
            speed += acceleration * throttle;
        }else if (throttle < 0)
        {
            speed += decceleration * throttle;
        }
        else
        {
            if (speed > 0)
            {
                speed -= stabilisation;
            }else if (speed < 0)
            {
                speed += stabilisation;
            }
        }
        speed = Mathf.Clamp(speed, -cruiseSpeed/2, cruiseSpeed);
        rigidBody.angularVelocity = rotation * rotationSpeed;
        float cos = Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
        float sin = Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad);
        Vector2 velocity = new Vector2(cos, sin);
        rigidBody.velocity = velocity*speed;
    }

    IEnumerator Shoot()
    {
        if (input.fire && allowFire)
        {
            allowFire = false;
            Vector2 offset = new Vector2();
            Projectile p = Instantiate(bullet, transform.position, transform.rotation);
            float cos = Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
            float sin = Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad);
            float bulletSpeed = 1f;
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(-sin, cos) * bulletSpeed;
            yield return new WaitForSeconds(firerate);
            allowFire = true;
        }
    }

    void FollowMovement()
    {
        Vector2 target = new Vector2(input.mousePosition.x, input.mousePosition.y);
        float throttle = cruiseSpeed * input.throttle;
        float dx = target.x - transform.position.x;
        float dy = target.y - transform.position.y;
        target = new Vector2(dx, dy);
        float cos = Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
        float sin = Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad);
        Vector2 currentAngle = new Vector2(cos, sin);
        float targetAngle = Vector2.SignedAngle(currentAngle, target);
        //   print(string.Format("cAngle = {0} targetAngle = {1} dAngle = {2}", transform.eulerAngles.z, targetAngle, targetAngle - transform.eulerAngles.z));
        //if(transform.eulerAngles.z > )
        print(string.Format("tAngle = {0}", targetAngle));
        if (targetAngle < 0)
        {
            rigidBody.angularVelocity = -rotationSpeed;
        }
        else
        {
            rigidBody.angularVelocity = rotationSpeed;
        }
        if (throttle > 0)
        {
            speed += acceleration * throttle;
        }
        else if (throttle < 0)
        {
            speed += decceleration * throttle;
        }
        else
        {
            if (speed > 0)
            {
                speed -= stabilisation;
            }
            else if (speed < 0)
            {
                speed += stabilisation;
            }
        }
        speed = Mathf.Clamp(speed, -cruiseSpeed / 2, cruiseSpeed);
        Vector2 velocity = new Vector2(cos, sin);
        rigidBody.velocity = velocity * speed;
    }

    void PointMovement()
    {
        Vector2 target = currentTarget;
        float throttle = cruiseSpeed * 1;
        float dx = target.x - transform.position.x;
        float dy = target.y - transform.position.y;
        target = new Vector2(dx, dy);
        float cos = Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
        float sin = Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad);
        Vector2 currentAngle = new Vector2(cos, sin);
        float targetAngle = Vector2.SignedAngle(currentAngle, target);
        if (targetAngle < 0)
        {
            rigidBody.angularVelocity = -rotationSpeed;
        }
        else
        {
            rigidBody.angularVelocity = rotationSpeed;
        }
        if (throttle > 0)
        {
            speed += acceleration * throttle;
        }
        else if (throttle < 0)
        {
            speed += decceleration * throttle;
        }
        else
        {
            if (speed > 0)
            {
                speed -= stabilisation;
            }
            else if (speed < 0)
            {
                speed += stabilisation;
            }
        }
        speed = Mathf.Clamp(speed, -cruiseSpeed / 2, cruiseSpeed);
        Vector2 velocity = new Vector2(cos, sin);
        rigidBody.velocity = velocity * speed;
    }
}
