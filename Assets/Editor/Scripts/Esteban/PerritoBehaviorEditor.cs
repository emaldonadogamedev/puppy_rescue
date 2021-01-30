using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PerritoBehavior))]
public class PerritoBehaviorEditor : Editor
{
    public void OnSceneGUI()
    {
        var perritoBehavior = target as PerritoBehavior;

        if (perritoBehavior == null)
            return;

        if (perritoBehavior.destinationOwner != null)
        {
            //Handles.BeginGUI();
            Handles.DrawDottedLine(perritoBehavior.transform.position, perritoBehavior.destinationOwner.transform.position, 0.5f);
            //Handles.EndGUI();
        }
    }
}

