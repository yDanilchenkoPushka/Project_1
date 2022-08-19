using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace DefaultNamespace
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private float _animationTime;

        [SerializeField] 
        private float _closingTime;

        [SerializeField]
        private Outline _outline;

        [SerializeField]
        private InteractiveTrigger _interactiveTrigger;

        private Tween _animation;

        public void Awake()
        {
            _animation = transform
                .DOMoveY(-5f, _animationTime)
                .SetAutoKill(false)
                .Pause();
            
            SetOutline(false);

            _interactiveTrigger.OnEntered += EnterInteractive;
            _interactiveTrigger.OnExited += ExitInteractive;
        }

        public void Interact()
        {
            _interactiveTrigger.enabled = false;
            
            Open();
        }

        private void EnterInteractive(IInteractiveHandler interactiveHandler)
        {
            interactiveHandler.EnterInteractive(this);
            
            SetOutline(true);
        }

        private void ExitInteractive(IInteractiveHandler interactiveHandler)
        {
            interactiveHandler.ExitInteractive();
            
            SetOutline(false);
        }
        
        private void SetOutline(bool isOutline) => 
            _outline.enabled = isOutline;

        [ContextMenu("Open")]
        private void Open()
        {
            _animation.PlayForward();

            StartCoroutine(Close());
        }

        private IEnumerator Close()
        {
            yield return new WaitForSeconds(_closingTime);
            
            _animation.PlayBackwards();
        }
    }
}