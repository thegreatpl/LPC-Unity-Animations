using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance; 

    public AnimationManager AnimationManager;

    public PrefabManager PrefabManager; 



    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
        AnimationManager = GetComponent<AnimationManager>();
        PrefabManager = GetComponent<PrefabManager>(); 
        StartCoroutine(StartGame()); 
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator StartGame()
    {
        yield return null;

        yield return StartCoroutine(SpawnEntity("player", new Vector3(0, 0)));
        StartCoroutine(Spawner());
    }


    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            yield return StartCoroutine(SpawnEntity("civilian", Helper.RandomVector3(new Rect(-5, -5, 10, 10))));
        }
    }

    /// <summary>
    /// Spawns in a new entity with the chosen AI. 
    /// </summary>
    /// <param name="AI"></param>
    /// <param name="location"></param>
    /// <param name="animatorLayers"></param>
    /// <returns></returns>
    IEnumerator SpawnEntity(string AI, Vector3 location, bool? ismale = null, Dictionary<string, string> animatorLayers = null )
    {
        var prefab = PrefabManager.GetPrefab("Entity"); 
        var newEnt = Instantiate(prefab, location, prefab.transform.rotation);
        yield return null;
        if (!ismale.HasValue)
            ismale = Helper.RandomBool();

        var playerAnimator = newEnt.GetComponent<EntityAnimationController>();
        if (animatorLayers == null)
        {
            playerAnimator.SetAnimation(AnimationManager.GetRandomElementForLayer("body", ismale.Value));
            playerAnimator.SetAnimation(AnimationManager.GetRandomElementForLayer("hair", ismale.Value), Helper.RandomColor());
            playerAnimator.SetAnimation(AnimationManager.GetRandomElementForLayer("chest", ismale.Value));
            playerAnimator.SetAnimation(AnimationManager.GetRandomElementForLayer("legs", ismale.Value), Helper.RandomColor());
        }
        else
        {
            if (animatorLayers.ContainsKey("body"))
                playerAnimator.SetAnimation(AnimationManager.GetAnimation(animatorLayers["body"]));
            else
                playerAnimator.SetAnimation(AnimationManager.GetRandomElementForLayer("body", ismale.Value));

            if (animatorLayers.ContainsKey("hair"))
                playerAnimator.SetAnimation(AnimationManager.GetAnimation(animatorLayers["hair"]));
            else
                playerAnimator.SetAnimation(AnimationManager.GetRandomElementForLayer("hair", ismale.Value), Helper.RandomColor());

            if (animatorLayers.ContainsKey("chest"))
                playerAnimator.SetAnimation(AnimationManager.GetAnimation(animatorLayers["chest"]));
            else
                playerAnimator.SetAnimation(AnimationManager.GetRandomElementForLayer("chest",ismale.Value));

            if (animatorLayers.ContainsKey("legs"))
                playerAnimator.SetAnimation(AnimationManager.GetAnimation(animatorLayers["legs"]));
            else
                playerAnimator.SetAnimation(AnimationManager.GetRandomElementForLayer("legs",ismale.Value));
        }

        switch(AI)
        {
            case "player":
                newEnt.AddComponent<Player>();
                break;
            case "civilian":
                newEnt.AddComponent<Civilian>();
                break; 

        }

    }
}
