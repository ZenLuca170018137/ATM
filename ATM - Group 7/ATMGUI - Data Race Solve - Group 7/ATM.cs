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

        //Initialises semaphore object
        public static Semaphore semaphore = new Semaphore(1, 1);

        // id for number of threads
        public int threadID;

        // log to display what has been accessed
        public TextLog tlog;

        // used to safely set the textlog's text field
        private delegate void SetTextLogDelegate(String text);

        // local reference to the array of accounts
        private Account[] ac;

        // this is a reference to the account that is being used
        public Account activeAccount = null;

        //Initialises important variables
        public ATM(Account[] ac, TextLog log)
        {
            InitializeComponent();
            tlog = log;
            this.threadID = log.getThreadCounter();
            this.ac = ac;
            this.displayText.Text = "Enter your account number: ";
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
                    { //No input
                        this.displayText.Text = "Enter account number first: ";
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
                    if (splitText[0] == "Enter the account number")
                    {
                        break;
                    }
                    else if (splitText[1] == " " | splitText[1] == "")
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
                            setTextLog(
                                "ATM THREAD: " + threadID + Environment.NewLine +
                                "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                                Environment.NewLine + "Action: " + "Accessed" +
                                Environment.NewLine + "Balance: " +
                                BankComputer.ac[arrayNum].balance + Environment.NewLine);
                            balance = BankComputer.ac[arrayNum].balance;
                            open = true;
                            errors = 0;
                        }
                        else
                        { //Pin is incorrect
                            this.displayText.Text =
                                "Pin incorrect - press continue and re-enter the pin: ";
                            errors++;
                        }
                    }
                    else
                    { //If account is blocked, this code is run
                        this.displayText.Text = "Error - Card blocked";
                        break;
                    }
                    break;

                //Withdraw case
                case "withdraw":
                    splitText = this.displayText.Text.Split(':');
                    if (splitText[1] == " " | splitText[1] == "")
                    { //User entered 0/invalid value
                        this.displayText.Text = "Enter valid amount: ";
                        break;
                    }
                    textInt = Convert.ToInt32(splitText[1]);
                    
                    if (textInt > BankComputer.ac[arrayNum].balance)
                    { //User entered amount higher than balance amount
                        this.displayText.Text = "Insufficient Funds...";
                        break;
                    }
                    else
                    {
                        setTextLog(
                            "ATM THREAD: " + threadID + Environment.NewLine +
                            "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                            Environment.NewLine + "Action: " + "Withdraw - PENDING" +
                            Environment.NewLine + "Amount: " + splitText[1] +
                            Environment.NewLine + "Balance: " +
                            BankComputer.ac[arrayNum].balance + Environment.NewLine);
                    }
                    //Creates new thread
                    Thread t1 = new Thread(() => withdraw(textInt, splitText));
                    //Starts thread
                    t1.Start();
                    Thread.Sleep(10000);
                    //Displays balance after thread is closed
                    this.displayText.Text =
                        "Balance left:" + BankComputer.ac[arrayNum].balance;
/*                    setTextLog(
                        "ATM THREAD: " + threadID + Environment.NewLine +
                        "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                        Environment.NewLine + "Action: " + "UPDATED" + Environment.NewLine +
                        "Balance: " + BankComputer.ac[arrayNum].balance +
                        Environment.NewLine);*/
                    break;

                //Deposit case
                case "deposit":
                    splitText = this.displayText.Text.Split(':');
                    if (splitText[1] == " " | splitText[1] == "")
                    { //User entered 0/invalid value
                        this.displayText.Text = "Enter valid amount: ";
                        break;
                    }
                    textInt = Convert.ToInt32(splitText[1]);
                    if (textInt < 0)
                    { //User entered 0/invalid value
                        this.displayText.Text = "Enter a value: ";
                        break;
                    }
                    else
                    {
                        setTextLog(
                            "ATM THREAD: " + threadID + Environment.NewLine +
                            "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                            Environment.NewLine + "Action: " + "Deposit - PENDING" +
                            Environment.NewLine + "Amount: " + splitText[1] +
                            Environment.NewLine + "Balance: " +
                            BankComputer.ac[arrayNum].balance + Environment.NewLine);
                    }
                    //Creates new thread
                    Thread t2 = new Thread(() => Depo(textInt, splitText));
                    //Starts new thread
                    t2.Start();
                    Thread.Sleep(10000);
                    this.displayText.Text =
                        "Balance left:" + BankComputer.ac[arrayNum].balance;
