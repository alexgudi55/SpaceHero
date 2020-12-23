using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    [SerializeField] RectTransform bar;
    float maxWidth;

    void Awake()
    {
        maxWidth = bar.rect.width;
    }

    public void UpdateShieldDisplay(float percentage)
    {
        bar.sizeDelta.Set(maxWidth * percentage, 10f);
    }
}
