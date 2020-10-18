/*
 Assignment 2: Sokoban level designer

 Created by John Lane October 29 2019
 */

using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace JLaneAssignment1
{
    public partial class PlayForm : Form
    {
        public PlayForm()
        {
            InitializeComponent();
        }
        //declare global variables
        PictureBox[,] tileArray;
        private int row;
        private int column;
        private int moveCounter = 0;
        private int pushCounter = 0;
        private int currentHeroRow;
        private int currentHeroColumn;
        private int newCrateRow;
        private int newCrateColumn;
        private int targetTile;
        private int NumbeOfDestinations;
        Tile hero;
        //made the image files into global variables to save some typing
        private readonly Image heroImage = Properties.Resources.Character5;
        private readonly Image leftHero = Properties.Resources.leftHero;
        private readonly Image rightHero = Properties.Resources.rightHero;
        private readonly Image upHero = Properties.Resources.Character7;
        private readonly Image redCrate = Properties.Resources.Crate_Red;
        private readonly Image destination = Properties.Resources.EndPoint_Yellow;
        private readonly Image brickWall = Properties.Resources.Wall_Brown;
        private readonly Image purpleCrate = Properties.Resources.Crate_Purple;

        private TileType returnedTileType;
        const int WIDTH = 50;//sets the width of all picture boxes to 50
        const int HEIGHT = 50;//sets the height of all picture boxes to 50

        //enum type
        enum TileType
        {
            None,
            Hero,
            Wall,
            Box,
            Destination,
        }
        
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {   //adjust the score display on load event
            playFormPanel.Controls.Clear();
            txtNumberOfMoves.Clear();
            txtNumberOfPushes.Clear();
            txtNumberOfMoves.Text = "0";
            txtNumberOfPushes.Text = "0";
            moveCounter = 0;
            pushCounter = 0;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Multiselect = false;
                ofd.ShowHelp = true;
                ofd.InitialDirectory = Environment.CurrentDirectory;
                ofd.Filter = "Sokoban(*.txt)|*.txt|ALL(*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //loop through the saved file
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        row = Convert.ToInt32(sr.ReadLine());
                        column = Convert.ToInt32(sr.ReadLine());

                        tileArray = new PictureBox[row, column]; //assign array dimensions
                        while (sr.EndOfStream == false)
                        {
                            int tileRow = Convert.ToInt32(sr.ReadLine());
                            int tileColumn = Convert.ToInt32(sr.ReadLine());
                            int tileType = Convert.ToInt32(sr.ReadLine());

                            Tile tile = new Tile();

                            tile.TileType = tileType;
                            tile.Row = tileRow;
                            tile.Column = tileColumn;

                            tileArray[tileRow, tileColumn] = tile;
                            //write a tile of specific type to the specified row and column
                        }

                    }

                    for (int i = 0; i < tileArray.GetLength(0); i++)//reads back tile objects from array
                    {
                        int y = HEIGHT * i;
                        for (int j = 0; j < tileArray.GetLength(1); j++)
                        {
                            var arrayElement = tileArray[i, j];
                            Tile tile = (Tile)arrayElement; //tileArray[i, j]
                            tile.BorderStyle = BorderStyle.Fixed3D;
                            int x = WIDTH * j;
                            tile.Location = new Point(x, y);
                            tile.Width = WIDTH;
                            tile.Height = HEIGHT;
                            tile.SizeMode = PictureBoxSizeMode.Zoom;

                            playFormPanel.Controls.Add(tile);
                            //if statements assign image to tiles
                            if (tile.TileType == ((int)TileType.None))
                            {
                                tile.Image = null;

                            }

                            if (tile.TileType == ((int)TileType.Hero))
                            {
                                tile.Image = heroImage;
                                hero = tile;
                                tile.BringToFront();
                            }

                            if (tile.TileType == ((int)TileType.Wall))
                            {
                                tile.Image = brickWall;
                            }

                            if (tile.TileType == ((int)TileType.Box))
                            {
                                tile.Image = redCrate;
                                tile.BringToFront();
                            }

                            if (tile.TileType == ((int)TileType.Destination))
                            {
                                tile.Image = destination;
                                NumbeOfDestinations++;
                                tile.SendToBack();
                            }
                        }
                    }

                }

            }
        }

        private void btnLeft_Click(object sender, EventArgs e)//handles left movment logic
        {
            /*all the code in this method works by determining what the hero's 
             destination tile is based on his current location. The location of his 
             destination tile is passed to GetTile() which returns an enum
             which will determine which movement logic gets executed*/
            
            if (playFormPanel.Controls.Count == 0)
            {
                CheckPanel();
            }

            else
            {   
                currentHeroRow = hero.Row;
                currentHeroColumn = hero.Column;
                targetTile = currentHeroColumn - 1;
                returnedTileType = GetTile(currentHeroRow, hero.Column - 1);

                               
                if (returnedTileType == TileType.Wall)
                {
                    CantGoThere();
                    return;
                }

               
                if (returnedTileType == TileType.None)
                {
                    tileArray[currentHeroRow, targetTile].Image = leftHero;
                    tileArray[currentHeroRow, currentHeroColumn].Image = null;
                    hero.Column--;
                    txtNumberOfMoves.Text = (++moveCounter).ToString();
                }

                if (returnedTileType == TileType.Box)
                {
                    if (tileArray[currentHeroRow, targetTile - 1].Image == brickWall ||
                        tileArray[currentHeroRow,targetTile -1].Image == purpleCrate)//br
                    {
                        CantGoThere();
                        return;
                    }

                    if (tileArray[currentHeroRow, targetTile].Image == redCrate)
                    {
                        tileArray[currentHeroRow, targetTile].Image = leftHero;
                        tileArray[currentHeroRow, currentHeroColumn].Image = null;
                        newCrateRow = currentHeroRow;
                        newCrateColumn = targetTile - 1;

                        DestinationCounter(tileArray[newCrateRow, newCrateColumn]);

                        if (tileArray[newCrateRow, newCrateColumn].Image != purpleCrate)
                        {
                            tileArray[newCrateRow, newCrateColumn].Image = redCrate;
                            txtNumberOfMoves.Text = (++moveCounter).ToString();//if this were the last click event, it would not fire
                            txtNumberOfPushes.Text = (++pushCounter).ToString();
                        }


                        //tileArray[newCrateRow, newCrateColumn].Image = redCrate;

                        hero.Column--;

                        //txtNumberOfMoves.Text = (++moveCounter).ToString();
                        //txtNumberOfPushes.Text = (++pushCounter).ToString();
                        //I think you broke it messing up with loading different levels. now it works, and lets hope he is not going to do the same
                    }//the tally doesn't work. lets run it again. should be 11
                }

               //DestinationCounter();

            }
            
        }

        private void btnRight_Click(object sender, EventArgs e)//handles right movement logic
        {
            /*all the code in this method works by determining what the hero's 
            destination tile is based on his current location. The location of his 
            destination tile is passed to GetTile() which returns an enum
            which will determine which movement logic gets executed*/

            if (playFormPanel.Controls.Count == 0)
            {
                CheckPanel();
            }

            else
            {
                currentHeroRow = hero.Row;
                currentHeroColumn = hero.Column;
                targetTile = currentHeroColumn + 1;
                returnedTileType = GetTile(currentHeroRow, hero.Column + 1);

                if (returnedTileType == TileType.Wall)
                {
                    CantGoThere();
                    return;
                }
                if (returnedTileType == TileType.None)
                {
                    tileArray[currentHeroRow, targetTile].Image = rightHero;
                    tileArray[hero.Row, hero.Column].Image = null;
                    hero.Column++;
                    txtNumberOfMoves.Text = (++moveCounter).ToString();
                }

                if (returnedTileType == TileType.Box)
                {
                    if (tileArray[currentHeroRow, targetTile + 1].Image == brickWall  ||
                        tileArray[currentHeroRow, targetTile + 1].Image == purpleCrate) 
                    {
                        CantGoThere();
                        return;
                    }

                    if (tileArray[currentHeroRow, targetTile].Image == redCrate)
                    {
                        tileArray[currentHeroRow, targetTile].Image = rightHero;
                        tileArray[currentHeroRow, currentHeroColumn].Image = null;
                        newCrateRow = currentHeroRow;
                        newCrateColumn = targetTile + 1;

                        DestinationCounter(tileArray[newCrateRow, newCrateColumn]);

                        if (tileArray[newCrateRow, newCrateColumn].Image != purpleCrate)
                        {
                            tileArray[newCrateRow, newCrateColumn].Image = redCrate;
                            txtNumberOfMoves.Text = (++moveCounter).ToString();//if this were the last click event, it would not fire
                            txtNumberOfPushes.Text = (++pushCounter).ToString();//put this inside if block for all button handlers
                        }//hang on I want to see something//ok it was incrementing wrong. just wanted to make sure i saw that correctly

                       
                        //tileArray[newCrateRow, newCrateColumn].Image = purpleCrate;

                        hero.Column++;
                        //neither would this

                    }
                }

                //DestinationCounter();
            }

           
        }

        private void BtnDown_Click(object sender, EventArgs e)//handles downward movment logic
        {
            /*all the code in this method works by determining what the hero's 
            destination tile is based on his current location. The location of his 
            destination tile is passed to GetTile() which returns an enum
            which will determine which movement logic gets executed*/
            if (playFormPanel.Controls.Count == 0)
            {
                CheckPanel();
            }

            else
            {
                currentHeroRow = hero.Row;
                currentHeroColumn = hero.Column;
                targetTile = currentHeroRow + 1;

                returnedTileType = GetTile(hero.Row + 1, currentHeroColumn);

                if (returnedTileType == TileType.Wall)
                {
                    CantGoThere();
                    return;
                }
                if (returnedTileType == TileType.None)
                {
                    tileArray[targetTile, currentHeroColumn].Image = heroImage;
                    tileArray[hero.Row, hero.Column].Image = null;
                    hero.Row++;
                    txtNumberOfMoves.Text = (++moveCounter).ToString();
                }

                if (returnedTileType == TileType.Box)
                {
                    if (tileArray[targetTile + 1, currentHeroColumn].Image == brickWall)
                    {
                        CantGoThere();
                        return;
                    }

                    if (tileArray[targetTile, currentHeroColumn].Image == redCrate)
                    {
                        tileArray[targetTile, currentHeroColumn].Image = heroImage;
                        tileArray[currentHeroRow, currentHeroColumn].Image = null;
                        newCrateRow = targetTile + 1;
                        newCrateColumn = currentHeroColumn;

                        DestinationCounter(tileArray[newCrateRow, newCrateColumn]);

                        if (tileArray[newCrateRow, newCrateColumn].Image != purpleCrate)
                        {
                            tileArray[newCrateRow, newCrateColumn].Image = redCrate;
                            txtNumberOfMoves.Text = (++moveCounter).ToString();//if this were the last click event, it would not fire
                            txtNumberOfPushes.Text = (++pushCounter).ToString();
                        }
                        //please, you have already done so much. Don't sink any more time into this. //ok just let me ake a look
                        //tileArray[newCrateRow, newCrateColumn].Image = purpleCrate;

                        hero.Row++;
                        
                        //txtNumberOfMoves.Text = (++moveCounter).ToString();
                        //txtNumberOfPushes.Text = (++pushCounter).ToString();

                    }

                }

                //DestinationCounter();
            }
           
        }

        private void btnUp_Click(object sender, EventArgs e)//handles upward movment logic
        {
            /*all the code in this method works by determining what the hero's 
            destination tile is based on his current location. The location of his 
            destination tile is passed to GetTile() which returns an enum
            which will determine which movement logic gets executed*/

            if (playFormPanel.Controls.Count == 0)
            {
                CheckPanel();
            }

            else
            {
                currentHeroRow = hero.Row;
                currentHeroColumn = hero.Column;
                targetTile = currentHeroRow - 1;

                returnedTileType = GetTile(hero.Row - 1, currentHeroColumn);

                if (returnedTileType == TileType.Wall)
                {
                    CantGoThere();
                    return;
                }
                if (returnedTileType == TileType.None)
                {
                    tileArray[targetTile, currentHeroColumn].Image = upHero;
                    tileArray[hero.Row, hero.Column].Image = null;
                    hero.Row--;
                    txtNumberOfMoves.Text = (++moveCounter).ToString();
                }

                if (returnedTileType == TileType.Box)
                {
                    if (tileArray[targetTile - 1, currentHeroColumn].Image == brickWall)
                    {
                        CantGoThere();
                        return;
                    }

                    if (tileArray[targetTile, currentHeroColumn].Image == redCrate)
                    {
                        tileArray[targetTile, currentHeroColumn].Image = upHero;
                        tileArray[currentHeroRow, currentHeroColumn].Image = null;
                        newCrateRow = targetTile - 1;
                        newCrateColumn = currentHeroColumn;


                        DestinationCounter(tileArray[newCrateRow, newCrateColumn]);

                        if(tileArray[newCrateRow, newCrateColumn].Image != purpleCrate)
                        {
                            tileArray[newCrateRow, newCrateColumn].Image = redCrate;
                            txtNumberOfMoves.Text = (++moveCounter).ToString();//if; this were the last click event, it would not fire
                            txtNumberOfPushes.Text = (++pushCounter).ToString(); 
                        }
                       

                        hero.Row--;
                        //txtNumberOfMoves.Text = (++moveCounter).ToString();
                        //txtNumberOfPushes.Text = (++pushCounter).ToString();

                    }
                }
                
            } 
        
        }
        private TileType GetTile(int currentHeroRow, int targetTile)//returns enum type
        {
            if (tileArray[currentHeroRow, targetTile].Image == brickWall)
            {
                return TileType.Wall;
            }
            else if(tileArray[currentHeroRow, targetTile].Image == purpleCrate)
            {
                return TileType.Wall;
            }
            else if (tileArray[currentHeroRow, targetTile].Image == destination)
            {
                return TileType.Destination;
            }
            else if (tileArray[currentHeroRow, targetTile].Image == redCrate) // box is 3?
            {
                return TileType.Box;
            }
            return TileType.None;
        }

        private void CantGoThere()
        {
            MessageBox.Show("You can't move any further in that direction.",
                "Please note", MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);
        }

        private void CheckPanel()
        {
            MessageBox.Show("Please load a map before attempting to play",
                   "Advisory",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

        }


        private void DestinationCounter(PictureBox box)
        {

            if (box.Image == destination) 
            {
                NumbeOfDestinations--;
                box.Image = purpleCrate;

                txtNumberOfMoves.Text = (++moveCounter).ToString();
                txtNumberOfPushes.Text = (++pushCounter).ToString();

                if (NumbeOfDestinations == 0) // end of game message and score displayed
                {

                    EndGame();
                    
                }
                
            }            
        }

        private void EndGame() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Game Over");
            sb.AppendLine($"Total Moves: {txtNumberOfMoves.Text}");
            sb.AppendLine($"Total Pushes:{txtNumberOfPushes.Text}");

            string exitMessage = sb.ToString();

            DialogResult dr = MessageBox.Show(
                exitMessage, "Sokoban", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            if (dr == DialogResult.OK)
            {

                playFormPanel.Controls.Clear();
                txtNumberOfMoves.Clear();
                txtNumberOfPushes.Clear();

                txtNumberOfMoves.Text = "0";
                txtNumberOfPushes.Text = "0";

                pushCounter = 0;
                moveCounter = 0;

               
            }

        }
       



    }
}
