using TettekeKobo.StateMachine;
using UnityEngine;

namespace TettekeKobo.StatePatternTest
{
    /// <summary>
    /// 赤い画像を表示しているときのState
    /// </summary>
    public class OpenRedImageState : IState
    {
        private readonly ITransitionState<UIStateType> transitionState;
        private UIChangeController uiChangeController;
        
        public OpenRedImageState(ITransitionState<UIStateType> transitionState,UIChangeController uiChangeController)
        {
            this.transitionState = transitionState;
            this.uiChangeController = uiChangeController;
        }
        
        public void Enter()
        {
            Debug.Log("赤色の画像を表示します");
            uiChangeController.ChangeRedImage(true);
        }

        public void MyUpdate()
        {
            if(Input.GetKeyDown(KeyCode.X)) transitionState.TransitionState(UIStateType.OpeningNone);
            else if(Input.GetKeyDown(KeyCode.C)) transitionState.TransitionState(UIStateType.OpeningBlueImage);
        }

        public void MyFixedUpdate()
        {
            
        }

        public void Exit()
        {
            uiChangeController.ChangeRedImage(false);
        }
    }
}
