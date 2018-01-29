namespace Delegates
{
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

        private void counterBox1_TextChanged(object sender, System.EventArgs e)
        {
            this.textBox1.Text = this.counterBox1.Text;
            this.textBox2.Text = this.counterBox1.Counter.ToString();
        }
        ////теперь надо сделать таки тот калькулятор. А затем уже делать шаблоны.


    }
}
