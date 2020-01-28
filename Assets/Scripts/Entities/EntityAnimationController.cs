using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationController : MonoBehaviour
{

    public GameObject AnimationLayerPrefab;

    Dictionary<string, EntityAnimationLayer> AnimationLayers;

    // Start is called before the first frame update
    void Start()
    {
        AnimationLayers = new Dictionary<string, EntityAnimationLayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInteger(string name, int value)
    {
        foreach (var layer in AnimationLayers)
            layer.Value.SetInteger(name, value);
    }

    public void SetAnimation(AnimationCollection animationCollection, Color? color = null)
    {
        if (AnimationLayers.ContainsKey(animationCollection.Layer))
        {
            AnimationLayers[animationCollection.Layer].SetAnimation(animationCollection);
            return; 
        }
        var newObj = Instantiate(AnimationLayerPrefab, transform);
        var layer = newObj.GetComponent<EntityAnimationLayer>();
        layer.Layer = animationCollection.Layer;
        layer.name = animationCollection.Layer;
        AnimationLayers.Add(animationCollection.Layer, layer); 
        layer.SetAnimation(animationCollection);

        if (color.HasValue)
            layer.SetColor(color.Value); 

    }
}
