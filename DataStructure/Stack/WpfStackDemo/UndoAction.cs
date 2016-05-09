using System.Windows.Controls;
using System.Windows.Media;

namespace WpfStackDemo
{
    internal class UndoAction
    {
        private readonly Brush brush;

        private readonly Button button;

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
            return $"{button.Content}: {brush}";
        }
    }
}