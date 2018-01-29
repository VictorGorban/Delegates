
// ReSharper disable PossibleNullReferenceException

namespace UserControls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using JetBrains.Annotations;

    public partial class ButtonWithLabel1 : UserControl
    {
        private Position labelPosition;

        public ButtonWithLabel1()
        {
            InitializeComponent();
            LabelPosition = Position.MiddleLeft; // использовал обработчик set.
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
            var addYLabel = (Button.Height - Label.Height) / 2;

            var addYButton = (Height - Button.Height) / 2;
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (labelPosition)
            {
                case Position.MiddleLeft:
                    Label.Location = new Point(
                       0, addYButton + addYLabel);
                    Button.Location = new Point(
                        Label.Right + 3, addYButton);
                    break;
                case Position.MiddleRight:
                    Button.Location = new Point(0, addYButton);
                    Label.Location = new Point(
                        Button.Right,
                        Button.Top + addYLabel);
                    break;
                default:
                    break;
            }
        }

    }
}
