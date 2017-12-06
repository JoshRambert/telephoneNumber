using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telephoneNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // the isvalid mehtod accepts a string and returns true
        // if it contains 10 digits or false otherwise 
        private bool IsValid(string str)
        {
            const int VALID_LENGTH = 10;      //length of a valid string 
            bool valid = true;                //flag to indicate validity 

            //check the strings length 
            if (str.Length == VALID_LENGTH)
            {
                //check each character in the string 
                foreach(char ch in str)
                {
                    if(!char.IsDigit(ch))
                    {
                        valid = false;
                    }
                }
            }
            else
            {
                //incorrect length 
                valid = false;
            }
            //return the boolean value 
            return valid;
        }

        //the telephone format accepts a string by reference  
        //and formats it as a telephone number 
        private void TelephoneFormat(ref string str)
        {
            //first, insert the left parenthesis at position 0
            str = str.Insert(0, "(");

            //next inser the right arenthesis at position 4
            str = str.Insert(4, ")");

            //next insert eh hyphen at position 8
            str = str.Insert(8, "-");
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            //get a trimmed copy of th eusers input 
            string input = numberTextBox.Text.Trim();

            //if the input is a valid number then format it 
            //and display it 
            if (IsValid(input))
            {
                TelephoneFormat(ref input);
                MessageBox.Show(input);
            }
            else
                //display an error message
                MessageBox.Show("Invalid input");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close the form 
            this.Close();
        }
    }
}
