using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace write_to_Excel
{
    public partial class Form1 : Form
    {
        public static int rowCount, colCount;
        public static string[,] decode;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getExcelFile();
        }
        public void getExcelFile()
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Application.StartupPath + @"\Database.xlsx");
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"E:\Cuahang_ap\Database.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            rowCount = xlRange.Rows.Count;
            colCount = xlRange.Columns.Count;
            decode = new string[rowCount, colCount];
            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i=rowCount+1;i<=rowCount+productList.Count;i++)
            {
                xlRange.Cells[i, 1].Value2 = "hello";
                xlRange.Cells[i, 2].Value2 = "hello2";
                xlRange.Cells[i, 2].Value2 = "hello2";
                xlRange.Cells[i, 2].Value2 = "hello2";
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad
            Console.WriteLine(decode[0, 0] + decode[1, 1]);
            //close and release
            xlWorkbook.Close();
            //quit and release
            xlApp.Quit();
        }
    }
}
