using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Autotiler_SO))]
public class AutotilerGUI : Editor
{
    private SerializedProperty tilemaps;
    private SerializedProperty ruleTileTemplate;
    private Autotiler_SO autotilerScript;

    private void OnEnable()
    {
        tilemaps = serializedObject.FindProperty("tilemaps");
        ruleTileTemplate = serializedObject.FindProperty("ruleTileTemplate");
        autotilerScript = (Autotiler_SO)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawHeader();
        DrawTilemapSection();
        DrawRuleTileTemplateSection();
        DrawGenerateButton();

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawHeader()
    {
        EditorGUILayout.LabelField("BF Tools - Rule Tile Generator", EditorStyles.boldLabel);
        DrawHorizontalLine();
    }

    private void DrawTilemapSection()
    {
        EditorGUILayout.LabelField("Provide a tilemap file that follows the image.png template layout.");
        EditorGUILayout.LabelField("If more than one file is provided, tilemaps will be assigned randomly.");
        EditorGUILayout.LabelField("Useful for quickly creating visually different tilemaps.");
        EditorGUILayout.PropertyField(tilemaps);
        DrawHorizontalLine();
    }

    private void DrawRuleTileTemplateSection()
    {
        EditorGUILayout.LabelField("If you have created a custom rule tile template, you can provide it here.");
        EditorGUILayout.LabelField("Doing so will allow you to use your own tile layouts rather than the one provided.");
        EditorGUILayout.LabelField("Warning: this is for more advanced users only.");
        EditorGUILayout.PropertyField(ruleTileTemplate);
        DrawHorizontalLine();
    }

    private void DrawGenerateButton()
    {
        if (GUILayout.Button("Generate Rule Tile"))
        {
            autotilerScript.CreateRuleTiles();
        }
    }

    private static void DrawHorizontalLine()
    {
        Rect rect = GUILayoutUtility.GetRect(10, 1, GUILayout.ExpandWidth(true));
        Color lineColor = new Color(0.10196f, 0.10196f, 0.10196f, 1);
        EditorGUI.DrawRect(rect, lineColor);
    }
}