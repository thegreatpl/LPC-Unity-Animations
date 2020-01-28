using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationLayer : MonoBehaviour
{
    string _layer; 
    public string Layer
    {
        get
        {
            return _layer; 
        }
        set
        {
            _layer = value;
            switch(value)
            {
                case "body":
                    SpriteRenderer.sortingOrder = 2;
                    return;
                case "hair":
                    SpriteRenderer.sortingOrder = 8;
                    return;
                case "chest":
                    SpriteRenderer.sortingOrder = 19;
                    return;
                case "legs":
                    SpriteRenderer.sortingOrder = 16;
                    return; 
            }
        }
    }


    Animator Animator;

    AnimatorOverrideController AnimatorOverrideController;
    AnimationClipOverrides animationClipOverides;

    public SpriteRenderer SpriteRenderer; 

    /// <summary>
    /// The current animation collection of this entity.
    /// </summary>
    AnimationCollection AnimationCollection;

    bool delayed = false; 

    // Start is called before the first frame update
    void Start()
    {
        if (Animator == null)
            Animator = GetComponent<Animator>();
        AnimatorOverrideController = new AnimatorOverrideController(Animator.runtimeAnimatorController);
        Animator.runtimeAnimatorController = AnimatorOverrideController;
        animationClipOverides = new AnimationClipOverrides(AnimatorOverrideController.overridesCount);
        AnimatorOverrideController.GetOverrides(animationClipOverides);

        SpriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void Update()
    {
        if (delayed)
            SetAnimation(AnimationCollection); 
    }


    public void SetInteger(string name, int value)
    {
        Animator?.SetInteger(name, value); 
    }

    public void SetAnimation(AnimationCollection animationCollection)
    {
        AnimationCollection = animationCollection;
        if (Animator == null)
        {
            delayed = true;
            return; 
        }

        animationClipOverides["idle"] = animationCollection.Idle;

        animationClipOverides["walkup"] = animationCollection.WalkUp;
        animationClipOverides["walkdown"] = animationCollection.WalkDown;
        animationClipOverides["walkleft"] = animationCollection.WalkLeft;
        animationClipOverides["walkright"] = animationCollection.WalkRight;
        AnimatorOverrideController.ApplyOverrides(animationClipOverides);
        delayed = false; 
    }

    public void SetColor(Color color)
    {
        SpriteRenderer.color = color; 
            
    }
}

