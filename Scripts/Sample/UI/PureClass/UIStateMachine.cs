using TettekeKobo.StateMachine;
using UnityEngine;

namespace TettekeKobo.StatePatternTest
{
    /// <summary>
    /// UIのStateMachine（抽象クラスを用いたパターン）
    /// </summary>
    public class UIStateMachine : HamuStateMachineBase<UIStateType>
    {
        private readonly OpenNoneState openNoneState;
        private readonly OpenBlueImageState openBlueImageState;
        private readonly OpenRedImageState openRedImageState;

        public UIStateMachine(UIChangeController uiChangeController)
        {
            openNoneState = new OpenNoneState(this, uiChangeController);
            openBlueImageState = new OpenBlueImageState(this, uiChangeController);
            openRedImageState = new OpenRedImageState(this, uiChangeController);
        }

        public override IState ConvertToState(UIStateType stateType)
        {
            switch (stateType)
            {
                case UIStateType.OpeningNone:
                    return openNoneState;
                case UIStateType.OpeningRedImage:
                    return openRedImageState;
                case UIStateType.OpeningBlueImage:
                    return openBlueImageState;
                default:
                    Debug.LogWarning("存在しないStateが渡されました");
                    return null;
            }
        }
    }
}
