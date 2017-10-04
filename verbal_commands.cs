//This script allows a user to call out functions verbally and have them executed using the Windows SAPI
//The functions that can be executed are:  "start bot", "go home", and "follow bot"

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Create a new SpeechRecognitionEngine instance.
            SpeechRecognizer recognizer = new SpeechRecognizer();

            // Create a simple grammar that recognizes "red", "green", or "blue".
            Choices colors = new Choices();
            colors.Add(new string[] { "start bot", "go home", "follow bot" });

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar(gb);
            recognizer.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
        }

        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
           
            if (e.Result.Text == "start bot")
                startBot();
            if (e.Result.Text == "follow bot")
                followBot();
            if (e.Result.Text == "go home")
                goHome();
        }
        void startBot()
        {
            MessageBox.Show("TableBot Started");
        }
        void followBot()
        {
            MessageBox.Show("TableBot Following");
        }
        void goHome()
        {
            MessageBox.Show("TableBot Going Home");
        }
    }
}
