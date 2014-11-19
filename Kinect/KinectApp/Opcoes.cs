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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectApp
{
    public partial class Opcoes : Form
    {
        MainWindow mw;
        int previousAngle;

        public Opcoes(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            this.Icon = Resource.Icone;
            this.trackAngle.Value = 10;
            previousAngle = 10;
        }

        private void Opcoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (radioDir.Checked)
            {
                mw.setDefHand(0);
            }
            else
            {
                mw.setDefHand(1);
            }
            Hide();
        }

        private void cbPrecisao_CheckedChanged(object sender, EventArgs e)
        {
            mw.setPrecision(cbPrecisao.Checked);
        }

        private void trackRate_Scroll(object sender, EventArgs e)
        {
            textRate.Text = trackRate.Value.ToString();
            mw.setSkeletonRefreshRate(trackRate.Value);
        }

        private void bAngle_Click(object sender, EventArgs e)
        {
            int angle = trackAngle.Value;
            if (angle != previousAngle)
            {
                previousAngle = angle;
                mw.setSensorAngle(angle);
            }
        }

        private void trackAngle_Scroll(object sender, EventArgs e)
        {
            textAngle.Text = trackAngle.Value.ToString();
        }
    }
}
