using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logic.Models;
using Logic.Services;

namespace FrontEnd
{
    public partial class Main : Form
    {
        string path;
        public Main()
        {
            InitializeComponent();
        }

        private void FillDataGridView()
        {
            BinaryParser parser = new BinaryParser();
            Document document = parser.Read(path);

            var bindingList = new BindingList<Car>(document.Cars);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            
        }
            

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                FillDataGridView();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bindingList = new BindingList<Car>(document.Cars);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }
    }
}
