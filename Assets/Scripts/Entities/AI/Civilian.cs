using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : EntityAI
{

    EntityMovement EntityMovement;


    // Start is called before the first frame update
    void Start()
    {
        EntityMovement = GetComponent<EntityMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Wander(); 
    }

    int cooldown = 0; 

    void Wander()
    {
        if (cooldown < 0)
        {
            var percent = Random.Range(0, 1.0f);

            if (percent < 0.050f)
                EntityMovement.Direction = Direction.None;
            else if (percent < 0.10f)
                EntityMovement.Direction = Helper.RandomDirection();

            cooldown = 20; 
        }
        else
            cooldown--; 

    }

    public override void Attacked()
    {
    }
}
