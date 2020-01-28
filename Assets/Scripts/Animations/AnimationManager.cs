using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    public List<AnimationCollection> AnimationCollections; 


    public AnimationCollection GetRandomElementForLayer(string layer, bool isMale)
    {
        IEnumerable<AnimationCollection> layerElements;
        if (isMale)
            layerElements= AnimationCollections.Where(x => x.Layer == layer && x.Male == true);
        else
            layerElements = AnimationCollections.Where(x => x.Layer == layer && x.Female == true);

        return layerElements.GetRandomElement(); 
    }

    public AnimationCollection GetAnimation(string name)
    {
        return AnimationCollections.FirstOrDefault(x => x.Name == name); 
    }
}
