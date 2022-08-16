using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace.UI
{
    public class ButtonBar : MonoBehaviour
    {
        private const int DefaultButtonIndex = 0;
        
        [SerializeField]
        private Color _selectedColor;
        
        [SerializeField]
        private InteractiveButton[] _buttons;

        private Dictionary<Type, InteractiveButton> _buttonDictionary = new Dictionary<Type, InteractiveButton>();
        private int _selectedIndex = 0;

        private Controls _controls;

        public void Construct(Controls controls)
        {
            _controls = controls;
            
            InitializeButtons();
            
            _controls.MainMenu.Up.performed += ToUp;
            _controls.MainMenu.Down.performed += ToDown;

            _controls.MainMenu.Click.performed += Click;
            
            _selectedIndex = DefaultButtonIndex;
            Select();
        }

        private void InitializeButtons()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttonDictionary.Add(_buttons[i].GetType(), _buttons[i]);
                
                _buttons[i].Initialize(i);

                _buttons[i].OnOvered += Choose;
            }
        }

        public void DeInitialize()
        {
            _controls.MainMenu.Up.performed -= ToUp;
            _controls.MainMenu.Down.performed -= ToDown;

            _controls.MainMenu.Click.performed -= Click;

            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].OnOvered -= Choose;
                
                _buttons[i].DeInitialize();
            }
        }

        public bool TryGetButton<TButton>(out InteractiveButton interactiveButton) where TButton : InteractiveButton
        {
            if (_buttonDictionary.TryGetValue(typeof(TButton), out InteractiveButton foundButton))
            {
                interactiveButton = foundButton;
                return true;
            }

            interactiveButton = default;
            return false;
        }

        private void ToUp(InputAction.CallbackContext obj)
        {
            CleanSelected();

            _selectedIndex--;
            
            if (_selectedIndex <= -1)
                _selectedIndex = _buttons.Length - 1;
            
            Select();
        }

        private void ToDown(InputAction.CallbackContext obj)
        {
            CleanSelected();
            
            _selectedIndex++;
            
            if (_selectedIndex >= _buttons.Length)
                _selectedIndex = 0;
            
            Select();
        }

        private void Select() => 
            _buttons[_selectedIndex].Select(_selectedColor);

        private void CleanSelected() => 
            _buttons[_selectedIndex].UnSelect();

        private void Click(InputAction.CallbackContext obj) => 
            _buttons[_selectedIndex].Click();

        private void Choose(int id)
        {
            CleanSelected();
            
            _selectedIndex = id;
            Select();
        }
    }
}