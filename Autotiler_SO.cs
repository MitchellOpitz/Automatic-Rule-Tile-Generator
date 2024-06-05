using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
using UnityEngine.Tilemaps;
using System.Text.RegularExpressions;

#if UNITY_EDITOR

[ExecuteInEditMode]
[CreateAssetMenu(menuName = "BF Tools - Auto Rule Tile", fileName = "BF Tools - Auto Rule Tile")]
public class Autotiler_SO : ScriptableObject
{
    [SerializeField]
    List<Texture2D> tilemaps;

    [SerializeField]
    RuleTile ruleTileTemplate;

    private RuleTile newRuleTile;
    private int numberOfRules;

    public void CreateRuleTiles()
    {
        if (CheckRuleTemplate() && CompareTilemapsToRuleTile())
        {
            CopyRuleTile();
            if (tilemaps.Count == 1)
            {
                SingleTilemap();
            }
            else
            {
                RandomTilemaps();
            }
            CreateAsset();
        }
    }

    private bool CheckRuleTemplate()
    {
        if (ruleTileTemplate == null)
        {
            Debug.LogError("Rule tile not assigned.");
            return false;
        }
        return true;
    }

    private bool CompareTilemapsToRuleTile()
    {
        numberOfRules = ruleTileTemplate.m_TilingRules.Count;

        foreach (Texture2D tilemap in tilemaps)
        {
            string spriteSheetName = AssetDatabase.GetAssetPath(tilemap);
            Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheetName).OfType<Sprite>().ToArray();

            if (sprites.Length != numberOfRules)
            {
                Debug.LogError("Tilemap does not contain the number of sprites needed by Rule Tile template.");
                Debug.LogError($"Sprite sheet: {tilemap.name} | Sprites contained: {sprites.Length}");
                Debug.LogError($"Rule Tile template: {ruleTileTemplate} | Rules contained: {numberOfRules}");
                return false;
            }
        }
        return true;
    }

    private void CopyRuleTile()
    {
        newRuleTile = CreateInstance<RuleTile>();
        EditorUtility.CopySerialized(ruleTileTemplate, newRuleTile);
    }

    private void SingleTilemap()
    {
        foreach (RuleTile.TilingRule rule in newRuleTile.m_TilingRules)
        {
            rule.m_Output = RuleTile.TilingRule.OutputSprite.Single;
            rule.m_Sprites = new Sprite[] { rule.m_Sprites[0] };
        }

        string spriteSheetName = AssetDatabase.GetAssetPath(tilemaps[0]);
        Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheetName).OfType<Sprite>().OrderByNatural(s => s.name).ToArray();

        for (int i = 0; i < numberOfRules; i++)
        {
            newRuleTile.m_TilingRules[i].m_Sprites[0] = sprites[i];
        }
    }

    private void RandomTilemaps()
    {
        foreach (RuleTile.TilingRule rule in newRuleTile.m_TilingRules)
        {
            rule.m_Output = RuleTile.TilingRule.OutputSprite.Random;
            rule.m_Sprites = new Sprite[tilemaps.Count];
        }

        for (int i = 0; i < tilemaps.Count; i++)
        {
            Texture2D tilemap = tilemaps[i];
            string spriteSheetName = AssetDatabase.GetAssetPath(tilemap);
            Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheetName).OfType<Sprite>().OrderByNatural(s => s.name).ToArray();
            for (int j = 0; j < numberOfRules; j++)
            {
                newRuleTile.m_TilingRules[j].m_Sprites[i] = sprites[j];
            }
        }
    }

    private void CreateAsset()
    {
        string currentPath = AssetDatabase.GetAssetPath(this);
        string directory = System.IO.Path.GetDirectoryName(currentPath);
        string newFileName = "New Rule Tile.asset";
        string newPath = System.IO.Path.Combine(directory, newFileName);
        AssetDatabase.CreateAsset(newRuleTile, newPath);
        AssetDatabase.SaveAssets();
    }

}

#endif

public static class NaturalSortingExtension
{
    public static IOrderedEnumerable<T> OrderByNatural<T>(this IEnumerable<T> source, Func<T, string> selector)
    {
        int maxLen = source.Select(selector).Select(s => s.Length).Max();
        return source.OrderBy(s => NaturalSortingExtension.NaturalString(selector(s), maxLen));
    }

    private static string NaturalString(string str, int maxLen)
    {
        return string.Join("\0", Regex.Split(str, "([0-9]+)").Select(s => s.PadLeft(maxLen, '0')));
    }
}
