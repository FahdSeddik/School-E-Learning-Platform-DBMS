namespace School_DB_Application
{
    partial class App_Base
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App_Base));
            this.App_X_Btn = new System.Windows.Forms.Button();
            this.Login_Panel = new System.Windows.Forms.Panel();
            this.Home_Panel = new System.Windows.Forms.Panel();
            this.Home_Op_View_Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // App_X_Btn
            // 
            this.App_X_Btn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.App_X_Btn.FlatAppearance.BorderSize = 0;
            this.App_X_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.App_X_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.App_X_Btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.App_X_Btn.Location = new System.Drawing.Point(973, 6);
            this.App_X_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.App_X_Btn.Name = "App_X_Btn";
            this.App_X_Btn.Size = new System.Drawing.Size(20, 20);
            this.App_X_Btn.TabIndex = 4;
            this.App_X_Btn.Text = "X";
            this.App_X_Btn.UseVisualStyleBackColor = false;
            this.App_X_Btn.Click += new System.EventHandler(this.App_X_Btn_Click);
            this.App_X_Btn.MouseLeave += new System.EventHandler(this.App_X_Btn_MouseLeave);
            this.App_X_Btn.MouseHover += new System.EventHandler(this.App_X_Btn_MouseHover);
            // 
            // Login_Panel
            // 
            this.Login_Panel.Location = new System.Drawing.Point(100, 100);
            this.Login_Panel.Name = "Login_Panel";
            this.Login_Panel.Size = new System.Drawing.Size(800, 400);
            this.Login_Panel.TabIndex = 5;
            // 
            // Home_Panel
            // 
            this.Home_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Home_Panel.Location = new System.Drawing.Point(0, 0);
            this.Home_Panel.Name = "Home_Panel";
            this.Home_Panel.Size = new System.Drawing.Size(1000, 600);
            this.Home_Panel.TabIndex = 6;
            // 
            // Home_Op_View_Panel
            // 
            this.Home_Op_View_Panel.BackColor = System.Drawing.SystemColors.Window;
            this.Home_Op_View_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Home_Op_View_Panel.Location = new System.Drawing.Point(226, 54);
            this.Home_Op_View_Panel.Name = "Home_Op_View_Panel";
            this.Home_Op_View_Panel.Size = new System.Drawing.Size(751, 528);
            this.Home_Op_View_Panel.TabIndex = 7;
            this.Home_Op_View_Panel.Visible = false;
            // 
            // App_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.Home_Op_View_Panel);
            this.Controls.Add(this.App_X_Btn);
            this.Controls.Add(this.Home_Panel);
            this.Controls.Add(this.Login_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "App_Base";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School DB System";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button App_X_Btn;
        private System.Windows.Forms.Panel Login_Panel;
        private System.Windows.Forms.Panel Home_Panel;
        private System.Windows.Forms.Panel Home_Op_View_Panel;
    }
}

