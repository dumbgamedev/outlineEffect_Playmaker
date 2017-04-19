// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using cakeslice;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Outline Effect")]
    [Tooltip("Set outline effect camera color.")]

    public class setOutlineEffectCameraColor1 : FsmStateAction

    {
        [RequiredField]
        [CheckForComponent(typeof(OutlineEffect))]
        public FsmOwnerDefault gameObject;

        public FsmColor lineColor1;
        public FsmBool everyFrame;

        OutlineEffect theScript;

        public override void Reset()
        {

            lineColor1 = null;
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

            theScript.lineColor1 = lineColor1.Value;
          
        }

    }
}
