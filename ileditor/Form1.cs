using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ileditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public string IldasmPath { get { return @"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe"; } }
        public string IlasmPath { get { return @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe"; } }

        public string CurrentAsmPath { get; set; }

        public string ParameterILASM { get; set; }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                var path = fileSelector.FileName;

                int dllIdx = path.LastIndexOf(".dll");

                if(dllIdx > 0)
                {
                    ParameterILASM = "/dll";
                    this.CurrentAsmPath = path.Substring(0, dllIdx) + ".asm";
                }
                else
                {
                    ParameterILASM = "/exe";
                    this.CurrentAsmPath = path.Substring(0, path.LastIndexOf(".exe")) + ".asm";
                }
                


                Process info = Process.Start(this.IldasmPath, string.Format("\"{0}\" /out={1}",  path, this.CurrentAsmPath));
                info.WaitForExit();

                txtILCode.Text = File.ReadAllText(this.CurrentAsmPath);



            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(this.CurrentAsmPath, txtILCode.Text);

            Process info = Process.Start(this.IlasmPath, this.ParameterILASM + " " + this.CurrentAsmPath);
            info.WaitForExit();

            MessageBox.Show("Done!");
        }
    }
}
