using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace PetrolStation
{
    public partial class Records : MetroFramework.Forms.MetroForm
    {
        List<Record> rcdList = new List<Record>();
        public Records()
        {
            InitializeComponent();

            if (File.Exists(RecordsFile.filePath))
            {
                try
                {

                    //reading file
                    using (StreamReader str = new StreamReader(RecordsFile.filePath))
                    {
                        string line;
                        while ((line = str.ReadLine()) != null)
                        {
                            if (line != "")
                            {
                                rcdList.Add(new Record());
                                rcdList.Last<Record>().type = line.Substring(0, line.IndexOf(','));
                                line = line.Substring(line.IndexOf(',') + 1);
                                rcdList.Last<Record>().litres = line.Substring(0, line.IndexOf(','));
                                line = line.Substring(line.IndexOf(',') + 1);
                                rcdList.Last<Record>().pump = line;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("File not Found!");
                }
                for (int c = 0; c < rcdList.Count; c++)
                {
                    metroGrid1.Rows.Add();
                    metroGrid1.Rows[c].Cells[0].Value = rcdList.ElementAt<Record>(c).type;
                    metroGrid1.Rows[c].Cells[1].Value = rcdList.ElementAt<Record>(c).litres;
                    metroGrid1.Rows[c].Cells[2].Value = rcdList.ElementAt<Record>(c).pump;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //if back to station button is clicked
        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            PetrolPump f1 = new PetrolPump();
        }
    }
}