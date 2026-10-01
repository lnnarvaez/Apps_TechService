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
            mskNationalId = new MaskedTextBox();
            label3 = new Label();
            txtName = new TextBox();
            label4 = new Label();
            txtLastname = new TextBox();
            label5 = new Label();
            mskPhone = new MaskedTextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            panel2 = new Panel();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            label7 = new Label();
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
            panel1.Size = new Size(909, 60);
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
            // mskNationalId
            // 
            mskNationalId.Font = new Font("Segoe UI Variable Display", 11F);
            mskNationalId.Location = new Point(147, 48);
            mskNationalId.Margin = new Padding(3, 3, 3, 24);
            mskNationalId.Name = "mskNationalId";
            mskNationalId.Size = new Size(541, 37);
            mskNationalId.TabIndex = 2;
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
            // txtName
            // 
            txtName.Font = new Font("Segoe UI Variable Display", 11F);
            txtName.Location = new Point(147, 112);
            txtName.Margin = new Padding(3, 3, 3, 24);
            txtName.Name = "txtName";
            txtName.Size = new Size(541, 37);
            txtName.TabIndex = 4;
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
            // txtLastname
            // 
            txtLastname.Font = new Font("Segoe UI Variable Display", 11F);
            txtLastname.Location = new Point(147, 176);
            txtLastname.Margin = new Padding(3, 3, 3, 24);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(541, 37);
            txtLastname.TabIndex = 6;
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
            // mskPhone
            // 
            mskPhone.Font = new Font("Segoe UI Variable Display", 11F);
            mskPhone.Location = new Point(147, 240);
            mskPhone.Margin = new Padding(3, 3, 3, 24);
            mskPhone.Name = "mskPhone";
            mskPhone.Size = new Size(541, 37);
            mskPhone.TabIndex = 8;
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
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI Variable Display", 11F);
            txtEmail.Location = new Point(147, 304);
            txtEmail.Margin = new Padding(3, 3, 3, 24);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(541, 37);
            txtEmail.TabIndex = 10;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(147, 368);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Dirección";
            txtAddress.Size = new Size(541, 133);
            txtAddress.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(mskNationalId);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtName);
            panel2.Controls.Add(mskPhone);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtLastname);
            panel2.Location = new Point(61, 196);
            panel2.Name = "panel2";
            panel2.Size = new Size(792, 562);
            panel2.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Variable Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.WhiteSmoke;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(465, 95);
            btnSave.Margin = new Padding(3, 32, 3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(174, 56);
            btnSave.TabIndex = 13;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.Gainsboro;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Variable Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = Color.Black;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.Location = new Point(679, 95);
            btnCancel.Margin = new Padding(24, 32, 3, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(174, 56);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(47, 371);
            label7.Name = "label7";
            label7.Size = new Size(94, 28);
            label7.TabIndex = 12;
            label7.Text = "Dirección";
            // 
            // NewCustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(909, 836);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
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
        private MaskedTextBox mskNationalId;
        private Label label3;
        private TextBox txtName;
        private Label label4;
        private TextBox txtLastname;
        private Label label5;
        private MaskedTextBox mskPhone;
        private Label label6;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnCancel;
        private Label label7;
    }
}