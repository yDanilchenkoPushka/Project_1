using Services.Input;
using TMPro;
using UnityEngine;

namespace UI.Bars
{
    public class DeviceBar : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _title;

        private ISimpleInput _simpleInput;

        public void Construct(ISimpleInput simpleInput)
        {
            _simpleInput = simpleInput;
            
            simpleInput.OnControlUpdated += UpdateControl;
        }

        public void DeInitialize() => 
            _simpleInput.OnControlUpdated -= UpdateControl;

        private void UpdateControl(string message) => 
            _title.text = message;
    }
}