namespace Apps_TechService
{
    partial class MainContainerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            BtnClosed = new FontAwesome.Sharp.IconButton();
            splitContainer1 = new SplitContainer();
            iconButton6 = new FontAwesome.Sharp.IconButton();
            mnuCustomers = new FontAwesome.Sharp.IconButton();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 254, 254);
            panel1.Controls.Add(BtnClosed);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1597, 120);
            panel1.TabIndex = 0;
            // 
            // BtnClosed
            // 
            BtnClosed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnClosed.Cursor = Cursors.Hand;
            BtnClosed.FlatAppearance.BorderSize = 0;
            BtnClosed.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 254, 254);
            BtnClosed.FlatStyle = FlatStyle.Flat;
            BtnClosed.IconChar = FontAwesome.Sharp.IconChar.ArrowRightToFile;
            BtnClosed.IconColor = Color.DimGray;
            BtnClosed.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClosed.Location = new Point(1493, 35);
            BtnClosed.Margin = new Padding(32, 8, 48, 3);
            BtnClosed.Name = "BtnClosed";
            BtnClosed.Padding = new Padding(8);
            BtnClosed.Size = new Size(56, 56);
            BtnClosed.TabIndex = 0;
            BtnClosed.UseVisualStyleBackColor = true;
            BtnClosed.Click += BtnClosed_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 120);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(17, 52, 87);
            splitContainer1.Panel1.Controls.Add(iconButton6);
            splitContainer1.Panel1.Controls.Add(mnuCustomers);
            splitContainer1.Panel1.Controls.Add(iconButton4);
            splitContainer1.Panel1.Controls.Add(iconButton3);
            splitContainer1.Panel1.Controls.Add(iconButton2);
            splitContainer1.Panel1.Controls.Add(iconButton1);
            splitContainer1.Panel1.Cursor = Cursors.Hand;
            splitContainer1.Panel1.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            splitContainer1.Panel1MinSize = 280;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(245, 248, 251);
            splitContainer1.Size = new Size(1597, 966);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 1;
            // 
            // iconButton6
            // 
            iconButton6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iconButton6.FlatAppearance.BorderSize = 0;
            iconButton6.FlatStyle = FlatStyle.Flat;
            iconButton6.Font = new Font("Segoe UI Variable Display", 11F);
            iconButton6.ForeColor = SystemColors.ButtonFace;
            iconButton6.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton6.IconColor = Color.Black;
            iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton6.Location = new Point(4, 342);
            iconButton6.Name = "iconButton6";
            iconButton6.Size = new Size(260, 56);
            iconButton6.TabIndex = 5;
            iconButton6.Text = "Informes";
            iconButton6.TextAlign = ContentAlignment.MiddleLeft;
            iconButton6.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton6.UseVisualStyleBackColor = true;
            // 
            // mnuCustomers
            // 
            mnuCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mnuCustomers.FlatAppearance.BorderSize = 0;
            mnuCustomers.FlatStyle = FlatStyle.Flat;
            mnuCustomers.Font = new Font("Segoe UI Variable Display", 11F);
            mnuCustomers.ForeColor = SystemColors.ButtonFace;
            mnuCustomers.IconChar = FontAwesome.Sharp.IconChar.None;
            mnuCustomers.IconColor = Color.Black;
            mnuCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            mnuCustomers.Location = new Point(4, 280);
            mnuCustomers.Name = "mnuCustomers";
            mnuCustomers.Size = new Size(260, 56);
            mnuCustomers.TabIndex = 4;
            mnuCustomers.Text = "Clientes";
            mnuCustomers.TextAlign = ContentAlignment.MiddleLeft;
            mnuCustomers.TextImageRelation = TextImageRelation.ImageBeforeText;
            mnuCustomers.UseVisualStyleBackColor = true;
            // 
            // iconButton4
            // 
            iconButton4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.Font = new Font("Segoe UI Variable Display", 11F);
            iconButton4.ForeColor = SystemColors.ButtonFace;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton4.IconColor = Color.Black;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.Location = new Point(4, 218);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(260, 56);
            iconButton4.TabIndex = 3;
            iconButton4.Text = "Mantenimientos";
            iconButton4.TextAlign = ContentAlignment.MiddleLeft;
            iconButton4.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton4.UseVisualStyleBackColor = true;
            // 
            // iconButton3
            // 
            iconButton3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI Variable Display", 11F);
            iconButton3.ForeColor = SystemColors.ButtonFace;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.Location = new Point(4, 156);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(260, 56);
            iconButton3.TabIndex = 2;
            iconButton3.Text = "Equipos";
            iconButton3.TextAlign = ContentAlignment.MiddleLeft;
            iconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton3.UseVisualStyleBackColor = true;
            // 
            // iconButton2
            // 
            iconButton2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI Variable Display", 11F);
            iconButton2.ForeColor = SystemColors.ButtonFace;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(4, 94);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(260, 56);
            iconButton2.TabIndex = 1;
            iconButton2.Text = "Servicios";
            iconButton2.TextAlign = ContentAlignment.MiddleLeft;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iconButton1.BackColor = SystemColors.HotTrack;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Segoe UI Variable Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            iconButton1.ForeColor = SystemColors.ButtonFace;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            iconButton1.IconColor = Color.WhiteSmoke;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(4, 32);
            iconButton1.Margin = new Padding(0, 32, 16, 3);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(260, 56);
            iconButton1.TabIndex = 0;
            iconButton1.Text = "Dashboard";
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // MainContainerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1597, 1086);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainContainerForm";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private SplitContainer splitContainer1;
        private FontAwesome.Sharp.IconButton BtnClosed;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton6;
        private FontAwesome.Sharp.IconButton mnuCustomers;
        private FontAwesome.Sharp.IconButton iconButton4;
    }
}
