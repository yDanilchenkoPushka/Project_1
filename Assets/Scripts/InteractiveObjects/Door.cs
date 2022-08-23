using System;
using System.Collections;
using DG.Tweening;
using Interactive;
using UnityEngine;

namespace InteractiveObjects
{
    public class Door : MonoBehaviour, IInteractable
    {
        public event Action<bool> OnStateChanged;
        
        public Vector3 Position => transform.position;
        
        [SerializeField]
        private float _animationTime;

        [SerializeField] 
        private float _closingTime;

        [SerializeField]
        private Outline _outline;

        private Tween _animation;

        public void Awake()
        {
            _animation = transform
                .DOMoveY(-5f, _animationTime)
                .SetAutoKill(false)
                .Pause();
            
            SetOutline(false);
        }

        public void Interact(object sender)
        {
            Debug.Log("Interact with door");
            
            Open();
        }
        
        // private void EnterInteractive(IInteractiveHandler interactiveHandler)
        // {
        //     interactiveHandler.EnterInteractive(this);
        //     
        //     SetOutline(true);
        // }
        //
        // private void ExitInteractive(IInteractiveHandler interactiveHandler)
        // {
        //     interactiveHandler.ExitInteractive(this);
        //     
        //     SetOutline(false);
        // }
        
        private void SetOutline(bool isOutline) => 
            _outline.enabled = isOutline;

        [ContextMenu("Open")]
        private void Open()
        {
            OnStateChanged?.Invoke(true);
            
            _animation.PlayForward();

            StartCoroutine(Close());
        }

        private IEnumerator Close()
        {
            yield return new WaitForSeconds(_closingTime);
            
            OnStateChanged?.Invoke(false);
            
            _animation.PlayBackwards();
        }
    }
}