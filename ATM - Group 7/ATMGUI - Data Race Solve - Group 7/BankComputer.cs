using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ATM
{
    public partial class BankComputer : Form
    {
        public TextLog textlog = new TextLog();
        public static Account[] ac = new Account[3];
        public ATM atm;

        public BankComputer()
        {
            InitializeComponent();

            textlog.Size = new Size(350, 300);
            textlog.Location = new Point(400, 30);
            Controls.Add(textlog);

            ac[0] = new Account(300, 1111, 111111,true);
            ac[1] = new Account(750, 2222, 222222, true);
            ac[2] = new Account(3000, 3333, 333333, true);

            //atm = new ATM(ac);
        }



        public class Account
        {
            //the attributes for the account
            public int balance;
            private int pin;
            private int accountNum;
            public bool active;

            // a constructor that takes initial values for each of the attributes (balance, pin, accountNumber)
            public Account(int balance, int pin, int accountNum, bool active)
            {
                this.balance = balance;
                this.pin = pin;
                this.accountNum = accountNum;
                this.active = active;
            }

            //getter and setter functions for balance
            public int getBalance()
            {
                return balance;
            }
            public void setBalance(int newBalance)
            {
                this.balance = newBalance;
            }
            public int getAccountNum()
            {
                return accountNum;
            }
            public Boolean decrementBalance(int amount)
            {
                if (this.balance > amount)
                {
                    balance -= amount;
                    return true;
                }
                else
                {
                    return false;
             
                }

            }
            public Boolean checkPin(int pinEntered)
            {
                if (pinEntered == pin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }







        private void button1_Click(object sender, EventArgs e)
        {
            newATM();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newATM();
        }

        public void newATM()
        {
            textlog.incrementThreadCounter();
            textlog.logStart();

            //https://stackoverflow.com/questions/47438631/c-sharp-open-form-in-a-new-thread-or-task
            Thread atmThread = new Thread(() =>
        {
            Application.Run(new ATM(ac, textlog));
        });
            atmThread.Start();
        }

        private void BankComputer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

/*        private void button3_Click(object sender, EventArgs e)
        {
            //newATM.atmThread.Abort();
        }*/
    }
}
