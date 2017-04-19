// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using cakeslice;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Outline Effect")]
    [Tooltip("Set outline effect color int on object.")]

    public class setOutlineEffectColorInt : FsmStateAction

    {
        [RequiredField]
        [CheckForComponent(typeof(Outline))]
        public FsmOwnerDefault gameObject;

        [Title("Color Int")]
        public FsmInt colorInt;
        public FsmBool everyFrame;

        Outline theScript;

        public override void Reset()
        {

            colorInt = null;
            gameObject = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);

            theScript = go.GetComponent<Outline>();

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

            theScript.color = colorInt.Value;

        }

    }
}
