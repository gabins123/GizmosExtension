using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

public class GizmosManagerWindowsEditor : EditorWindow
{
    private bool[] values = new bool[31];
    private FieldInfo layerField;
    private SerializedProperty activatingLayerField;
    private Object target;
    private SerializedObject objectTarget;

    private void OnEnable()
    {
        layerField = typeof(GizmosLayerManager).GetField("layers", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    }
    [MenuItem("Tool/Gizmos Layer Manager _G")]
    static void Init()
    {
        GizmosManagerWindowsEditor window = (GizmosManagerWindowsEditor)GetWindow(typeof(GizmosManagerWindowsEditor), false, "Gizmos Layer Manager");
        window.Show();
    }
    private void OnGUI()
    {
        target = AssetDatabase.LoadAllAssetsAtPath("Assets/GizmosExtension/Base/GizmosManager.asset")[0];
        objectTarget = new SerializedObject(target);
        var layerValue = layerField.GetValue(target) as string[];
        activatingLayerField = objectTarget.FindProperty("activatingLayers");
        int value = 0;
        for (int i = 0; i < layerValue.Length; i++)
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Layer " + i);
                layerValue[i] = EditorGUILayout.TextField(layerValue[i]);
            }
            EditorGUILayout.EndHorizontal();
        }
        Undo.RecordObject(target, "Change gizmos layer manager");
        EditorGUILayout.PropertyField(activatingLayerField);
        layerField.SetValue(target, layerValue);
        objectTarget.ApplyModifiedProperties();
        EditorUtility.SetDirty(target);
    }
}
[CustomEditor(typeof(GizmosLayerManager))]
public class GizmosLayerManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
    }
}