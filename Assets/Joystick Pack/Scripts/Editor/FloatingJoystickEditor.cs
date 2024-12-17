using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FloatingJoystick))]
public class FloatingJoystickEditor : JoystickEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (background == null) return;
        var backgroundRect = (RectTransform)background.objectReferenceValue;
        // backgroundRect.anchorMax = Vector2.zero;
        // backgroundRect.anchorMin = Vector2.zero;
        // backgroundRect.pivot = center;
            
        backgroundRect.pivot = new Vector2(0.5f, 0.5f);
        backgroundRect.anchorMin = new Vector2(0.5f, 0.5f);
        backgroundRect.anchorMax = new Vector2(0.5f, 0.5f);
    }
}