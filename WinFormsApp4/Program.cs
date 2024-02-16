using System;
using System.Windows.Forms;

namespace WinFormsApp4
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    partial class Form1 : Form
    {
        private TextBox inputTextBox;
        private Button checkButton;
        private Label resultLabel;
        private System.ComponentModel.IContainer components = null;

        public Form1()
        {
            InitializeComponent();
        }

        private bool IsPrime(int num)
        {
            if (num <= 1)
                return false;
            if (num == 2)
                return true;
            if (num % 2 == 0)
                return false;

            int sqrt = (int)Math.Sqrt(num);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Prime Number Checker";

            // Создание текстового поля для ввода числа
            inputTextBox = new TextBox();
            inputTextBox.Location = new System.Drawing.Point(50, 50);
            inputTextBox.Size = new System.Drawing.Size(100, 25);
            this.Controls.Add(inputTextBox);

            // Создание кнопки для проверки числа
            checkButton = new Button();
            checkButton.Text = "Check";
            checkButton.Location = new System.Drawing.Point(50, 100);
            checkButton.Click += new EventHandler(checkButton_Click);
            this.Controls.Add(checkButton);

            // Создание метки для отображения результата
            resultLabel = new Label();
            resultLabel.Text = "";
            resultLabel.Location = new System.Drawing.Point(50, 150);
            resultLabel.Size = new System.Drawing.Size(200, 25);
            this.Controls.Add(resultLabel);
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(inputTextBox.Text, out n))
            {
                bool p = IsPrime(n);
                resultLabel.Text = p ? "True" : "False";
            }
            else
            {
                MessageBox.Show("Please enter a valid integer number.");
            }
        }
    }
}
