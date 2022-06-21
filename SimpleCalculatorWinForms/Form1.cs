using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculatorWinForms
{
    public partial class Calculator : Form
    {
        float num1, num2, result;
        char operation;
        bool dec = false;

        public Calculator()
        {
            InitializeComponent();

            lblTotal.Text = null;
        }

        private void changeLabel(int numPressed)
        {
            if (dec == true)
            {
                int decimalCount = 0;
                foreach (char c in lblPartial.Text)
                {
                    if (c == '.')
                    {
                        decimalCount++;
                    }
                }
                if (decimalCount < 1)
                {
                    lblPartial.Text = lblPartial.Text + ".";
                }
                dec = false;
            }
            else
            {
                if ((lblPartial.Text.Equals("0") == true && lblPartial.Text != null))
                {
                    lblPartial.Text = numPressed.ToString();
                }
                else if (lblPartial.Text.Equals("-0") == true)
                {
                    lblPartial.Text = "-" + numPressed.ToString();
                }
                else
                {
                    lblPartial.Text = lblPartial.Text + numPressed.ToString();
                }
            }
        }
        private void zeroButton_Click(object sender, EventArgs e)
        {
            changeLabel(0);
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            changeLabel(1);
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            changeLabel(2);
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            changeLabel(3);
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            changeLabel(4);
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            changeLabel(5);
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            changeLabel(6);
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            changeLabel(7);
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            changeLabel(8);
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            changeLabel(9);
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            dec = true;
            changeLabel(0);
        }

        private void plusMinusButton_Click(object sender, EventArgs e)
        {
            lblPartial.Text = "-" + lblPartial.Text;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            lblPartial.Text = "0";
            num1 = 0;
            num2 = 0;
            result = 0;
            operation = '\0';
            dec = false;
            lblTotal.Text = null;
            lblOperation.Text = null;
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(lblPartial.Text);
            operation = '*';
            lblPartial.Text = ""; 
            lblOperation.Text = "×";
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(lblPartial.Text);
            operation = '/';
            lblPartial.Text = "";
            lblOperation.Text = "÷";
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(lblPartial.Text);
            operation = '-';
            lblPartial.Text = "";
            lblOperation.Text = "−";
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            lblPartial.Text = lblPartial.Text + " " + operation;
            num1 = float.Parse(lblPartial.Text);
            operation = '+';
            result = result + num1;
            lblPartial.Text = "";
            lblOperation.Text = "+";
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            lblOperation.Text = null;
            result = 0;
            if (lblPartial.Text.Equals("0") == false)
            {
                switch (operation)
                {
                    case '+':
                        num2 = float.Parse(lblPartial.Text);
                        result = num1 + num2;
                        break;
                    case '-':
                        num2 = float.Parse(lblPartial.Text);
                        result = num1 - num2;
                        break;
                    case '/':
                        if(num2.Equals(0))
                        {
                            lblTotal.Text = "Error";
                        }
                        else
                        {
                            num2 = float.Parse(lblPartial.Text);
                            result = num1 / num2;
                        }
                        break;
                    case '*':
                        num2 = float.Parse(lblPartial.Text);
                        result = num1 * num2;
                        break;
                    default:
                        break;
                }
            }
            lblPartial.Text = null;
            lblTotal.Text = result.ToString();
            lblOperation.Text = null;
        }

        private void backSpaceButton_Click(object sender, EventArgs e)
        {
            int stringLength = lblPartial.Text.Length;
            if (stringLength > 1)
            {
                lblPartial.Text = lblPartial.Text.Substring(0, stringLength - 1);
            }
            else
            {
                lblPartial.Text = "0";
            }
            if(lblPartial.Text.Equals("0"))
            {
                lblTotal.Text = null;
                lblOperation.Text = null;
            }
        }
    }

}