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

        public TableParameters(List<String> parameterNames)
        {
            InitializeComponent();
            foreach(string parameterName in parameterNames)
            {
                dataGridView1.Rows.Add(parameterName);
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                valueMap.Add(row.Cells[0].Value.ToString(), Convert.ToDouble(row.Cells[1].Value));
            }
        }

        public Dictionary<String, double> getValueMap()
        {
            return valueMap;
        }
    }
}
