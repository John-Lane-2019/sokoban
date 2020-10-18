/*
 Assignment 2: Sokoban level designer

 Created by John Lane October 29 2019
 */

using System.Windows.Forms;

namespace JLaneAssignment1
{
   //this class is the blueprint for PanelPictureBox objects. it inherits from PicturePox
    public class Tile:PictureBox
    {
        

        public int TileType { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
       
    }
}
