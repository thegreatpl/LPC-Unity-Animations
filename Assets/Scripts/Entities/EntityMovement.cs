using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{

    public EntityAnimationController Animator;

    /// <summary>
    /// The movement speed of this entity. 
    /// </summary>
    public float Speed = 2f;

    /// <summary>
    /// Direction this entity is travelling in. 
    /// </summary>
    public Direction Direction; 

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<EntityAnimationController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        switch (Direction)
        {
            case Direction.None:
                Animator.SetInteger("Direction", (int)Direction); 
                break;
            case Direction.Left:
                Animator.SetInteger("Direction", (int)Direction);
                transform.position += new Vector3(-Speed, 0, 0) * Time.deltaTime;
                break;
            case Direction.Up:
                Animator.SetInteger("Direction", (int)Direction);
                transform.position += new Vector3(0, Speed, 0) * Time.deltaTime;
                break;
            case Direction.Right:
                Animator.SetInteger("Direction", (int)Direction);
                transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime;
                break;
            case Direction.Down:
                Animator.SetInteger("Direction", (int)Direction);
                transform.position += new Vector3(0, -Speed, 0) * Time.deltaTime;
                break;
        }
    }


   
}