using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Architecture_and_Organization_midterm_project
{
    public partial class Number_System_Converter : Form
    {
        public Number_System_Converter()
        {
            InitializeComponent();
        }

        private void txtInput_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            gbOperation.Visible = true;

            if (rbtnDecimal.Checked == true)
            {
                cbDecimal.Visible = false;
                txtDecimal.Text = "Input is Decimal";

                cbBinary.Visible = true;
                txtBinary.Text = "";
                cbHexa.Visible = true;
                txtHexa.Text = "";
                cbOctal.Visible = true;
                txtOctal.Text = "";
            }

            if (rbtnBinary.Checked == true)
            {
                cbBinary.Visible = false;
                txtBinary.Text = "Input is Binary";

                cbDecimal.Visible = true;
                txtDecimal.Text = "";
                cbHexa.Visible = true;
                txtHexa.Text = "";
                cbOctal.Visible = true;
                txtOctal.Text = "";
            }

            if (rbtnHexa.Checked == true)
            {
                cbHexa.Visible = false;
                txtHexa.Text = "Input is Hexadecimal";

                cbDecimal.Visible = true;
                txtDecimal.Text = "";
                cbBinary.Visible = true;
                txtBinary.Text = "";
                cbOctal.Visible = true;
                txtOctal.Text = "";
            }

            if (rbtnOctal.Checked == true)
            {
                cbOctal.Visible = false;
                txtOctal.Text = "Input is Octal";

                cbDecimal.Visible = true;
                txtDecimal.Text = "";
                cbBinary.Visible = true;
                txtBinary.Text = "";
                cbHexa.Visible = true;
                txtHexa.Text = "";
            }

            if(rbtnBinary.Checked == true || rbtnHexa.Checked == true || rbtnOctal.Checked == true)
            {
                cbSigned.Visible = true;
            }
            else
            {
                cbSigned.Visible = false;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {

            string Input = txtInput.Text;

            //checks what type of data is the input
            //Decimal
            if (rbtnDecimal.Checked == true)
            {
                //Clears the textboxes
                txtBinary.Text = "";
                txtHexa.Text = "";
                txtOctal.Text = "";
                txtDecimalDup.Text = "";

                if(cbBinary.Checked == true)//Binary output
                {
                    string Input_Decimal_string = txtInput.Text;
                    string Output_Decimal = Input_Decimal_string;
                    double Input_Decimal_parsedToDouble = double.Parse(Input_Decimal_string);

                    //Input is negative
                    if (Input_Decimal_parsedToDouble <= 0)
                    {
                        //Convert to positive
                        Input_Decimal_parsedToDouble = Input_Decimal_parsedToDouble * -1;
                        //Convert to string
                        Input_Decimal_string = Convert.ToString(Input_Decimal_parsedToDouble);

                        //detect if the input is not whole number
                        if (Input_Decimal_string.Contains("."))
                        {
                            var whole_number_decimal = Input_Decimal_string.Split('.')[0];
                            Input_Decimal_string = Input_Decimal_string.Substring(Input_Decimal_string.IndexOf(".")); //This is the decimal value
                            int parsedToInt_whole_number_decimal = int.Parse(whole_number_decimal);
                            double parsedToDouble_decimal_point = double.Parse(Input_Decimal_string);

                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;
                            //Convert the whole number to binary
                            string Decimalwn = Convert.ToString(parsedToInt_whole_number_decimal, 2);

                            if (Input_Decimal_string.Length > 8)
                            {
                                for (int i = 0; i < Input_Decimal_string.Length - 1; i++)
                                {
                                    holder = parsedToDouble_decimal_point * 2;
                                    holderstring = Convert.ToString(holder);
                                    var dpd2 = holderstring.Split('.')[0];
                                    dpdfinal += dpd2;
                                    if (holder != 1 && holder != -1)
                                    {
                                        holderstring = holderstring.Substring(holderstring.IndexOf(".")); //This is the remaining decimal
                                        holder2 = double.Parse(holderstring);
                                        parsedToDouble_decimal_point = holder2; //Loops the value again
                                    }
                                    if (holder == 1 || holder == -1)
                                    {
                                        break;
                                    }
                                }

                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append(Decimalwn);
                                stringBuilder.Append(".");
                                stringBuilder.Append(dpdfinal);
                                string output = GFG.findTwoscomplement(stringBuilder);
                                //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                                txtBinary.Text = output;
                            }
                            if (Input_Decimal_string.Length <= 8)
                            {
                                for (int i = 0; i <= 8; i++)
                                {
                                    holder = parsedToDouble_decimal_point * 2;
                                    holderstring = Convert.ToString(holder);
                                    var dpd2 = holderstring.Split('.')[0];
                                    dpdfinal += dpd2;
                                    if (holder != 1 && holder != -1)
                                    {
                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        parsedToDouble_decimal_point = holder2;
                                    }
                                    if (holder == 1 || holder == -1)
                                    {
                                        break;
                                    }
                                }

                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append(Decimalwn);
                                stringBuilder.Append(".");
                                stringBuilder.Append(dpdfinal);
                                string output = GFG.findTwoscomplement(stringBuilder);
                                //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                                txtBinary.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal_string), 2);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(output);
                            output = GFG.findTwoscomplement(stringBuilder);
                            //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                            txtBinary.Text = output;
                        }
                    }

                    //Input is positive
                    else if (Input_Decimal_parsedToDouble > 0)
                    {
                        Console.WriteLine("Input is positive");
                        //detect if the input is not whole number
                        if (Input_Decimal_string.Contains("."))
                        {
                            var wnd = Input_Decimal_string.Split('.')[0];
                            Input_Decimal_string = Input_Decimal_string.Substring(Input_Decimal_string.IndexOf("."));
                            //Console.WriteLine("check input dec " + Input_Decimal_string);//check inp dec
                            //var dpd = Input_Decimal_string.Split('.')[1]; //"703125"
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal_string);
                            //Console.WriteLine("check parsedToDouble_decimal_point " + parsedToDouble_decimal_point);//checker
                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            if (Input_Decimal_string.Length > 8)
                            {
                                for (int i = 0; i < Input_Decimal_string.Length - 1; i++)
                                {
                                    holder = dpd1 * 2;
                                    //Console.WriteLine("checking holder " + holder);
                                    holderstring = Convert.ToString(holder);
                                    var dpd2 = holderstring.Split('.')[0];
                                    dpdfinal += dpd2;
                                    if (holder != 1 && holder != -1)
                                    {
                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        //Console.WriteLine("check holderstring " + holderstring);//check holderstring
                                        holder2 = double.Parse(holderstring);
                                        //Console.WriteLine("checking holder2 " + holder2);
                                        dpd1 = holder2;
                                    }
                                    if (holder == 1 || holder == -1)
                                    {
                                        break;
                                    }
                                }
                                //Console.WriteLine("The Binary form of " + Output_Decimal + " is " + Decimalwn + "." + dpdfinal);
                                string output = Decimalwn + "." + dpdfinal;
                                txtBinary.Text = output;
                            }
                            if (Input_Decimal_string.Length <= 8)
                            {
                                for (int i = 0; i <= 8; i++)
                                {
                                    holder = dpd1 * 2;
                                    //Console.WriteLine("checking holder " + holder);
                                    holderstring = Convert.ToString(holder);
                                    var dpd2 = holderstring.Split('.')[0];
                                    dpdfinal += dpd2;
                                    if (holder != 1 && holder != -1)
                                    {
                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        //Console.WriteLine("check holderstring " + holderstring);//check holderstring
                                        holder2 = double.Parse(holderstring);
                                        //Console.WriteLine("checking holder2 " + holder2);
                                        dpd1 = holder2;
                                    }
                                    if (holder == 1 || holder == -1)
                                    {
                                        break;
                                    }
                                }
                                //Console.WriteLine("The Binary form of " + Output_Decimal + " is " + Decimalwn + "." + dpdfinal);
                                string output = Decimalwn + "." + dpdfinal;
                                txtBinary.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal_string), 2);
                            txtBinary.Text = output;
                        }
                    }

                }

                if(cbOctal.Checked == true)
                {
                    string Input_Decimal = txtInput.Text;
                    string Output_Decimal = Input_Decimal, Octalwn;
                    double Input_DecimalD = double.Parse(Input_Decimal);


                    //Input is positive
                    if (Input_DecimalD > 0)
                    {

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check parsedToDouble_decimal_point " + parsedToDouble_decimal_point);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {
                                Octalwn = Convert.ToString(wnd1, 8);

                                if (Input_Decimal.Length > 9)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;



                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length <= 9)
                                {

                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holderstring.Contains("."))
                                        {
                                            if (holder == 1 || holder == -1)
                                            {
                                                dpofinal.Append("1");
                                                //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                                string output = Octalwn + "." + dpofinal.ToString();
                                                txtOctal.Text = output;
                                                break;
                                            }

                                            var dpd2 = holderstring.Split('.')[0];
                                            dpofinal.Append(dpd2);

                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }

                                        else
                                        {
                                            dpofinal.Append(holder.ToString());
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                            break;
                                        }


                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 0
                            else if (wnd1 == 0)
                            {
                                Octalwn = "0";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holderstring.Contains("."))
                                        {
                                            if (holder == 1 || holder == -1)
                                            {
                                                dpofinal.Append("1");
                                                //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                                string output = Octalwn + "." + dpofinal.ToString();
                                                txtOctal.Text = output;
                                                break;
                                            }

                                            var dpd2 = holderstring.Split('.')[0];
                                            dpofinal.Append(dpd2);

                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }

                                        else
                                        {
                                            dpofinal.Append(holder.ToString());
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                            break;
                                        }


                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else
                                {
                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holderstring.Contains("."))
                                        {
                                            if (holder == 1 || holder == -1)
                                            {
                                                dpofinal.Append("1");
                                                //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                                string output = Octalwn + "." + dpofinal.ToString();
                                                txtOctal.Text = output;
                                                break;
                                            }

                                            var dpd2 = holderstring.Split('.')[0];
                                            dpofinal.Append(dpd2);

                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }

                                        else
                                        {
                                            dpofinal.Append(holder.ToString());
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                            break;
                                        }


                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }

                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Octalwn = Convert.ToString(Output, 8);
                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn);
                            string output = Octalwn;
                            txtOctal.Text = output;
                        }
                    }

                    //Input is negative
                    else if (Input_DecimalD <= 0)
                    {
                        Input_DecimalD = Input_DecimalD * -1;
                        StringBuilder subtrahend = new StringBuilder();

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {

                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            wnd1 = wnd1 * -1;
                            double dpd1 = double.Parse(Input_Decimal);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {

                                Octalwn = Convert.ToString(wnd1, 8);

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {

                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = Input_Decimal.Length - 1;
                                        }


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();
                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));
                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length < 8)
                                {
                                    for (int a = 0; a <= 8; a++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            a = 8;
                                        }


                                        if (a == 8)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();

                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));

                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 1
                            else if (wnd1 == 0)
                            {
                                Octalwn = "0000";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = Input_Decimal.Length - 1;
                                        }


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();

                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));

                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else
                                {
                                    for (int b = 0; b <= 8; b++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            b = 8;
                                        }


                                        if (b == 8)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();

                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));
                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Output = Output * -1;
                            Octalwn = Convert.ToString(Output, 8);

                            for (int j = 0; j < Octalwn.Length; j++)
                            {
                                string holder4 = Convert.ToString(Octalwn[j]);
                                if (holder4 == ".")
                                {
                                    subtrahend.Append(holder4);
                                }
                                else
                                {
                                    holder4 = "7";
                                    subtrahend.Append(holder4);
                                }
                            }


                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(Octalwn));
                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                            StringBuilder _8C = new StringBuilder();
                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                            {
                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                if (k == OutputFinal2.Length - 1)
                                {
                                    holder5 = "1";
                                    _8C.Append(holder5);
                                    break;
                                }
                                if (holder5 == ".")
                                {
                                    _8C.Append(holder5);
                                }
                                else
                                {
                                    holder5 = "0";
                                    _8C.Append(holder5);
                                }
                            }

                            double _1add = Double.Parse(_8C.ToString());
                            double OutputFinal3 = OutputFinal1 + _1add;

                            //Console.WriteLine("8's complement is " + OutputFinal3);
                            string output = OutputFinal3.ToString();
                            txtOctal.Text = output;
                        }
                    }

                }

                if(cbHexa.Checked == true)
                {
                    string Input_Decimal = txtInput.Text;
                    string Output_Decimal = Input_Decimal, Hexawn;
                    double Input_DecimalD = double.Parse(Input_Decimal);


                    //Input is positive
                    if (Input_DecimalD > 0)
                    {

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check parsedToDouble_decimal_point " + parsedToDouble_decimal_point);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {
                                Hexawn = Convert.ToString(wnd1, 16);
                                Hexawn = Hexawn.ToUpper();

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = Input_Decimal.Length- 1;
                                        }



                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length <= 9)
                                {

                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = 8;
                                        }



                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 1
                            else if (wnd1 == 0)
                            {
                                Hexawn = "0";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }
                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = Input_Decimal.Length - 1;
                                        }



                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length <= 9)
                                {

                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = 8;
                                        }



                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Hexawn = Convert.ToString(Output, 16);
                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn);
                            string output = Hexawn;
                            txtHexa.Text = output;
                        }
                    }

                    //Input is negative
                    else if (Input_DecimalD <= 0)
                    {
                        Input_DecimalD = Input_DecimalD * -1;
                        StringBuilder subtrahend = new StringBuilder();

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {

                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            wnd1 = wnd1 * -1;
                            double dpd1 = double.Parse(Input_Decimal);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {

                                Hexawn = Convert.ToString(wnd1, 16);
                                Hexawn = Hexawn.ToUpper();

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = Input_Decimal.Length - 1;
                                        }


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length < 8)
                                {
                                    for (int i = 0; i <= 8; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = 8;
                                        }


                                        if (i == 8)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 1
                            else if (wnd1 == 0)
                            {
                                Hexawn = "0000";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = Input_Decimal.Length - 1;
                                        }


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else
                                {
                                    for (int i = 0; i <= 8; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = 8;
                                        }


                                        if (i == 8)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Output = Output * -1;
                            Hexawn = Convert.ToString(Output, 16);
                            Hexawn = Hexawn.ToUpper();
                            for (int j = 0; j < Hexawn.Length; j++)
                            {
                                string holder4 = Convert.ToString(Hexawn[j]);
                                if (holder4 == "A")
                                {
                                    subtrahend.Append("5");
                                }
                                if (holder4 == "B")
                                {
                                    subtrahend.Append("4");
                                }
                                if (holder4 == "C")
                                {
                                    subtrahend.Append("3");
                                }
                                if (holder4 == "D")
                                {
                                    subtrahend.Append("2");
                                }
                                if (holder4 == "E")
                                {
                                    subtrahend.Append("1");
                                }
                                if (holder4 == "F")
                                {
                                    subtrahend.Append("0");
                                }
                                else
                                {
                                    if (holder4 == "0")
                                    {
                                        subtrahend.Append("F");
                                    }
                                    if (holder4 == "1")
                                    {
                                        subtrahend.Append("E");
                                    }
                                    if (holder4 == "2")
                                    {
                                        subtrahend.Append("D");
                                    }
                                    if (holder4 == "3")
                                    {
                                        subtrahend.Append("C");
                                    }
                                    if (holder4 == "4")
                                    {
                                        subtrahend.Append("B");
                                    }
                                    if (holder4 == "5")
                                    {
                                        subtrahend.Append("A");
                                    }
                                    if (holder4 == "6")
                                    {
                                        subtrahend.Append("9");
                                    }
                                    if (holder4 == "7")
                                    {
                                        subtrahend.Append("8");
                                    }
                                    if (holder4 == "8")
                                    {
                                        subtrahend.Append("7");
                                    }
                                    if (holder4 == "9")
                                    {
                                        subtrahend.Append("6");
                                    }
                                }
                            }

                            //Console.WriteLine("15's complement of " + Output_Decimal + " is " + subtrahend);

                            StringBuilder _16C = new StringBuilder();


                            for (int w = 0; w < subtrahend.Length; w++)
                            {
                                string holder5 = Convert.ToString(subtrahend[w]);
                                if (w == subtrahend.Length - 1)
                                {
                                    if (holder5 == "1")
                                    {
                                        _16C.Append("2");
                                    }
                                    if (holder5 == "2")
                                    {
                                        _16C.Append("3");
                                    }
                                    if (holder5 == "3")
                                    {
                                        _16C.Append("4");
                                    }
                                    if (holder5 == "4")
                                    {
                                        _16C.Append("5");
                                    }
                                    if (holder5 == "5")
                                    {
                                        _16C.Append("6");
                                    }
                                    if (holder5 == "6")
                                    {
                                        _16C.Append("7");
                                    }
                                    if (holder5 == "7")
                                    {
                                        _16C.Append("8");
                                    }
                                    if (holder5 == "8")
                                    {
                                        _16C.Append("9");
                                    }
                                    if (holder5 == "9")
                                    {
                                        _16C.Append("A");
                                    }
                                    if (holder5 == "A")
                                    {
                                        _16C.Append("B");
                                    }
                                    if (holder5 == "B")
                                    {
                                        _16C.Append("C");
                                    }
                                    if (holder5 == "C")
                                    {
                                        _16C.Append("D");
                                    }
                                    if (holder5 == "D")
                                    {
                                        _16C.Append("E");
                                    }
                                    if (holder5 == "E")
                                    {
                                        _16C.Append("F");
                                    }
                                }
                                else
                                {
                                    _16C.Append(holder5);
                                }
                            }

                            //Console.WriteLine("16's complement is " + _16C.ToString());
                            string output = _16C.ToString();
                            txtHexa.Text = output;
                        }
                    }
                }


            }

            //Binary
            if (rbtnBinary.Checked == true)
            {
                //Clears the textboxes
                txtDecimal.Text = "";
                txtHexa.Text = "";
                txtOctal.Text = "";
                txtDecimalDup.Text = "";

                if (cbSigned.Checked == false) //Input is positive
                {
                    string Input_Binary = txtInput.Text;
                    string Output_Binary = Input_Binary;
                    double Input_BinaryB = double.Parse(Input_Binary);

                    //Input is fraction
                    if (Input_Binary.Contains("."))
                    {
                        var wnb = Input_Binary.Split('.')[0];
                        Input_Binary = Input_Binary.Substring(Input_Binary.IndexOf("."));

                        //Convert wnb to decimal using variable wnb1
                        int wnb1 = Convert.ToInt32(wnb, 2);
                        double wnbfinal = Convert.ToDouble(wnb1);

                        //Convert the decimal values to double
                        double DecValD = double.Parse(Input_Binary);

                        string DecValfinal = "", holderstring, holder3;
                        double holder, holder2, InBinLast;


                        int n = Input_Binary.Length - 1;
                        holderstring = Convert.ToString(Input_Binary.Last());
                        InBinLast = double.Parse(holderstring);


                        for (int i = n; i > 0; i--)
                        {

                            holder = InBinLast / 2;

                            n = n - 1;
                            if (n > 0)
                            {
                                holder3 = Input_Binary[n].ToString();
                                Input_BinaryB = double.Parse(holder3);
                                holder2 = holder + Input_BinaryB;
                                InBinLast = holder2;

                                DecValfinal = holder.ToString();
                            }
                            else
                            {
                                double outputfinal = wnbfinal + holder;
                                //Console.WriteLine("The decimal form of " + Output_Binary + " is " + outputfinal);
                                txtDecimalDup.Text = outputfinal.ToString();
                                if (cbDecimal.Checked == true)
                                {
                                    txtDecimal.Text = outputfinal.ToString();
                                }
                            }
                        }

                    }

                    //Input is whole number
                    else
                    {
                        int wnb1 = Convert.ToInt32(Output_Binary, 2);

                        //Console.WriteLine("The decimal form of " + Output_Binary + " is " + wnb1);
                        txtDecimalDup.Text = wnb1.ToString();
                        if (cbDecimal.Checked == true)
                        {
                            txtDecimal.Text = wnb1.ToString();
                        }
                    }
                }


                //Input is negative
                else if (cbSigned.Checked == true) //Input is negative
                {
                    string Input_Binary = txtInput.Text;
                    string Output_Binary = Input_Binary;
                    double Input_BinaryB = double.Parse(Input_Binary);

                    //Input is fraction
                    if (Input_Binary.Contains("."))
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(Output_Binary);


                        string output1 = GFG.findTwoscomplement(stringBuilder);
                        Input_BinaryB = double.Parse(output1);

                        var wnb = output1.Split('.')[0];
                        output1 = output1.Substring(output1.IndexOf("."));

                        //Convert wnb to decimal using variable wnb1
                        int wnb1 = Convert.ToInt32(wnb, 2);
                        double wnbfinal = Convert.ToDouble(wnb1);

                        //Convert the decimal values to double
                        double DecValD = double.Parse(output1);

                        string DecValfinal = "", holderstring, holder3;
                        double holder, holder2, InBinLast;


                        int n = output1.Length - 1;
                        holderstring = Convert.ToString(output1.Last());
                        InBinLast = double.Parse(holderstring);

                        for (int i = n; i > 0; i--)
                        {

                            holder = InBinLast / 2;

                            n = n - 1;
                            if (n > 0)
                            {
                                holder3 = output1[n].ToString();
                                Input_BinaryB = double.Parse(holder3);
                                holder2 = holder + Input_BinaryB;
                                InBinLast = holder2;

                                DecValfinal = holder.ToString();
                            }
                            else
                            {
                                double outputfinal = wnbfinal + holder;
                                outputfinal = outputfinal * -1;
                                //Console.WriteLine("The decimal form of " + Output_Binary + " is -" + outputfinal);
                                txtDecimalDup.Text = outputfinal.ToString();
                                if (cbDecimal.Checked == true)
                                {
                                    txtDecimal.Text = outputfinal.ToString();
                                }
                            }
                        }
                    }

                    //Input is whole number
                    else
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(Output_Binary);

                        string output1 = GFG.findTwoscomplement(stringBuilder);
                        int output = Convert.ToInt32(output1, 2);
                        output = output * -1;
                        //Console.WriteLine("The binary in 2\'s complement form of " + Output_Binary + " is " + output);
                        txtDecimalDup.Text = output.ToString();
                        if (cbDecimal.Checked == true)
                        {
                            txtDecimal.Text = output.ToString();
                        }
                    }
                }
                

                if(cbOctal.Checked == true)
                {
                    string Input_Decimal = txtDecimalDup.Text;
                    string Output_Decimal = Input_Decimal, Octalwn;
                    double Input_DecimalD = double.Parse(Input_Decimal);


                    //Input is positive
                    if (Input_DecimalD > 0)
                    {

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check parsedToDouble_decimal_point " + parsedToDouble_decimal_point);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {
                                Octalwn = Convert.ToString(wnd1, 8);

                                if (Input_Decimal.Length > 9)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;



                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length <= 9)
                                {

                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holderstring.Contains("."))
                                        {
                                            if (holder == 1 || holder == -1)
                                            {
                                                dpofinal.Append("1");
                                                //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                                string output = Octalwn + "." + dpofinal.ToString();
                                                txtOctal.Text = output;
                                                break;
                                            }

                                            var dpd2 = holderstring.Split('.')[0];
                                            dpofinal.Append(dpd2);

                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }

                                        else
                                        {
                                            dpofinal.Append(holder.ToString());
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                            break;
                                        }


                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 0
                            else if (wnd1 == 0)
                            {
                                Octalwn = "0";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holderstring.Contains("."))
                                        {
                                            if (holder == 1 || holder == -1)
                                            {
                                                dpofinal.Append("1");
                                                //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                                string output = Octalwn + "." + dpofinal.ToString();
                                                txtOctal.Text = output;
                                                break;
                                            }

                                            var dpd2 = holderstring.Split('.')[0];
                                            dpofinal.Append(dpd2);

                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }

                                        else
                                        {
                                            dpofinal.Append(holder.ToString());
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                            break;
                                        }


                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else
                                {
                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holderstring.Contains("."))
                                        {
                                            if (holder == 1 || holder == -1)
                                            {
                                                dpofinal.Append("1");
                                                //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                                string output = Octalwn + "." + dpofinal.ToString();
                                                txtOctal.Text = output;
                                                break;
                                            }

                                            var dpd2 = holderstring.Split('.')[0];
                                            dpofinal.Append(dpd2);

                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }

                                        else
                                        {
                                            dpofinal.Append(holder.ToString());
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                            break;
                                        }


                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }

                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Octalwn = Convert.ToString(Output, 8);
                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn);
                            string output = Octalwn;
                            txtOctal.Text = output;
                        }
                    }

                    //Input is negative
                    else if (Input_DecimalD <= 0)
                    {
                        Input_DecimalD = Input_DecimalD * -1;
                        StringBuilder subtrahend = new StringBuilder();

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {

                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            wnd1 = wnd1 * -1;
                            double dpd1 = double.Parse(Input_Decimal);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {

                                Octalwn = Convert.ToString(wnd1, 8);

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {

                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();
                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));
                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length < 8)
                                {
                                    for (int a = 0; a <= 8; a++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            a = 8;
                                        }


                                        if (a == 8)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();

                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));

                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 1
                            else if (wnd1 == 0)
                            {
                                Octalwn = "0000";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();

                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));

                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else
                                {
                                    for (int b = 0; b <= 8; b++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            b = 8;
                                        }


                                        if (b == 8)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();

                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));
                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Output = Output * -1;
                            Octalwn = Convert.ToString(Output, 8);

                            for (int j = 0; j < Octalwn.Length; j++)
                            {
                                string holder4 = Convert.ToString(Octalwn[j]);
                                if (holder4 == ".")
                                {
                                    subtrahend.Append(holder4);
                                }
                                else
                                {
                                    holder4 = "7";
                                    subtrahend.Append(holder4);
                                }
                            }


                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(Octalwn));
                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                            StringBuilder _8C = new StringBuilder();
                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                            {
                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                if (k == OutputFinal2.Length - 1)
                                {
                                    holder5 = "1";
                                    _8C.Append(holder5);
                                    break;
                                }
                                if (holder5 == ".")
                                {
                                    _8C.Append(holder5);
                                }
                                else
                                {
                                    holder5 = "0";
                                    _8C.Append(holder5);
                                }
                            }

                            double _1add = Double.Parse(_8C.ToString());
                            double OutputFinal3 = OutputFinal1 + _1add;

                            //Console.WriteLine("8's complement is " + OutputFinal3);
                            string output = OutputFinal3.ToString();
                            txtOctal.Text = output;
                        }
                    }
                }

                if(cbHexa.Checked == true)
                {
                    string Input_Decimal = txtDecimalDup.Text;
                    string Output_Decimal = Input_Decimal, Hexawn;
                    double Input_DecimalD = double.Parse(Input_Decimal);


                    //Input is positive
                    if (Input_DecimalD > 0)
                    {

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check parsedToDouble_decimal_point " + parsedToDouble_decimal_point);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {
                                Hexawn = Convert.ToString(wnd1, 16);
                                Hexawn = Hexawn.ToUpper();

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;



                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length <= 9)
                                {

                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = 8;
                                        }



                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 1
                            else if (wnd1 == 0)
                            {
                                Hexawn = "0";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;



                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length <= 9)
                                {

                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = 8;
                                        }



                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Hexawn = Convert.ToString(Output, 16);
                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn);
                            string output = Hexawn;
                            txtHexa.Text = output;
                        }
                    }

                    //Input is negative
                    else if (Input_DecimalD <= 0)
                    {
                        Input_DecimalD = Input_DecimalD * -1;
                        StringBuilder subtrahend = new StringBuilder();

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {

                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            wnd1 = wnd1 * -1;
                            double dpd1 = double.Parse(Input_Decimal);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {

                                Hexawn = Convert.ToString(wnd1, 16);
                                Hexawn = Hexawn.ToUpper();

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length < 8)
                                {
                                    for (int i = 0; i <= 8; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = 8;
                                        }


                                        if (i == 8)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 1
                            else if (wnd1 == 0)
                            {
                                Hexawn = "0000";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else
                                {
                                    for (int i = 0; i <= 8; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            i = 8;
                                        }


                                        if (i == 8)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Output = Output * -1;
                            Hexawn = Convert.ToString(Output, 16);
                            Hexawn = Hexawn.ToUpper();
                            for (int j = 0; j < Hexawn.Length; j++)
                            {
                                string holder4 = Convert.ToString(Hexawn[j]);
                                if (holder4 == "A")
                                {
                                    subtrahend.Append("5");
                                }
                                if (holder4 == "B")
                                {
                                    subtrahend.Append("4");
                                }
                                if (holder4 == "C")
                                {
                                    subtrahend.Append("3");
                                }
                                if (holder4 == "D")
                                {
                                    subtrahend.Append("2");
                                }
                                if (holder4 == "E")
                                {
                                    subtrahend.Append("1");
                                }
                                if (holder4 == "F")
                                {
                                    subtrahend.Append("0");
                                }
                                else
                                {
                                    if (holder4 == "0")
                                    {
                                        subtrahend.Append("F");
                                    }
                                    if (holder4 == "1")
                                    {
                                        subtrahend.Append("E");
                                    }
                                    if (holder4 == "2")
                                    {
                                        subtrahend.Append("D");
                                    }
                                    if (holder4 == "3")
                                    {
                                        subtrahend.Append("C");
                                    }
                                    if (holder4 == "4")
                                    {
                                        subtrahend.Append("B");
                                    }
                                    if (holder4 == "5")
                                    {
                                        subtrahend.Append("A");
                                    }
                                    if (holder4 == "6")
                                    {
                                        subtrahend.Append("9");
                                    }
                                    if (holder4 == "7")
                                    {
                                        subtrahend.Append("8");
                                    }
                                    if (holder4 == "8")
                                    {
                                        subtrahend.Append("7");
                                    }
                                    if (holder4 == "9")
                                    {
                                        subtrahend.Append("6");
                                    }
                                }
                            }

                            //Console.WriteLine("15's complement of " + Output_Decimal + " is " + subtrahend);

                            StringBuilder _16C = new StringBuilder();


                            for (int w = 0; w < subtrahend.Length; w++)
                            {
                                string holder5 = Convert.ToString(subtrahend[w]);
                                if (w == subtrahend.Length - 1)
                                {
                                    if (holder5 == "1")
                                    {
                                        _16C.Append("2");
                                    }
                                    if (holder5 == "2")
                                    {
                                        _16C.Append("3");
                                    }
                                    if (holder5 == "3")
                                    {
                                        _16C.Append("4");
                                    }
                                    if (holder5 == "4")
                                    {
                                        _16C.Append("5");
                                    }
                                    if (holder5 == "5")
                                    {
                                        _16C.Append("6");
                                    }
                                    if (holder5 == "6")
                                    {
                                        _16C.Append("7");
                                    }
                                    if (holder5 == "7")
                                    {
                                        _16C.Append("8");
                                    }
                                    if (holder5 == "8")
                                    {
                                        _16C.Append("9");
                                    }
                                    if (holder5 == "9")
                                    {
                                        _16C.Append("A");
                                    }
                                    if (holder5 == "A")
                                    {
                                        _16C.Append("B");
                                    }
                                    if (holder5 == "B")
                                    {
                                        _16C.Append("C");
                                    }
                                    if (holder5 == "C")
                                    {
                                        _16C.Append("D");
                                    }
                                    if (holder5 == "D")
                                    {
                                        _16C.Append("E");
                                    }
                                    if (holder5 == "E")
                                    {
                                        _16C.Append("F");
                                    }
                                }
                                else
                                {
                                    _16C.Append(holder5);
                                }
                            }

                            //Console.WriteLine("16's complement is " + _16C.ToString());
                            string output = _16C.ToString();
                            txtHexa.Text = output;
                        }
                    }
                }
            }

            //Hexadecimal
            if (rbtnHexa.Checked == true)
            {
                //Clears the textboxes
                txtDecimal.Text = "";
                txtBinary.Text = "";
                txtOctal.Text = "";
                txtDecimalDup.Text = "";

                //Input is in 16's complement
                if(cbSigned.Checked == true)
                {
                    string Input_Decimal = txtInput.Text;
                    string Output_Decimal = Input_Decimal, holder4, holder5;

                    StringBuilder _15C = new StringBuilder();
                    StringBuilder pos = new StringBuilder();

                    for (int i = 0; i < Input_Decimal.Length; i++)
                    {
                        holder4 = Input_Decimal[i].ToString();

                        if (i == Input_Decimal.Length - 1)
                        {
                            if (holder4 == "A")
                            {
                                _15C.Append("9");
                            }
                            if (holder4 == "B")
                            {
                                _15C.Append("A");
                            }
                            if (holder4 == "C")
                            {
                                _15C.Append("B");
                            }
                            if (holder4 == "D")
                            {
                                _15C.Append("C");
                            }
                            if (holder4 == "E")
                            {
                                _15C.Append("D");
                            }
                            if (holder4 == "F")
                            {
                                _15C.Append("E");
                            }
                            else
                            {
                                if (holder4 == "1")
                                {
                                    _15C.Append("0");
                                }
                                if (holder4 == "2")
                                {
                                    _15C.Append("1");
                                }
                                if (holder4 == "3")
                                {
                                    _15C.Append("2");
                                }
                                if (holder4 == "4")
                                {
                                    _15C.Append("3");
                                }
                                if (holder4 == "5")
                                {
                                    _15C.Append("4");
                                }
                                if (holder4 == "6")
                                {
                                    _15C.Append("5");
                                }
                                if (holder4 == "7")
                                {
                                    _15C.Append("6");
                                }
                                if (holder4 == "8")
                                {
                                    _15C.Append("7");
                                }
                                if (holder4 == "9")
                                {
                                    _15C.Append("8");
                                }
                            }
                        }
                        else
                        {
                            _15C.Append(holder4);
                        }
                    }
                    for (int j = 0; j < _15C.Length; j++)
                    {
                        holder5 = _15C[j].ToString();

                        if (holder5 == "0")
                        {
                            pos.Append("F");
                        }
                        if (holder5 == "1")
                        {
                            pos.Append("E");
                        }
                        if (holder5 == "2")
                        {
                            pos.Append("D");
                        }
                        if (holder5 == "3")
                        {
                            pos.Append("C");
                        }
                        if (holder5 == "4")
                        {
                            pos.Append("B");
                        }
                        if (holder5 == "5")
                        {
                            pos.Append("A");
                        }
                        if (holder5 == "6")
                        {
                            pos.Append("9");
                        }
                        if (holder5 == "7")
                        {
                            pos.Append("8");
                        }
                        if (holder5 == "8")
                        {
                            pos.Append("7");
                        }
                        if (holder5 == "9")
                        {
                            pos.Append("6");
                        }
                        if (holder5 == "A")
                        {
                            pos.Append("5");
                        }
                        if (holder5 == "B")
                        {
                            pos.Append("4");
                        }
                        if (holder5 == "C")
                        {
                            pos.Append("3");
                        }
                        if (holder5 == "D")
                        {
                            pos.Append("2");
                        }
                        if (holder5 == "E")
                        {
                            pos.Append("1");
                        }
                        if (holder5 == "F")
                        {
                            pos.Append("0");
                        }
                        if (holder5 == ".")
                        {
                            pos.Append(holder5);
                        }
                    }

                    string Input1 = pos.ToString();
                    int base1 = 16;




                    double decimal1 = 0;
                    string wholeNum = Input1.Split('.')[0], decVal = Input1.Split('.')[1];
                    StringBuilder decPoint = new StringBuilder();

                    for (int i = 0; i < wholeNum.Length; i++)
                    {
                        int j = wholeNum.Length - 1 - i;
                        string digit = Convert.ToString(wholeNum[j]);

                        if (digit == "A" || digit == "a")
                        {
                            digit = "10";
                        }
                        if (digit == "B" || digit == "b")
                        {
                            digit = "11";
                        }
                        if (digit == "C" || digit == "c")
                        {
                            digit = "12";
                        }
                        if (digit == "D" || digit == "d")
                        {
                            digit = "13";
                        }
                        if (digit == "E" || digit == "e")
                        {
                            digit = "14";
                        }
                        if (digit == "F" || digit == "f")
                        {
                            digit = "15";
                        }

                        decimal1 += Convert.ToInt32(digit) * (Math.Pow(base1, i));
                    }

                    for (int i = 0; i < decVal.Length; i++)
                    {
                        string digit1 = Convert.ToString(decVal[i]);

                        if (digit1 == "A" || digit1 == "a")
                        {
                            digit1 = "10";
                        }
                        if (digit1 == "B" || digit1 == "b")
                        {
                            digit1 = "11";
                        }
                        if (digit1 == "C" || digit1 == "c")
                        {
                            digit1 = "12";
                        }
                        if (digit1 == "D" || digit1 == "d")
                        {
                            digit1 = "13";
                        }
                        if (digit1 == "E" || digit1 == "e")
                        {
                            digit1 = "14";
                        }
                        if (digit1 == "F" || digit1 == "f")
                        {
                            digit1 = "15";
                        }

                        decimal1 += Convert.ToInt32(digit1) * (Math.Pow(base1, (-1 * (i + 1))));
                    }



                    //Console.WriteLine("Output is " + decimal1);
                    decimal1 = decimal1 * -1;
                    txtDecimalDup.Text = decimal1.ToString();

                }

                //Input is positive
                else
                {
                    string Input1 = txtInput.Text;
                    int base1 = 16;




                    double decimal1 = 0;
                    string wholeNum = Input1.Split('.')[0], decVal = Input1.Split('.')[1];
                    StringBuilder decPoint = new StringBuilder();

                    for (int i = 0; i < wholeNum.Length; i++)
                    {
                        int j = wholeNum.Length - 1 - i;
                        string digit = Convert.ToString(wholeNum[j]);

                        if (digit == "A" || digit == "a")
                        {
                            digit = "10";
                        }
                        if (digit == "B" || digit == "b")
                        {
                            digit = "11";
                        }
                        if (digit == "C" || digit == "c")
                        {
                            digit = "12";
                        }
                        if (digit == "D" || digit == "d")
                        {
                            digit = "13";
                        }
                        if (digit == "E" || digit == "e")
                        {
                            digit = "14";
                        }
                        if (digit == "F" || digit == "f")
                        {
                            digit = "15";
                        }

                        decimal1 += Convert.ToInt32(digit) * (Math.Pow(base1, i));
                    }

                    for (int i = 0; i < decVal.Length; i++)
                    {
                        string digit1 = Convert.ToString(decVal[i]);

                        if (digit1 == "A" || digit1 == "a")
                        {
                            digit1 = "10";
                        }
                        if (digit1 == "B" || digit1 == "b")
                        {
                            digit1 = "11";
                        }
                        if (digit1 == "C" || digit1 == "c")
                        {
                            digit1 = "12";
                        }
                        if (digit1 == "D" || digit1 == "d")
                        {
                            digit1 = "13";
                        }
                        if (digit1 == "E" || digit1 == "e")
                        {
                            digit1 = "14";
                        }
                        if (digit1 == "F" || digit1 == "f")
                        {
                            digit1 = "15";
                        }

                        decimal1 += Convert.ToInt32(digit1) * (Math.Pow(base1, (-1 * (i + 1))));
                    }



                    //Console.WriteLine("Output is " + decimal1);
                    txtDecimalDup.Text = decimal1.ToString();

                }

                if(cbDecimal.Checked == true)
                {
                    txtDecimal.Text = txtDecimalDup.Text;
                }
                if(cbBinary.Checked == true)
                {
                    string Input_Decimal = txtDecimalDup.Text;
                    string Output_Decimal = Input_Decimal;
                    double Input_DecimalD = double.Parse(Input_Decimal);

                    //Input is negative
                    if (Input_DecimalD <= 0)
                    {
                        //Convert to positive
                        Input_DecimalD = Input_DecimalD * -1;
                        //Convert to string
                        Input_Decimal = Convert.ToString(Input_DecimalD);

                        //detect if the input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);

                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            for (int i = 0; i < Input_Decimal.Length - 1; i++)
                            {
                                holder = dpd1 * 2;
                                holderstring = Convert.ToString(holder);
                                var dpd2 = holderstring.Split('.')[0];
                                dpdfinal += dpd2;
                                if (holder != 1 && holder != -1)
                                {
                                    holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                    holder2 = double.Parse(holderstring);
                                    dpd1 = holder2;
                                }
                                if (holder == 1 || holder == -1)
                                {
                                    break;
                                }
                            }

                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(Decimalwn);
                            stringBuilder.Append(".");
                            stringBuilder.Append(dpdfinal);
                            string output = GFG.findTwoscomplement(stringBuilder);
                            //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                            txtBinary.Text = output;
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(output);
                            output = GFG.findTwoscomplement(stringBuilder);
                            //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                            txtBinary.Text = output;
                        }
                    }

                    //Input is positive
                    else if (Input_DecimalD > 0)
                    {
                        Console.WriteLine("Input is positive");
                        //detect if the input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));
                            //Console.WriteLine("check input dec " + Input_Decimal_string);//check inp dec
                            //var dpd = Input_Decimal_string.Split('.')[1]; //"703125"
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check parsedToDouble_decimal_point " + parsedToDouble_decimal_point);//checker
                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            for (int i = 0; i < Input_Decimal.Length - 1; i++)
                            {
                                holder = dpd1 * 2;
                                //Console.WriteLine("checking holder " + holder);
                                holderstring = Convert.ToString(holder);
                                var dpd2 = holderstring.Split('.')[0];
                                dpdfinal += dpd2;
                                if (holder != 1 && holder != -1)
                                {
                                    holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                    //Console.WriteLine("check holderstring " + holderstring);//check holderstring
                                    holder2 = double.Parse(holderstring);
                                    //Console.WriteLine("checking holder2 " + holder2);
                                    dpd1 = holder2;
                                }
                                if (holder == 1 || holder == -1)
                                {
                                    break;
                                }
                            }
                            //Console.WriteLine("The Binary form of " + Output_Decimal + " is " + Decimalwn + "." + dpdfinal);
                            string output = Decimalwn + "." + dpdfinal;
                            txtBinary.Text = output;
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            txtBinary.Text = output;
                        }
                    }
                }
                if(cbOctal.Checked == true)
                {
                    string Input_Decimal = txtDecimalDup.Text;
                    string Output_Decimal = Input_Decimal, Octalwn;
                    double Input_DecimalD = double.Parse(Input_Decimal);


                    //Input is positive
                    if (Input_DecimalD > 0)
                    {

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check parsedToDouble_decimal_point " + parsedToDouble_decimal_point);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {
                                Octalwn = Convert.ToString(wnd1, 8);

                                if (Input_Decimal.Length > 9)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;



                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length <= 9)
                                {

                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holderstring.Contains("."))
                                        {
                                            if (holder == 1 || holder == -1)
                                            {
                                                dpofinal.Append("1");
                                                //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                                string output = Octalwn + "." + dpofinal.ToString();
                                                txtOctal.Text = output;
                                                break;
                                            }

                                            var dpd2 = holderstring.Split('.')[0];
                                            dpofinal.Append(dpd2);

                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }

                                        else
                                        {
                                            dpofinal.Append(holder.ToString());
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                            break;
                                        }


                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 0
                            else if (wnd1 == 0)
                            {
                                Octalwn = "0";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holderstring.Contains("."))
                                        {
                                            if (holder == 1 || holder == -1)
                                            {
                                                dpofinal.Append("1");
                                                //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                                string output = Octalwn + "." + dpofinal.ToString();
                                                txtOctal.Text = output;
                                                break;
                                            }

                                            var dpd2 = holderstring.Split('.')[0];
                                            dpofinal.Append(dpd2);

                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }

                                        else
                                        {
                                            dpofinal.Append(holder.ToString());
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                            break;
                                        }


                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else
                                {
                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);

                                        if (holderstring.Contains("."))
                                        {
                                            if (holder == 1 || holder == -1)
                                            {
                                                dpofinal.Append("1");
                                                //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                                string output = Octalwn + "." + dpofinal.ToString();
                                                txtOctal.Text = output;
                                                break;
                                            }

                                            var dpd2 = holderstring.Split('.')[0];
                                            dpofinal.Append(dpd2);

                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }

                                        else
                                        {
                                            dpofinal.Append(holder.ToString());
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                            break;
                                        }


                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn + "." + dpofinal);//checking dpofinal
                                            string output = Octalwn + "." + dpofinal.ToString();
                                            txtOctal.Text = output;
                                        }

                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Octalwn = Convert.ToString(Output, 8);
                            //Console.WriteLine("The Octal form of " + Output_Decimal + " is " + Octalwn);
                            string output = Octalwn;
                            txtOctal.Text = output;
                        }
                    }

                    //Input is negative
                    else if (Input_DecimalD <= 0)
                    {
                        Input_DecimalD = Input_DecimalD * -1;
                        StringBuilder subtrahend = new StringBuilder();

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {

                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            wnd1 = wnd1 * -1;
                            double dpd1 = double.Parse(Input_Decimal);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {

                                Octalwn = Convert.ToString(wnd1, 8);

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {

                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();
                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));
                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length < 8)
                                {
                                    for (int a = 0; a <= 8; a++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            a = 8;
                                        }


                                        if (a == 8)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();

                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));

                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 1
                            else if (wnd1 == 0)
                            {
                                Octalwn = "0000";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();

                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));

                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }

                                else
                                {
                                    for (int b = 0; b <= 8; b++)
                                    {
                                        holder = dpd1 * 8;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        dpofinal.Append(dpd2);

                                        if (holderstring.Contains("."))
                                        {
                                            holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                            holder2 = double.Parse(holderstring);
                                            dpd1 = holder2;
                                        }
                                        else
                                        {
                                            b = 8;
                                        }


                                        if (b == 8)
                                        {
                                            string FinalOutput = Octalwn + "." + dpofinal.ToString();

                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);
                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                else
                                                {
                                                    holder4 = "7";
                                                    subtrahend.Append(holder4);
                                                }
                                            }


                                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(FinalOutput));
                                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                                            StringBuilder _8C = new StringBuilder();
                                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                                            {
                                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                                if (k == OutputFinal2.Length - 1)
                                                {
                                                    holder5 = "1";
                                                    _8C.Append(holder5);
                                                    break;
                                                }
                                                if (holder5 == ".")
                                                {
                                                    _8C.Append(holder5);
                                                }
                                                else
                                                {
                                                    holder5 = "0";
                                                    _8C.Append(holder5);
                                                }
                                            }

                                            double _1add = Double.Parse(_8C.ToString());
                                            double OutputFinal3 = OutputFinal1 + _1add;

                                            //Console.WriteLine("8's complement is " + OutputFinal3);
                                            string output = OutputFinal3.ToString();
                                            txtOctal.Text = output;
                                        }
                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Output = Output * -1;
                            Octalwn = Convert.ToString(Output, 8);

                            for (int j = 0; j < Octalwn.Length; j++)
                            {
                                string holder4 = Convert.ToString(Octalwn[j]);
                                if (holder4 == ".")
                                {
                                    subtrahend.Append(holder4);
                                }
                                else
                                {
                                    holder4 = "7";
                                    subtrahend.Append(holder4);
                                }
                            }


                            double subtrahendFinal = Double.Parse(Convert.ToString(subtrahend)), FinalOutputFinal = Double.Parse(Convert.ToString(Octalwn));
                            double OutputFinal1 = subtrahendFinal - FinalOutputFinal;

                            //Console.WriteLine("The octal (7's complement) of " + Output_Decimal + " is " + OutputFinal1);

                            StringBuilder _8C = new StringBuilder();
                            string OutputFinal2 = Convert.ToString(OutputFinal1);
                            for (int k = 0; k <= Convert.ToString(OutputFinal1).Length - 1; k++)
                            {
                                string holder5 = Convert.ToString(OutputFinal2[k]);

                                if (k == OutputFinal2.Length - 1)
                                {
                                    holder5 = "1";
                                    _8C.Append(holder5);
                                    break;
                                }
                                if (holder5 == ".")
                                {
                                    _8C.Append(holder5);
                                }
                                else
                                {
                                    holder5 = "0";
                                    _8C.Append(holder5);
                                }
                            }

                            double _1add = Double.Parse(_8C.ToString());
                            double OutputFinal3 = OutputFinal1 + _1add;

                            //Console.WriteLine("8's complement is " + OutputFinal3);
                            string output = OutputFinal3.ToString();
                            txtOctal.Text = output;
                        }
                    }
                }

            }

            //Octal
            if (rbtnOctal.Checked == true)
            {
                //Clears the textboxes
                txtDecimal.Text = "";
                txtBinary.Text = "";
                txtHexa.Text = "";
                txtDecimalDup.Text = "";

                //Input is in 8's complement
                if (cbSigned.Checked == true)
                {
                    string Input_Decimal = txtInput.Text;
                    string Output_Decimal = Input_Decimal, holder4, holder5;

                    StringBuilder _7C = new StringBuilder();
                    StringBuilder pos = new StringBuilder();

                    for (int i = 0; i < Input_Decimal.Length; i++)
                    {
                        holder4 = Input_Decimal[i].ToString();

                        if (i == Input_Decimal.Length - 1)
                        {
                            if (holder4 == "A")
                            {
                                _7C.Append("9");
                            }
                            if (holder4 == "B")
                            {
                                _7C.Append("A");
                            }
                            if (holder4 == "C")
                            {
                                _7C.Append("B");
                            }
                            if (holder4 == "D")
                            {
                                _7C.Append("C");
                            }
                            if (holder4 == "E")
                            {
                                _7C.Append("D");
                            }
                            if (holder4 == "F")
                            {
                                _7C.Append("E");
                            }
                            else
                            {
                                if (holder4 == "1")
                                {
                                    _7C.Append("0");
                                }
                                if (holder4 == "2")
                                {
                                    _7C.Append("1");
                                }
                                if (holder4 == "3")
                                {
                                    _7C.Append("2");
                                }
                                if (holder4 == "4")
                                {
                                    _7C.Append("3");
                                }
                                if (holder4 == "5")
                                {
                                    _7C.Append("4");
                                }
                                if (holder4 == "6")
                                {
                                    _7C.Append("5");
                                }
                                if (holder4 == "7")
                                {
                                    _7C.Append("6");
                                }
                                if (holder4 == "8")
                                {
                                    _7C.Append("7");
                                }
                                if (holder4 == "9")
                                {
                                    _7C.Append("8");
                                }
                            }
                        }
                        else
                        {
                            _7C.Append(holder4);
                        }
                    }
                    for (int j = 0; j < _7C.Length; j++)
                    {
                        holder5 = _7C[j].ToString();

                        if (holder5 == "0")
                        {
                            pos.Append("7");
                        }
                        if (holder5 == "1")
                        {
                            pos.Append("6");
                        }
                        if (holder5 == "2")
                        {
                            pos.Append("5");
                        }
                        if (holder5 == "3")
                        {
                            pos.Append("4");
                        }
                        if (holder5 == "4")
                        {
                            pos.Append("3");
                        }
                        if (holder5 == "5")
                        {
                            pos.Append("2");
                        }
                        if (holder5 == "6")
                        {
                            pos.Append("1");
                        }
                        if (holder5 == "7")
                        {
                            pos.Append("0");
                        }
                        if (holder5 == ".")
                        {
                            pos.Append(holder5);
                        }
                    }

                    string Input1 = pos.ToString();
                    int base1 = 8;




                    double decimal1 = 0;
                    string wholeNum = Input1.Split('.')[0], decVal = Input1.Split('.')[1];
                    StringBuilder decPoint = new StringBuilder();

                    for (int i = 0; i < wholeNum.Length; i++)
                    {
                        int j = wholeNum.Length - 1 - i;
                        string digit = Convert.ToString(wholeNum[j]);

                        if (digit == "A" || digit == "a")
                        {
                            digit = "10";
                        }
                        if (digit == "B" || digit == "b")
                        {
                            digit = "11";
                        }
                        if (digit == "C" || digit == "c")
                        {
                            digit = "12";
                        }
                        if (digit == "D" || digit == "d")
                        {
                            digit = "13";
                        }
                        if (digit == "E" || digit == "e")
                        {
                            digit = "14";
                        }
                        if (digit == "F" || digit == "f")
                        {
                            digit = "15";
                        }

                        decimal1 += Convert.ToInt32(digit) * (Math.Pow(base1, i));
                    }

                    for (int i = 0; i < decVal.Length; i++)
                    {
                        string digit1 = Convert.ToString(decVal[i]);

                        if (digit1 == "A" || digit1 == "a")
                        {
                            digit1 = "10";
                        }
                        if (digit1 == "B" || digit1 == "b")
                        {
                            digit1 = "11";
                        }
                        if (digit1 == "C" || digit1 == "c")
                        {
                            digit1 = "12";
                        }
                        if (digit1 == "D" || digit1 == "d")
                        {
                            digit1 = "13";
                        }
                        if (digit1 == "E" || digit1 == "e")
                        {
                            digit1 = "14";
                        }
                        if (digit1 == "F" || digit1 == "f")
                        {
                            digit1 = "15";
                        }

                        decimal1 += Convert.ToInt32(digit1) * (Math.Pow(base1, (-1 * (i + 1))));
                    }



                    //Console.WriteLine("Output is " + decimal1);
                    decimal1 = decimal1 * -1;
                    txtDecimalDup.Text = decimal1.ToString();

                }
                //Input is positive
                else if(cbSigned.Checked == false)
                {
                    string Input1 = txtInput.Text;
                    int base1 = 8;




                    double decimal1 = 0;
                    string wholeNum = Input1.Split('.')[0], decVal = Input1.Split('.')[1];
                    StringBuilder decPoint = new StringBuilder();

                    for (int i = 0; i < wholeNum.Length; i++)
                    {
                        int j = wholeNum.Length - 1 - i;
                        string digit = Convert.ToString(wholeNum[j]);

                        if (digit == "A" || digit == "a")
                        {
                            digit = "10";
                        }
                        if (digit == "B" || digit == "b")
                        {
                            digit = "11";
                        }
                        if (digit == "C" || digit == "c")
                        {
                            digit = "12";
                        }
                        if (digit == "D" || digit == "d")
                        {
                            digit = "13";
                        }
                        if (digit == "E" || digit == "e")
                        {
                            digit = "14";
                        }
                        if (digit == "F" || digit == "f")
                        {
                            digit = "15";
                        }

                        decimal1 += Convert.ToInt32(digit) * (Math.Pow(base1, i));
                    }

                    for (int i = 0; i < decVal.Length; i++)
                    {
                        string digit1 = Convert.ToString(decVal[i]);

                        if (digit1 == "A" || digit1 == "a")
                        {
                            digit1 = "10";
                        }
                        if (digit1 == "B" || digit1 == "b")
                        {
                            digit1 = "11";
                        }
                        if (digit1 == "C" || digit1 == "c")
                        {
                            digit1 = "12";
                        }
                        if (digit1 == "D" || digit1 == "d")
                        {
                            digit1 = "13";
                        }
                        if (digit1 == "E" || digit1 == "e")
                        {
                            digit1 = "14";
                        }
                        if (digit1 == "F" || digit1 == "f")
                        {
                            digit1 = "15";
                        }

                        decimal1 += Convert.ToInt32(digit1) * (Math.Pow(base1, (-1 * (i + 1))));
                    }



                    txtDecimalDup.Text = decimal1.ToString();

                }



                if (cbDecimal.Checked == true)
                {
                    txtDecimal.Text = txtDecimalDup.Text;
                }
                if(cbBinary.Checked == true)
                {
                    string Input_Decimal = txtDecimalDup.Text;
                    string Output_Decimal = Input_Decimal;
                    double Input_DecimalD = double.Parse(Input_Decimal);

                    //Input is negative
                    if (Input_DecimalD <= 0)
                    {
                        //Convert to positive
                        Input_DecimalD = Input_DecimalD * -1;
                        //Convert to string
                        Input_Decimal = Convert.ToString(Input_DecimalD);

                        //detect if the input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);

                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            for (int i = 0; i < Input_Decimal.Length - 1; i++)
                            {
                                holder = dpd1 * 2;
                                holderstring = Convert.ToString(holder);
                                var dpd2 = holderstring.Split('.')[0];
                                dpdfinal += dpd2;
                                if (holder != 1 && holder != -1)
                                {
                                    holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                    holder2 = double.Parse(holderstring);
                                    dpd1 = holder2;
                                }
                                if (holder == 1 || holder == -1)
                                {
                                    break;
                                }
                            }

                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(Decimalwn);
                            stringBuilder.Append(".");
                            stringBuilder.Append(dpdfinal);
                            string output = GFG.findTwoscomplement(stringBuilder);
                            //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                            txtBinary.Text = output;
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(output);
                            output = GFG.findTwoscomplement(stringBuilder);
                            //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                            txtBinary.Text = output;
                        }
                    }

                    //Input is positive
                    else if (Input_DecimalD > 0)
                    {
                        Console.WriteLine("Input is positive");
                        //detect if the input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));
                            //Console.WriteLine("check input dec " + Input_Decimal_string);//check inp dec
                            //var dpd = Input_Decimal_string.Split('.')[1]; //"703125"
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check parsedToDouble_decimal_point " + parsedToDouble_decimal_point);//checker
                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            for (int i = 0; i < Input_Decimal.Length - 1; i++)
                            {
                                holder = dpd1 * 2;
                                //Console.WriteLine("checking holder " + holder);
                                holderstring = Convert.ToString(holder);
                                var dpd2 = holderstring.Split('.')[0];
                                dpdfinal += dpd2;
                                if (holder != 1 && holder != -1)
                                {
                                    holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                    //Console.WriteLine("check holderstring " + holderstring);//check holderstring
                                    holder2 = double.Parse(holderstring);
                                    //Console.WriteLine("checking holder2 " + holder2);
                                    dpd1 = holder2;
                                }
                                if (holder == 1 || holder == -1)
                                {
                                    break;
                                }
                            }
                            //Console.WriteLine("The Binary form of " + Output_Decimal + " is " + Decimalwn + "." + dpdfinal);
                            string output = Decimalwn + "." + dpdfinal;
                            txtBinary.Text = output;
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            txtBinary.Text = output;
                        }
                    }
                }
                if(cbHexa.Checked == true)
                {
                    string Input_Decimal = txtDecimalDup.Text;
                    string Output_Decimal = Input_Decimal, Hexawn;
                    double Input_DecimalD = double.Parse(Input_Decimal);


                    //Input is positive
                    if (Input_DecimalD > 0)
                    {

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check parsedToDouble_decimal_point " + parsedToDouble_decimal_point);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {
                                Hexawn = Convert.ToString(wnd1, 16);
                                Hexawn = Hexawn.ToUpper();

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;



                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length <= 9)
                                {

                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;



                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 1
                            else if (wnd1 == 0)
                            {
                                Hexawn = "0";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;



                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length <= 9)
                                {

                                    for (int i = 0; i <= 8; i++)
                                    {
                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);

                                        if (holder == 1 || holder == -1)
                                        {
                                            break;
                                        }

                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;



                                        if (i == 8)
                                        {
                                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn + "." + dpofinal);//checking dpofinal
                                            string output = Hexawn + "." + dpofinal.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                        }
                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Hexawn = Convert.ToString(Output, 16);
                            //Console.WriteLine("The Hexadecimal form of " + Output_Decimal + " is " + Hexawn);
                            string output = Hexawn;
                            txtHexa.Text = output;
                        }
                    }

                    //Input is negative
                    else if (Input_DecimalD <= 0)
                    {
                        Input_DecimalD = Input_DecimalD * -1;
                        StringBuilder subtrahend = new StringBuilder();

                        //detect if input is whole number
                        //Input is not whole number
                        if (Input_Decimal.Contains("."))
                        {

                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));

                            int wnd1 = int.Parse(wnd);
                            wnd1 = wnd1 * -1;
                            double dpd1 = double.Parse(Input_Decimal);
                            double holder, holder2;
                            string holderstring;
                            StringBuilder dpofinal = new StringBuilder();


                            //Checking if the input is less than 0
                            //Input is > 0
                            if (wnd1 > 0)
                            {

                                Hexawn = Convert.ToString(wnd1, 16);
                                Hexawn = Hexawn.ToUpper();

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else if (Input_Decimal.Length < 8)
                                {
                                    for (int i = 0; i <= 8; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == 8)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                            //Input is < 1
                            else if (wnd1 == 0)
                            {
                                Hexawn = "0000";

                                if (Input_Decimal.Length > 8)
                                {
                                    for (int i = 0; i <= Input_Decimal.Length - 1; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == Input_Decimal.Length - 1)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }

                                else
                                {
                                    for (int i = 0; i <= 8; i++)
                                    {

                                        holder = dpd1 * 16;
                                        holderstring = Convert.ToString(holder);
                                        var dpd2 = holderstring.Split('.')[0];
                                        if (dpd2 == "10")
                                        {
                                            dpd2 = "A";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "11")
                                        {
                                            dpd2 = "B";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "12")
                                        {
                                            dpd2 = "C";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "13")
                                        {
                                            dpd2 = "D";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "14")
                                        {
                                            dpd2 = "E";
                                            dpofinal.Append(dpd2);
                                        }
                                        if (dpd2 == "15")
                                        {
                                            dpd2 = "F";
                                            dpofinal.Append(dpd2);
                                        }
                                        else
                                        {
                                            dpofinal.Append(dpd2);
                                        }

                                        holderstring = holderstring.Substring(holderstring.IndexOf("."));
                                        holder2 = double.Parse(holderstring);
                                        dpd1 = holder2;


                                        if (i == 8)
                                        {
                                            string FinalOutput = Hexawn + "." + dpofinal.ToString();


                                            for (int j = 0; j < FinalOutput.Length; j++)
                                            {
                                                string holder4 = Convert.ToString(FinalOutput[j]);

                                                if (holder4 == ".")
                                                {
                                                    subtrahend.Append(holder4);
                                                }
                                                if (holder4 == "A")
                                                {
                                                    subtrahend.Append("5");
                                                }
                                                if (holder4 == "B")
                                                {
                                                    subtrahend.Append("4");
                                                }
                                                if (holder4 == "C")
                                                {
                                                    subtrahend.Append("3");
                                                }
                                                if (holder4 == "D")
                                                {
                                                    subtrahend.Append("2");
                                                }
                                                if (holder4 == "E")
                                                {
                                                    subtrahend.Append("1");
                                                }
                                                if (holder4 == "F")
                                                {
                                                    subtrahend.Append("0");
                                                }
                                                else
                                                {
                                                    if (holder4 == "0")
                                                    {
                                                        subtrahend.Append("F");
                                                    }
                                                    if (holder4 == "1")
                                                    {
                                                        subtrahend.Append("E");
                                                    }
                                                    if (holder4 == "2")
                                                    {
                                                        subtrahend.Append("D");
                                                    }
                                                    if (holder4 == "3")
                                                    {
                                                        subtrahend.Append("C");
                                                    }
                                                    if (holder4 == "4")
                                                    {
                                                        subtrahend.Append("B");
                                                    }
                                                    if (holder4 == "5")
                                                    {
                                                        subtrahend.Append("A");
                                                    }
                                                    if (holder4 == "6")
                                                    {
                                                        subtrahend.Append("9");
                                                    }
                                                    if (holder4 == "7")
                                                    {
                                                        subtrahend.Append("8");
                                                    }
                                                    if (holder4 == "8")
                                                    {
                                                        subtrahend.Append("7");
                                                    }
                                                    if (holder4 == "9")
                                                    {
                                                        subtrahend.Append("6");
                                                    }

                                                }

                                            }

                                            //Console.WriteLine("15's complement is " + subtrahend);
                                            StringBuilder _16C = new StringBuilder();


                                            for (int w = 0; w < subtrahend.Length; w++)
                                            {
                                                string holder5 = Convert.ToString(subtrahend[w]);
                                                if (w == subtrahend.Length - 1)
                                                {
                                                    if (holder5 == "1")
                                                    {
                                                        _16C.Append("2");
                                                    }
                                                    if (holder5 == "2")
                                                    {
                                                        _16C.Append("3");
                                                    }
                                                    if (holder5 == "3")
                                                    {
                                                        _16C.Append("4");
                                                    }
                                                    if (holder5 == "4")
                                                    {
                                                        _16C.Append("5");
                                                    }
                                                    if (holder5 == "5")
                                                    {
                                                        _16C.Append("6");
                                                    }
                                                    if (holder5 == "6")
                                                    {
                                                        _16C.Append("7");
                                                    }
                                                    if (holder5 == "7")
                                                    {
                                                        _16C.Append("8");
                                                    }
                                                    if (holder5 == "8")
                                                    {
                                                        _16C.Append("9");
                                                    }
                                                    if (holder5 == "9")
                                                    {
                                                        _16C.Append("A");
                                                    }
                                                    if (holder5 == "A")
                                                    {
                                                        _16C.Append("B");
                                                    }
                                                    if (holder5 == "B")
                                                    {
                                                        _16C.Append("C");
                                                    }
                                                    if (holder5 == "C")
                                                    {
                                                        _16C.Append("D");
                                                    }
                                                    if (holder5 == "D")
                                                    {
                                                        _16C.Append("E");
                                                    }
                                                    if (holder5 == "E")
                                                    {
                                                        _16C.Append("F");
                                                    }
                                                }
                                                else
                                                {
                                                    _16C.Append(holder5);
                                                }
                                            }

                                            //Console.WriteLine("16's complement is " + _16C.ToString());
                                            string output = _16C.ToString();
                                            txtHexa.Text = output;
                                        }
                                    }
                                }
                            }
                        }

                        //Input is whole number
                        else
                        {
                            int Output = Convert.ToInt32(Output_Decimal);
                            Output = Output * -1;
                            Hexawn = Convert.ToString(Output, 16);
                            Hexawn = Hexawn.ToUpper();
                            for (int j = 0; j < Hexawn.Length; j++)
                            {
                                string holder4 = Convert.ToString(Hexawn[j]);
                                if (holder4 == "A")
                                {
                                    subtrahend.Append("5");
                                }
                                if (holder4 == "B")
                                {
                                    subtrahend.Append("4");
                                }
                                if (holder4 == "C")
                                {
                                    subtrahend.Append("3");
                                }
                                if (holder4 == "D")
                                {
                                    subtrahend.Append("2");
                                }
                                if (holder4 == "E")
                                {
                                    subtrahend.Append("1");
                                }
                                if (holder4 == "F")
                                {
                                    subtrahend.Append("0");
                                }
                                else
                                {
                                    if (holder4 == "0")
                                    {
                                        subtrahend.Append("F");
                                    }
                                    if (holder4 == "1")
                                    {
                                        subtrahend.Append("E");
                                    }
                                    if (holder4 == "2")
                                    {
                                        subtrahend.Append("D");
                                    }
                                    if (holder4 == "3")
                                    {
                                        subtrahend.Append("C");
                                    }
                                    if (holder4 == "4")
                                    {
                                        subtrahend.Append("B");
                                    }
                                    if (holder4 == "5")
                                    {
                                        subtrahend.Append("A");
                                    }
                                    if (holder4 == "6")
                                    {
                                        subtrahend.Append("9");
                                    }
                                    if (holder4 == "7")
                                    {
                                        subtrahend.Append("8");
                                    }
                                    if (holder4 == "8")
                                    {
                                        subtrahend.Append("7");
                                    }
                                    if (holder4 == "9")
                                    {
                                        subtrahend.Append("6");
                                    }
                                }
                            }


                            //Console.WriteLine("15's complement of " + Output_Decimal + " is " + subtrahend);

                            StringBuilder _16C = new StringBuilder();


                            for (int w = 0; w < subtrahend.Length; w++)
                            {
                                string holder5 = Convert.ToString(subtrahend[w]);
                                if (w == subtrahend.Length - 1)
                                {
                                    if (holder5 == "1")
                                    {
                                        _16C.Append("2");
                                    }
                                    if (holder5 == "2")
                                    {
                                        _16C.Append("3");
                                    }
                                    if (holder5 == "3")
                                    {
                                        _16C.Append("4");
                                    }
                                    if (holder5 == "4")
                                    {
                                        _16C.Append("5");
                                    }
                                    if (holder5 == "5")
                                    {
                                        _16C.Append("6");
                                    }
                                    if (holder5 == "6")
                                    {
                                        _16C.Append("7");
                                    }
                                    if (holder5 == "7")
                                    {
                                        _16C.Append("8");
                                    }
                                    if (holder5 == "8")
                                    {
                                        _16C.Append("9");
                                    }
                                    if (holder5 == "9")
                                    {
                                        _16C.Append("A");
                                    }
                                    if (holder5 == "A")
                                    {
                                        _16C.Append("B");
                                    }
                                    if (holder5 == "B")
                                    {
                                        _16C.Append("C");
                                    }
                                    if (holder5 == "C")
                                    {
                                        _16C.Append("D");
                                    }
                                    if (holder5 == "D")
                                    {
                                        _16C.Append("E");
                                    }
                                    if (holder5 == "E")
                                    {
                                        _16C.Append("F");
                                    }
                                }
                                else
                                {
                                    _16C.Append(holder5);
                                }
                            }

                            //Console.WriteLine("16's complement is " + _16C.ToString());
                            string output = _16C.ToString();
                            txtHexa.Text = output;
                        }
                    }
                }

            }
        }
    }
}