using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _5_Calculadora;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        CreateGridButtons();
    }

    private void CreateGridButtons()
    {
        for (int i = 0; i < 9; i++)
        {
            var btn = CreateNumberButton($"{i + 1}");
            Grid.SetRow(btn, i % 3);
            Grid.SetColumn(btn, i / 3);
            Botonera.Children.Add(btn);
        }
    }
    
    private Button CreateNumberButton(string number)
    {
        var btn = new Button
        {
            Content = new Viewbox
            {
                Child = new TextBlock
                {
                    Text = number,
                }
            },
            Tag = number,
            Style = (Style)Resources["NumberButton"]!
        };
        
        btn.Click += Button_OnClick;

        return btn;
    }

    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            textBoxNumeros?.Text = textBoxNumeros.Text + btn.Tag;
        }
    }
}