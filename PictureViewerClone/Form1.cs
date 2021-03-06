﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewerClone
{
    public partial class Form1 : Form
    {
        public string SavedFolder;

        public Form1()
        {
            InitializeComponent();

            this.BackColor = Color.White;
            this.TabStop = false;

            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        #region buttons

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the 
            // picture that the user chose. 
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                SavedFolder = openFileDialog1.FileName;

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TestBox\all other\PictureViewer\WriteLines.txt", true))
                {
                    file.WriteLine(SavedFolder);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {            
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorDialog1.AllowFullOpen = false;
                colorDialog1.AnyColor = true;
                colorDialog1.SolidColorOnly = false;
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            String SavedImage = pictureBox1.ImageLocation;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TestBox\all other\PictureViewer\RememberImages.txt", true))
            {
                file.WriteLine(SavedImage);
            }
        }

        #endregion

        #region menu
        private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void OpenFileMenuItem_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the 
            // picture that the user chose. 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void ExitFileMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion menu



    }
}
