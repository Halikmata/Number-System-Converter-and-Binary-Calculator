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
    public partial class Binary_Calculator : Form
    {
        double Input1 = 0, Input2 = 0, OutputInitial = 0;

        private void txtInput1_TextChanged(object sender, EventArgs e)
        {
            //checking if positive or negative
            if (txtInput1.Text[0] == '1')
            {
                cbSign1.Checked = true;
            }
            else
            {
                cbSign1.Checked = false;
            }
        }

        private void txtInput2_TextChanged(object sender, EventArgs e)
        {
            //checking if positive or negative
            if (txtInput2.Text[0] == '1')
            {
                cbSign2.Checked = true;
            }
            else
            {
                cbSign2.Checked = false;
            }
        }

        private void txtOutput_Click(object sender, EventArgs e)
        {
            if(txtOutput.Text == "Input here")
            {
                txtOutput.Text = "";
            }
        }

        public Binary_Calculator()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";


            if(txtInput1.Text == "" || txtInput2.Text == "")
            {
                if (txtInput1.Text == "" && txtInput2.Text == "")
                {
                    MessageBox.Show("No Input!");
                }
                else if (txtInput1.Text == "")
                {
                    MessageBox.Show("Incomplete Input: Input 1 has no value.");
                }
                else if (txtInput2.Text == "")
                {
                    MessageBox.Show("Incomplete Input: Input 2 has no value.");
                }
                
            }

            lblSign.Visible = false;

            if (txtInput1.Text != "" && txtInput2.Text != "")
            {
            
                //Input 1
                if (cbSign1.Checked == false) //Input is positive
                {
                    string Input_Binary = txtInput1.Text;
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
                                Input1 = outputfinal;
                            }
                        }

                    }

                    //Input is whole number
                    else
                    {
                        int wnb1 = Convert.ToInt32(Output_Binary, 2);

                        //Console.WriteLine("The decimal form of " + Output_Binary + " is " + wnb1);
                        Input1 = Convert.ToDouble(wnb1);
                    }
                }


                //Input is negative
                else if (cbSign1.Checked == true) //Input is negative
                {
                    string Input_Binary = txtInput1.Text;
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
                                Input1 = outputfinal;
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
                        Input1 = output;
                    }
                }

                //Input 2
                if (cbSign2.Checked == false) //Input is positive
                {
                    string Input_Binary = txtInput2.Text;
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
                                Input2 = outputfinal;
                            }
                        }

                    }

                    //Input is whole number
                    else
                    {
                        int wnb1 = Convert.ToInt32(Output_Binary, 2);

                        //Console.WriteLine("The decimal form of " + Output_Binary + " is " + wnb1);
                        Input2 = Convert.ToDouble(wnb1);
                    }
                }


                //Input is negative
                else if (cbSign2.Checked == true) //Input is negative
                {
                    string Input_Binary = txtInput2.Text;
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
                                Input2 = outputfinal;
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
                        Input2 = Convert.ToDouble(output);
                    }
                }

                if (rbtnAdd.Checked == true)
                {
                    //txtOutput.Text = (Input1 + Input2).ToString();
                    OutputInitial = Input1 + Input2;
                    if (OutputInitial < 0)
                    {
                        lblSign.Visible = true;
                    }

                    string Input_Decimal = OutputInitial.ToString();
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

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
                            {
                                for (int i = 0; i <= 8; i++)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(output);
                            output = GFG.findTwoscomplement(stringBuilder);
                            //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                            txtOutput.Text = output;
                        }
                    }

                    //Input is positive
                    else if (Input_DecimalD > 0)
                    {
                        //detect if the input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));
                            //Console.WriteLine("check input dec " + Input_Decimal);//check inp dec
                            //var dpd = Input_Decimal.Split('.')[1]; //"703125"
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check dpd1 " + dpd1);//checker
                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            txtOutput.Text = output;
                        }
                    }
                }
                if (rbtnSub.Checked == true)
                {
                    //txtOutput.Text = (Input1 - Input2).ToString();
                    OutputInitial = Input1 - Input2;
                    if (OutputInitial < 0)
                    {
                        lblSign.Visible = true;
                    }

                    string Input_Decimal = OutputInitial.ToString();
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

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
                            {
                                for (int i = 0; i <= 8; i++)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            if (OutputInitial == 0)
                            {
                                txtOutput.Text = "0";
                            }
                            else
                            {
                                int OutputInitial1 = Convert.ToInt32(OutputInitial);
                                OutputInitial1 = OutputInitial1 * -1;
                                string output = Convert.ToString(OutputInitial1, 2);
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append(output);
                                string output1 = GFG.findTwoscomplement(stringBuilder);
                                //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                                txtOutput.Text = output1;
                            }
                        }
                    }

                    //Input is positive
                    else if (Input_DecimalD > 0)
                    {
                        //detect if the input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));
                            //Console.WriteLine("check input dec " + Input_Decimal);//check inp dec
                            //var dpd = Input_Decimal.Split('.')[1]; //"703125"
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check dpd1 " + dpd1);//checker
                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            txtOutput.Text = output;
                        }
                    }
                }
                if (rbtnMult.Checked == true)
                {
                    //txtOutput.Text = (Input1 * Input2).ToString();
                    OutputInitial = Input1 * Input2;
                    if (OutputInitial < 0)
                    {
                        lblSign.Visible = true;
                    }

                    string Input_Decimal = OutputInitial.ToString();
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

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
                            {
                                for (int i = 0; i <= 8; i++)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(output);
                            output = GFG.findTwoscomplement(stringBuilder);
                            //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                            txtOutput.Text = output;
                        }
                    }

                    //Input is positive
                    else if (Input_DecimalD > 0)
                    {
                        //detect if the input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));
                            //Console.WriteLine("check input dec " + Input_Decimal);//check inp dec
                            //var dpd = Input_Decimal.Split('.')[1]; //"703125"
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check dpd1 " + dpd1);//checker
                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            txtOutput.Text = output;
                        }
                    }
                }
                if (rbtnDiv.Checked == true)
                {
                    //txtOutput.Text = (Input1 / Input2).ToString();
                    OutputInitial = Input1 / Input2;
                    if (OutputInitial < 0)
                    {
                        lblSign.Visible = true;
                    }

                    string Input_Decimal = OutputInitial.ToString();
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

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
                            {
                                for (int i = 0; i <= 8; i++)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(output);
                            output = GFG.findTwoscomplement(stringBuilder);
                            //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                            txtOutput.Text = output;
                        }
                    }

                    //Input is positive
                    else if (Input_DecimalD > 0)
                    {
                        //detect if the input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));
                            //Console.WriteLine("check input dec " + Input_Decimal);//check inp dec
                            //var dpd = Input_Decimal.Split('.')[1]; //"703125"
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check dpd1 " + dpd1);//checker
                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            txtOutput.Text = output;
                        }
                    }
                }
                if (rbtnPow.Checked == true)
                {
                    //txtOutput.Text = (Math.Pow(Input1, Input2)).ToString();
                    OutputInitial = Math.Pow(Input1, Input2);
                    if (OutputInitial < 0)
                    {
                        lblSign.Visible = true;
                    }

                    string Input_Decimal = OutputInitial.ToString();
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

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
                            {
                                for (int i = 0; i <= 8; i++)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(output);
                            output = GFG.findTwoscomplement(stringBuilder);
                            //Console.WriteLine("The binary in 2\'s complement form of " + Output_Decimal + " is " + output);
                            txtOutput.Text = output;
                        }
                    }

                    //Input is positive
                    else if (Input_DecimalD > 0)
                    {
                        //detect if the input is not whole number
                        if (Input_Decimal.Contains("."))
                        {
                            var wnd = Input_Decimal.Split('.')[0];
                            Input_Decimal = Input_Decimal.Substring(Input_Decimal.IndexOf("."));
                            //Console.WriteLine("check input dec " + Input_Decimal);//check inp dec
                            //var dpd = Input_Decimal.Split('.')[1]; //"703125"
                            int wnd1 = int.Parse(wnd);
                            double dpd1 = double.Parse(Input_Decimal);
                            //Console.WriteLine("check dpd1 " + dpd1);//checker
                            string dpdfinal = "", holderstring;
                            double holder, holder2 = 0;

                            string Decimalwn = Convert.ToString(wnd1, 2);

                            if (Input_Decimal.Length > 8)
                            {
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
                                txtOutput.Text = output;
                            }
                            if (Input_Decimal.Length <= 8)
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
                                txtOutput.Text = output;
                            }
                        }

                        else
                        {
                            string output = Convert.ToString(Convert.ToInt32(Input_Decimal), 2);
                            txtOutput.Text = output;
                        }
                    }
                }
                if(rbtn2s.Checked == true)
                {
                    StringBuilder in1 = new StringBuilder();
                    StringBuilder in2 = new StringBuilder();
                    in1.Append(txtInput1.Text);
                    in2.Append(txtInput2.Text);
                    string out1 = Convert.ToString(GFG.findTwoscomplement(in1));
                    string out2 = Convert.ToString(GFG.findTwoscomplement(in2));

                    txtOutput.Text = "Input 1: " + out1 + " Input 2: " + out2;


                    //StringBuilder in1 = new StringBuilder();
                    //in1.Append(txtOutput.Text);
                    //string out1 = Convert.ToString(GFG.findTwoscomplement(in1));

                    //txtOutput.Text = txtOutput.Text + " 2's complement is: " + out1;
                }
            }
        }
    }
}
