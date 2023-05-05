using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimate : MonoBehaviour
{
    Animator animate;
    public float horizontal;
    Enemy enemy;

    [HideInInspector]
    public Vector3 movementVector; //variable for Vector3 



    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        animate = GetComponent<Animator>();
    }

    private void Start()
    {
       
    }

        private void Update()
    {
        //

        if (enemy.transform.position.x > 0) //this and the vertical mirror allow us to toggle the variables to key our last input active without spamming A/D W/S
        {
            animate.SetBool("Horizontal", true);
        }
        else {
            animate.SetBool("Horizontal", false);
        }

    }


}
