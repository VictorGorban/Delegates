// ReSharper disable PossibleNullReferenceException

namespace UserControls
{
    using System.Drawing;
    using System.Windows.Forms;

    public partial class ButtonWithLabel2 : UserControl
    {
        private Position labelPosition;

        public ButtonWithLabel2()
        {
            InitializeComponent();
            LabelPosition = Position.TopLeft; // использовал обработчик set.
        }

        public string LabelText
        {
            get => Label.Text;
            set => Label.Text = value;
        }

        public string ButtonText
        {
            get => Button.Text;
            set => Button.Text = value;
        }

        public Position LabelPosition
        {
            get => labelPosition;
            set
            {
                labelPosition = value;
                SetLabelPosition();
            }
        }

        // ReSharper disable once UnusedMember.Local
        private new string Text { get; set; } // спрятал это свойство

        private void SetLabelPosition()
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (labelPosition)
            {
                case Position.TopLeft:
                    Label.Location = new Point(
                       0, 0);
                    Button.Location = new Point(
                        0, Label.Bottom);
                    break;
                case Position.BottomLeft:
                    Button.Location = new Point(0, 0);
                    Label.Location = new Point(
                        Button.Left,
                        Button.Bottom);
                    break;
                default:
                    break;
            }
        }
    }
}
