using Backprop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Car_Evaluation_Application
{
    public partial class Form1 : Form
    {
        NeuralNet neuralNet;
        double[,] data = new double[,] {
            {1, 1, 0, 0, 0, 0, 0},
            {1, 1, 0, 0, 0, 0.5, 0},
            {1, 1, 0, 0, 0, 1, 0},
            {1, 1, 0, 0, 0.5, 0, 0},
            {1, 1, 0, 0, 0.5, 0.5, 0},
            {1, 1, 0, 0, 0.5, 1, 0},
            {1, 1, 0, 0, 1, 0, 0},
            {1, 1, 0, 0, 1, 0.5, 0},
            {1, 0.66, 0, 0.5, 0, 1, 0.33},
            {1, 0.66, 0, 0.5, 0.5, 1, 0.33},
            {1, 0.66, 0, 0.5, 1, 0.5, 0.33},
            {1, 0.66, 0, 0.5, 1, 1, 0.33},
            {1, 0.66, 0, 1, 0.5, 1, 0.33},
            {1, 0.66, 0, 1, 1, 0.5, 0.33},
            {1, 0.66, 0, 1, 1, 1, 0.33},
            {1, 0.66, 0.5, 0.5, 0, 1, 0.33},
            {0.33, 0, 0, 0.5, 1, 1, 0.66},
            {0.33, 0, 0, 0.5, 0.5, 1, 0.66},
            {0.33, 0, 0, 0.5, 1, 0.5, 0.66},
            {0.33, 0, 0, 1, 0.5, 1, 0.66},
            {0.33, 0, 0, 1, 1, 0.5, 0.66},
            {0.33, 0, 0.5, 4, 0, 1, 0.66},
            {0.33, 0, 0.5, 4, 0.5, 1, 0.66},
            {0.33, 0, 0.5, 1, 0, 1, 0.66},
            {0.33, 0, 0.5, 1, 0.5, 1, 1},
            {0.33, 0, 0.5, 1, 1, 1, 1},
            {0.33, 0, 1, 4, 0.5, 1, 1},
            {0.33, 0, 1, 4, 1, 1, 1},
            {0.33, 0, 1, 1, 0.5, 1, 1},
            {0.33, 0, 1, 1, 1, 1, 1},
            {0.33, 0, 1, 4, 0.5, 1, 1},
            {0.33, 0, 1, 1, 1, 1, 1}
        };
        public Form1()
        {
            InitializeComponent();
            neuralNet = new NeuralNet(6, 10, 1);
        }

        private void trainbtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                neuralNet.setInputs(0, data[i, 0]);
                neuralNet.setInputs(1, data[i, 1]);
                neuralNet.setInputs(2, data[i, 2]);
                neuralNet.setInputs(3, data[i, 3]);
                neuralNet.setInputs(4, data[i, 4]);
                neuralNet.setInputs(5, data[i, 5]);
                neuralNet.setDesiredOutput(0, data[i, 6]);
                neuralNet.learn();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            neuralNet.setInputs(0, Convert.ToDouble(pricetxt.Text));
            neuralNet.setInputs(1, Convert.ToDouble(mainttxt.Text));
            neuralNet.setInputs(2, Convert.ToDouble(doortxt.Text));
            neuralNet.setInputs(3, Convert.ToDouble(persontxt.Text));
            neuralNet.setInputs(4, Convert.ToDouble(lugtxt.Text));
            neuralNet.setInputs(5, Convert.ToDouble(safetytxt.Text));
            neuralNet.run();
            outputtxt.Text = "" + neuralNet.getOuputData(0);
        }
    }
}
