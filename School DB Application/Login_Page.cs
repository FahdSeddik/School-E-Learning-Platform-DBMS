using School_DB_Application.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//SCHOOL DB APPLICATION NAMESPACE
namespace School_DB_Application
{
    public partial class Login_Page : UserControl //Login Page UserControl
    {   
        //PRIVATE DAT MEMBERS
        private Button SelectedBtn; //Last selected Button

        public Login_Page() //Default constructor
        {
            InitializeComponent();  //Initializing Component
            Create_New_Profile_panel.Hide(); //Initially Hiding Create new profile panel
            Login_Panel.Hide(); //Initially Hiding Login panel
        }

        //METHODS

        //Expand Button size with respect to its center
        //Mainly used after hovering over button to expand button
        private void ExpandButton()
        {
            SelectedBtn.Width += 2; // increasing button width by 2 pixels
            SelectedBtn.Height += 2; // increasing button height by 2 pixels
            int xCoord = SelectedBtn.Location.X - 1; //moving the top left corner left by half the increase in width to adjust center
            int yCoord = SelectedBtn.Location.Y - 1; //moving the top left corner up by half the increase in Height to adjust center
            SelectedBtn.Location = new Point(xCoord, yCoord); //Setting location to the new location to adjust center
            if (SelectedBtn.Size == SelectedBtn.MaximumSize) //If Button reached its maximum size stop the timer (stop increasing size)
            {
                Btn_Expand_Timer.Stop(); //stop button expand timer
            }
        }

        //Shrink Button size with respect to its center
        //Mainly used after leaving the button after hovering to shrink  button size back gradually using timer
        private void ShrinkButton()
        {
            SelectedBtn.Width -= 2; // Decreasing button width by 2 pixels
            SelectedBtn.Height -= 2; // Decreasing button height by 2 pixels
            int xCoord = SelectedBtn.Location.X + 1; //moving the top left corner right by half the deacrease in width to adjust center
            int yCoord = SelectedBtn.Location.Y + 1; //moving the top left corner down by half the increase in Height to adjust center
            SelectedBtn.Location = new Point(xCoord, yCoord);
            if (SelectedBtn.Size == SelectedBtn.MinimumSize) // If Button reached its minimum size stop the timer(stop decreasing size)
            {
                Btn_Shrink_Timer.Stop(); //stop button shrink timer
            }
        }

        //Reset Button Color and Size
        //mainly used after hovering over button to reset color and size
        private void ResetBtnDesign() 
        {
            SelectedBtn.BackColor = Color.FromArgb(24, 30, 54); // Reseting Button color to The original color
            Btn_Shrink_Timer.Start(); //Start Shrinking Timer (deacreasing size using timer to deacrease gradually)
        }

        //BUTTONS CLICK EVENT

        //Create new profile button click event
        private void Create_New_Profile_Btn_Click(object sender, EventArgs e)
        {
            Create_New_Profile_panel.Show(); //display ceate new profile panel to create account
            //create new profile using username, password, server token
            Create_New_Profile_panel.BringToFront(); //bring Creae new profile panel to front
        }

        //Create new profile button click
        private void Create_Btn_Click(object sender, EventArgs e)
        {
            //Testing
            //if valid and New username and correct password and correct server token
            //Display profile creation success message
            //if not valid username or not correct password or incorrect server token
            //display sutiable error message
            if (string.IsNullOrEmpty(Username_Txt.Text) || string.IsNullOrEmpty(ServerToken_Txt.Text) || string.IsNullOrEmpty(Password_Txt.Text))
            {
                MessageBox.Show("Please enter correct information"); //error message
                return;
            }
            else
            {
                //Testing
                //Create profile (adds new profile information to database) and displays sutiable messages
                MessageBox.Show("Profile is Created Successfully ");
                MessageBox.Show("Hello " + Username_Txt.Text + " :)");
                return;
            }

        }

