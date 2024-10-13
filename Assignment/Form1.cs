using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment
{
    public partial class Form1 : Form
    {           //CS/2016/036
        public int x = 0;//index number

        public Form1()
        {
            InitializeComponent();
        }

        //set up to accept only numbers
        private void txtAddNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

        }

        private void txtAddNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void txtAddNo3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void txtShowNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }


        private void txtShowNo3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }
        private void txtShowNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        //update the total number of contacts
        void Count()
        {
            lblCount.Text = lstDetail.Items.Count.ToString() + " Contacts";
        }

        void InputData()//check the repeation of entering data and write data into list box and text file
        {
            int i;

            //avoid the repetition with existing details
            for (i = 0; i < lstDetail.Items.Count; i++)
            {
                if (txtAddName.Text == lstDetail.Items[i].ToString().Substring(0, 19).Trim())
                {
                    MessageBox.Show("Name Already existing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                else if ((txtAddNo1.Text == lstDetail.Items[i].ToString().Substring(19, 14).Trim() || txtAddNo1.Text == lstDetail.Items[i].ToString().Substring(33, 14).Trim() || txtAddNo1.Text == lstDetail.Items[i].ToString().Substring(47, 10).Trim()) && txtAddNo1.Text != "")
                {
                    MessageBox.Show("Number 1 is Already existing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                else if ((txtAddNo2.Text == lstDetail.Items[i].ToString().Substring(19, 14).Trim() || txtAddNo2.Text == lstDetail.Items[i].ToString().Substring(33, 14).Trim() || txtAddNo2.Text == lstDetail.Items[i].ToString().Substring(47, 10).Trim()) && txtAddNo2.Text != "")
                {
                    MessageBox.Show("Number 2 is Already existing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                else if ((txtAddNo3.Text == lstDetail.Items[i].ToString().Substring(19, 14).Trim() || txtAddNo3.Text == lstDetail.Items[i].ToString().Substring(33, 14).Trim() || txtAddNo3.Text == lstDetail.Items[i].ToString().Substring(47, 10).Trim()) && txtAddNo3.Text != "")
                {
                    MessageBox.Show("Number 3 is Already existing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            //Input data in to a listbox
            if (i == lstDetail.Items.Count)
            {
                lstDetail.Items.Add(string.Format("{0,-20 }", txtAddName.Text) + string.Format("{0,-14 }", txtAddNo1.Text) + string.Format("{0,-14 }", txtAddNo2.Text) + string.Format("{0,-10 }", txtAddNo3.Text));
                txtAddName.Text = "";
                txtAddNo1.Text = "";
                txtAddNo2.Text = "";
                txtAddNo3.Text = "";
                //Store data in to a text file
                //text file is stored in the debug folder
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("phonebook.txt", true))
                {
                    file.WriteLine(lstDetail.Items[lstDetail.Items.Count - 1]);
                    file.Close();
                }
                Count();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Avoid Inputs which havent name
            if (txtAddName.Text != "")
            {   //Avoid Inputs which havent any number
                if (txtAddNo1.Text != "" || txtAddNo2.Text != "" || txtAddNo3.Text != "")
                {
                    //avoid checkig single inputs from checking reaptions in entering numbers
                    if ((txtAddNo1.Text == "" && txtAddNo2.Text == "") || (txtAddNo2.Text == "" && txtAddNo3.Text == "") || (txtAddNo1.Text == "" && txtAddNo3.Text == ""))
                    {
                        InputData();
                    }
                    //avoid repeation in entering numbers
                    else if (txtAddNo1.Text != txtAddNo2.Text && txtAddNo3.Text != txtAddNo2.Text && txtAddNo1.Text != txtAddNo3.Text)
                    {
                        InputData();
                    }
                    else
                    {
                        MessageBox.Show("Reapeating numbers","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("At least one number need", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Contact Name cannot be empty", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //Add Element to the contact details
        void AddElement()
        {
            txtShowName.Text = lstDetail.Items[x].ToString().Substring(0, 19).Trim();
            txtShowNo1.Text = lstDetail.Items[x].ToString().Substring(19, 14).Trim();
            txtShowNo2.Text = lstDetail.Items[x].ToString().Substring(33, 14).Trim();
            txtShowNo3.Text = lstDetail.Items[x].ToString().Substring(47, 10).Trim();
            btnEdit.Enabled = true;
            txtSearch.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                for (x = 0; x < lstDetail.Items.Count; x++)
                {
                    //compare the search keyword with existing items
                    if (txtSearch.Text == lstDetail.Items[x].ToString().Substring(0, 19).Trim())
                    {
                        AddElement();
                        break;
                    }

                    else if (txtSearch.Text == lstDetail.Items[x].ToString().Substring(19, 14).Trim())
                    {
                        AddElement();
                        break;
                    }

                    else if (txtSearch.Text == lstDetail.Items[x].ToString().Substring(33, 14).Trim())
                    {
                        AddElement();
                        break;
                    }

                    else if (txtSearch.Text == lstDetail.Items[x].ToString().Substring(47, 10).Trim())
                    {
                        AddElement();
                        break;
                    }

                }
                if (x == lstDetail.Items.Count)
                {
                    txtShowName.Text = "";
                    txtShowName.Enabled = false;
                    txtShowNo1.Text = "";
                    txtShowNo1.Enabled = false;
                    txtShowNo2.Text = "";
                    txtShowNo2.Enabled = false;
                    txtShowNo3.Text = "";
                    txtShowNo3.Enabled = false;
                    btnReSubmit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;

                    MessageBox.Show("No any Result!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtShowName.Enabled = false;
                txtShowNo1.Enabled = false;
                txtShowNo2.Enabled = false;
                txtShowNo3.Enabled = false;
                btnReSubmit.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;

                MessageBox.Show("Input number or name!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtShowName.Enabled = true;
            txtShowNo1.Enabled = true;
            txtShowNo2.Enabled = true;
            txtShowNo3.Enabled = true;
            btnReSubmit.Enabled = true;
            btnDelete.Enabled = true;
        }

        void EditData()//check the repeation of editing data and edit data in list box and text file
        {
            int i;
            //eliminate the repeations

            for (i = 0; i < lstDetail.Items.Count; i++)
            {
                if (i != x)
                {


                    if (txtShowName.Text == lstDetail.Items[i].ToString().Substring(0, 19).Trim())
                    {
                        MessageBox.Show("Name Already existing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    else if ((txtShowNo1.Text == lstDetail.Items[i].ToString().Substring(19, 14).Trim() || txtShowNo1.Text == lstDetail.Items[i].ToString().Substring(33, 14).Trim() || txtShowNo1.Text == lstDetail.Items[i].ToString().Substring(47, 10).Trim()) && txtShowNo1.Text != "")
                    {
                        MessageBox.Show("Number 1 is Already existing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    else if ((txtShowNo2.Text == lstDetail.Items[i].ToString().Substring(19, 14).Trim() || txtShowNo2.Text == lstDetail.Items[i].ToString().Substring(33, 14).Trim() || txtShowNo2.Text == lstDetail.Items[i].ToString().Substring(47, 10).Trim()) && txtShowNo2.Text != "")
                    {
                        MessageBox.Show("Number 2 is Already existing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    else if ((txtShowNo3.Text == lstDetail.Items[i].ToString().Substring(19, 14).Trim() || txtShowNo3.Text == lstDetail.Items[i].ToString().Substring(33, 14).Trim() || txtShowNo3.Text == lstDetail.Items[i].ToString().Substring(47, 10).Trim()) && txtShowNo3.Text != "")
                    {
                        MessageBox.Show("Number 3 is Already existing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }


            }
            if (i == lstDetail.Items.Count)
            {
                //input updated entry to the list box
                lstDetail.Items.Insert(x, string.Format("{0,-20 }", txtShowName.Text) + string.Format("{0,-14 }", txtShowNo1.Text) + string.Format("{0,-14 }", txtShowNo2.Text) + string.Format("{0,-10 }", txtShowNo3.Text));
                //update entry in text file
                string tempFile = Path.GetTempFileName();
                using (var txtentry = new StreamReader("phonebook.txt"))
                using (var tempentry = new StreamWriter(tempFile))
                {
                    string entry;

                    while ((entry = txtentry.ReadLine()) != null)
                    {
                        {
                            if (entry != lstDetail.Items[x + 1].ToString())
                                tempentry.WriteLine(entry);
                            else
                                tempentry.WriteLine(lstDetail.Items[x].ToString());

                        }
                    }
                    txtentry.Close();
                    tempentry.Close();
                    File.Delete("phonebook.txt");
                    File.Move(tempFile, "phonebook.txt");

                    //update entry in list box
                    lstDetail.Items.RemoveAt(x + 1);

                    Count();//update the count

                    txtShowName.Enabled = false;
                    txtShowNo1.Enabled = false;
                    txtShowNo2.Enabled = false;
                    txtShowNo3.Enabled = false;
                    btnReSubmit.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
        }
                //store edited contact details
        private void btnReSubmit_Click(object sender, EventArgs e)
        {

            if (txtShowName.Text != "")
            {
                if (txtShowNo1.Text != "" || txtShowNo2.Text != "" || txtShowNo3.Text != "")
                {  
                    //avoid checkig single inputs from checking reaptions in entering numbers
                    if ((txtShowNo1.Text == "" && txtShowNo2.Text == "") || (txtShowNo2.Text == "" && txtShowNo3.Text == "") || (txtShowNo1.Text == "" && txtShowNo3.Text == ""))
                    {
                        EditData();
                    }
                    //avoid repeation in entering numbers
                    else if (txtShowNo1.Text != txtShowNo2.Text && txtShowNo3.Text != txtShowNo2.Text && txtShowNo1.Text != txtShowNo3.Text)
                    {
                        EditData();
                    }
                    else
                    {
                        MessageBox.Show("Reapeating numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("At least one number need", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Contact Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Delete an entry
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to continue?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //delete entry from text file
                string tempFile = Path.GetTempFileName();

                using (var txtentry = new StreamReader("phonebook.txt"))
                using (var tempentry = new StreamWriter(tempFile))
                {
                    string entry;

                    while ((entry = txtentry.ReadLine()) != null)
                    {
                        {
                            if (entry != lstDetail.Items[x].ToString())
                                tempentry.WriteLine(entry);
                        }
                    }
                }

                File.Delete("phonebook.txt");
                File.Move(tempFile, "phonebook.txt");

                lstDetail.Items.RemoveAt(x);

                Count();

                txtShowName.Text = "";
                txtShowName.Enabled = false;
                txtShowNo1.Text = "";
                txtShowNo1.Enabled = false;
                txtShowNo2.Text = "";
                txtShowNo2.Enabled = false;
                txtShowNo3.Text = "";
                txtShowNo3.Enabled = false;
                btnReSubmit.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;   
            }
        }

        private void lstDetail_DoubleClick(object sender, EventArgs e)
        {
            if (lstDetail.SelectedItem != null)
            {
                txtShowName.Text = lstDetail.SelectedItem.ToString().Substring(0, 19).Trim();
                txtShowNo1.Text = lstDetail.SelectedItem.ToString().Substring(19, 14).Trim();
                txtShowNo2.Text = lstDetail.SelectedItem.ToString().Substring(33, 14).Trim();
                txtShowNo3.Text = lstDetail.SelectedItem.ToString().Substring(47, 10).Trim();
                x = lstDetail.SelectedIndex ;
                btnEdit.Enabled = true;
                txtShowName.Enabled = false;
                txtShowNo1.Enabled = false;
                txtShowNo2.Enabled = false;
                txtShowNo3.Enabled = false;
                btnReSubmit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        //load the items in the text file to the list box
        private void Form1_Load(object sender, EventArgs e)
        {
            int count = 0;
            using (var txtentry = new StreamReader("phonebook.txt"))
            
            {
                string entry;
                while ((entry = txtentry.ReadLine()) != null)
                {
                    //eliminate the first two lines of text file
                    count++;
                    if (count > 2)
                    {
                        lstDetail.Items.Add(entry);
                    }
                }
            }
            Count();//load the count
        }

        private void btnHelp_Click(object sender, EventArgs e) //to give some instructions
        {
            MessageBox.Show("->phonebook.txt file is stored in the debug folder.\n->To delete or update a selected or searched contact you should click the edit button.","Note",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}


        