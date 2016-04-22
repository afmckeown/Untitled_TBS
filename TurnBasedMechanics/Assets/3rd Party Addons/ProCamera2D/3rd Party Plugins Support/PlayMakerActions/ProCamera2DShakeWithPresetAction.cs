﻿#if PC2D_PLAYMAKER_SUPPORT

using Com.LuisPedroFonseca.ProCamera2D;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using UnityEngine;

[ActionCategory(ActionCategory.Camera)]
[Tooltip("Shakes the camera position along its horizontal and vertical axes using a preset configured in the editor")]
public class ProCamera2DShakeWithPresetAction : FsmStateAction 
{
    [RequiredField]
    [Tooltip("The camera with the ProCamera2D component, most probably the MainCamera")]
    public FsmGameObject MainCamera;

    [Tooltip("The name of the shake preset configured in the editor")]
    public FsmString PresetName;

    public override void Enter() 
    {
        var shake = MainCamera.Value.GetComponent<ProCamera2DShake>();

        if (shake == null)
            Debug.LogError("The ProCamera2D component needs to have the Shake plugin enabled.");

        if (ProCamera2D.Instance != null && shake != null)
            shake.ShakeUsingPreset(PresetName.Value);

        Finish();
    }
}

#endif