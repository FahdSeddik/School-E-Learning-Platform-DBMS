using School_DB_Application.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//SCHOOL DB APPLICATION NAMESPACE
namespace School_DB_Application
{
    //HOME USERCONTROL
    public partial class Home : UserControl
    {
        //PRIVATE DATA MEMBERS
        private bool IsCollapsed = true; //boolean variable to check if dropdown menu buttons reachead its maximum
        private Button SelectedBtn; //Seleted or recent used button (clicked, hovered , left...etc)
        private Panel SelectedPanel; //Selected pane or recent used panel (dropdown menus (Add, Update, View, Remove))
       
        public Home()//Default constructor
        {
            InitializeComponent(); //initiallizing
        }

        //BUTTONS CLICK EVENT

        //Add button click event
        private void Add_Btn_Click(object sender, EventArgs e)
        {
            SelectedBtn = Add_Btn; //Gets selected button (clicked button - > add button) 
            SelectedPanel = Add_Dropdown_Panel; //Gets panel which contains selected button (add dropdown menu)
            Dropdown_Menu_Timer.Start(); //start dropdown menu timer to dropdown menu gradually
            //showing 10 pixels every timer tick (5ms)
        }

        //Update button click event
        private void Update_Btn_Click(object sender, EventArgs e)
        {
            SelectedBtn = Update_Btn;//Gets selected button (clicked button - > update button) 
            SelectedPanel = Update_Dropdown_Panel;//Gets panel which contains selected button (Update dropdown menu)
            Dropdown_Menu_Timer.Start();//start dropdown menu timer to dropdown menu gradually
            //showing 10 pixels every timer tick (5ms)
        }

        private void View_Btn_Click(object sender, EventArgs e)
        {
            SelectedBtn = View_Btn;//Gets selected button (clicked button - > view button) 
            SelectedPanel = View_Dropdown_Panel;//Gets panel which contains selected button (view dropdown menu)
            Dropdown_Menu_Timer.Start();//start dropdown menu timer to dropdown menu gradually
            //showing 10 pixels every timer tick (5ms)
        }

        private void Remove_Btn_Click(object sender, EventArgs e)
        {
            SelectedBtn = Remove_Btn;//Gets selected button (clicked button - > remove button) 
            SelectedPanel = Remove_Dropdown_Panel;//Gets panel which contains selected button (Remove dropdown menu)
            Dropdown_Menu_Timer.Start();//start dropdown menu timer to dropdown menu gradually
            //showing 10 pixels every timer tick (5ms)
        }

        //BUTTONS HOVER EVENT

        //General drobdown Menu button hover (used for all drobdown buttons)
        private void Menu_Btn_Hover(object sender, EventArgs e)
        {
            SelectedBtn = (sender as Button); // Gets selected button (hovered over button)
            SelectedBtn.BackColor = Color.FromName("AppWorkspace"); //changes selected button color to "AppWorkspace" color
        }

        //BUTTONS LEAVE EVENT

        //General drobdown Menu button leave event (used for all drobdown buttons)
        //used to reset back button design after changing its design by hovering over it
        private void Menu_Btn_Leave(object sender, EventArgs e)
        {
            SelectedBtn = (sender as Button); // Gets selected button (left button)
            SelectedBtn.BackColor = Color.FromArgb(24, 30, 54); //resets selected button color to (red:24, green:30, blue:54) color
        }

        //TIMER TICKS

        //General drobdown Menu timer tick (used for all drobdown buttons)
        private void Dropdown_Menu_Timer_Tick(object sender, EventArgs e)
        {
             if (IsCollapsed) //Is menu hidden ?, initially true (minimum size)
            {
                SelectedBtn.Image = Resources.Up_Arrow; //Change button icon to up arrow
                SelectedPanel.Height += 10; //Increase panel height by 10 pixels (reveal more 10 pixels)
                //every timer tick (5ms)
                if (SelectedPanel.Size == SelectedPanel.MaximumSize) // if panel reached its maximum size 
                {
                    Dropdown_Menu_Timer.Stop(); //Stop timer (stop increasing height)
                    IsCollapsed = false; //Set Iscollapsed to false to reverse operation next time
                }

            }
            else
            {
                SelectedBtn.Image = Resources.Down_Arrow; //Change button icon to down arrow
                SelectedPanel.Height -= 10; //Decrease panel height by 10 pixels (hides more 10 pixels)
                //every timer tick (5ms)
                if (SelectedPanel.Size == SelectedPanel.MinimumSize) // if panel reached its minimum size
                {
                    Dropdown_Menu_Timer.Stop(); //Stop timer (stop decreasing height)
                    IsCollapsed = true; //Set Iscollapsed to true to reverse operation next time
                }
            }
        }

    }//END HOME USERCONTROL
}
