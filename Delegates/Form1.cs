namespace Delegates
{
    using System;
    using System.Diagnostics;
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

        private void Button1Click(object sender, EventArgs e)
        {
            var calc = new Calculator();

            /*calc.DefineOperation1("%", (d, d1) => { return d % d1;});//Неоднозначный вызов метода, типа подходит и тому, и тому, что не удивительно.
                        calc.DefineOperation1("%", delegate(double d, double d1) { return d % d1; });//инициализируем новый делегат анонимным методом. Опять же, неоднозначный вызов.
                        calc.DefineOperation1("%", Body);//и снова неоднозначный вызов.*/

            tbRes.Text = calc.PerformOperation(tbOp.Text, double.Parse(tbA.Text), double.Parse(tbB.Text)).ToString();            
        }


        ////теперь надо сделать таки тот калькулятор. А затем уже делать шаблоны.
    }
}