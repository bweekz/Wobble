using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Wobble.Input
{
    public static class KeyboardManager
    {
        /// <summary>
        ///     The current keyboard state
        /// </summary>
        public static KeyboardState CurrentState { get; private set; }

        /// <summary>
        ///     The keyboard state of the previous frame
        /// </summary>
        public static KeyboardState PreviousState { get; private set; }

        /// <summary>
        ///     Keeps our keyboard states updated each frame
        /// </summary>
        internal static void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Keyboard.GetState();
        }

        /// <summary>
        ///     If the key was pressed and released - useful for actions that require a single key press.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsUniqueKeyPress(Keys key) => CurrentState.IsKeyDown(key) && PreviousState.IsKeyUp(key);

        /// <summary>
        ///     If a key was previously pressed down and then released.
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool IsUniqueKeyRelease(Keys k) => CurrentState.IsKeyUp(k) && PreviousState.IsKeyDown(k);

        /// <summary>
        ///     If a key was previously pressed down and then released.
        /// </summary>
        /// <returns>The status of the full screen key pressed</returns>
        public static bool IsFullScreenKeyPressed()
        {
            var pressedKey = CurrentState.GetPressedKeys();

            if (pressedKey.Contains(Keys.Enter) && (pressedKey.Contains(Keys.LeftAlt) || pressedKey.Contains(Keys.RightAlt)))
                return true;
            return false;
        }
    }
}
