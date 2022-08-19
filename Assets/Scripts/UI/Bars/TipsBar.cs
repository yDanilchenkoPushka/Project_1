using System.Collections.Generic;
using Services.Input;
using TMPro;
using UnityEngine;
using DeviceType = Data.DeviceType;

namespace UI.Bars
{
    [RequireComponent(typeof(Canvas))]
    public class TipsBar : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _label;
        
        private Dictionary<DeviceType, string> _message = new Dictionary<DeviceType, string>
        {
            [DeviceType.UnknownDevice] = "Unsupported device",
            [DeviceType.Keyboard] = "Press Space",
            [DeviceType.Gamepad] = "Press O",
        };

        [SerializeField, HideInInspector]
        private Canvas _canvas;

        private ISimpleInput _simpleInput;
        private IInteractiveHandler _interactiveHandler;

        private void OnValidate() => 
            _canvas = GetComponent<Canvas>();

        public void Construct(ISimpleInput simpleInput)
        {
            _simpleInput = simpleInput;
            
            Hide();
        }

        public void Initialize(IInteractiveHandler interactiveHandler)
        {
            _interactiveHandler = interactiveHandler;
            
            _interactiveHandler.OnInteractiveEntered += OnInteractiveEntered;
            _interactiveHandler.OnInteractiveExited += OnInteractiveExited;
        }

        public void DeInitialize()
        {
            if (_interactiveHandler == null)
                return;
            
            _simpleInput.OnDeviceUpdated -= UpdateMessage;
            
            _interactiveHandler.OnInteractiveEntered -= OnInteractiveEntered;
            _interactiveHandler.OnInteractiveExited -= OnInteractiveExited;
        }
        
        private void OnInteractiveEntered()
        {
            _simpleInput.OnDeviceUpdated += UpdateMessage;
            
            UpdateMessage(_simpleInput.LastDevice);
            
            Show();
        }
        
        private void OnInteractiveExited()
        {
            _simpleInput.OnDeviceUpdated -= UpdateMessage;
            
            Hide();
        }

        private void Show() => 
            _canvas.enabled = true;

        private void Hide() => 
            _canvas.enabled = false;

        private void UpdateMessage(DeviceType deviceType) => 
            _label.text = GetMessage(_simpleInput.LastDevice);

        private string GetMessage(DeviceType deviceType)
        {
            if (_message.TryGetValue(deviceType, out string foundMessage))
                return foundMessage;

            return _message[DeviceType.UnknownDevice];
        }
    }
}