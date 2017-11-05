using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataModeling
{
    public partial class TableParameters : Form
    {
        private Dictionary<String, double> valueMap = new Dictionary<String, double>();
        private DistributionStrategy strategy;

        public TableParameters(List<String> parameterNames, DistributionStrategy strategy)
        {
            InitializeComponent();
            dataGridView1.Rows.Add("xBegin");            
            dataGridView1.Rows.Add("xEnd");
            dataGridView1.Rows.Add("Dots number");
            dataGridView1.Rows.Add("deviation");
            foreach (string parameterName in parameterNames)
            {
                dataGridView1.Rows.Add(parameterName);
            }
            this.strategy = strategy;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!fieldsAreReady())
            {
                MessageBox.Show("Fill all fields");
                return;
            }
            List<string> errors = new List<string>(); 
            validateParameters(errors);
            if (errors.Count != 0)
            {
                valueMap.Clear();
                String message = "";
                foreach(String error in errors)
                {
                    message += error + "\n"; 
                }
                MessageBox.Show(message);
                return;
            }
            this.DialogResult = DialogResult.OK;

        }

        public Dictionary<String, double> getValueMap()
        {
            return valueMap;
        }

        private void validateParameters(List<string> errors)
        {         
            double xBegin = validateDouble("xBegin", dataGridView1.Rows[0].Cells[1].Value, -50000, 50000, errors);
            valueMap.Add("xBegin", xBegin);
            double xEnd = validateDouble("xEnd", dataGridView1.Rows[1].Cells[1].Value, -50000, 50000, errors);
            valueMap.Add("xEnd", xEnd);
            if (errors.Count == 0 && xBegin >= xEnd)
            {
                errors.Add("xEnd must be bigger than xEnd.");               
            }
            valueMap.Add("Dots number", validateInt("Dots number", dataGridView1.Rows[2].Cells[1].Value, 2, 2000000, errors));
            valueMap.Add("deviation", validateDouble("deviation", dataGridView1.Rows[3].Cells[1].Value, 0.0, 1.0, errors));          
            for(int i = 4; i < dataGridView1.Rows.Count; i++)
            {
                string name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                valueMap.Add(name, strategy.validateParametr(name, dataGridView1.Rows[i].Cells[1].Value, errors));              
            }
        }
       
        private double validateInt(string name, object value, int begin, int end, List<string> errors)
        {
            double convertedValue = 0.0;
            try
            {
                convertedValue = Convert.ToInt32(value); 
                if(convertedValue < begin || convertedValue > end)
                {
                    errors.Add(name + " must be in range [" + begin + ";" + end + "]");
                }
            }
            catch (OverflowException)
            {
                errors.Add(value + " is outside the range of the Int32 type.");                
            }
            catch (FormatException)
            {
                errors.Add(value + " is not an integer.");                              
            }
            return convertedValue;
        }

        private double validateDouble(string name, object value, double begin, double end, List<string> errors)
        {
            double convertedValue = 0.0;
            try
            {
                convertedValue = Convert.ToDouble(value);
                if(convertedValue < begin || convertedValue > end)
                {
                    errors.Add(name + " must be in range [" + begin + ";" + end + "]");                    
                }
                
            }
            catch (OverflowException)
            {
                errors.Add(value + " is outside the range of the Int32 type.");                
            }
            catch (FormatException)
            {
                errors.Add(value + " is not an integer.");               
            }
            return convertedValue;
        }

     
        private bool fieldsAreReady()
        {
            bool ready = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString().Equals(""))
                {
                    ready = false;
                    break;
                }
            }
            return ready;
        }

       
    }
}
