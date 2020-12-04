
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState
{
    interface IGameStateControllerMappings
    {
        Dictionary<Keys, ICommand> KeyboardMappings { get; }
        Dictionary<MouseButton, ICommand> MouseMappings { get; }
        Dictionary<Buttons, ICommand> GamepadMappings { get; }
        Dictionary<Type, ICommand> ButtonMappings { get; }
        List<Keys> RepeatableKeyboardKeys { get; }
        List<Buttons> RepeatableGamepadButtons { get; }
    }
}
