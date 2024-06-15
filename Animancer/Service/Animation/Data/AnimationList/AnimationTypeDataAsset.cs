using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Game.Code.Services.Animation.Data.AnimationList
{
    [CreateAssetMenu(menuName = "Gameplay/Data/Animation/AnimationType Data Asset", fileName = "AnimationType  Data Asset")]
    public class AnimationTypeDataAsset : ScriptableObject
    {
        [InlineProperty]
        public List<AnimationType> Types = new List<AnimationType>();
        
        #if UNITY_EDITOR
        [Button("Generate Static Properties")]
        public void GenerateProperties()
        {
            GenerateStaticProperties(this);
        }

        public static void GenerateStaticProperties(AnimationTypeDataAsset dataAsset)
        {
            var idType = typeof(AnimationTypeId);
            var scriptPath = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(dataAsset));
            var directoryPath = Path.GetDirectoryName(scriptPath);
            var outputPath = Path.Combine(directoryPath, "Generated");
            var outputFileName = "AnimationTypeId.Generated.cs";

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
                writer.WriteLine("    public partial struct AnimationTypeId");
                writer.WriteLine("    {");

                var typesField = typeof(AnimationTypeDataAsset).GetField("Types",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (typesField != null)
                {
                    var types = (List<AnimationType>)typesField.GetValue(dataAsset);
                    foreach (var type in types)
                    {
                        var propertyName = type.Name.Replace(" ", "");
                        writer.WriteLine(
                            $"        public static AnimationTypeId {propertyName} => new AnimationTypeId {{ value = {type.Id} }};");
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