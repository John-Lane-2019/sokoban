/*
 Assignment 1: Sokoban level designer

 Created by John Lane October 29 2019
 */

using System;
using System.Windows.Forms;

namespace JLaneAssignment1
{
    public partial class SokobanForm : Form
    {
        //constructor
        public SokobanForm()
        {
            InitializeComponent();
        }
       //event handler on first form that opens main form
        private void BtnDesign_Click_1(object sender, EventArgs e)
        {
            using (DesignForm designForm = new DesignForm())
            {
                designForm.ShowDialog();
            }

        }
        //closes form
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            using (PlayForm playForm = new PlayForm())
            {
                playForm.ShowDialog();
            }
        }
    }
}
