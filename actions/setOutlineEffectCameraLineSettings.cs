﻿// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using cakeslice;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Outline Effect")]
    [Tooltip("Set outline effect camera line effects.")]

    public class setOutlineEffectCameraLineSettings : FsmStateAction

    {
        [RequiredField]
        [CheckForComponent(typeof(OutlineEffect))]
        public FsmOwnerDefault gameObject;

        public FsmFloat lineThickness;
        public FsmFloat lineIntensity;
        public FsmFloat fillAmount;
        public FsmBool everyFrame;

        OutlineEffect theScript;

        public override void Reset()
        {

            lineThickness = null;
            lineIntensity = null;
            fillAmount = null;
            gameObject = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);

            theScript = go.GetComponent<OutlineEffect>();

            if (!everyFrame.Value)
            {
                MakeItSo();
                Finish();
            }

        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                MakeItSo();
            }
        }


        void MakeItSo()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            theScript.lineIntensity = lineIntensity.Value;
            theScript.lineThickness = lineThickness.Value;
            theScript.fillAmount = fillAmount.Value;            
        }

    }
}
