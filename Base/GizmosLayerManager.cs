using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "GizmosLayer", menuName = "GizmosLayer", order = 1)]
public class GizmosLayerManager : ScriptableObject
{
    private const int MAX_LAYERS = 31;
    public string[] layers = new string[MAX_LAYERS];
    [GizmosFlags]
    //[SerializeField]
    public int activatingLayers;

}
