using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

#if UNITY_EDITOR
public class GizmosFlagsAttribute : PropertyAttribute
{
    public GizmosFlagsAttribute() { }
}
[CustomPropertyDrawer(typeof(GizmosFlagsAttribute))]
public class GizmosFlagsAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        SerializedObject layers = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("Assets/GizmosExtension/Base/GizmosManager.asset")[0]);
        SerializedProperty layersArray = layers.FindProperty("layers");
        string[] layerString =new string[layersArray.arraySize];
        for (int i = 0; i < layerString.Length; i++)
        {
            layerString[i] = layersArray.GetArrayElementAtIndex(i).stringValue;
        }
        _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, layerString);
    }
}
public class GizmosEnumAttribute : PropertyAttribute
{
    public GizmosEnumAttribute() { }
}
[CustomPropertyDrawer(typeof(GizmosEnumAttribute))]
public class GizmosEnumAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        SerializedObject layers = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("Assets/GizmosExtension/Base/GizmosManager.asset")[0]);
        SerializedProperty layersArray = layers.FindProperty("layers");
        string[] layerString = new string[layersArray.arraySize];
        for (int i = 0; i < layerString.Length; i++)
        {
            layerString[i] = layersArray.GetArrayElementAtIndex(i).stringValue;
        }
        EditorGUI.LabelField(new Rect(_position.position.x, _position.position.y, _position.width/2-5, _position.height),_property.displayName);
        _property.intValue = 1 << EditorGUI.Popup(new Rect(_position.position.x + _position.width/2, _position.position.y, _position.width / 2 + 5, _position.height), GizmosExtension.ReverseBitShift(_property.intValue), layerString);
    }
    
}
#endif