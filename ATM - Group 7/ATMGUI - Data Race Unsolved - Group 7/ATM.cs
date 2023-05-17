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
using static ATM.BankComputer;

namespace ATM
{
    public partial class ATM : Form
    {
        //Declaration of global variables
        public string stage = "start";
        public string text;
        public int errors = 0;
        public int arrayNum;
        public bool open;
        public int balance;
        string[] splitText;

        // id for number of threads
        public int threadID;

        // log to display what has been accessed
        public TextLog tlog;

        // used to safely set the textlog's text field
        private delegate void SetTextLogDelegate(String text);

        // local referance to the array of accounts
        private Account[] ac;

        // this is a referance to the account that is being used
        public Account activeAccount = null;
        public ATM(Account[] ac, TextLog log)
        {
            InitializeComponent();
            tlog = log;
            this.threadID = log.getThreadCounter();
            this.ac = ac;
            // an infanite loop to keep the flow of controll going on and on\
            //ask for account number and store result in activeAccount (null if no match found)
            this.displayText.Text = "Enter the account number: ";
            this.FormClosing += new FormClosingEventHandler(ATM_FormClosing);
        }

        //Finds bank account using input param
        private Account findAccount(String text)
        {
            int input = Convert.ToInt32(text);
            for (int i = 0; i < this.ac.Length; i++)
            {
                if (ac[i]
                        .getAccountNum() == input)
                {
                    arrayNum = i;
                    return ac[i];
                }
            }
            return null;
        }

