using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public int Faction; 

    public int MaxHealth; 

    public int Health; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Attack(int damage, bool infectious)
    {
        Health -= damage; 


        if (Health < 0)
        {
            //death code here. 
            if (!infectious)
            {
                //if not infectious attack, destroy this game object. 
                Destroy(gameObject);
                return; 
            }


        }
    }
}
