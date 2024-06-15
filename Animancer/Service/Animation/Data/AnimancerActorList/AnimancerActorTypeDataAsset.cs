using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Game.Code.Services.Animation.Data.AnimacerActorList
{
    [CreateAssetMenu(menuName = "Gameplay/Data/Animation/AnimancerActorType Data Asset", fileName = "AnimancerActorType  Data Asset")]
    public class AnimancerActorTypeDataAsset : ScriptableObject
    {
        [InlineProperty]
        public List<AnimancerActorType> Types = new List<AnimancerActorType>();
       
#if UNITY_EDITOR
        [Button("Generate Static Properties")]
        public void GenerateProperties()
        {
            GenerateStaticProperties(this);
        }

        public static void GenerateStaticProperties(AnimancerActorTypeDataAsset dataAsset)
    {
        var idType = typeof(AnimancerActorTypeId);
        //Get script for AnimancerActorTypeId path
        var scriptPath = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(dataAsset));
        var directoryPath = Path.GetDirectoryName(scriptPath);
        var outputPath = Path.Combine(directoryPath, "Generated");
        var outputFileName = "AnimancerActorTypeId.Generated.cs";

        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }
        
        var namespaceName = idType.Namespace;

        var filePath = Path.Combine(outputPath, outputFileName);
        using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            writer.WriteLine($"namespace {namespaceName}");
            writer.WriteLine("{");
            writer.WriteLine("    public partial struct AnimancerActorTypeId");
            writer.WriteLine("    {");

            var typesField = typeof(AnimancerActorTypeDataAsset).GetField("Types", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (typesField != null)
            {
                var types = (List<AnimancerActorType>)typesField.GetValue(dataAsset);
                foreach (var type in types)
                {
                    var propertyName = type.Name.Replace(" ", "");
                    writer.WriteLine($"        public static AnimancerActorTypeId {propertyName} => new AnimancerActorTypeId {{ value = {type.Id} }};");
                }
            }

            writer.WriteLine("    }");
            writer.WriteLine("}");
        }

        AssetDatabase.Refresh();
        Debug.Log("Partial class with static properties generated successfully.");
    }
#endif
    }
}