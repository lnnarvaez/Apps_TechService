namespace Apps_TechService.UI
{
    partial class NewCustomerForm
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
            panel1 = new Panel();
            label1 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            maskedTextBox2 = new MaskedTextBox();
            label6 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            panel2 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(iconButton1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(711, 60);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(108, 17);
            label1.Name = "label1";
            label1.Size = new Size(205, 27);
            label1.TabIndex = 1;
            label1.Text = "Home | Nuevo Cliente";
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            iconButton1.IconColor = Color.DimGray;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(33, 1);
            iconButton1.Margin = new Padding(24, 3, 16, 3);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(4);
            iconButton1.Size = new Size(56, 56);
            iconButton1.TabIndex = 0;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 57);
            label2.Margin = new Padding(48, 0, 16, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 1;
            label2.Text = "Cédula";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Font = new Font("Segoe UI Variable Display", 11F);
            maskedTextBox1.Location = new Point(143, 48);
            maskedTextBox1.Margin = new Padding(3, 3, 3, 24);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(380, 37);
            maskedTextBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 112);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 3;
            label3.Text = "Nombre";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Variable Display", 11F);
            textBox1.Location = new Point(143, 112);
            textBox1.Margin = new Padding(3, 3, 3, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(380, 37);
            textBox1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 170);
            label4.Margin = new Padding(3, 0, 12, 0);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 5;
            label4.Text = "Apellidos";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI Variable Display", 11F);
            textBox2.Location = new Point(143, 176);
            textBox2.Margin = new Padding(3, 3, 3, 24);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(380, 37);
            textBox2.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 231);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 7;
            label5.Text = "Teléfono";
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Font = new Font("Segoe UI Variable Display", 11F);
            maskedTextBox2.Location = new Point(143, 240);
            maskedTextBox2.Margin = new Padding(3, 3, 3, 24);
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(380, 37);
            maskedTextBox2.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 289);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 9;
            label6.Text = "Correo";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI Variable Display", 11F);
            textBox3.Location = new Point(143, 304);
            textBox3.Margin = new Padding(3, 3, 3, 24);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(380, 37);
            textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(42, 368);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Dirección";
            textBox4.Size = new Size(481, 133);
            textBox4.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(maskedTextBox1);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(maskedTextBox2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(62, 166);
            panel2.Name = "panel2";
            panel2.Size = new Size(580, 562);
            panel2.TabIndex = 12;
            // 
            // iconButton2
            // 
            iconButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton2.BackColor = SystemColors.HotTrack;
            iconButton2.Cursor = Cursors.Hand;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI Variable Display", 10F);
            iconButton2.ForeColor = Color.WhiteSmoke;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(351, 88);
            iconButton2.Margin = new Padding(3, 32, 3, 3);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(132, 56);
            iconButton2.TabIndex = 13;
            iconButton2.Text = "Guardar";
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // iconButton3
            // 
            iconButton3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton3.BackColor = Color.Gainsboro;
            iconButton3.Cursor = Cursors.Hand;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI Variable Display", 10F);
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.Location = new Point(510, 88);
            iconButton3.Margin = new Padding(24, 32, 3, 3);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(132, 56);
            iconButton3.TabIndex = 14;
            iconButton3.Text = "Cancelar";
            iconButton3.UseVisualStyleBackColor = false;
            // 
            // NewCustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(711, 798);
            Controls.Add(iconButton3);
            Controls.Add(iconButton2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewCustomerForm";
            Text = "NewCustomerForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Label label2;
        private MaskedTextBox maskedTextBox1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private MaskedTextBox maskedTextBox2;
        private Label label6;
        private TextBox textBox3;
        private TextBox textBox4;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
    }
}