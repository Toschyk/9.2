using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;


namespace Decoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string str;
        byte[] key;
        byte[] te;
        byte[] cipherbytes;

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("my_file.txt");
            file.Close();
            te = new Byte[str.Length];
            te = Encoding.Default.GetBytes(str);
            SymmetricAlgorithm sa2 = TripleDES.Create();
            sa2.Key = key;
            sa2.Mode = CipherMode.ECB;
            sa2.Padding = PaddingMode.PKCS7;
            MemoryStream ms2 = new MemoryStream(te);
            CryptoStream cs2 = new CryptoStream(ms2, sa2.CreateDecryptor(), CryptoStreamMode.Read);
            byte[] plainbytes2 = new Byte[te.Length];
            cs2.Read(plainbytes2, 0, te.Length);
            cs2.Close();
            ms2.Close();
            textBox1.Text = Encoding.Default.GetString(plainbytes2);
        }
    }
}
