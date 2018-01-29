namespace Delegates
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;

    //// что ж, я прозрел. Я осознал, насколько же обработчики событий - это делегаты.
    ////  OnLoad? Delegate. На него ж можно повесить даже не одну функцию, используюя +=.
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }


        private void Button1Click(object sender, System.EventArgs e)
        {
            var calc = new Calculator();
            tbRes.Text = calc.PerformOperation(tbOp.Text, double.Parse(tbA.Text), double.Parse(tbB.Text)).ToString();
        }
        ////теперь надо сделать таки тот калькулятор. А затем уже делать шаблоны.


    }

}
