using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
using UnityEngine.Tilemaps;
using BF_Tools;

#if UNITY_EDITOR

[ExecuteInEditMode]
[CreateAssetMenu(menuName = "BF Tools - Auto Rule Tile", fileName = "BF Tools - Auto Rule Tile")]
public class Autotiler_SO : ScriptableObject
{
    [SerializeField]
    private List<Texture2D> tilemaps;

    [SerializeField]
    private RuleTile ruleTileTemplate;

    private RuleTile newRuleTile;
    private int numberOfRules;

    public void CreateRuleTiles()
    {
        if (IsValidRuleTemplate() && AreTilemapsValid())
        {
            CopyRuleTileTemplate();
            if (tilemaps.Count == 1)
            {
                ApplySingleTilemap();
            }
            else
            {
                ApplyRandomTilemaps();
            }
            CreateNewRuleTileAsset();
        }
    }

    private bool IsValidRuleTemplate()
    {
        if (ruleTileTemplate == null)
        {
            Debug.LogError("Rule tile template not assigned.");
            return false;
        }
        return true;
    }

    private bool AreTilemapsValid()
    {
        numberOfRules = ruleTileTemplate.m_TilingRules.Count;

        foreach (Texture2D tilemap in tilemaps)
        {
            string spriteSheetPath = AssetDatabase.GetAssetPath(tilemap);
            Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheetPath).OfType<Sprite>().ToArray();

            if (sprites.Length != numberOfRules)
            {
                Debug.LogError($"Tilemap {tilemap.name} does not contain the required number of sprites. " +
                               $"Expected: {numberOfRules}, Found: {sprites.Length}");
                return false;
            }
        }
        return true;
    }

    private void CopyRuleTileTemplate()
    {
        newRuleTile = CreateInstance<RuleTile>();
        EditorUtility.CopySerialized(ruleTileTemplate, newRuleTile);
    }

    private void ApplySingleTilemap()
    {
        foreach (RuleTile.TilingRule rule in newRuleTile.m_TilingRules)
        {
            rule.m_Output = RuleTile.TilingRule.OutputSprite.Single;
            rule.m_Sprites = new Sprite[] { rule.m_Sprites[0] };
        }

        string spriteSheetPath = AssetDatabase.GetAssetPath(tilemaps[0]);
        Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheetPath).OfType<Sprite>().OrderByNatural(s => s.name).ToArray();

        for (int i = 0; i < numberOfRules; i++)
        {
            newRuleTile.m_TilingRules[i].m_Sprites[0] = sprites[i];
        }
    }

    private void ApplyRandomTilemaps()
    {
        foreach (RuleTile.TilingRule rule in newRuleTile.m_TilingRules)
        {
            rule.m_Output = RuleTile.TilingRule.OutputSprite.Random;
            rule.m_Sprites = new Sprite[tilemaps.Count];
        }

        for (int i = 0; i < tilemaps.Count; i++)
        {
            Texture2D tilemap = tilemaps[i];
            string spriteSheetPath = AssetDatabase.GetAssetPath(tilemap);
            Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheetPath).OfType<Sprite>().OrderByNatural(s => s.name).ToArray();

            for (int j = 0; j < numberOfRules; j++)
            {
                newRuleTile.m_TilingRules[j].m_Sprites[i] = sprites[j];
            }
        }
    }

    private void CreateNewRuleTileAsset()
    {
        string currentPath = AssetDatabase.GetAssetPath(this);
        string directory = System.IO.Path.GetDirectoryName(currentPath);
        string newPath = System.IO.Path.Combine(directory, "New Rule Tile.asset");
        AssetDatabase.CreateAsset(newRuleTile, newPath);
        AssetDatabase.SaveAssets();
    }
}

#endif