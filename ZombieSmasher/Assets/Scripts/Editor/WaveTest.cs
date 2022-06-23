using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaveController))]
public class WaveTest : Editor
{
    WaveController wave;

    private void OnEnable()
    {
        wave = target as WaveController;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Spawn Wave"))
        {
            wave.OnStartWave();
        }
    }

}
