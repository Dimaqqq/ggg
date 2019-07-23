using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1[i, 0].Value = random.Next(-40, 40);
            dataGridView1.ClearSelection();
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(textBox1.Text, out n))
            {
                dataGridView1.ColumnCount = n;
                dataGridView1.RowCount = 1;
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Columns[i].HeaderText = i.ToString();
                    dataGridView1.Columns[i].Width = 35;
                }
                button3.Enabled = true;
            }
            else
                MessageBox.Show("Ошибка", "Неправильное количество элементов"); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            int[] arr = new int[dataGridView1.ColumnCount];
            try
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = int.Parse(dataGridView1[i, 0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int summa = int.MinValue;
            int index = 0;
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] + arr[i + 1] > summa)
                {
                    summa = arr[i] + arr[i + 1];
                    index = i;
                }
            dataGridView1.ClearSelection();
            dataGridView1[index, 0].Selected = true;
            dataGridView1[index + 1, 0].Selected = true;
            label2.Text = "Макс сум сусідніх елементів " + summa.ToString();
            label2.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            int[] arr = new int[dataGridView1.ColumnCount];
            try
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = int.Parse(dataGridView1[i, 0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int summa = int.MinValue;
            int index = 0;
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] > summa)
                {
                    summa = arr[i];
                    index = i;
                }
            
            
            label3.Text = "Макс елемент " + summa.ToString();
            label3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            int[] arr = new int[dataGridView1.ColumnCount];
            try
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = int.Parse(dataGridView1[i, 0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int summa = int.MaxValue;
            int index = 0;
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] < summa)
                {
                    summa = arr[i];
                    index = i;
                }
            

            label4.Text = "Мін елемент " + summa.ToString();
            label4.Visible = true;
        }
    }
}
