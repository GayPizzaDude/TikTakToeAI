using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using static ttt_ai.Classes.ViewController;

namespace ttt_ai.Classes
{
    public class ViewController
    {

        // --- PROPERTIES ---

        public enum GameMode
        {
            Easy,
            Hard,
            AI
        }

        private MainWindow _mainWindow;



        // --- CONSTRUCTOR ---

        public ViewController(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;

            SetHomeScreen(GameMode.Easy);
            SetHomeScreen(GameMode.Hard);
            SetHomeScreen(GameMode.AI);
        }




        // --- PUBLIC METHODS ---

        public void SetHomeScreen(GameMode gameMode)
        {
            _mainWindow.HomeScreen.Visibility = Visibility.Visible;
            _mainWindow.EasyModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.HardModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.AIModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.SettingsScreen.Visibility = Visibility.Collapsed;

            switch (gameMode)
            {
                case GameMode.Easy:
                    _mainWindow.ImageEasy1.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageEasy2.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageEasy3.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageEasy4.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageEasy5.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageEasy6.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageEasy7.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageEasy8.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageEasy9.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));

                    _mainWindow.Button1_Easy.Opacity = 0.5;
                    _mainWindow.Button2_Easy.Opacity = 0.5;
                    _mainWindow.Button3_Easy.Opacity = 0.5;
                    _mainWindow.Button4_Easy.Opacity = 0.5;
                    _mainWindow.Button5_Easy.Opacity = 0.5;
                    _mainWindow.Button6_Easy.Opacity = 0.5;
                    _mainWindow.Button7_Easy.Opacity = 0.5;
                    _mainWindow.Button8_Easy.Opacity = 0.5;
                    _mainWindow.Button9_Easy.Opacity = 0.5;

                    _mainWindow.Button1_Easy.IsEnabled = true;
                    _mainWindow.Button2_Easy.IsEnabled = true;
                    _mainWindow.Button3_Easy.IsEnabled = true;
                    _mainWindow.Button4_Easy.IsEnabled = true;
                    _mainWindow.Button5_Easy.IsEnabled = true;
                    _mainWindow.Button6_Easy.IsEnabled = true;
                    _mainWindow.Button7_Easy.IsEnabled = true;
                    _mainWindow.Button8_Easy.IsEnabled = true;
                    _mainWindow.Button9_Easy.IsEnabled = true;
                    
                    break;

