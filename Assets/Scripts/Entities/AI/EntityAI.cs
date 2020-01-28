using System;
using UnityEngine; 

public abstract class EntityAI : MonoBehaviour
{

    /// <summary>
    /// Called when this entity is attacked. 
    /// </summary>
    public abstract void Attacked(); 
}
