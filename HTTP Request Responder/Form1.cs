using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using MetroFramework;
using MetroFramework.Forms;
namespace HTTP_Request_Responder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool SettingsVerify = Properties.Settings.Default.Format_Indented && Properties.Settings.Default.Format_Normal;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (SettingsVerify == true)
            {
                MessageBox.Show("Please go to settings and set a format.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            metroTextBox2.ForeColor = Color.Green;
            WebClient wb = new WebClient();
            Form1 f1 = new Form1();
            //Indented Format
            if (Properties.Settings.Default.Format_Indented == true)
            {
                try
                {
                    f1.Name = "HTTP Request Responder | Format: Indented";
                    metroTextBox2.Clear();
                    var json = wb.DownloadString(metroTextBox1.Text.ToString());
                    var parsedJson = JsonConvert.DeserializeObject(json);
                    string a = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                    metroTextBox2.AppendText(a);
                }
                catch (Exception ex)
                {
                    metroTextBox2.Clear();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            //Normal Format
            if (Properties.Settings.Default.Format_Normal == true)
            {
                try
                {
                    f1.Name = "HTTP Request Responder | Format: Normal JSON";
                    metroTextBox2.Clear();
                    var json = wb.DownloadString(metroTextBox1.Text.ToString());
                    metroTextBox2.AppendText(json);
                }
                catch (Exception ex)
                {
                    metroTextBox2.Clear();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.ReadOnly == true)
            {
                metroTextBox2.ReadOnly = true;
            }else
            {
                metroTextBox2.ReadOnly = false;
            }
            if (Properties.Settings.Default.ReadWrite == true)
            {
                metroTextBox2.ReadOnly = false;
            }
            else
            {
                metroTextBox2.ReadOnly = true;
            }
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Hi, {Environment.UserName}. To use this program, all you have to do is firstly select a format you would like the data to be returned in by heading over to the settings and changing them. Then save your current changes and then press (Request) and BOOM! that's it.\n\nFor help check out my github: https://github.com/Morphine999", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}