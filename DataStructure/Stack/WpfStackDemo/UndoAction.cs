using System.Windows.Controls;
using System.Windows.Media;

namespace WpfStackDemo
{
    class UndoAction
    {
        public UndoAction(Button button)
        {
            this.button = button;
            brush = button.Background.CloneCurrentValue();
        }

        public void Execute()
        {
            button.Background = brush;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", button.Content, brush.ToString());
        }

        Button button;
        Brush brush;
    }
}
