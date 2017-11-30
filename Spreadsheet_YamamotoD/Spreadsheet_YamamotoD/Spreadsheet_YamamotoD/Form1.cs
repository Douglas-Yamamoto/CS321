using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetEngine;

namespace Spreadsheet_YamamotoD
{
    public partial class Form1 : Form
    {
        Spreadsheet sheet;
   
        // Constructor creates a fixed sized Spreadsheet object is made of the Cell objects
        // The Cell objects are a child class of the abstract base class SpreadsheetCell
        // Subscribing to the event in Spreadsheet
        public Form1()
        {
            InitializeComponent();
            sheet = new Spreadsheet(50, 26);
            sheet.CellPropertyChanged += SheetUpdate;
        }

        // Creating row and column headers for the actual GUI form
        private void Form1_Load(object sender, EventArgs e)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (int i = 0; i < alphabet.Length; i++)
            {
                string columnLabel = alphabet[i].ToString();
                dataGridView1.Columns.Add(columnLabel, columnLabel);
            }

            for (int i = 0; i < 50; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        // Method called when user is done editing a cell in the GUI
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Take the coordinate information from the event
            // With this location, we can see what the updated text value at that location 
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            string text = dataGridView1.Rows[row].Cells[column].Value.ToString();

            // Call a method created in Spreadsheet to further decouple UI and Spreadsheet interaction
            sheet.EndEdit(row, column, text);
        
        }

        // Event handler to update UI's value in appropriate location
        public void SheetUpdate(object sender, PropertyChangedEventArgs e)
        {
            SpreadsheetCell updatedCell = (SpreadsheetCell)sender;
            string updatedValue = e.PropertyName;

            dataGridView1.Rows[updatedCell.getRowIndex()].Cells[updatedCell.getColumnIndex()].Value = updatedValue;
        }

        // Method called when the user clicks the Demo button in the GUI
        private void button1_Click(object sender, EventArgs e)
        {
            Random rowNumber = new Random();
            Random columnNumber = new Random();
            
            int tempRow, tempColumn;

            for (int i = 0; i < 50; i++)
            {
                tempRow = rowNumber.Next(50);
                tempColumn = columnNumber.Next(26);
                DataGridViewCellEventArgs demo = new DataGridViewCellEventArgs(tempColumn, tempRow);
                dataGridView1.Rows[tempRow].Cells[tempColumn].Value = "Hello World!";                
                dataGridView1_CellEndEdit(this, demo);
            }

            for (int i = 0; i < 50; i++)
            {
                DataGridViewCellEventArgs demo = new DataGridViewCellEventArgs(1, i);
                dataGridView1.Rows[i].Cells[1].Value = "This is cell B" + (i + 1);
                dataGridView1_CellEndEdit(this, demo);
            }

            for (int i = 0; i < 50; i++)
            {
                DataGridViewCellEventArgs demo = new DataGridViewCellEventArgs(0, i);
                dataGridView1.Rows[i].Cells[0].Value = "= B" + (i + 1);
                dataGridView1_CellEndEdit(this, demo);
            }
        }
    }
}
