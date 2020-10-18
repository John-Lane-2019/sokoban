/*
 Assignment 2: Sokoban level designer

 Created by John Lane October 29 2019
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JLaneAssignment1
{
    public partial class DesignForm : Form
    {
        const int WIDTH = 50;//sets the width of all picture boxes to 50
        const int HEIGHT = 50;//sets the height of all picture boxes to 50

        enum ToolButtonType//enums with values 0,1,2,3,4 respectively.
        {
            none,
            hero,
            wall,
            box,
            destination,
        }

        ToolButtonType toolButtonType;//toolButtonType ascribes values to PanelPictureBox.PanelPictureBoxNumber
        public DesignForm()
        {
            InitializeComponent();
        }

        //event handler for grid generation
        private void BtnGenerate_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtRows.Text, out int rows) || !int.TryParse(txtColumns.Text, out int columns))
            {
                MessageBox.Show("Please enter an integer for row and column", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (rows < 1 || columns < 1)
            {
                MessageBox.Show("Please enter values greater than zero for row and column");
            }

            else
            {
                for (int i = 0; i < rows; i++)
                {
                    int y = HEIGHT * i;
                    for (int j = 0; j < columns; j++)
                    {
                        Tile tile = new Tile
                        {
                            BorderStyle = BorderStyle.Fixed3D,
                            Height = HEIGHT,
                            Width = WIDTH,

                        };
                        tile.Click += new EventHandler(ClickPictureBox);
                        int x = WIDTH * j;
                        tile.SizeMode = PictureBoxSizeMode.Zoom;
                        tile.Location = new Point(x, y);
                        tile.Row = i;
                        tile.Column = j;
                        panelOfPictureBoxes.Controls.Add(tile);
                    }

                }

            }
        }

        //event handler for the toolbutton click 
        //assigns value to tool button type based on button property
        private void ToolButtonClick(object sender, EventArgs e)
        {
            if (panelOfPictureBoxes.Controls.Count == 0)
            {
                MessageBox.Show("Please enter numeric a values in the row and column fields and press Generate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Button button = (Button)sender;

                if (button.Name == "btnNone")
                {
                    toolButtonType = ToolButtonType.none;
                }

                if (button.Name == "btnHero")
                {
                    toolButtonType = ToolButtonType.hero;
                }

                if (button.Name == "btnWall")
                {
                    toolButtonType = ToolButtonType.wall;
                }

                if (button.Name == "btnBox")
                {
                    toolButtonType = ToolButtonType.box;
                }

                if (button.Name == "btnDestination")
                {
                    toolButtonType = ToolButtonType.destination;
                }
            }
        }
        //assigns a value to each picture box based on enum from previous method
        private void ClickPictureBox(object sender, EventArgs e)
        {
            Tile panelPictureBox = (Tile)sender;

            switch (toolButtonType)
            {
                case ToolButtonType.none:
                    panelPictureBox.TileType = Convert.ToInt32(toolButtonType);
                    panelPictureBox.Image = null;
                    break;
                case ToolButtonType.hero:
                    panelPictureBox.TileType = Convert.ToInt32(toolButtonType);
                    panelPictureBox.Image = Properties.Resources.Character5;
                    break;
                case ToolButtonType.wall:
                    panelPictureBox.TileType = Convert.ToInt32(toolButtonType);
                    panelPictureBox.Image = Properties.Resources.Wall_Brown;
                    break;
                case ToolButtonType.box:
                    panelPictureBox.TileType = Convert.ToInt32(toolButtonType);
                    panelPictureBox.Image = Properties.Resources.Crate_Red;
                    break;
                case ToolButtonType.destination:
                    panelPictureBox.TileType = Convert.ToInt32(toolButtonType);
                    panelPictureBox.Image = Properties.Resources.EndPoint_Yellow;
                    break;
                default:
                    break;
            }
        }
        /*Event handler for saving a level
        /if the user tries to save when there are no picture boxes
        /in the panel, they get an error message.
        Each numeric value in the panelPictureBox objects is written
        to the file in the loop*/
        private void SaveLevel(object sender, EventArgs e)
        {
            if (panelOfPictureBoxes.Controls.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.FileName = "save1.skbn";
                    sfd.AddExtension = true;
                    sfd.CheckPathExists = true;
                    sfd.Filter = "TEXT(*.txt)|*.txt|ALL(*.*)|*.*";
                    sfd.InitialDirectory = Environment.CurrentDirectory;
                    sfd.Title = "Save Text Document";
                    sfd.ValidateNames = true;
                    sfd.OverwritePrompt = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string path = sfd.FileName;

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine(txtRows.Text);
                            sw.WriteLine(txtColumns.Text);

                            foreach (Tile panelPictureBox in panelOfPictureBoxes.Controls)
                            {
                                sw.WriteLine(panelPictureBox.Row);
                                sw.WriteLine(panelPictureBox.Column);
                                sw.WriteLine(panelPictureBox.TileType);

                            }

                        }
                        MessageBox.Show("File saved successfully", "Sokoban", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            else
            {
                MessageBox.Show("Please design a level before saving", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //event handler for the toolstrip exit. Gives the user 
        //a chance to save on exit if they forgot
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        //form closing event gives user chance to save upon closing. 
        private void DesignForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to save before exiting?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.FileName = "save1.skbn";
                    sfd.AddExtension = true;
                    sfd.CheckPathExists = true;
                    sfd.Filter = "TEXT(*.txt)|*.txt|ALL(*.*)|*.*";
                    sfd.InitialDirectory = Environment.CurrentDirectory;
                    sfd.Title = "Save Text Document";
                    sfd.ValidateNames = true;
                    sfd.OverwritePrompt = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string path = sfd.FileName;

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine(txtRows.Text);
                            sw.WriteLine(txtColumns.Text);

                            foreach (Tile panelPictureBox in panelOfPictureBoxes.Controls)
                            {
                                sw.WriteLine(panelPictureBox.Row);
                                sw.WriteLine(panelPictureBox.Column);
                                sw.WriteLine(panelPictureBox.TileType);

                            }

                            MessageBox.Show("File saved successfully", "Sokoban", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

        }
    }
}





