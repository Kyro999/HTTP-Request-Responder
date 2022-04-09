using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace HTTP_Request_Responder
{
    public partial class Form2 : MetroForm
    {
        //Testing URL: https://fortnite-api.com/v1/map
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //NOTE: Form Config (check if settings were saved, if so apply them to the checkboxes)
            if (Properties.Settings.Default.Format_Indented == true)
            {
                metroCheckBox1.Checked = true;
            }
            else
            {
                metroCheckBox1.Checked = false;
            }
            if (Properties.Settings.Default.Format_Normal == true)
            {
                metroCheckBox2.Checked = true;
            }
            else
            {
                metroCheckBox2.Checked = true;
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(metroCheckBox1.Checked == false && metroCheckBox2.Checked == false)
            {
                DialogResult result;
                result = MessageBox.Show("Are you sure you want to exit without changes?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
                else if(result == DialogResult.No)
                {
                    e.Cancel = false;
                }
            }
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true && metroCheckBox2.Checked == true)
            {
                MessageBox.Show("You cannot select more than one format", "Setting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (metroCheckBox1.Checked == true)
            {
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Format_Indented = true;
            }else
            {
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Format_Indented = false;
            }
            if(metroCheckBox2.Checked == true)
            {
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Format_Normal = true;
            }
            else
            {
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Format_Normal = false;
            }
            if(metroCheckBox1.Checked == false && metroCheckBox2.Checked == false)
            {
                //NOTE: Save everything as false because no setting was saved.
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Format_Indented = false;
                Properties.Settings.Default.Format_Normal = false;
            }
            MessageBox.Show("Changes were saved, you can now exit.", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}

//if u take this code pls make sure to credit me.