﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLLanguageSelector
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            string strDefaultPath = "C:/Riot Games/League of Legends/LeagueClient.exe";
            if (File.Exists(strDefaultPath)) {
                txtFilePath.Text = strDefaultPath;
            } else {
                txtFilePath.Text = "Please select the path to LeagueClient.exe";
            }

            // Set the language combo box properties
            cmbLanguage.DisplayMember = "KEY";
            cmbLanguage.ValueMember = "VALUE";

            IDictionary<string, string> items = new Dictionary<string, string>();
            items.Add("English (US)", "en_US");
            items.Add("Japanese (日本語)", "ja_JP");
            items.Add("Korean (한글)", "ko_KR");
            items.Add("Chinese (汉字)", "zh_CN");
            items.Add("Russian (Русский)", "ru_RU");
            items.Add("Portuguese (Português)", "pt_BR");
            items.Add("Turkish (Türkçe)", "tr_TR");
            items.Add("Spanish (Latin)", "es_MX");
            items.Add("Spanish (Castilian)", "es_ES");
            items.Add("German (Deutsch)", "de_DE");
            items.Add("Greek (Ελληνικά)", "el_GR");
            items.Add("Hungarian (Magyar)", "hu_HU");
            items.Add("Polish (Polski)", "pl_PL");
            items.Add("Romanian (Română)", "ro_RO"); 
            items.Add("French (Français)", "fr_FR");
            items.Add("Italian (Italiano)", "it_IT");
            items.Add("Czech (Čeština)", "cs_CZ");
            items.Add("English (Australia)", "en_AU");

            cmbLanguage.DataSource = new BindingSource(items, null);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\Riot Games\\League of Legends\\";
            openFileDialog1.FileName = "LeagueClient";
            openFileDialog1.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { 
                // Check if this is valid executable
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
           System.Diagnostics.Process.Start(txtFilePath.Text, "--locale=" + cmbLanguage.SelectedValue.ToString());
            MessageBox.Show("Locale settings were applied! Wait for League of Legends to initialize with the new locale.");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout1 = new frmAbout();
            frmAbout1.ShowDialog();
        }
    }
}