/*                    setTextLog(
                        "ATM THREAD: " + threadID + Environment.NewLine +
                        "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                        Environment.NewLine + "Action: " + "UPDATED" + Environment.NewLine +
                        "Balance: " + BankComputer.ac[arrayNum].balance +
                        Environment.NewLine);*/
                    break;
            }
        }

        //Withdraw thread
        private void withdraw(int textInt, string[] splitTextWithdraw)
        {
            try
            {
                setTextLog("WITHDRAW THREAD " + threadID + " WAITING...");
                //Attempts to proceed
                semaphore.WaitOne();
                setTextLog("WITHDRAW THREAD " + threadID + " STARTS...");
                //Updates balance
                BankComputer.ac[arrayNum].balance =
                BankComputer.ac[arrayNum].balance - textInt;
                setTextLog("PROCESSED - WITHDRAW THREAD " + threadID + " SLEEP...");
                //Pauses thread for 10s to allow for additional outside transaction
                Thread.Sleep(10000);
            }
            finally
            {
                setTextLog("WITHDRAW THREAD " + threadID + " RELEASING..." +
                           Environment.NewLine);
                setTextLog(
                        "ATM THREAD: " + threadID + Environment.NewLine +
                        "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                        Environment.NewLine + "Action: " + "UPDATED" + Environment.NewLine +
                        "Balance: " + BankComputer.ac[arrayNum].balance +
                        Environment.NewLine);
                //Releases the thread, allows next thread to proceed
                semaphore.Release();
            }
        }

        //Deposit thread
        private void Depo(int textInt, string[] splitTextDeposit)
        {
            try
            {
                setTextLog("DEPOSIT THREAD " + threadID + " WAITING...");
                //Attempts to proceed
                semaphore.WaitOne();
                setTextLog("DEPOSIT THREAD " + threadID + " STARTS...");
                //Updates balance
                BankComputer.ac[arrayNum].balance =
                    BankComputer.ac[arrayNum].balance + textInt;
                setTextLog("PROCESSED - ATM DEPOSIT THREAD " + threadID + " SLEEP...");
                //Pauses thread for 10s to allow for additional outside transaction
                Thread.Sleep(10000);
                /*                setTextLog("ATM THREAD: " + threadID + Environment.NewLine +
                                           Environment.NewLine +
                                           "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                                           Environment.NewLine + "Balance: " +
                                           BankComputer.ac[arrayNum].balance + Environment.NewLine);
                            }*/
            }
            finally
            {
                setTextLog("DEPOSIT THREAD" + threadID + " RELEASING...");
                setTextLog(
                        "ATM THREAD: " + threadID + Environment.NewLine +
                        "Account: " + Convert.ToString(activeAccount.getAccountNum()) +
                        Environment.NewLine + "Action: " + "UPDATED" + Environment.NewLine +
                        "Balance: " + BankComputer.ac[arrayNum].balance +
                        Environment.NewLine);
                //Releases the thread, allows next thread to proceed
                semaphore.Release();
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            // BankComputer.ac[arrayNum].balance = balance;
            this.Close();
        }

        // Allows for Deposit
        private void deposit_Click(object sender, EventArgs e)
        {
            if (open == true)
            {
                stage = "deposit";
                this.displayText.Text = "Enter how much you want to deposit:";
            }
            else
            {
                this.displayText.Text = "Insert details first: ";
            }
        }

        // Displays Balance
        private void balance_Click(object sender, EventArgs e)
        {
            if (open == true)
            {
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

        // Allows for Withdraw
        private void withdraw_Click(object sender, EventArgs e)
        {
            if (open == true)
            {
                stage = "withdraw";
                this.displayText.Text = "Enter how much you want to withdraw:";
            }
            else
            {
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
            setTextLog("Ended ATM Thread " + threadID);
            // tlog.logEnd(threadID);
        }

        private void ATM_Load(object sender, EventArgs e) { }

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

        //Clears the user input
        private void clearBtn_Click(object sender, EventArgs e)
        {
            splitText = this.displayText.Text.Split(':');
            this.displayText.Text = splitText[0] + ": ";
        }
    }
}
