using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EntityAI
{
    EntityMovement EntityMovement;

    /// <summary>
    /// Previous direction of movement
    /// </summary>
    Direction PrevDirect;

    public override void Attacked()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        EntityMovement = GetComponent<EntityMovement>();
        PrevDirect = Direction.None; 
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");


        if (moveX < 0)
        {
            PrevDirect = EntityMovement.Direction;

            EntityMovement.Direction = Direction.Left;
        }

        else if (moveX > 0)
        {
            PrevDirect = EntityMovement.Direction;

            EntityMovement.Direction = Direction.Right;
        }

        else if (moveY < 0)
        {
            PrevDirect = EntityMovement.Direction;

            EntityMovement.Direction = Direction.Down;
        }

        else if (moveY > 0)
        {
            PrevDirect = EntityMovement.Direction;
            EntityMovement.Direction = Direction.Up;
        }

        else
        {
            if (EntityMovement.Direction != Direction.None)
                PrevDirect = EntityMovement.Direction;

            EntityMovement.Direction = Direction.None;
        }
    }
}
