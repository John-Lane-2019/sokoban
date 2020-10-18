namespace JLaneAssignment1
{
    partial class DesignForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripSaveLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelOfPictureBoxes = new System.Windows.Forms.Panel();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnHero = new System.Windows.Forms.Button();
            this.btnWall = new System.Windows.Forms.Button();
            this.btnBox = new System.Windows.Forms.Button();
            this.btnDestination = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(244, 36);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(243, 32);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSaveLevel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1653, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripSaveLevel
            // 
            this.toolStripSaveLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripSaveLevel.Name = "toolStripSaveLevel";
            this.toolStripSaveLevel.Size = new System.Drawing.Size(54, 29);
            this.toolStripSaveLevel.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 34);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveLevel);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rows:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Columns:";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(131, 50);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(152, 26);
            this.txtRows.TabIndex = 4;
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(461, 50);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(152, 26);
            this.txtColumns.TabIndex = 5;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(683, 50);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(122, 29);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Toolbox";
            // 
            // panelOfPictureBoxes
            // 
            this.panelOfPictureBoxes.AutoSize = true;
            this.panelOfPictureBoxes.Location = new System.Drawing.Point(344, 174);
            this.panelOfPictureBoxes.Name = "panelOfPictureBoxes";
            this.panelOfPictureBoxes.Size = new System.Drawing.Size(54, 29);
            this.panelOfPictureBoxes.TabIndex = 7;
            // 
            // btnNone
            // 
            this.btnNone.Image = global::JLaneAssignment1.Properties.Resources.Ground_Concrete;
            this.btnNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNone.Location = new System.Drawing.Point(64, 174);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(197, 92);
            this.btnNone.TabIndex = 0;
            this.btnNone.Text = "None";
            this.btnNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.ToolButtonClick);
            // 
            // btnHero
            // 
            this.btnHero.Image = global::JLaneAssignment1.Properties.Resources.Character5;
            this.btnHero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHero.Location = new System.Drawing.Point(64, 272);
            this.btnHero.Name = "btnHero";
            this.btnHero.Size = new System.Drawing.Size(197, 92);
            this.btnHero.TabIndex = 8;
            this.btnHero.Text = "Hero";
            this.btnHero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHero.UseVisualStyleBackColor = true;
            this.btnHero.Click += new System.EventHandler(this.ToolButtonClick);
            // 
            // btnWall
            // 
            this.btnWall.Image = global::JLaneAssignment1.Properties.Resources.Wall_Brown;
            this.btnWall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWall.Location = new System.Drawing.Point(64, 370);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(197, 92);
            this.btnWall.TabIndex = 9;
            this.btnWall.Text = "Wall";
            this.btnWall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWall.UseVisualStyleBackColor = true;
            this.btnWall.Click += new System.EventHandler(this.ToolButtonClick);
            // 
            // btnBox
            // 
            this.btnBox.Image = global::JLaneAssignment1.Properties.Resources.Crate_Red;
            this.btnBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBox.Location = new System.Drawing.Point(64, 468);
            this.btnBox.Name = "btnBox";
            this.btnBox.Size = new System.Drawing.Size(197, 92);
            this.btnBox.TabIndex = 10;
            this.btnBox.Text = "Box";
            this.btnBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBox.UseVisualStyleBackColor = true;
            this.btnBox.Click += new System.EventHandler(this.ToolButtonClick);
            // 
            // btnDestination
            // 
            this.btnDestination.Image = global::JLaneAssignment1.Properties.Resources.EndPoint_Yellow;
            this.btnDestination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDestination.Location = new System.Drawing.Point(64, 566);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(197, 92);
            this.btnDestination.TabIndex = 11;
            this.btnDestination.Text = "Destination";
            this.btnDestination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.ToolButtonClick);
            // 
            // DesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1653, 682);
            this.Controls.Add(this.btnDestination);
            this.Controls.Add(this.btnBox);
            this.Controls.Add(this.btnWall);
            this.Controls.Add(this.btnHero);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.panelOfPictureBoxes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtColumns);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DesignForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Design Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DesignForm_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveLevel;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelOfPictureBoxes;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnHero;
        private System.Windows.Forms.Button btnWall;
        private System.Windows.Forms.Button btnBox;
        private System.Windows.Forms.Button btnDestination;
    }
}