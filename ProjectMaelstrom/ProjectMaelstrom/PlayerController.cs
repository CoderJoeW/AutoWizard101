using ProjectMaelstrom.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using WindowsInput;
using WindowsInput.Native;

namespace ProjectMaelstrom
{
    internal class PlayerController
    {
        private InputSimulator _inputSimulator = new InputSimulator();

        public void MoveForward()
        {
            _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.UP);
        }

        public void MoveBackward()
        {
            _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.BACK);
        }

        public void MoveLeft()
        {
            _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.LEFT);
        }

        public void MoveRight()
        {
            _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.RIGHT);
        }

        public void Interact()
        {
            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_X);
        }

        public void PressNumber9()
        {
            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD9);
        }

        public void Click(Point clickPoint)
        {
            WinAPI.click(clickPoint);
        }
    }
}
