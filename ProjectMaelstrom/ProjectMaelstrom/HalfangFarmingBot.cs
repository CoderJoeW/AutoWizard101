using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProjectMaelstrom.Structs;

namespace ProjectMaelstrom
{
    public partial class HalfangFarmingBot : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        private ImageRecognition _image_recognition = new ImageRecognition();
        private Thread _halfangBot;
        private bool _botRun = false;

        public HalfangFarmingBot()
        {
            InitializeComponent();

            
        }

        private void HalfangFarmingBot_Load(object sender, EventArgs e)
        {
            Task.Run(() => UpdateMouse());
        }

        private void RunBot()
        {
            bool battleStarted = false;
            bool justTeleported = false;

            while (_botRun)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                
                if (!IsBattleStarted())
                {
                    MoveForward();
                }

                if (IsInBattle() && IsMyTurn())
                {
                    battleStarted = true;
                    bool result = UseMeteorCard();

                    if (!result)
                    {
                        //If we couldnt find the meteor card we pass
                        Pass();
                    }

                    ResetCursor();
                }
                /*else if(!IsInBattle() && battleStarted)
                {
                    Teleport();
                    battleStarted = false;
                    justTeleported = true;
                }else if(!IsInBattle() && justTeleported)
                {
                    Thread.Sleep(5000);
                    SetMarker();
                    JoinFight();
                    justTeleported = false;
                }*/
            }
        }

        private void Teleport()
        {
            Point teleport = _image_recognition.GetImageLocation($"800x600/Halfang/Utils/teleportto.png");

            if(teleport.X > 0 && teleport.Y > 0)
            {
                WinAPI.click(teleport);
            }
        }

        private void SetMarker()
        {
            Point marker = _image_recognition.GetImageLocation($"800x600/Halfang/Utils/marklocation.png");

            if (marker.X > 0 && marker.Y > 0)
            {
                WinAPI.click(marker);
            }
        }

        private void JoinFight()
        {
            Input[] inputs = new Input[]
            {
                new Input
                {
                    type = (int)InputType.Keyboard,
                    u = new InputUnion
                    {
                        ki = new KeyboardInput
                        {
                            wVk = 0x58,
                            wScan = 0, // W
                            dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                            dwExtraInfo = GetMessageExtraInfo()
                        }
                    }
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }

        private bool IsBattleStarted()
        {
            Point bristlecrown = _image_recognition.GetImageLocation("800x600/Halfang/Utils/bristlecrown.png");

            if(bristlecrown.X > 0 && bristlecrown.Y > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void MoveForward()
        {
            Input[] inputs = new Input[]
            {
                new Input
                {
                    type = (int)InputType.Keyboard,
                    u = new InputUnion
                    {
                        ki = new KeyboardInput
                        {
                            wVk = 0,
                            wScan = 0x11, // W
                            dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                            dwExtraInfo = GetMessageExtraInfo()
                        }
                    }
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }

        private bool IsInBattle()
        {
            Point spellbook = _image_recognition.GetImageLocation($"800x600/Halfang/Utils/spellbook.png");

            if(spellbook.X > 0 && spellbook.Y > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool UseMeteorCard()
        {
            bool matchFound = false;

            string[] images = Directory.GetFiles($"800x600/Halfang/Cards/meteor/");

            for (int i = 0; i < images.Length; i++)
            {
                if (!matchFound)
                {
                    Point meteor = _image_recognition.GetImageLocation(images[i]);

                    if (meteor.X > 0 && meteor.Y > 0)
                    {
                        WinAPI.click(meteor);
                        matchFound = true;
                    }
                    else
                    {
                        matchFound = false;
                    }
                }
            }

            return matchFound;
        }

        private bool IsMyTurn()
        {
            Point passBtn = _image_recognition.GetImageLocation($"800x600/Halfang/Utils/passbutton.png");

            if (passBtn.X > 0 && passBtn.Y > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Pass()
        {
            Point passBtn = _image_recognition.GetImageLocation($"800x600/Halfang/Utils/passbutton.png");

            if(passBtn.X > 0 && passBtn.Y > 0)
            {
                WinAPI.click(passBtn);
            }
        }

        private void ResetCursor()
        {
            Point blankSpot = _image_recognition.GetImageLocation($"800x600/Halfang/Utils/blank.png");

            if (blankSpot.X > 0 && blankSpot.Y > 0)
            {
                WinAPI.click(blankSpot);
            }
            else
            {
                WinAPI.click(new Point(50, 20));
            }
        }

        private void UpdateMouse()
        {
            while (true)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    //xLabel.Text = "X: " + Cursor.Position.X;
                    //yLabel.Text = "Y: " + Cursor.Position.Y;
                    Thread.Sleep(10);
                }

                if (GetAsyncKeyState(0x70) != 0)
                {
                    _botRun = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _halfangBot = new Thread(RunBot);
            _halfangBot.Name = "Halfang Bot";
            _botRun = true;
            _halfangBot.Start();
        }
    }
}
