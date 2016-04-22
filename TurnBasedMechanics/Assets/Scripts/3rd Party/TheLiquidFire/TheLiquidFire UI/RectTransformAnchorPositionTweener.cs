// TheLiquidFire.wordpress.com

using UnityEngine;
using System.Collections;

public class RectTransformAnchorPositionTweener : Vector3Tweener
{
    RectTransform rt;

    new void Awake()
    {
        base.Awake();
        rt = transform as RectTransform;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        rt.anchoredPosition = currentTweenValue;
    }
}