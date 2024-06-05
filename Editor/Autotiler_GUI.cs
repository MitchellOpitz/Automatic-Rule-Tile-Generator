using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Autotiler_SO))]
public class Autotiler_GUI : Editor
{
    SerializedProperty tilemaps;
    SerializedProperty ruleTileTemplate;
    Autotiler_SO script;

    private void Awake()
    {
        tilemaps = serializedObject.FindProperty("tilemaps");
        ruleTileTemplate = serializedObject.FindProperty("ruleTileTemplate");
        script = (Autotiler_SO)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Header
        EditorGUILayout.LabelField("BF Tools - Automatic Rule Tile Generator", EditorStyles.boldLabel);
        GUI_HorizontalLine();

        // Tilemap
        EditorGUILayout.LabelField("Provide a tilemap file that follows the image.png template layout.");
        EditorGUILayout.LabelField("If more than one file is provided, tilemaps will be assigned randomly.");
        EditorGUILayout.LabelField("Useful for quickly creating visually different tilemaps.");
        EditorGUILayout.PropertyField(tilemaps);
        GUI_HorizontalLine();

        // Rule Tile Template
        EditorGUILayout.LabelField("If you have created a custom rule tile template, you can provide it here.");
        EditorGUILayout.LabelField("Doing so will allow you to use your own tile layouts rather than the one provided.");
        EditorGUILayout.LabelField("Warning: this is for more advanced users only.");
        EditorGUILayout.PropertyField(ruleTileTemplate);
        GUI_HorizontalLine();

        //Button
        if (GUILayout.Button("Generate Rule Tile"))
        {
            script.CreateRuleTiles();
        }

        serializedObject.ApplyModifiedProperties();
    }

    private static void GUI_HorizontalLine()
    {
        Rect rect = GUILayoutUtility.GetRect(10, 1, GUILayout.ExpandWidth(true));
        Color lineColor = new Color(0.10196f, 0.10196f, 0.10196f, 1);
        EditorGUI.DrawRect(rect, lineColor);
    }
}
