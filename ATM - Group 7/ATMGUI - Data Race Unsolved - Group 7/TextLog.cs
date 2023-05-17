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
    public class TextLog : TextBox
    {
        int threadCounter;

        public TextLog()
        {
            this.ReadOnly = true;
            this.Multiline = true;
            this.ScrollBars = ScrollBars.Vertical;
            this.WordWrap = true;
            this.Width = 1000;
        }

        public void updateText(String s)
        {
            this.AppendText(s);
            this.AppendText(Environment.NewLine);
        }

        public void logStart()
        {
            updateText("Started ATM Thread " + threadCounter);
        }

        public void logEnd(int id)
        {
            String textID = id.ToString();
            updateText("Ended Thread " + textID);
            this.threadCounter = 0;
        }

        public void incrementThreadCounter()
        {
            this.threadCounter += 1;
        }

        public int getThreadCounter()
        {
            return this.threadCounter;
        }
    }
}
