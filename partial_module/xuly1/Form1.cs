using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xuly1
{
  
    public partial class Form1 : Form
    {
        string text_read;
        string Product_Name, Image_URL, Product_URL, Price;
        public Form1()
        {
            InitializeComponent();
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        private void bt_ok_Click(object sender, EventArgs e)
        {
            text_read = txt1.Text;
            Product_Name = getBetween(text_read, "title=\"", "\"");
            Image_URL=getBetween(text_read, "src=\"//", "\"");
            Price= getBetween(text_read,"\"price\"><em>","x");
            Product_URL = getBetween(text_read, "<strong><a href='", "'>");
            // txt2.Text = Product_Name;
            // txt2.Text = Product_URL;
           // txt2.Text = Image_URL;
            txt2.Text = Price;
        }
    }
}
