using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using ttt_ai.Classes;

namespace ttt_ai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewController viewController;

        public EasyMode easyMode;
        public HardMode hardMode;
        public AIMode aiMode;

        public string circleImagePath = "Resources\\circle.png";
        public string crossImagePath = "Resources\\cross.png";
        public string blankImagePath = "Resources\\blank.png";

        public MainWindow()
        {
            InitializeComponent();

            viewController = new ViewController(this);
            easyMode = new EasyMode(this);
            hardMode = new HardMode(this);
            aiMode = new AIMode(this);
        }

        private void EasyModeButton_Click(object sender, RoutedEventArgs e)
        {
            viewController.SetEasyModeScreen();
        }

        private void HardModeButton_Click(object sender, RoutedEventArgs e)
        {
            viewController.SetHardModeScreen();
        }

        private void AIModeButton_Click(object sender, RoutedEventArgs e)
        {
            viewController.SetAIModeScreen();
        }

        private void CancelEasyButton_Click(object sender, RoutedEventArgs e)
        {
            viewController.SetHomeScreen(ViewController.GameMode.Easy);
            easyMode.Reset();
        }

        private void CancelHardButton_Click(object sender, RoutedEventArgs e)
        {
            viewController.SetHomeScreen(ViewController.GameMode.Hard);
            hardMode.Reset();
        }

        private void CancelAIButton_Click(object sender, RoutedEventArgs e)
        {
            viewController.SetHomeScreen(ViewController.GameMode.AI);
        }

        private void BackSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            viewController.SetHomeScreen(ViewController.GameMode.Easy);
            viewController.SetHomeScreen(ViewController.GameMode.Hard);
            viewController.SetHomeScreen(ViewController.GameMode.AI);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            viewController.SetSettingsScreen();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }




        private void Button1_Easy_Click(object sender, RoutedEventArgs e)
        {
            easyMode.Clicked(1);
        }

        private void Button2_Easy_Click(object sender, RoutedEventArgs e)
        {
            easyMode.Clicked(2);
        }

        private void Button3_Easy_Click(object sender, RoutedEventArgs e)
        {
            easyMode.Clicked(3);
        }

        private void Button4_Easy_Click(object sender, RoutedEventArgs e)
        {
            easyMode.Clicked(4);
        }

        private void Button5_Easy_Click(object sender, RoutedEventArgs e)
        {
            easyMode.Clicked(5);
        }

        private void Button6_Easy_Click(object sender, RoutedEventArgs e)
        {
            easyMode.Clicked(6);
        }

        private void Button7_Easy_Click(object sender, RoutedEventArgs e)
        {
            easyMode.Clicked(7);
        }

        private void Button8_Easy_Click(object sender, RoutedEventArgs e)
        {
            easyMode.Clicked(8);
        }

        private void Button9_Easy_Click(object sender, RoutedEventArgs e)
        {
            easyMode.Clicked(9);
        }



        private void Button1_Hard_Click(object sender, RoutedEventArgs e)
        {
            hardMode.Clicked(1);
        }

        private void Button2_Hard_Click(object sender, RoutedEventArgs e)
        {
            hardMode.Clicked(2);
        }

        private void Button3_Hard_Click(object sender, RoutedEventArgs e)
        {
            hardMode.Clicked(3);
        }

        private void Button4_Hard_Click(object sender, RoutedEventArgs e)
        {
            hardMode.Clicked(4);
        }

        private void Button5_Hard_Click(object sender, RoutedEventArgs e)
        {
            hardMode.Clicked(5);
        }

        private void Button6_Hard_Click(object sender, RoutedEventArgs e)
        {
            hardMode.Clicked(6);
        }

        private void Button7_Hard_Click(object sender, RoutedEventArgs e)
        {
            hardMode.Clicked(7);
        }

        private void Button8_Hard_Click(object sender, RoutedEventArgs e)
        {
            hardMode.Clicked(8);
        }



        private void Button9_Hard_Click(object sender, RoutedEventArgs e)
        {
            hardMode.Clicked(9);
        }

        private void Button1_AI_Click(object sender, RoutedEventArgs e)
        {
            aiMode.Clicked(1);
        }

        private void Button2_AI_Click(object sender, RoutedEventArgs e)
        {
            aiMode.Clicked(2);
        }

        private void Button3_AI_Click(object sender, RoutedEventArgs e)
        {
            aiMode.Clicked(3);
        }

        private void Button4_AI_Click(object sender, RoutedEventArgs e)
        {
            aiMode.Clicked(4);
        }

        private void Button5_AI_Click(object sender, RoutedEventArgs e)
        {
            aiMode.Clicked(5);
        }

        private void Button6_AI_Click(object sender, RoutedEventArgs e)
        {
            aiMode.Clicked(6);
        }

        private void Button7_AI_Click(object sender, RoutedEventArgs e)
        {
            aiMode.Clicked(7);
        }

        private void Button8_AI_Click(object sender, RoutedEventArgs e)
        {
            aiMode.Clicked(8);
        }

        private void Button9_AI_Click(object sender, RoutedEventArgs e)
        {
            aiMode.Clicked(9);
        }
    }


    public class AIMode
    {
        private MainWindow _mainWindow;
        private MLModule mlModule;

        Random random = new Random();

        public AIMode(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            mlModule = new MLModule();
        }

        public void Clicked(int id)
        {
            switch (id)
            {
                case 1:
                    _mainWindow.ImageAI1.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button1_AI.IsEnabled = false;
                    _mainWindow.Button1_AI.Opacity = 0.2;

                    mlModule.PassValue(1, MLModule.ClickType.Circle);

                    break;

                case 2:
                    _mainWindow.ImageAI2.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button2_AI.IsEnabled = false;
                    _mainWindow.Button2_AI.Opacity = 0.2;

                    mlModule.PassValue(2, MLModule.ClickType.Circle);

                    break;

                case 3:
                    _mainWindow.ImageAI3.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button3_AI.IsEnabled = false;
                    _mainWindow.Button3_AI.Opacity = 0.2;

                    mlModule.PassValue(3, MLModule.ClickType.Circle);

                    break;

                case 4:
                    _mainWindow.ImageAI4.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button4_AI.IsEnabled = false;
                    _mainWindow.Button4_AI.Opacity = 0.2;

                    mlModule.PassValue(4, MLModule.ClickType.Circle);

                    break;

                case 5:
                    _mainWindow.ImageAI5.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button5_AI.IsEnabled = false;
                    _mainWindow.Button5_AI.Opacity = 0.2;

                    mlModule.PassValue(5, MLModule.ClickType.Circle);

                    break;

                case 6:
                    _mainWindow.ImageAI6.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button6_AI.IsEnabled = false;
                    _mainWindow.Button6_AI.Opacity = 0.2;

                    mlModule.PassValue(6, MLModule.ClickType.Circle);

                    break;

                case 7:
                    _mainWindow.ImageAI7.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button7_AI.IsEnabled = false;
                    _mainWindow.Button7_AI.Opacity = 0.2;

                    mlModule.PassValue(7, MLModule.ClickType.Circle);

                    break;

                case 8:
                    _mainWindow.ImageAI8.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button8_AI.IsEnabled = false;
                    _mainWindow.Button8_AI.Opacity = 0.2;

                    mlModule.PassValue(8, MLModule.ClickType.Circle);

                    break;

                case 9:
                    _mainWindow.ImageAI9.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button9_AI.IsEnabled = false;
                    _mainWindow.Button9_AI.Opacity = 0.2;

                    mlModule.PassValue(9, MLModule.ClickType.Circle);

                    break;
            }
        }
    }
}