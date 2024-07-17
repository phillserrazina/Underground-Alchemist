using System;

using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.InputSystem.DualShock;

using Lucerna.Common.Singletons;

namespace Lucerna.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        // VARIABLES
        public bool UsingKeyboard
        {
            get
            {
                if (cachedPlayerInput == null)
                {
                    cachedPlayerInput = GetComponent<PlayerInput>();
                }

                return cachedPlayerInput.currentControlScheme == "KeyboardMouse";
            }
        }

        public bool UsingGamepad
        {
            get
            {
                if (cachedPlayerInput == null)
                {
                    cachedPlayerInput = GetComponent<PlayerInput>();
                }

                return cachedPlayerInput.currentControlScheme == "Gamepad";
            }
        }

        public bool UsingXbox
        {
            get
            {
                if (cachedPlayerInput == null)
                {
                    cachedPlayerInput = GetComponent<PlayerInput>();
                }

                if (!UsingGamepad)
                {
                    return false;
                }

                return Gamepad.current is XInputController || Gamepad.current is XInputControllerWindows;
            }
        }

        public bool UsingPlaystation
        {
            get
            {
                if (cachedPlayerInput == null)
                {
                    cachedPlayerInput = GetComponent<PlayerInput>();
                }

                if (!UsingGamepad)
                {
                    return false;
                }

                return Gamepad.current is DualShockGamepad || Gamepad.current is DualSenseGamepadHID;
            }
        }

        private PlayerInput cachedPlayerInput;

        public event EventHandler OnControllerDisconnected;

        // EXECUTION FUNCTIONS
        private void Start()
        {
            InputSystem.onDeviceChange += (device, change) =>
            {
                switch (change)
                {
                    case InputDeviceChange.Removed:
                        OnControllerDisconnected?.Invoke(this, EventArgs.Empty);
                        break;
                    case InputDeviceChange.Disconnected:
                        OnControllerDisconnected?.Invoke(this, EventArgs.Empty);
                        break;
                    default:
                        break;
                }
            };
        }
    }
}