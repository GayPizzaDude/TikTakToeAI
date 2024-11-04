using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ttt_ai.Classes
{
    public class EasyMode
    {

        // --- PROPERTIES ---

        private MainWindow _mainWindow;
        private List<int> AvailableSquares;
        private List<int> SquareStatus;

        private enum WhoWon
        {
            None,
            Circle,
            Cross
        }

        private bool isWon;
        private WhoWon winner;
        private int moves;

        Random random = new Random();





        // --- CONSTRUCTOR ---

        public EasyMode(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            AvailableSquares = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // 0 - not clicked, 1 - clicked by circle, 2 - clicked by cross
            SquareStatus = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            isWon = false;
            winner = WhoWon.None;
            moves = 0;
        }





        // --- PUBLIC METHODS ---

        public void Clicked(int id)
        {
            switch (id)
            {
                case 1:
                    AvailableSquares.Remove(1);
                    SquareStatus[0] = 1;

                    _mainWindow.ImageEasy1.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button1_Easy.IsEnabled = false;
                    _mainWindow.Button1_Easy.Opacity = 0.2;

                    break;

                case 2:
                    AvailableSquares.Remove(2);
                    SquareStatus[1] = 1;

                    _mainWindow.ImageEasy2.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button2_Easy.IsEnabled = false;
                    _mainWindow.Button2_Easy.Opacity = 0.2;

                    break;

                case 3:
                    AvailableSquares.Remove(3);
                    SquareStatus[2] = 1;

                    _mainWindow.ImageEasy3.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button3_Easy.IsEnabled = false;
                    _mainWindow.Button3_Easy.Opacity = 0.2;

                    break;

                case 4:
                    AvailableSquares.Remove(4);
                    SquareStatus[3] = 1;

                    _mainWindow.ImageEasy4.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button4_Easy.IsEnabled = false;
                    _mainWindow.Button4_Easy.Opacity = 0.2;

                    break;

                case 5:
                    AvailableSquares.Remove(5);
                    SquareStatus[4] = 1;

                    _mainWindow.ImageEasy5.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button5_Easy.IsEnabled = false;
                    _mainWindow.Button5_Easy.Opacity = 0.2;

                    break;

                case 6:
                    AvailableSquares.Remove(6);
                    SquareStatus[5] = 1;

                    _mainWindow.ImageEasy6.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button6_Easy.IsEnabled = false;
                    _mainWindow.Button6_Easy.Opacity = 0.2;

                    break;

                case 7:
                    AvailableSquares.Remove(7);
                    SquareStatus[6] = 1;

                    _mainWindow.ImageEasy7.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button7_Easy.IsEnabled = false;
                    _mainWindow.Button7_Easy.Opacity = 0.2;

                    break;

                case 8:
                    AvailableSquares.Remove(8);
                    SquareStatus[7] = 1;

                    _mainWindow.ImageEasy8.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button8_Easy.IsEnabled = false;
                    _mainWindow.Button8_Easy.Opacity = 0.2;

                    break;

                case 9:
                    AvailableSquares.Remove(9);
                    SquareStatus[8] = 1;

                    _mainWindow.ImageEasy9.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button9_Easy.IsEnabled = false;
                    _mainWindow.Button9_Easy.Opacity = 0.2;

                    break;
            }

            moves++;

            winner = CheckWinning();

            if (winner == WhoWon.Circle) { _mainWindow.viewController.WinningScreen( ViewController.GameMode.Easy ); }
            if (winner == WhoWon.Cross) { _mainWindow.viewController.LosingScreen(ViewController.GameMode.Easy ); }

            if (moves == 9)
            {
                switch (winner)
                {
                    case WhoWon.None:
                        _mainWindow.viewController.DrawScreen(ViewController.GameMode.Easy );
                        break;

                    case WhoWon.Circle:
                        _mainWindow.viewController.WinningScreen(ViewController.GameMode.Easy );
                        break;

                    case WhoWon.Cross:
                        _mainWindow.viewController.LosingScreen(ViewController.GameMode.Easy );
                        break;
                }
            }

            else
            {
                MakeMove();


                winner = CheckWinning();
                Debug.WriteLine(winner.ToString());

                if (winner == WhoWon.Circle) { _mainWindow.viewController.WinningScreen(ViewController.GameMode.Easy ); }
                if (winner == WhoWon.Cross) { _mainWindow.viewController.LosingScreen(ViewController.GameMode.Easy ); }

                if (moves == 9)
                {
                    switch (winner)
                    {
                        case WhoWon.None:
                            _mainWindow.viewController.DrawScreen(ViewController.GameMode.Easy );
                            break;

                        case WhoWon.Circle:
                            _mainWindow.viewController.WinningScreen(ViewController.GameMode.Easy );
                            break;

                        case WhoWon.Cross:
                            _mainWindow.viewController.LosingScreen(ViewController.GameMode.Easy );
                            break;
                    }


                }
            Debug.WriteLine(moves.ToString());
            }
        }

        public void MakeMove()
        {
            int randomIndex = random.Next(AvailableSquares.Count);
            int randomValue = AvailableSquares[randomIndex];

            switch (randomValue)
            {
                case 1:
                    AvailableSquares.Remove(1);
                    SquareStatus[0] = 2;

                    _mainWindow.ImageEasy1.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button1_Easy.IsEnabled = false;
                    _mainWindow.Button1_Easy.Opacity = 0.2;
                    break;

                case 2:
                    AvailableSquares.Remove(2);
                    SquareStatus[1] = 2;

                    _mainWindow.ImageEasy2.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button2_Easy.IsEnabled = false;
                    _mainWindow.Button2_Easy.Opacity = 0.2;
                    break;

                case 3:
                    AvailableSquares.Remove(3);
                    SquareStatus[2] = 2;

                    _mainWindow.ImageEasy3.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button3_Easy.IsEnabled = false;
                    _mainWindow.Button3_Easy.Opacity = 0.2;
                    break;

                case 4:
                    AvailableSquares.Remove(4);
                    SquareStatus[3] = 2;

                    _mainWindow.ImageEasy4.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button4_Easy.IsEnabled = false;
                    _mainWindow.Button4_Easy.Opacity = 0.2;
                    break;

                case 5:
                    AvailableSquares.Remove(5);
                    SquareStatus[4] = 2;

                    _mainWindow.ImageEasy5.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button5_Easy.IsEnabled = false;
                    _mainWindow.Button5_Easy.Opacity = 0.2;
                    break;

                case 6:
                    AvailableSquares.Remove(6);
                    SquareStatus[5] = 2;

                    _mainWindow.ImageEasy6.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button6_Easy.IsEnabled = false;
                    _mainWindow.Button6_Easy.Opacity = 0.2;
                    break;

                case 7:
                    AvailableSquares.Remove(7);
                    SquareStatus[6] = 2;

                    _mainWindow.ImageEasy7.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button7_Easy.IsEnabled = false;
                    _mainWindow.Button7_Easy.Opacity = 0.2;
                    break;

                case 8:
                    AvailableSquares.Remove(8);
                    SquareStatus[7] = 2;

                    _mainWindow.ImageEasy8.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button8_Easy.IsEnabled = false;
                    _mainWindow.Button8_Easy.Opacity = 0.2;
                    break;

                case 9:
                    AvailableSquares.Remove(9);
                    SquareStatus[8] = 2;

                    _mainWindow.ImageEasy9.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button9_Easy.IsEnabled = false;
                    _mainWindow.Button9_Easy.Opacity = 0.2;
                    break;
            }

            moves++;
        }

        public void Reset()
        {
            AvailableSquares = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            SquareStatus = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            isWon = false;
            winner = WhoWon.None;
            moves = 0;
        }

        public void InitializeGame()
        {
            Reset();

            Random random = new Random();
            int rngValue = 0;

            rngValue = random.Next(2);

            if (rngValue == 0)
            {
                MakeMove();
            }

        }






        // --- PRIVATE METHODS ---

        private WhoWon CheckWinning()
        {
            List<int> row1 = new List<int>
            {
                SquareStatus[0],
                SquareStatus[1],
                SquareStatus[2]
            };

            List<int> row2 = new List<int>
            {
                SquareStatus[3],
                SquareStatus[4],
                SquareStatus[5]
            };

            List<int> row3 = new List<int>
            {
                SquareStatus[6],
                SquareStatus[7],
                SquareStatus[8]
            };

            List<int> col1 = new List<int>
            {
                SquareStatus[0],
                SquareStatus[3],
                SquareStatus[6],
            };

            List<int> col2 = new List<int>
            {
                SquareStatus[1],
                SquareStatus[4],
                SquareStatus[7],
            };

            List<int> col3 = new List<int>
            {
                SquareStatus[2],
                SquareStatus[5],
                SquareStatus[8]
            };

            List<int> slash1 = new List<int>
            {
                SquareStatus[0],
                SquareStatus[4],
                SquareStatus[8],
            };

            List<int> slash2 = new List<int>
            {
                SquareStatus[2],
                SquareStatus[4],
                SquareStatus[6]
            };





            if (IsTheSame(row1, WhoWon.Circle))
            {
                return WhoWon.Circle;
            }

            if (IsTheSame(row2, WhoWon.Circle))
            {
                return WhoWon.Circle;
            }

            if (IsTheSame(row3, WhoWon.Circle))
            {
                return WhoWon.Circle;
            }

            if (IsTheSame(col1, WhoWon.Circle))
            {
                return WhoWon.Circle;
            }

            if (IsTheSame(col2, WhoWon.Circle))
            {
                return WhoWon.Circle;
            }

            if (IsTheSame(col3, WhoWon.Circle))
            {
                return WhoWon.Circle;
            }

            if (IsTheSame(slash1, WhoWon.Circle))
            {
                return WhoWon.Circle;
            }

            if (IsTheSame(slash2, WhoWon.Circle))
            {
                return WhoWon.Circle;
            }



            if (IsTheSame(row1, WhoWon.Cross))
            {
                return WhoWon.Cross;
            }

            if (IsTheSame(row2, WhoWon.Cross))
            {
                return WhoWon.Cross;
            }

            if (IsTheSame(row3, WhoWon.Cross))
            {
                return WhoWon.Cross;
            }

            if (IsTheSame(col1, WhoWon.Cross))
            {
                return WhoWon.Cross;
            }

            if (IsTheSame(col2, WhoWon.Cross))
            {
                return WhoWon.Cross;
            }

            if (IsTheSame(col3, WhoWon.Cross))
            {
                return WhoWon.Cross;
            }

            if (IsTheSame(slash1, WhoWon.Cross))
            {
                return WhoWon.Cross;
            }

            if (IsTheSame(slash2, WhoWon.Cross))
            {
                return WhoWon.Cross;
            }


            return WhoWon.None;
        }

        private bool IsTheSame(List<int> shortList, WhoWon checkCase)
        {
            if (checkCase == WhoWon.Circle)
            {
                if (shortList[0] == 1 && shortList[1] == 1 && shortList[2] == 1)
                { return true; }
            }

            if (checkCase == WhoWon.Cross)
            {
                if (shortList[0] == 2 && shortList[1] == 2 && shortList[2] == 2)
                { return true; }
            }

            return false;
        }
    }
}
