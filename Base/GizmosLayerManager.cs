using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[FilePath( "Assets/GizmosExtension/Base", FilePathAttribute.Location.ProjectFolder)]
public class GizmosLayerManager : ScriptableSingleton<GizmosLayerManager>
{
    private const int MAX_LAYERS = 31;
    public string[] layers = new string[MAX_LAYERS];
    [GizmosFlags]
    public int activatingLayers;

}
