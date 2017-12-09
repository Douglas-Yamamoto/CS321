using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Xml;

namespace CptS321
{
    // Test
    public class Spreadsheet
    {
        int Rows;
        int Columns;
        Cell[,] array;
        public event PropertyChangedEventHandler CellPropertyChanged;

        // Populating the 2-d array of Cells
        // Subscribing to the SpreadsheetCell's PropertyChanged event
        public Spreadsheet(int rows, int columns)
        {
            this.array = new Cell[rows, columns];

            this.Rows = rows;
            this.Columns = columns;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Cell newCell = new Cell(i,j);
                    newCell.PropertyChanged += OnCellPropertyChanged;
                    array.SetValue(newCell, i, j);                    
                }
            }
        }

        // Creating a child class to the abstract base class, SpreadsheetCell
        private class Cell : SpreadsheetCell
        {
            public Cell(int row, int column) : base(row, column) {}
        }

        // Getter property for column count in the instance of the Spreadsheet
        public int ColumnCount
        {
            get
            {
                return this.Columns;
            }
        }
        // Getter property for row count in the instance of the Spreadsheet
        public int RowCount
        {
            get
            {
                return this.Rows;
            }
        }
        // Method to get a specific cell that exists 'below' the GUI
        public SpreadsheetCell GetCell(int row, int column)
        {
            if (((row >=0) & (row < Rows)) & ((column >= 0) & (column < Columns)))
            {
                return (SpreadsheetCell) array.GetValue(row, column);
            }

            else
            {
                return null;
            }
        }

        public void EndEdit(int row, int column, string text)
        {
            // Get the proper cell and changed the text/value if appropriate
            this.GetCell(row, column).CellText = text;
        }
        
        // Event handler when SpreadsheetCell is changed
        public void OnCellPropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            // Value is what is shown in form
            // Text is the formula held in cell
            string text = e.PropertyName;
            SpreadsheetCell currentCell = (SpreadsheetCell) sender;

            Pull(text, currentCell);

            // Raising the event that a cell value has been changed
            CellPropertyChanged(currentCell, new PropertyChangedEventArgs(currentCell.ValueText));
            return;
        }

        // Pull function
        private void Pull (string text, SpreadsheetCell currentCell)
        {
            string pull;
            string pulledValue;
            int pullColumn;
            int pullRow;
            int[] rowDigits = new int[2];

            if (text[0] == '=')
            {
                pull = text.Substring(1, text.Length - 1);
                pull = pull.Trim();
                pullColumn = char.ToUpper(pull[0]) - 65;

                pull = pull.Substring(1, pull.Length - 1);

                if (pull.Length > 1)
                {
                    for (int i = 0; i < pull.Length; i++)
                    {
                        rowDigits[i] = pull[i] - 48;
                    }

                    pullRow = 10 * rowDigits[0];
                    pullRow += rowDigits[1] - 1;
                }

                else
                {
                    pullRow = pull[0] - 49;
                }

                pulledValue = this.GetCell(pullRow, pullColumn).CellText;

                // If the pulled cell is also pulling from another cell, keep following
                if (pulledValue[0] == '=')
                {
                    Pull(pulledValue, currentCell);
                }
                // End condition to bring out    
                else
                {
                    currentCell.ValueText = pulledValue;
                }
            }

            else
            {
                currentCell.ValueText = text;
            }
            return;
        }

        public void Save()
        {
            // Need stream as the parameter
            // Only write data from cells that have one or more non-default properties.
            // This means that if a cell hasn't been changed in any way then you don't need to write data for it to the file

            FileStream fileStream = new FileStream("..//..//..//test.xml", FileMode.Create);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.CloseOutput = false;
            XmlWriter writer = XmlWriter.Create(fileStream, settings);

            writer.WriteStartElement("Spreadsheet");
            foreach (Cell i in this.array)
            {
                if (i.CellEdited == true)
                {
                    char row = (char)(65 + i.getRowIndex());
                    string column = i.getColumnIndex().ToString();

                    writer.WriteStartElement("Cell");
                    writer.WriteAttributeString("Location", row.ToString() + column);
                        writer.WriteStartElement("Text");
                        writer.WriteAttributeString("Text", i.CellText);
                            writer.WriteStartElement("Value");    
                            writer.WriteAttributeString("Value", i.ValueText);
                            writer.WriteEndElement();
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
            fileStream.Close();
        }

        public void Load()
        {
            // Need stream as the parameter
            // Clear all spreadsheet data before loading file data.
            // The load from file action is not a merge with existing content
            // Make sure formulas are properly evaluated after loading
            // Need to make sure that it can sift through extra or out of order tags 
        }
    }
}