        //Activated when Confirm button pressed
        public void confirmBtn_Click(object sender, EventArgs e)
        {
            switch (stage)
            {
                //Initial stage for getting/checking account details
                case "start":
                    splitText = this.displayText.Text.Split(':');
                    if (splitText[1] == " ")
                    { //User entered 0/invalid value
                        this.displayText.Text = "Enter valid input: ";
                        break;
                    }
                    activeAccount = findAccount(splitText[1]);
                    if (activeAccount != null)
                    { //Valid account number
                        this.displayText.Text = "Account found - Enter pin: ";
                        stage = "continue";
                    }
                    else
                    { //Invalid account number
                        this.displayText.Text = "Account not found - enter account number again: ";
                    }
                    break;

                //Main stage
                case "continue":
                    splitText = this.displayText.Text.Split(':');
                        if(splitText[0] == "Enter the account number")
                        {
                           break;
                        } else if(splitText[1] == " " | splitText[1] == "")
                        { //User entered 0/invalid value
                          //BUG NOTE: If confirm button pressed at menu
                          //Code will break here as splitText[1] is out of bounds
                            this.displayText.Text = "Enter valid input: ";
                            break;
                        }

                    int textInt = Convert.ToInt32(splitText[1]);
                    //Checks if this is error number 3
                    //Will block account permenantly if true
                    if (errors == 3)
                    {
                        setTextLog(
                            "ATM THREAD: " + threadID + Environment.NewLine +
                            "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                            Environment.NewLine + "Action: " + "Account blocked" +
                            Environment.NewLine);

                        BankComputer.ac[arrayNum].active = false;
                        errors = 0;
                        this.Close();
                    }
                    if (activeAccount.active != false)
                    { //Pin is correct
                        if (activeAccount.checkPin(textInt))
                        {
                            this.displayText.Text = "Pin correct - Choose option...";
                            balance = activeAccount.getBalance();
                            setTextLog(
                                "ATM THREAD: " + threadID + Environment.NewLine +
                                "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                                Environment.NewLine + "Action: " + "Accessed" +
                                Environment.NewLine + "Balance: " + Convert.ToString(balance) +
                                Environment.NewLine);

                            open = true;
                            errors = 0;
                        }
                        else
                        { //Pin is incorrect
                            this.displayText.Text = "Pin incorrect, re-enter the pin: ";
                            errors++;
                        }
                    }
                    else
                    { //If account is blocked, this code is run
                        this.displayText.Text = "Error - Card blocked...";
                        break;
                    }
                    break;

                //Withdraw case
                case "withdraw":
                    splitText = this.displayText.Text.Split(':');
                    if (splitText[1] == " ")
                    { //User entered 0/invalid value
                        this.displayText.Text = "Enter valid input: ";
                        break;
                    }
                    textInt = Convert.ToInt32(splitText[1]);
                    if (splitText[1] == " ")
                    { //User entered 0/invalid value
                        this.displayText.Text = "Enter valid amount: ";
                        break;
                    }
                    if (textInt > BankComputer.ac[arrayNum].balance)
                    { //User entered amount higher than balance amount
                        this.displayText.Text = "Insufficient Funds...";
                        break;
                    }
                    else
                    {
                        //Updates local balance variable
                        balance -= textInt;
                        setTextLog(
                            "ATM THREAD: " + threadID + Environment.NewLine +
                            "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                            Environment.NewLine + "Action: " + "Withdrawal" +
                            Environment.NewLine + "Amount: " + splitText[1] +
                            Environment.NewLine + "Balance: " + Convert.ToString(balance) +
                            Environment.NewLine);
                        //Transaction is finished
                        //Updates the computer variable
                        //Seperate ATM will still be using its local variable
                        //Allowing for a data race problem
                        BankComputer.ac[arrayNum].balance = balance;
                        this.displayText.Text =
                            "Balance left - " + balance + Environment.NewLine +
                            "Session closed..." + Environment.NewLine +
                            "Enter an account number: ";
                        setTextLog(
                            "ATM THREAD: " + threadID + Environment.NewLine +
                            "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                            Environment.NewLine + "Action: " + "Account closed" +
                            Environment.NewLine + "Balance: " + Convert.ToString(balance) +
                            Environment.NewLine);
                        //Sets stage back to start
                        //For user to enter details
                        //BUG NOTE: user can still use side buttons which access account details 
                        stage = "start";
                    }
                    break;

                //Withdraw case
                case "deposit":
                    splitText = this.displayText.Text.Split(':');
                    if (splitText[1] == " ")
                    { //User entered 0/invalid value
                        this.displayText.Text = "Enter valid input: ";
                        break;
                    }
                    textInt = Convert.ToInt32(splitText[1]);
                    if (textInt < 0)
                    {
                        this.displayText.Text = "Enter a value: ";
                    }
                    else
                    {
                        //Updates local balance variable
                        balance += textInt;
                        setTextLog(
                            "ATM THREAD: " + threadID + Environment.NewLine +
                            "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                            Environment.NewLine + "Action: " + "Accessed" +
                            Environment.NewLine + "Amount: " + splitText[1] +
                            Environment.NewLine + "Balance: " + Convert.ToString(balance) +
                            Environment.NewLine);
                        //Transaction is finished
                        //Updates the computer variable
                        //Seperate ATM will still be using its local variable
                        //Allowing for a data race problem
                        BankComputer.ac[arrayNum].balance = balance;
                        this.displayText.Text =
                            "Balance left - " + balance + Environment.NewLine +
                            "Session closed..." + Environment.NewLine +
                            "Enter an account number: ";
                        setTextLog(
                            "ATM THREAD: " + threadID + Environment.NewLine +
                            "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                            Environment.NewLine + "Action: " + "Account closed" +
                            Environment.NewLine + "Balance: " + Convert.ToString(balance) +
                            Environment.NewLine);
                        //Sets stage back to start
                        //For user to enter details
                        //BUG NOTE: user can still use side buttons
                        //which can access/change account variables 
                        stage = "start";
                    }
                    break;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e) { this.Close(); }

        // Deposit
        private void deposit_Click(object sender, EventArgs e)
        {
            if (open == true)
            { //Account accessed
              //Ask for deposit amount
                stage = "deposit";
                this.displayText.Text = "Enter how much you want to deposit:";
            }
            else
            { //No account accessed
                this.displayText.Text = "Insert details first: ";
            }
        }

        // Balance
        private void balance_Click(object sender, EventArgs e)
        {
            if (open == true)
            { //Account accessed
                this.displayText.Text =
                    "Your balance is: " + BankComputer.ac[arrayNum].balance;
                setTextLog("ATM THREAD: " + threadID + Environment.NewLine +
                           "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                           Environment.NewLine + "Action: " + "Balance Requested" +
                           Environment.NewLine + "Balance: " +
                           BankComputer.ac[arrayNum].balance + Environment.NewLine);
            }
            else
            {
                this.displayText.Text = "Insert details first: ";
            }
        }

        // Withdraw
        private void withdraw_Click(object sender, EventArgs e)
        {
            if (open == true)
            { //Account accessed
              //Ask for deposit amount
                stage = "withdraw";
                this.displayText.Text = "Enter how much you want to withdraw:";
            }
            else
            { //No account accessed
                this.displayText.Text = "Insert details first: ";
            }
        }

        /**https://docs.microsoft.com/en-gb/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls?view=netframeworkdesktop-4.8
         * Method to safely call the update text method of the log
         * using the "SetTextLogDelegate" delegate.
         * InvokeRequired compares the thread IDs of the curren thread
         * and the thread in which the original textlog variable resides - in this
         * case they are not in the same thread so InvokeRequired returns true. Using
         * the previously defined delegate it passes the delegate into the Invoke
         * method of the variable of type Textlog, tlog.
         */
        private void setTextLog(String text)
        {
            if (this.tlog.InvokeRequired)
            {
                SetTextLogDelegate d = new SetTextLogDelegate(setTextLog);
                tlog.Invoke(d, new object[] { text });
            }
            else
            {
                tlog.updateText(text);
            }
        }

        // Code that is run before closing a form
        private void ATM_FormClosing(Object sender, FormClosingEventArgs e)
        {
            setTextLog("Closed ATM Thread " + threadID);
        }

        private void ATM_Load(object sender, EventArgs e) {}

        private void insert1_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "1";
        }
        private void insert2_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "2";
        }

        private void insert3_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "3";
        }

        private void insert4_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "4";
        }

        private void insert5_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "5";
        }

        private void insert6_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "6";
        }

        private void insert7_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "7";
        }

        private void insert8_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "8";
        }

        private void insert9_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "9";
        }

        private void insert0_Click(object sender, EventArgs e)
        {
            this.displayText.Text += "0";
        }

        //Clears user input
        private void clearBtn_Click(object sender, EventArgs e)
        {
            splitText = this.displayText.Text.Split(':');
            this.displayText.Text = splitText[0] + ": ";
        }
    }
}