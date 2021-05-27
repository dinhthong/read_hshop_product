using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;
using System.IO;
namespace product_filter1
{
    public partial class Form1 : Form
    {
        private List<Product> productList = new List<Product>();
        public string strStart = "<a href=\"/products/";
        public string strEnd = "</em>";
        string product_temp;
        int index;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
        private void bt_do_Click(object sender, EventArgs e)
        {
            productList.Clear();
            string text_read = readhtml(txt_url.Text);
            txt_1.Text = text_read;
            addProductList(text_read);
            
        }
        private void bt_excel_Click(object sender, EventArgs e)
        {
            toExcelFile();
        }
        private void addProductList(string text_read)
        {
            txt_2.Text = "";
         
            while (true)
            {
                product_temp = getBetween(text_read, strStart, strEnd);
                if (product_temp == "")
                {
                   // stop = true;
                    break;
                }
                //code pro add to product list
                newproduct(product_temp);
                txt_2.Text += product_temp;
                txt_2.Text += Environment.NewLine;
                index = text_read.IndexOf(strEnd) + strEnd.Length;
                text_read = text_read.Substring(index);
            }
        }
        private string readhtml(string url)
        {
            string url_content;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            url_content=sr.ReadToEnd();
            sr.Close();
            return url_content;
        }
        private void newproduct(string product_temp)
        {
            string price, name;
            Product newProduct = new Product();
            name = getBetween(product_temp, "title=\"", "\"");
            newProduct.Name = name;
            newProduct.Image_url = getBetween(product_temp, "src=\"//", "\"");
            newProduct.Product_url = getBetween(product_temp, "<strong><a href='", "'>");
            price = getBetween(product_temp, "\"price\"><em>", "₫");
            price = price.Replace(" ", "");
            newProduct.Price = price;
            productList.Add(newProduct);
        }
        public static int rowCount, colCount;
        public static string[,] decode;
        public void toExcelFile()
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Application.StartupPath + @"\Database.xlsx");
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"E:\Cuahang_ap\Database.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            decode = new string[rowCount, colCount];
            rowCount = xlRange.Rows.Count;
            colCount = xlRange.Columns.Count;
            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = rowCount + 1; i <= rowCount + productList.Count; i++)
            {
                xlRange.Cells[i, 1].Value2 = productList[i-rowCount-1].Name;
                xlRange.Cells[i, 2].Value2 = productList[i-rowCount-1].Image_url;
                xlRange.Cells[i, 3].Value2 = productList[i-rowCount-1].Product_url;
                xlRange.Cells[i, 4].Value2 = productList[i-rowCount-1].Price;
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad
          //  Console.WriteLine(decode[0, 0] + decode[1, 1]);
            //close and release
            xlWorkbook.Close();
            //quit and release
            xlApp.Quit();
        }
    }
}
