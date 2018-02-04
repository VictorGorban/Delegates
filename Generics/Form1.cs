using System.Linq;

namespace Generics
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;


    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tb = TextField;//короче, textBox

            var list = new MyGenListUnique <int>();
            var countAdded = list.AddRange(new []{0,1,2,3,4,5,6,7});
            tb?.AppendText(list.ToString()+Environment.NewLine);
            list.AddAfter(item: 5, after: 7); //{0,1,2,3,4,5,6,7}
            list.AddAfter(5, 3); // {0,1,2,3,4,5,6,7} // не имеет значения, т.к. не проходит Contains
            list.AddAfter(-12, 2); // {0,1,2, -12, 3,4,5,6,7}
            list.AddAfter(5, 53); // {0,1,2, -12, 3,4,5,6,7}
            tb?.AppendText(list.ToString() + Environment.NewLine); // вот тут бы весьма пригодились модульные тесты

            list.AddBefore(item: -10, before: 1); // {0, -10, 1,2, -12, 3,4,5,6,7}
            tb?.AppendText(list.ToString() + Environment.NewLine);
            /*list.AddBefore(12, 43); // {12, 0, -10, 1,2, -12, 3,4,5,6,7}
            tb?.AppendText(list.ToString() + Environment.NewLine);
            list.AddBefore(11, 0); // {12, 11, 0, -10, 1,2, -12, 3,4,5,6,7}
            tb?.AppendText(list.ToString() + Environment.NewLine);
            list.AddBefore(1, 1); // {12, 11, 0, -10, 1,2, -12, 3,4,5,6,7}
            tb?.AppendText(list.ToString() + Environment.NewLine);*/

        }
    }
}
