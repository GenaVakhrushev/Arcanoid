#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BonusBrick)), CanEditMultipleObjects]
public class BonusRatioTexts : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        float sum = 0;

        BonusRatio[] bonusRatios = ((BonusBrick)target).BonusRatios;

        if (bonusRatios == null)
        {
            return;
        }

        for (int i = 0; i < bonusRatios.Length; i++)
        {
            sum += bonusRatios[i].RatioPart;
        }

        for (int i = 0; i < bonusRatios.Length; i++)
        {
            bonusRatios[i].ChancePercent = bonusRatios[i].RatioPart / sum * 100;
        }

        GUILayout.Label("Sum of ratios = " + sum.ToString());
    }
}
#endif