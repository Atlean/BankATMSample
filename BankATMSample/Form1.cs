namespace BankATMSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            currentacount.balance = 300m; //Decimal value
            InitializeComponent();
        }
        Current_Account currentacount = new Current_Account();
        private void button3_Click(object sender, EventArgs e)
        {
            string result = currentacount.Withdraw(numericUpDown1.Value);
            MessageBox.Show(result);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = currentacount.Deposit(numericUpDown1.Value);
            MessageBox.Show(result);
        }

        //After the form design you can use the atm.
    }
}
