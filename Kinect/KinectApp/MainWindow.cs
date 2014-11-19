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
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectApp
{
    public partial class MainWindow : Form
    {
        Opcoes op;
        ContextMenu menu;
        KinectController kc;
        Camera cam;

        public MainWindow()
        {
            InitializeComponent();
            Icone.Text = Resource.AppTitle;
            Icone.ShowBalloonTip(3000, "Iniciando...", "O sensor está sendo iniciado. Por favor, aguarde.", ToolTipIcon.Info);
            
            op = new Opcoes(this);
            kc = new KinectController(this);
            cam = new Camera(kc.Sensor);

            menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem("Opções...", mi1_onClick));
            menu.MenuItems.Add(new MenuItem("Ver câmera", mi2_camera));
            menu.MenuItems.Add(new MenuItem("Mostrar teclado virtual", mi3_teclado));
            menu.MenuItems.Add(new MenuItem("Encerrar", mi4_encerrar));
            Icone.ContextMenu = menu;
            
            Icone.ShowBalloonTip(3000, "Pronto!", "O sensor está pronto para uso.", ToolTipIcon.Info);
        }

        public void mi1_onClick(object sender, EventArgs e)
        { 
            op.Show();
        }

        public void mi2_camera(object sender, EventArgs e)
        {
            if (!cam.IsVisible)
            {
                cam.Show();
            }
        }

        public void mi3_teclado(object sender, EventArgs e)
        {
            try
            {
                Process.Start("FreeVK.exe");
            }
            catch (Win32Exception)
            {
                MessageBox.Show(
                    "Não foi possível encontrar o aplicativo FreeVK.exe. Certifique-se de que o mesmo se encontra na pasta de instalação do Windows Kinect Control e tente novamente.",
                    "Erro ao iniciar o teclado virtual"
                    );
            }
        }

        public void mi4_encerrar(object sender, EventArgs e)
        {
            Close();
        }

        public void setDefHand(int hand)
        {
            if (hand == 0)
            {
                kc.DefHand = Microsoft.Kinect.JointType.HandRight;
                kc.DefShoulder = Microsoft.Kinect.JointType.ShoulderRight;
                kc.SecondaryHand = Microsoft.Kinect.JointType.HandLeft;
                kc.SecondaryShoulder = Microsoft.Kinect.JointType.ShoulderLeft;
            }
            else
            {
                kc.DefHand = Microsoft.Kinect.JointType.HandLeft;
                kc.DefShoulder = Microsoft.Kinect.JointType.ShoulderLeft;
                kc.SecondaryHand = Microsoft.Kinect.JointType.HandRight;
                kc.SecondaryShoulder = Microsoft.Kinect.JointType.ShoulderRight;
            }
        }

        public void setPrecision(bool precision)
        {
            kc.Precision = precision;
        }

        public void setSkeletonRefreshRate(int rate)
        {
            kc.setSkeletonRefreshRate(rate);
        }

        public void setSensorAngle(int angle)
        {
            kc.Sensor.ElevationAngle = angle;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Icone.Dispose();
            cam.Close();
            op.Dispose();
            if (kc != null) { kc.Dispose(); }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                Hide();
            }));
        }
    }
}