        //Temporary function testing login panel
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login_Panel.Show(); //show login panel to login using password
            Login_Panel.BringToFront(); //bring login panel to front
        }

        //Login button click event
        private void Login_Btn_Click(object sender, EventArgs e)
        {
            //if entered correct password switch to login page
            //if not correct display error message
            //initally setting password to "Password" just for testing
            if (Login_Password_Txt.Text == "password")
            {
                var panelContainer = this.Parent as Panel; //accessing panel to access form
                var form1 = panelContainer.TopLevelControl as Form; //accessing form to view switch to homepage
                ((Panel)form1.Controls.Find("Home_Panel", true)[0]).Show(); //Switch to homepage
                ((Panel)form1.Controls.Find("Home_Op_View_Panel", true)[0]).Show();
                return; //return
            }
            else
            {
                MessageBox.Show("Please enter correct password"); //error message responding to incorrect password
                return; //return
            }
        }

        //create new profile X (EXIT) button click
        private void X_CreateNewProfile_Btn_Click(object sender, EventArgs e)
        {
            Create_New_Profile_panel.Hide(); //Exits Create new profile panel
        }

        //Login panel X (EXIT) button click
        private void Login_X_Btn_Click(object sender, EventArgs e)
        {
            Login_Panel.Hide(); //Exits Create new profile panel
        }



        //BUTTONS HOVE EVENT

        //General button mouse hover event
        private void Btn_MouseHover(object sender, EventArgs e)
        {
            SelectedBtn = (sender as Button); //gets the selected button (hovered over button)
            SelectedBtn.BackColor = Color.FromName("AppWorkspace"); //setting Backcolor to "AppWorkspace" color
            Btn_Expand_Timer.Start(); //start expanding button size using Button expand timer to increase size gradullay
        }

        // X (EXIT) button mouse hover event
        private void X_Btn_MouseHover(object sender, EventArgs e)
        {
            SelectedBtn = (sender as Button); //gets the selected button (the hovered over button)
            SelectedBtn.BackColor = Color.DarkRed; //convert button backcolor to dark red
        }

        //BUTTONS LEAVE EVENT

        //general button mouse leave event
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            SelectedBtn = (sender as Button); //gets the selected button (the leaved button)
            //to reset the color after hovering over the button
            ResetBtnDesign(); //calling reset button design to reset color after changed by mouse hovering
        }

        // X (EXIT) button mouse leave event
        //used  reset X button design after changing its design after hovering over it
        private void X_Btn_MouseLeave(object sender, EventArgs e)
        {
            SelectedBtn = (sender as Button); //gets the selected button (the left button)
            SelectedBtn.BackColor = Color.FromArgb(46, 51, 73); //reseting button backcolor to (Red:46, green:51, blue:73)
            //Original color
        }

        //KEYBOARD KEYDOWN EVENTS

        //Create Enter key
        private void Create_EnterKey(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) //if user entered enter key
            {
                Create_Btn_Click(sender, e); //execute create button click event
            }
        }

        //Login Enter key
        private void Login_EnterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //if user entered enter key
            {
                Login_Btn_Click(sender, e); //execute Login button click event
            }
        }

        //TIMER TICKS

        //button expand timer tick (General Timer tick)
        private void Btn_Expand_Timer_Tick(object sender, EventArgs e)
        {
            ExpandButton(); //expand button width by 2 pixels and height by 2 pixels and adjust center every timer tick
                            //increasing size gradullay every timer tick (5ms)
                            //mainly used on hovering
        }

        //button Shrink timer tick (General Timer tick)
        private void Btn_Shrink_Timer_Tick(object sender, EventArgs e)
        {
            ShrinkButton();//shrink button width by 2 pixels and height by 2 pixels and adjust center every timer tick
                           //decreasing size gradullay every timer tick (5ms)
                           //mainly used after expanding button on hovering
        }


    }//Login_Page USERCONTROL END
}
