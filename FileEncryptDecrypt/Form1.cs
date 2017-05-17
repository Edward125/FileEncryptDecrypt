using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileEncryptDecrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + ",ver:" + Application.ProductVersion;
        }

        private void txtFile_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
                txtFile.Text = openfile.FileName;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFile.Text.Trim()))
                return;
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                return;

            string inFile = txtFile.Text;
            string outFile = inFile + ".edward";
            string password = txtPassword.Text;
            DESFile.EncryptFile(inFile, outFile, password);//加密文件
            //删除加密前的文件
            File.Delete(inFile);
            txtFile.Text = string.Empty;
            txtPassword.Text = string.Empty;
            MessageBox.Show("加密成功");
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFile.Text.Trim()))
                return;
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                return;

            string inFile = txtFile.Text;
            string outFile = inFile.Substring(0, inFile.LastIndexOf('.') + 1);
            string password = txtPassword.Text;
            if (File.Exists (outFile ))
                try
                {
                    File.Delete(outFile);
                }
                catch (Exception)
                {
                    
                
                }

            DESFile.DecryptFile(inFile, outFile, password);//解密文件
            //删除解密前的文件
            File.Delete(inFile);
            txtFile.Text = string.Empty;
            txtPassword.Text = string.Empty;
            MessageBox.Show("解密成功");
        }
    }
}
