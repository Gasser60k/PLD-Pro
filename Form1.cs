using com.calitha.goldparser;
using System.Configuration;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        MyParser p;
        public Form1()
        {
            InitializeComponent();
            p = new MyParser("PrincePL.cgt", Rtb_code, Rtb_debugger);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Rtb_code_TextChanged(object sender, EventArgs e)
        {
        }


        private void btn_debug_Click(object sender, EventArgs e)
        {
            Rtb_code.SelectAll();
            Rtb_code.SelectionBackColor = Color.FromArgb(80, 80, 80);
            Rtb_debugger.Clear();
            p.Parse(Rtb_code.Text);
        }
    }
}