                case GameMode.Hard:
                    _mainWindow.ImageHard1.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageHard2.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageHard3.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageHard4.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageHard5.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageHard6.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageHard7.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageHard8.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageHard9.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));

                    _mainWindow.Button1_Hard.Opacity = 0.5;
                    _mainWindow.Button2_Hard.Opacity = 0.5;
                    _mainWindow.Button3_Hard.Opacity = 0.5;
                    _mainWindow.Button4_Hard.Opacity = 0.5;
                    _mainWindow.Button5_Hard.Opacity = 0.5;
                    _mainWindow.Button6_Hard.Opacity = 0.5;
                    _mainWindow.Button7_Hard.Opacity = 0.5;
                    _mainWindow.Button8_Hard.Opacity = 0.5;
                    _mainWindow.Button9_Hard.Opacity = 0.5;

                    _mainWindow.Button1_Hard.IsEnabled = true;
                    _mainWindow.Button2_Hard.IsEnabled = true;
                    _mainWindow.Button3_Hard.IsEnabled = true;
                    _mainWindow.Button4_Hard.IsEnabled = true;
                    _mainWindow.Button5_Hard.IsEnabled = true;
                    _mainWindow.Button6_Hard.IsEnabled = true;
                    _mainWindow.Button7_Hard.IsEnabled = true;
                    _mainWindow.Button8_Hard.IsEnabled = true;
                    _mainWindow.Button9_Hard.IsEnabled = true;

                    break;

                case GameMode.AI:
                    _mainWindow.ImageAI1.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageAI2.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageAI3.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageAI4.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageAI5.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageAI6.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageAI7.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageAI8.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));
                    _mainWindow.ImageAI9.Source = new BitmapImage(new Uri(_mainWindow.blankImagePath, UriKind.Relative));

                    _mainWindow.Button1_AI.Opacity = 0.5;
                    _mainWindow.Button2_AI.Opacity = 0.5;
                    _mainWindow.Button3_AI.Opacity = 0.5;
                    _mainWindow.Button4_AI.Opacity = 0.5;
                    _mainWindow.Button5_AI.Opacity = 0.5;
                    _mainWindow.Button6_AI.Opacity = 0.5;
                    _mainWindow.Button7_AI.Opacity = 0.5;
                    _mainWindow.Button8_AI.Opacity = 0.5;
                    _mainWindow.Button9_AI.Opacity = 0.5;

                    _mainWindow.Button1_AI.IsEnabled = true;
                    _mainWindow.Button2_AI.IsEnabled = true;
                    _mainWindow.Button3_AI.IsEnabled = true;
                    _mainWindow.Button4_AI.IsEnabled = true;
                    _mainWindow.Button5_AI.IsEnabled = true;
                    _mainWindow.Button6_AI.IsEnabled = true;
                    _mainWindow.Button7_AI.IsEnabled = true;
                    _mainWindow.Button8_AI.IsEnabled = true;
                    _mainWindow.Button9_AI.IsEnabled = true;

                    break;

            }



        }

        public void SetEasyModeScreen()
        {
            _mainWindow.HomeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.EasyModeScreen.Visibility = Visibility.Visible;
            _mainWindow.HardModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.AIModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.SettingsScreen.Visibility = Visibility.Collapsed;

            _mainWindow.easyMode.InitializeGame();
        }

        public void SetHardModeScreen()
        {
            _mainWindow.HomeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.EasyModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.HardModeScreen.Visibility = Visibility.Visible;
            _mainWindow.AIModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.SettingsScreen.Visibility = Visibility.Collapsed;

            _mainWindow.hardMode.InitializeGame();
        }

        public void SetAIModeScreen()
        {
            _mainWindow.HomeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.EasyModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.HardModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.AIModeScreen.Visibility = Visibility.Visible;
            _mainWindow.SettingsScreen.Visibility = Visibility.Collapsed;
        }

        public void SetSettingsScreen()
        {
            _mainWindow.HomeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.EasyModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.HardModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.AIModeScreen.Visibility = Visibility.Collapsed;
            _mainWindow.SettingsScreen.Visibility = Visibility.Visible;
        }

        public async Task WinningScreen(GameMode gamemode)
        {
            _mainWindow.WinningScreen.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            _mainWindow.WinningScreen.Visibility = Visibility.Collapsed;

            _mainWindow.viewController.SetHomeScreen(gamemode);

            switch (gamemode)
            {
                case GameMode.Easy:
                    _mainWindow.viewController.SetEasyModeScreen();
                    break;

                case GameMode.Hard:
                    _mainWindow.viewController.SetHardModeScreen();
                    break;

                case GameMode.AI:
                    _mainWindow.viewController.SetAIModeScreen();
                    break;
            }

        }

        public async Task LosingScreen(GameMode gamemode)
        {
            _mainWindow.LosingScreen.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            _mainWindow.LosingScreen.Visibility = Visibility.Collapsed;

            _mainWindow.viewController.SetHomeScreen(gamemode);

            switch (gamemode)
            {
                case GameMode.Easy:
                    _mainWindow.viewController.SetEasyModeScreen();
                    break;

                case GameMode.Hard:
                    _mainWindow.viewController.SetHardModeScreen();
                    break;

                case GameMode.AI:
                    _mainWindow.viewController.SetAIModeScreen();
                    break;
            }
        }

        public async Task DrawScreen(GameMode gamemode)
        {
            _mainWindow.DrawScreen.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            _mainWindow.DrawScreen.Visibility = Visibility.Collapsed;

            _mainWindow.viewController.SetHomeScreen(gamemode);

            switch (gamemode)
            {
                case GameMode.Easy:
                    _mainWindow.viewController.SetEasyModeScreen();
                    break;

                case GameMode.Hard:
                    _mainWindow.viewController.SetHardModeScreen();
                    break;

                case GameMode.AI:
                    _mainWindow.viewController.SetAIModeScreen();
                    break;
            }
        }
    }
}
