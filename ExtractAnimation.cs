using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class ExtractAnimation : Editor
{
    [MenuItem("Utillity/Animation/ExtractClip")]
    private static void Extract()
    {
        var selections = Selection.objects;
        foreach (var item in selections)
        {
            var path = AssetDatabase.GetAssetPath(item);
            AnimationClip orgClip = (AnimationClip)AssetDatabase.LoadAssetAtPath(path, typeof(AnimationClip));

            //Save the clip
            AnimationClip placeClip = new AnimationClip();
            EditorUtility.CopySerialized(orgClip, placeClip);
            var parentpath = path.Substring(0, path.LastIndexOf('/'));
            AssetDatabase.CreateAsset(placeClip, parentpath + "/" + item.name + ".anim");
            AssetDatabase.Refresh();
        }
    }
}