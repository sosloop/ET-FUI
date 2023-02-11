using UnityEditor;
using UnityEngine;

namespace StarForce.Editor.ResourceTools
{
    public static class ResourceRuleEditorUtility
    {
        [MenuItem("Assets/刷新GF资源XML")]
        public  static void RefreshResourceCollection()
        {
            ResourceRuleEditor ruleEditor = ScriptableObject.CreateInstance<ResourceRuleEditor>();
            ruleEditor.RefreshResourceCollection();
        }
        public  static void RefreshResourceCollection(string configPath)
        {
            ResourceRuleEditor ruleEditor = ScriptableObject.CreateInstance<ResourceRuleEditor>();
            ruleEditor.RefreshResourceCollection(configPath);
        }
    }
}