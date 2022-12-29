using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Globalization;
using static System.ComponentModel.Design.ObjectSelectorEditor;

    //SCHOOL DATABASE SYSTEM NAMESPACE
    namespace School_DB_System
    {
        //ADD, UPDATE, DELETE STUDENT USERCONTROL BASE USERCONTROL
        //The used abbreviations in the format (abbreviation -> word) 
        //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
        //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

        //AUDSTUDENTPARENT USERCONTROL (BASE USERCONTROL FOR ADD STUDENT, UPDATE STUDENT, VIEW STUDENT)
        public partial class AUVStudentBase : AUVGeneralBase //inherits from usercontrol
        {
            //DATA MEMBERS
            ViewController viewController; //viewcontroller object
            Controller controllerObj; // controller object
            //non default constructor
            public AUVStudentBase(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
            {
                InitializeComponent(); //initializing component
                this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
                this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
                PrepareControls();
                StdSub_Pnl.BringToFront();

            }

            //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
            protected override void PrepareControls()
            {
                this.StdName_Txt.TextChanged += new System.EventHandler(this.StdName_Txt_TextChanged);
                this.StdPNum_Txt.TextChanged += new System.EventHandler(this.StdPNum_Txt_TextChanged);
                this.StdEmail_Txt.TextChanged += new System.EventHandler(this.StdEmail_Txt_TextChanged);
                this.StdSSN_Txt.TextChanged += new System.EventHandler(this.StdSSN_Txt_TextChanged);
                this.StdParName_Txt.TextChanged += new System.EventHandler(this.StdParName_Txt_TextChanged);
                this.StdParPNum_Txt.TextChanged += new System.EventHandler(this.StdParPNum_Txt_TextChanged);
                this.StdParSSN_Txt.TextChanged += new System.EventHandler(this.StdParSSN_Txt_TextChanged);
            this.StdName_Txt.Leave += new System.EventHandler(this.StdName_Txt_TextChanged);
            this.StdPNum_Txt.Leave += new System.EventHandler(this.StdPNum_Txt_TextChanged);
            this.StdEmail_Txt.Leave += new System.EventHandler(this.StdEmail_Txt_TextChanged);
            this.StdSSN_Txt.Leave += new System.EventHandler(this.StdSSN_Txt_TextChanged);
            this.StdParName_Txt.Leave += new System.EventHandler(this.StdParName_Txt_TextChanged);
            this.StdParPNum_Txt.Leave += new System.EventHandler(this.StdParPNum_Txt_TextChanged);
            this.StdParSSN_Txt.Leave += new System.EventHandler(this.StdParSSN_Txt_TextChanged);
        }



            //Graduate student view
            //depending on the active page type
            //in view and update it hides student year and textbox and shows graduated student university lbl and textbox
            //in addit hides graduated student university lbl and textbox and shows student year and textbox
            //because we are always adding a current student
            protected void graduatedStudentView()
            {
                //the default is current student view
                //in view and update it hides student year and textbox and shows graduated student university lbl and textbox
                StdYear_CBox.Visible = false;//hide student year comboo box
                StdYear_Lbl.Visible = false;//hide student year label
                StdUni_Txt.Visible = true;//shows student university text
                StdUni_Lbl.Visible = true;//shows student university label
                StdPayedTuition_CBox.Visible = false;//hide Payed tuition year comboobox
                                                  //by default properties student year label and comboobox are visible so hide them
                                                  //and unviersity label and textbox are not visible so show them
                return; //return;
            }



            //Student SSN Textbox text changed event
            //also used for Student SSN Textbox leave event
            protected virtual void StdSSN_Txt_TextChanged(object sender, EventArgs e)
            {
                //if name text contains length is out of range (from 14 to 20 digit) this is invalid
                if (StdSSN_Txt.TextLength < 9 || StdSSN_Txt.TextLength > 20 || StdSSN_Txt.Text.Any(char.IsLetter))
                {
                    showErrorMessage("invalid SSN, please inert a valid 9 - 20 numbers SSN"); //informing the user with a suitable message
                    StdSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                    return; //return
                }
                else //if valid data (no characters or ovalid SSN length)
                {
                    //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
                    hideErrorMessage(); //hide error message
                    StdSSN_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                    return; //return
                }
            }

            //Student phone number Textbox text changed event
            //also used for student phone number Textbox leave event
            protected virtual void StdPNum_Txt_TextChanged(object sender, EventArgs e)
            {
                //if number text length is not out of range (from 8 to 15 digit) this is invalid
                if (StdPNum_Txt.TextLength < 8 || StdPNum_Txt.TextLength > 15 || StdPNum_Txt.Text.Any(char.IsLetter))
                {
                    showErrorMessage("invalid phone number, please inert a valid 8 - 15 numbers"); //informing the user with a suitable message
                    StdPNum_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                    return; //return
                }
                else //if valid data (no characters or invalid mobile number length)
                {
                    //if valid data (no characters or invalid mobile number length) inform the user that the entered data is valid
                    hideErrorMessage(); //hide error message
                    StdPNum_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                    return; //return
                }
            }

            //Parent phone number Textbox text changed event
            //also used for student phone number Textbox leave event
            protected virtual void StdParPNum_Txt_TextChanged(object sender, EventArgs e)
            {
                //if number text length is not out of range (from 8 to 15 digit) this is invalid
                if (StdParPNum_Txt.TextLength < 8 || StdParPNum_Txt.TextLength > 15 || StdParPNum_Txt.Text.Any(char.IsLetter))
                {
                    showErrorMessage("invalid phone number, please inert a valid 8 - 15 numbers"); //informing the user with a suitable message
                    StdParPNum_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                    return; //return
                }
                else //if valid data (no characters or invalid mobile number length)
                {
                    //if valid data (no characters or invalid mobile number length) inform the user that the entered data is valid
                    hideErrorMessage(); //hide error message
                    StdParPNum_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                    return; //return
                }
            }


            //Parent SSN Textbox text changed event
            //also used for Parent SSN Textbox leave event
            protected virtual void StdParSSN_Txt_TextChanged(object sender, EventArgs e)
            {
            //if name text contains length is out of range (from 14 to 20 digit) this is invalid
            if (StdParSSN_Txt.TextLength < 9 || StdParSSN_Txt.TextLength > 20 || StdParSSN_Txt.Text.Any(char.IsLetter))
            {
                showErrorMessage("invalid SSN, please inert a valid 9 - 20 numbers SSN"); //informing the user with a suitable message
                StdParSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                StdParSSN_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
            }

            //Parent Name Textbox text changed event
            //also used for Parent Name Textbox leave event
            protected virtual void StdParName_Txt_TextChanged(object sender, EventArgs e)
            {
                if (StdParName_Txt.Text.Any(char.IsDigit)) //if name text contains digits (this is invalid)
                {
                    //informing the user with the Error
                    showErrorMessage("invalid name, names can't contain numbers, please inert a valid name");//informing the user with a suitable message
                    StdParName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                    return; //return
                }
                {
                    //if valid data (no digits) inform the user that the entered data is valid
                    hideErrorMessage(); //hide error message
                    StdParName_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                    return; //return
                }
            }

            //Student Name Textbox text changed event
            //also used for Student Name Textbox leave event
            protected virtual void StdName_Txt_TextChanged(object sender, EventArgs e)
            {
                if (StdName_Txt.Text.ToString() == "") //if name text is equal to "" i.e there is no data entered (empty textbox)
                {
                    //informing the user with the Error
                    showErrorMessage("invalid name, please inert a valid name"); //informing the user with a suitable message
                    StdName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                    return; //return
                }
                else if (StdName_Txt.Text.Any(char.IsDigit)) //if name text contains digits (this is invalid)
                {
                    showErrorMessage("invalid name, names can't contain numbers, please inert a valid name"); //informing the user with a suitable message
                    StdName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                    return; //return
                }
                else //if valid data (no digits) or empty textboxs
                {
                    //if valid data (no digits or empty textboxs) inform the user that the entered data is valid
                    hideErrorMessage(); //hide error message
                    StdName_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                    return; //return
                }
            }



            //Student Email Textbox text changed event
            //also used for Student Email Textbox leave event      
            protected virtual void StdEmail_Txt_TextChanged(object sender, EventArgs e)
            {
                //if empty textbox
                if (StdEmail_Txt.Text.ToString() == "")
                {
                    showErrorMessage("invalid email adress please enter a valid email adress"); //informing the user with a suitable message
                    StdEmail_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                    return; //return
                }
                else //if valid data
                {
                    //if valid data inform the user that the entered data is valid
                    hideErrorMessage(); //hide error message
                    StdEmail_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                    return; //return
                }
            }

            //University name Textbox text changed event
            //also used for university name Textbox leave event      
            protected virtual void University_Txt_TextChanged(object sender, EventArgs e)
            {
                //if empty textbox
                if (StdUni_Txt.Text.ToString() == "")
                {
                    showErrorMessage("invalid univesity name, please insert a valid name"); //informing the user with a suitable message
                    StdUni_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                    return; //return
                }
                else //if valid data
                {
                    //if valid data inform the user that the entered data is valid
                    hideErrorMessage(); //hide error message
                    StdUni_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                    return; //return
                }
            }
        }
    }
