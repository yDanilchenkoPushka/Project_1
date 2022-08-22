using System.Collections.Generic;
using DefaultNamespace;
using Player;
using Services.Input;
using UnityEngine;
using DeviceType = Data.DeviceType;

namespace UI.Bars
{
    [RequireComponent(typeof(Canvas))]
    public class TipsBar : MonoBehaviour
    {
        private const float Offset = 2f;
        
        private Dictionary<DeviceType, string> _message = new Dictionary<DeviceType, string>
        {
            [DeviceType.UnknownDevice] = "Unsupported device",
            [DeviceType.Keyboard] = "Press Space",
            [DeviceType.Gamepad] = "Press O",
        };

        [SerializeField]
        private RectTransform _canvasRectTransform;

        [SerializeField]
        private TipLabel _labelPrefab;

        private ISimpleInput _simpleInput;
        private IInteractiveHandler _interactiveHandler;

        private Dictionary<IInteractable, TipLabel> _labels = new Dictionary<IInteractable, TipLabel>();
        private TipsFactory _tipsFactory;
        private Camera _camera;

        public void Construct(ISimpleInput simpleInput, Camera camera)
        {
            _simpleInput = simpleInput;
            _camera = camera;

            _tipsFactory = new TipsFactory(_labelPrefab, GetComponent<RectTransform>());
        }

        public void Initialize(IInteractiveHandler interactiveHandler)
        {
            _interactiveHandler = interactiveHandler;
            
            _simpleInput.OnDeviceUpdated += UpdateLabels;
            
            _interactiveHandler.OnInteractiveEntered += OnInteractiveEntered;
            _interactiveHandler.OnInteractiveExited += OnInteractiveExited;
        }

        public void Tick() => 
            UpdateLabels();

        public void DeInitialize()
        {
            _simpleInput.OnDeviceUpdated -= UpdateLabels;
            
            if (_interactiveHandler == null)
                return;

            _interactiveHandler.OnInteractiveEntered -= OnInteractiveEntered;
            _interactiveHandler.OnInteractiveExited -= OnInteractiveExited;
        }

        private void UpdateLabels(DeviceType deviceType) => 
            UpdateLabels();

        private void OnInteractiveEntered(IInteractable interactable)
        {
            if (_labels.ContainsKey(interactable))
                return;

            TipLabel label = _tipsFactory.Take();
            
            UpdateLabel(interactable, label);

            _labels.Add(interactable, label);
        }

        private void OnInteractiveExited(IInteractable interactable)
        {
            if (_labels.TryGetValue(interactable, out TipLabel label))
            {
                label.Hide();
                
                _tipsFactory.Put(label);

                _labels.Remove(interactable);
            }
        }

        private void UpdateLabels()
        {
            foreach (var label in _labels) 
                UpdateLabel(label.Key, label.Value);
        }

        private void UpdateLabel(IInteractable interactable, TipLabel label)
        {
            Vector3 offsetPosition = interactable.Position + Vector3.up * Offset;
            
            UIUtils.PlaceUIElement(_camera, _canvasRectTransform, label.RectTransform, offsetPosition);
            
            label.Show(GetMessage(_simpleInput.LastDevice));
        }

        private string GetMessage(DeviceType deviceType)
        {
            if (_message.TryGetValue(deviceType, out string foundMessage))
                return foundMessage;

            return _message[DeviceType.UnknownDevice];
        }
    }
}