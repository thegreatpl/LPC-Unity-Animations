using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class AnimationCollection
{
    /// <summary>
    /// The name of this collection. 
    /// </summary>
    public string Name;

    /// <summary>
    /// What layer this animation is supposed to be on. 
    /// </summary>
    public string Layer;

    /// <summary>
    /// is suitable for males. 
    /// </summary>
    public bool Male;
    /// <summary>
    /// Is suitable for females. 
    /// </summary>
    public bool Female; 

    public AnimationClip Idle;

    public AnimationClip WalkUp;

    public AnimationClip WalkDown;

    public AnimationClip WalkLeft;

    public AnimationClip WalkRight; 
}

