using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO; 

public class CreateAnimations : MonoBehaviour
{
    const string AnimationSavePath = "Assets/Animations"; 

    [MenuItem("thegreatpl/CreateAnimations")]
    static void CreateAnimationFunction()
    {
        var animationManager = SceneAsset.FindObjectOfType<AnimationManager>(); 
        if (animationManager == null)
        {
            Debug.LogError("Unable to find Animation Manager");
            return; 
        }
        animationManager.AnimationCollections = new List<AnimationCollection>();


        var layers = Directory.GetDirectories("Assets/Sprites/Standard/Character");
        foreach (var layer in layers)
        {
            var layername = Path.GetFileName(layer);

            if (!Directory.Exists($"{AnimationSavePath}/{layername}"))
                Directory.CreateDirectory($"{AnimationSavePath}/{layername}"); 

            animationManager.AnimationCollections.AddRange(CreateForLayer(layername, "Assets/Sprites/Standard/Character"));
        }
        var layers2 = Directory.GetDirectories("Assets/Sprites/Standard/Equipment");
        foreach (var layer in layers2)
        {
            var layername = Path.GetFileName(layer);

            if (!Directory.Exists($"{AnimationSavePath}/{layername}"))
                Directory.CreateDirectory($"{AnimationSavePath}/{layername}");

            animationManager.AnimationCollections.AddRange(CreateForLayer(layername, "Assets/Sprites/Standard/Equipment"));
        }

        //allAssets.Fin
        //   Sprite[] sprites = spri as Sprite[];
        //   CreateAnimation("all", sprites); 
    }

    static List<AnimationCollection> CreateForLayer(string layer, string directoryPath)
    {
        var genders = Directory.GetDirectories($"{directoryPath}/{layer}");
        var collection = new List<AnimationCollection>();

        foreach (var genderPath in genders)
        {

            var files = Directory.GetFiles($"{genderPath}");
            var gender = Path.GetFileName(genderPath);

            foreach (var file in files)
            {
                if (Path.GetExtension(file) != ".png")
                    continue;

                var animationCollection = CreateCollection(file, layer, $"{gender}{Path.GetFileNameWithoutExtension(file)}");
                if (gender == "male")
                {
                    animationCollection.Male = true;
                    animationCollection.Female = false; 
                }
                if (gender == "female")
                {
                    animationCollection.Male = false;
                    animationCollection.Female = true; 
                }
                else
                {
                    animationCollection.Male = true;
                    animationCollection.Female = true; 
                }



                collection.Add(animationCollection);
            }

        }
      

        return collection; 
    }


    static AnimationCollection CreateCollection(string path, string layer, string assetName)
    {
        
        var allAssets = AssetDatabase.LoadAllAssetsAtPath(path);
        var spri = allAssets.Where(x => x.GetType() == typeof(Sprite)).ToArray();
        List<Sprite> sprites = new List<Sprite>();
        foreach (var s in spri)
            sprites.Add(s as Sprite);

        var animationCollection = new AnimationCollection();
        animationCollection.Name = assetName;
        animationCollection.Layer = layer;
        //idle
        var idle = sprites.Where(x => x.name.Contains("_hu_0"));
        animationCollection.Idle = CreateAnimation($"{layer}/{assetName}idle", idle.ToArray());

        //walk up
        var walkup = sprites.Where(x => x.name.Contains("_wc_t_"));
        animationCollection.WalkUp = CreateAnimation($"{layer}/{assetName}walkup", walkup.ToArray());
        //walk left
        var walkleft = sprites.Where(x => x.name.Contains("_wc_l_"));
        animationCollection.WalkLeft = CreateAnimation($"{layer}/{assetName}walkleft", walkleft.ToArray());
        //walk right
        var walkright = sprites.Where(x => x.name.Contains("_wc_r_"));
        animationCollection.WalkRight = CreateAnimation($"{layer}/{assetName}walkright", walkright.ToArray());
        //walk down
        var walkdown = sprites.Where(x => x.name.Contains("_wc_d_"));
        animationCollection.WalkDown = CreateAnimation($"{layer}/{assetName}walkdown", walkdown.ToArray());


        return animationCollection; 
    }


    static AnimationClip CreateAnimation(string savePath, Sprite[] sprites)
    {
        AnimationClip animClip = new AnimationClip();
        AnimationClipSettings animClipSett = new AnimationClipSettings();
        animClipSett.loopTime = true;
        AnimationUtility.SetAnimationClipSettings(animClip, animClipSett);
        animClip.frameRate = 12;   // FPS

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = "";
        spriteBinding.propertyName = "m_Sprite";
        ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[sprites.Length];
        for (int i = 0; i < (sprites.Length); i++)
        {
            spriteKeyFrames[i] = new ObjectReferenceKeyframe();
            spriteKeyFrames[i].time = i;
            spriteKeyFrames[i].value = sprites[i];
        }
        AnimationUtility.SetObjectReferenceCurve(animClip, spriteBinding, spriteKeyFrames);


        AssetDatabase.CreateAsset(animClip, $"{AnimationSavePath}/{savePath}.anim");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        return animClip; 
    }
}
