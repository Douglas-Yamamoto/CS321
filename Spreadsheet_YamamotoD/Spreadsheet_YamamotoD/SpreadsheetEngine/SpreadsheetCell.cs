using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SpreadsheetEngine
{
    public abstract class SpreadsheetCell : INotifyPropertyChanged
    {
        int RowIndex;
        int ColumnIndex;
        protected string Text;
        protected string Value;
        public event PropertyChangedEventHandler PropertyChanged;

        public SpreadsheetCell(int row, int column)
        {
            this.RowIndex = row;
            this.ColumnIndex = column;
        }

        public int getRowIndex()
        {
            return RowIndex;
        }

        public int getColumnIndex()
        {
            return ColumnIndex;
        }

        public string CellText
        {
            get 
            {
                return Text;
            }

            set
            {
                // If our new text is NOT the same as before, we call the method to change the text
                if (value != Text)
                {
                    this.Text = value;
                    
                    // Double check to ensure that no null pointer exception will occur 
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(Text));
                    }
                    
                }
            }
        }

        public string ValueText
        {
            get
            {
                return Value;
            }

            set
            {
                Value = value;
            }
        }

    }
}
