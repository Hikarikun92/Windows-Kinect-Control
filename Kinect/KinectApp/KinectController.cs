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
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit.Interaction;
using Microsoft.Kinect.Toolkit.Properties;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Windows.Input;


namespace KinectApp
{
    class KinectController
    {
        KinectSensor sensor;
        int posX, posY, nextX, nextY;
        double screenWidth, screenHeight;
        JointType defHand, defShoulder, secondaryHand, secondaryShoulder;
        bool clicked, isMouseLDown, isMouseMDown, isMouseRDown, precision;
        System.Timers.Timer timer;
        int skeletonRefreshRate;

        public KinectSensor Sensor
        {
            get
            {
                return sensor;
            }
        }

        public JointType DefHand
        {
            set { defHand = value; }
        }

        public JointType DefShoulder
        {
            set { defShoulder = value; }
        }

        public JointType SecondaryHand
        {
            set { secondaryHand = value; }
        }

        public JointType SecondaryShoulder
        {
            set { secondaryShoulder = value; }
        }

        public bool Precision
        {
            set { precision = value; }
        }

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        public KinectController(MainWindow mw)
        {
            bool sucesso = false;
            sensor=null;

            screenWidth = System.Windows.SystemParameters.VirtualScreenWidth;
            screenHeight = System.Windows.SystemParameters.VirtualScreenHeight;
			
            do
            {
                if (KinectSensor.KinectSensors.Count > 0)
                {
                    sensor = KinectSensor.KinectSensors.FirstOrDefault(s => s.Status == KinectStatus.Connected || s.Status == KinectStatus.Initializing);
                    
                    if (sensor != null)
                    {
                        if (sensor.Status == KinectStatus.Connected)
                        {
                            sucesso = true;
                            sensor.SkeletonStream.Enable();
                            defHand = JointType.HandRight;
                            secondaryHand = JointType.HandLeft;
                            defShoulder = JointType.ShoulderRight;
                            secondaryShoulder = JointType.ShoulderLeft;
                            clicked = false;
                            isMouseLDown = false;
                            isMouseMDown = false;
                            isMouseRDown = false;
                            precision = true;
                            posX = 0;
                            posY = 0;
                            timer = new System.Timers.Timer(1000.0 / 15.0);
                            timer.Elapsed += timer_Elapsed;
                            sensor.Start();
                            sensor.ElevationAngle = 10;
                            timer.Start();
                        }
                        else
                        {
                            MessageBox.Show("O sensor foi detectado, porém houve algum problema ao estabelecer a comunicação. Por favor, tente reconectá-lo e inicie o programa novamente.\nStatus do sensor: " + sensor.Status.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            mw.Close();
                            Environment.Exit(-1);
                        }
                    }
                    else
                    {
                        DialogResult resultado = MessageBox.Show("Nenhum sensor detectado. Tentar novamente?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (resultado == DialogResult.No)
                        {
                            mw.Close();
                            Environment.Exit(-1);
                        }
                    }
                }
                else
                {
                    DialogResult resultado = MessageBox.Show("Nenhum sensor detectado. Tentar novamente?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (resultado == DialogResult.No)
                    {
                        mw.Close();
                        Environment.Exit(-1);
                    }
                }
            } while (!sucesso);
        }

        public void setSkeletonRefreshRate(int rate)
        {
            timer.Interval = 1000.0 / (double) rate;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SkeletonFrame skelframe = null;
            
            skelframe = sensor.SkeletonStream.OpenNextFrame((int) timer.Interval);

            try
            {
                if (skelframe != null)
                {
                    Skeleton[] skeletonGroup = new Skeleton[skelframe.SkeletonArrayLength];
                    skelframe.CopySkeletonDataTo(skeletonGroup);
                    Skeleton sk = (from s in skeletonGroup where s.TrackingState == SkeletonTrackingState.Tracked select s).FirstOrDefault();

                    if (sk == null) return;
                    float rightX, rightY;

                    rightX = sk.Joints[defHand].Position.X;
                    rightY = sk.Joints[defHand].Position.Y;

                    nextX = (int)(screenWidth / 2 + rightX * screenWidth * 2.0);
                    nextY = (int)(screenHeight / 2 - rightY * screenHeight * 1.5);

                    if (precision)
                    {
                        if ((Math.Abs(nextX - posX) > 20) || Math.Abs(nextY - posY) > 20)
                        {
                            posX = nextX;
                            posY = nextY;
                            SetCursorPos(posX, posY);
                        }
                    }
                    else
                    {
                        posX = nextX;
                        posY = nextY;
                        SetCursorPos(posX, posY);
                    }

                    Joint secHand = sk.Joints[secondaryHand];
                    Joint secShoulder = sk.Joints[secondaryShoulder];

                    if (clicked)
                    {
                        if (secShoulder.Position.Z - secHand.Position.Z < 0.3 && isMouseRDown)
                        {
                            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                            isMouseRDown = false;
                            clicked = false;
                        }
                        if (secShoulder.Position.Z - secHand.Position.Z < 0.45)
                        {

                            if (isMouseLDown)
                            {
                                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                                isMouseLDown = false;
                            }
                            if (isMouseMDown)
                            {
                                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.MiddleUp);
                                isMouseMDown = false;
                            }

                            clicked = false;
                        }
                    }
                    else
                    {
                        if (secShoulder.Position.Z - secHand.Position.Z > 0.3 && secHand.Position.Y > secShoulder.Position.Y + 0.2)
                        {
                            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
                            isMouseRDown = true;
                            clicked = true;
                        }
                        else if (secShoulder.Position.Z - secHand.Position.Z > 0.45)
                        {
                            if (secHand.Position.Y < secShoulder.Position.Y - 0.1)
                            {
                                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                                isMouseLDown = true;
                            }
                            else if (secHand.Position.Y < secShoulder.Position.Y + 0.2)
                            {
                                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.MiddleDown);
                                isMouseMDown = true;
                            }
                            clicked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
            }
            finally
            {
                if (skelframe != null) skelframe.Dispose();
            }
        }

        public void Dispose()
        {
            if (sensor != null)
            {
                timer.Stop();
                sensor.SkeletonStream.Disable();
                sensor.Stop();
                sensor.Dispose();
            }
        }
    }
}
