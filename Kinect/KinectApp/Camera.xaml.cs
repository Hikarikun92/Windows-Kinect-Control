/*
	Copyright (C) 2014  Lucas José dos Santos Souza

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Kinect;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace KinectApp
{
    /// <summary>
    /// Interaction logic for Camera.xaml
    /// </summary>
    public partial class Camera : Window
    {
        KinectSensor sensor;

        public Camera(KinectSensor sensor)
        {
            InitializeComponent();
            this.sensor = sensor;
        }

		//Tira os botões de minimizar, maximizar e fechar da janela
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sensor.ColorStream.Disable();
            //Do not close application
            e.Cancel = true;
            Visibility = Visibility.Hidden;
        }
        
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            sensor.ColorFrameReady += sensor_ColorFrameReady;
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

		//Gera uma imagem 640x480 com os dados do stream de cores
        void sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame cif = e.OpenColorImageFrame())
            {
                if (cif == null) return;

                byte[] cbytes = new byte[cif.PixelDataLength];
                cif.CopyPixelDataTo(cbytes);

                int stride = cif.Width * 4;

                imgKinect.Source = BitmapImage.Create(640, 480, 96, 96, PixelFormats.Bgr32, null, cbytes, stride);
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            sensor.ColorStream.Enable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sensor.ColorStream.Disable();
            Hide();
        }
        
    }
}
