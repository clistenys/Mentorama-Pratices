using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Module4
{
    public class UIManager : MonoBehaviour
    {
        private void Awake()
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }

        public void QuitApplication()
        {
            Application.Quit();
        }

        public void ChangeVisualization(Toggle isWindownedToggle)
        {
            if (isWindownedToggle.isOn)
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            else
                Screen.fullScreenMode = FullScreenMode.Windowed;
        }

        public void SetResolution(Dropdown dropdownMenu)
        {
            switch (dropdownMenu.value)
            {
                case 0:
                    Screen.SetResolution(1280, 1024, Screen.fullScreenMode);
                    break;
                case 1:
                    Screen.SetResolution(1024, 768, Screen.fullScreenMode);
                    break;
                case 2:
                    Screen.SetResolution(800, 600, Screen.fullScreenMode);
                    break;
                default:
                    Screen.SetResolution(1280, 1024, Screen.fullScreenMode);
                    break;
            }
        }
    }
}

