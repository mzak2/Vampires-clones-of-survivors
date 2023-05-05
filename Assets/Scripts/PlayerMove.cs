using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    public float yTop = 98;
    public float yBottom = -98;
    public float xLeft = -98;
    public float xRight = 98;

    Rigidbody2D rgdbd2d;
    [HideInInspector]
    public Vector3 movementVector; //variable for Vector3 
    [HideInInspector]
    public float lastHorizontalVector; //whip will not play unless there is continuous key press, this allows us to toggle it
    [HideInInspector]
    public float lastVerticalVector; //whip will not play unless there is continuous key press, this allows us to toggle it

   [SerializeField] public float speed = 7;

    Animate animate;

    // Start is called before the first frame update
   private void Awake()
    {
        rgdbd2d= GetComponent<Rigidbody2D>(); // get rigidbody component from game object
        movementVector = new Vector3(); //assign a vector 3 to character on start
        animate= GetComponent<Animate>();
    }

    private void Start()
    {
        lastHorizontalVector = -1f; //assigns an input to player at beginning even though the player didn't move, that way things like knives will not stay at 0,0,0
        lastVerticalVector = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal"); //allow player to move horizontally
        movementVector.y = Input.GetAxisRaw("Vertical"); //allow player to move vertically

        if (movementVector.x != 0) //this and the vertical mirror allow us to toggle the variables to key our last input active without spamming A/D W/S
        {
            lastHorizontalVector = movementVector.x;
        }

        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }

        animate.horizontal = movementVector.x; //animates the horizontal movements
        animate.vertical = movementVector.y; // animtes the vertical movements

        movementVector *= speed; // increases speed of character

        rgdbd2d.velocity = movementVector; //assign velocity to movementVector variable


        //keep player in bounds +-98, +-98, 0
        if(transform.position.y > yTop)
        {
            transform.position = new Vector3(transform.position.x, yTop, transform.position.z);
        }

        if (transform.position.y < yBottom)
        {
            transform.position = new Vector3(transform.position.x, yBottom, transform.position.z);
        }

        if (transform.position.x > xRight)
        {
            transform.position = new Vector3(xRight, transform.position.y, transform.position.z);
        }

        if (transform.position.x < xLeft)
        {
            transform.position = new Vector3(xLeft, transform.position.y, transform.position.z);
        }

    }
}
