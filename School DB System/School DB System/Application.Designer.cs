namespace School_DB_System
{
    partial class Application
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
            this.Main_Screen_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.Exit_Btn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.Secondary_Screen_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.SuspendLayout();
            // 
            // Main_Screen_Pnl
            // 
            this.Main_Screen_Pnl.AutoRoundedCorners = true;
            this.Main_Screen_Pnl.BorderRadius = 299;
            this.Main_Screen_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Screen_Pnl.Location = new System.Drawing.Point(0, 0);
            this.Main_Screen_Pnl.Name = "Main_Screen_Pnl";
            this.Main_Screen_Pnl.Size = new System.Drawing.Size(1000, 600);
            this.Main_Screen_Pnl.TabIndex = 0;
            // 
            // Exit_Btn
            // 
            this.Exit_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Exit_Btn.BorderColor = System.Drawing.Color.Transparent;
            this.Exit_Btn.BorderRadius = 10;
            this.Exit_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(142)))));
            this.Exit_Btn.HoverState.FillColor = System.Drawing.Color.Red;
            this.Exit_Btn.IconColor = System.Drawing.Color.White;
            this.Exit_Btn.Location = new System.Drawing.Point(956, 12);
            this.Exit_Btn.Name = "Exit_Btn";
            this.Exit_Btn.PressedColor = System.Drawing.Color.DarkRed;
            this.Exit_Btn.Size = new System.Drawing.Size(32, 27);
            this.Exit_Btn.TabIndex = 0;
            this.Exit_Btn.UseTransparentBackground = true;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 50;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // Secondary_Screen_Pnl
            // 
            this.Secondary_Screen_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Secondary_Screen_Pnl.Location = new System.Drawing.Point(0, 0);
            this.Secondary_Screen_Pnl.Name = "Secondary_Screen_Pnl";
            this.Secondary_Screen_Pnl.Size = new System.Drawing.Size(1000, 600);
            this.Secondary_Screen_Pnl.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.Exit_Btn);
            this.Controls.Add(this.Secondary_Screen_Pnl);
            this.Controls.Add(this.Main_Screen_Pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel Main_Screen_Pnl;
        private Guna.UI2.WinForms.Guna2ControlBox Exit_Btn;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel Secondary_Screen_Pnl;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}

