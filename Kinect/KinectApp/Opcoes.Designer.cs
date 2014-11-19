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

using System.Windows.Forms;
namespace KinectApp
{
    partial class Opcoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textAngle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bAngle = new System.Windows.Forms.Button();
            this.trackAngle = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.textRate = new System.Windows.Forms.TextBox();
            this.trackRate = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrecisao = new System.Windows.Forms.CheckBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.chooseDefHand = new System.Windows.Forms.GroupBox();
            this.radioEsq = new System.Windows.Forms.RadioButton();
            this.radioDir = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRate)).BeginInit();
            this.chooseDefHand.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textAngle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.bAngle);
            this.groupBox1.Controls.Add(this.trackAngle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textRate);
            this.groupBox1.Controls.Add(this.trackRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPrecisao);
            this.groupBox1.Controls.Add(this.buttonConfirm);
            this.groupBox1.Controls.Add(this.chooseDefHand);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 278);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções do Kinect";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "graus";
            // 
            // textAngle
            // 
            this.textAngle.Enabled = false;
            this.textAngle.Location = new System.Drawing.Point(176, 170);
            this.textAngle.Name = "textAngle";
            this.textAngle.ReadOnly = true;
            this.textAngle.Size = new System.Drawing.Size(37, 20);
            this.textAngle.TabIndex = 10;
            this.textAngle.Text = "10";
            this.textAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ângulo de inclinação:";
            // 
            // bAngle
            // 
            this.bAngle.Location = new System.Drawing.Point(134, 240);
            this.bAngle.Name = "bAngle";
            this.bAngle.Size = new System.Drawing.Size(86, 23);
            this.bAngle.TabIndex = 8;
            this.bAngle.Text = "Testar Ângulo";
            this.bAngle.UseVisualStyleBackColor = true;
            this.bAngle.Click += new System.EventHandler(this.bAngle_Click);
            // 
            // trackAngle
            // 
            this.trackAngle.Location = new System.Drawing.Point(7, 190);
            this.trackAngle.Maximum = 27;
            this.trackAngle.Minimum = -27;
            this.trackAngle.Name = "trackAngle";
            this.trackAngle.Size = new System.Drawing.Size(276, 45);
            this.trackAngle.TabIndex = 7;
            this.trackAngle.Scroll += new System.EventHandler(this.trackAngle_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "quadros/s";
            // 
            // textRate
            // 
            this.textRate.Location = new System.Drawing.Point(176, 117);
            this.textRate.MaxLength = 2;
            this.textRate.Name = "textRate";
            this.textRate.ReadOnly = true;
            this.textRate.Size = new System.Drawing.Size(37, 20);
            this.textRate.TabIndex = 5;
            this.textRate.Text = "15";
            this.textRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // trackRate
            // 
            this.trackRate.Location = new System.Drawing.Point(7, 138);
            this.trackRate.Maximum = 30;
            this.trackRate.Minimum = 1;
            this.trackRate.Name = "trackRate";
            this.trackRate.Size = new System.Drawing.Size(276, 45);
            this.trackRate.TabIndex = 4;
            this.trackRate.Value = 15;
            this.trackRate.Scroll += new System.EventHandler(this.trackRate_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Taxa de atualização do cursor:";
            // 
            // cbPrecisao
            // 
            this.cbPrecisao.AutoSize = true;
            this.cbPrecisao.Checked = true;
            this.cbPrecisao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrecisao.Location = new System.Drawing.Point(17, 97);
            this.cbPrecisao.Name = "cbPrecisao";
            this.cbPrecisao.Size = new System.Drawing.Size(111, 17);
            this.cbPrecisao.TabIndex = 2;
            this.cbPrecisao.Text = "Modo de precisão";
            this.cbPrecisao.UseVisualStyleBackColor = true;
            this.cbPrecisao.CheckedChanged += new System.EventHandler(this.cbPrecisao_CheckedChanged);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(53, 240);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "Confirmar";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // chooseDefHand
            // 
            this.chooseDefHand.Controls.Add(this.radioEsq);
            this.chooseDefHand.Controls.Add(this.radioDir);
            this.chooseDefHand.Location = new System.Drawing.Point(7, 20);
            this.chooseDefHand.Name = "chooseDefHand";
            this.chooseDefHand.Size = new System.Drawing.Size(276, 70);
            this.chooseDefHand.TabIndex = 0;
            this.chooseDefHand.TabStop = false;
            this.chooseDefHand.Text = "Mão padrão";
            // 
            // radioEsq
            // 
            this.radioEsq.AutoSize = true;
            this.radioEsq.Location = new System.Drawing.Point(10, 43);
            this.radioEsq.Name = "radioEsq";
            this.radioEsq.Size = new System.Drawing.Size(70, 17);
            this.radioEsq.TabIndex = 1;
            this.radioEsq.TabStop = true;
            this.radioEsq.Text = "Esquerda";
            this.radioEsq.UseVisualStyleBackColor = true;
            // 
            // radioDir
            // 
            this.radioDir.AutoSize = true;
            this.radioDir.Location = new System.Drawing.Point(10, 21);
            this.radioDir.Name = "radioDir";
            this.radioDir.Size = new System.Drawing.Size(55, 17);
            this.radioDir.TabIndex = 0;
            this.radioDir.TabStop = true;
            this.radioDir.Text = "Direita";
            this.radioDir.UseVisualStyleBackColor = true;
            // 
            // Opcoes
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 302);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Opcoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opções";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Opcoes_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRate)).EndInit();
            this.chooseDefHand.ResumeLayout(false);
            this.chooseDefHand.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | 0x200;
                return myCp;
            }
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox chooseDefHand;
        private System.Windows.Forms.RadioButton radioEsq;
        private System.Windows.Forms.RadioButton radioDir;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.CheckBox cbPrecisao;
        private Label label2;
        private TextBox textRate;
        private TrackBar trackRate;
        private Label label1;
        private Label label4;
        private TextBox textAngle;
        private Label label3;
        private Button bAngle;
        private TrackBar trackAngle;
    }
}