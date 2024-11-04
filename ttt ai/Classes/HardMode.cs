using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ttt_ai.Classes
{
    public class HardMode
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

        // indexing: 1 - 9
        private int bestSquare;

        private bool isWon;
        private WhoWon winner;
        private int moves;





        // --- CONSTRUCTOR ---

        public HardMode(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            AvailableSquares = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // 0 - not clicked, 1 - clicked by circle, 2 - clicked by cross
            SquareStatus = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            isWon = false;
            winner = WhoWon.None;
            moves = 0;

            //ten is set as null
            bestSquare = 10;
        }






        // --- PUBLIC METHODS ---

        public void Clicked(int id)
        {
            switch (id)
            {
                case 1:
                    AvailableSquares.Remove(1);
                    SquareStatus[0] = 1;

                    _mainWindow.ImageHard1.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button1_Hard.IsEnabled = false;
                    _mainWindow.Button1_Hard.Opacity = 0.2;

                    break;

                case 2:
                    AvailableSquares.Remove(2);
                    SquareStatus[1] = 1;

                    _mainWindow.ImageHard2.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button2_Hard.IsEnabled = false;
                    _mainWindow.Button2_Hard.Opacity = 0.2;

                    break;

                case 3:
                    AvailableSquares.Remove(3);
                    SquareStatus[2] = 1;

                    _mainWindow.ImageHard3.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button3_Hard.IsEnabled = false;
                    _mainWindow.Button3_Hard.Opacity = 0.2;

                    break;

                case 4:
                    AvailableSquares.Remove(4);
                    SquareStatus[3] = 1;

                    _mainWindow.ImageHard4.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button4_Hard.IsEnabled = false;
                    _mainWindow.Button4_Hard.Opacity = 0.2;

                    break;

                case 5:
                    AvailableSquares.Remove(5);
                    SquareStatus[4] = 1;

                    _mainWindow.ImageHard5.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button5_Hard.IsEnabled = false;
                    _mainWindow.Button5_Hard.Opacity = 0.2;

                    break;

                case 6:
                    AvailableSquares.Remove(6);
                    SquareStatus[5] = 1;

                    _mainWindow.ImageHard6.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button6_Hard.IsEnabled = false;
                    _mainWindow.Button6_Hard.Opacity = 0.2;

                    break;

                case 7:
                    AvailableSquares.Remove(7);
                    SquareStatus[6] = 1;

                    _mainWindow.ImageHard7.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button7_Hard.IsEnabled = false;
                    _mainWindow.Button7_Hard.Opacity = 0.2;

                    break;

                case 8:
                    AvailableSquares.Remove(8);
                    SquareStatus[7] = 1;

                    _mainWindow.ImageHard8.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button8_Hard.IsEnabled = false;
                    _mainWindow.Button8_Hard.Opacity = 0.2;

                    break;

                case 9:
                    AvailableSquares.Remove(9);
                    SquareStatus[8] = 1;

                    _mainWindow.ImageHard9.Source = new BitmapImage(new Uri(_mainWindow.circleImagePath, UriKind.Relative));
                    _mainWindow.Button9_Hard.IsEnabled = false;
                    _mainWindow.Button9_Hard.Opacity = 0.2;

                    break;
            }

            moves++;

            winner = CheckWinning();

            if (winner == WhoWon.Circle) { _mainWindow.viewController.WinningScreen(ViewController.GameMode.Hard); }
            if (winner == WhoWon.Cross) { _mainWindow.viewController.LosingScreen(ViewController.GameMode.Hard); }

            if (moves == 9)
            {
                switch (winner)
                {
                    case WhoWon.None:
                        _mainWindow.viewController.DrawScreen(ViewController.GameMode.Hard);
                        break;

                    case WhoWon.Circle:
                        _mainWindow.viewController.WinningScreen(ViewController.GameMode.Hard);
                        break;

                    case WhoWon.Cross:
                        _mainWindow.viewController.LosingScreen(ViewController.GameMode.Hard);
                        break;
                }
            }

            else
            {
                MakeMove();

                winner = CheckWinning();

                if (winner == WhoWon.Circle) { _mainWindow.viewController.WinningScreen(ViewController.GameMode.Hard); }
                if (winner == WhoWon.Cross) { _mainWindow.viewController.LosingScreen(ViewController.GameMode.Hard); }

                if (moves == 9)
                {
                    switch (winner)
                    {
                        case WhoWon.None:
                            _mainWindow.viewController.DrawScreen(ViewController.GameMode.Hard);
                            break;

                        case WhoWon.Circle:
                            _mainWindow.viewController.WinningScreen(ViewController.GameMode.Hard);
                            break;

                        case WhoWon.Cross:
                            _mainWindow.viewController.LosingScreen(ViewController.GameMode.Hard);
                            break;
                    }
                }
            }
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

            Random rng = new Random();
            int randomValue = rng.Next(2);

            if (randomValue == 0)
            {
                MakeMove();
            }
        }






        // --- PRIVATE METHODS ---

        private void BestStrategy()
        {
            Opening();
            CheckTwoCircle();
            CheckTwoCross();

            if (bestSquare == 10)
            {
                UndefinedRule();
            }
        }

        private void MakeMove()
        {
            BestStrategy();

            Move(bestSquare);
            bestSquare = 10;

            moves++;
        }

        private void Move(int squrareID)
        {
            switch (squrareID)
            {
                case 1:
                    AvailableSquares.Remove(1);
                    SquareStatus[0] = 2;

                    _mainWindow.ImageHard1.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button1_Hard.IsEnabled = false;
                    _mainWindow.Button1_Hard.Opacity = 0.2;
                    break;

                case 2:
                    AvailableSquares.Remove(2);
                    SquareStatus[1] = 2;

                    _mainWindow.ImageHard2.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button2_Hard.IsEnabled = false;
                    _mainWindow.Button2_Hard.Opacity = 0.2;
                    break;

                case 3:
                    AvailableSquares.Remove(3);
                    SquareStatus[2] = 2;

                    _mainWindow.ImageHard3.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button3_Hard.IsEnabled = false;
                    _mainWindow.Button3_Hard.Opacity = 0.2;
                    break;

                case 4:
                    AvailableSquares.Remove(4);
                    SquareStatus[3] = 2;

                    _mainWindow.ImageHard4.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button4_Hard.IsEnabled = false;
                    _mainWindow.Button4_Hard.Opacity = 0.2;
                    break;

                case 5:
                    AvailableSquares.Remove(5);
                    SquareStatus[4] = 2;

                    _mainWindow.ImageHard5.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button5_Hard.IsEnabled = false;
                    _mainWindow.Button5_Hard.Opacity = 0.2;
                    break;

                case 6:
                    AvailableSquares.Remove(6);
                    SquareStatus[5] = 2;

                    _mainWindow.ImageHard6.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button6_Hard.IsEnabled = false;
                    _mainWindow.Button6_Hard.Opacity = 0.2;
                    break;

                case 7:
                    AvailableSquares.Remove(7);
                    SquareStatus[6] = 2;

                    _mainWindow.ImageHard7.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button7_Hard.IsEnabled = false;
                    _mainWindow.Button7_Hard.Opacity = 0.2;
                    break;

                case 8:
                    AvailableSquares.Remove(8);
                    SquareStatus[7] = 2;

                    _mainWindow.ImageHard8.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button8_Hard.IsEnabled = false;
                    _mainWindow.Button8_Hard.Opacity = 0.2;
                    break;

                case 9:
                    AvailableSquares.Remove(9);
                    SquareStatus[8] = 2;

                    _mainWindow.ImageHard9.Source = new BitmapImage(new Uri(_mainWindow.crossImagePath, UriKind.Relative));
                    _mainWindow.Button9_Hard.IsEnabled = false;
                    _mainWindow.Button9_Hard.Opacity = 0.2;
                    break;
            }
        }

        private void Opening()
        {
            int crossMoves = CheckCrossMoves();

            switch (crossMoves)
            {
                case 0:
                    MakeFirstMove();
                    break;

                case 1:
                    MakeSecondMove();
                    break;

                case 2:
                    MakeThirdMove();
                    break;
            }
        }

        private int OppositeCorner(int squareID)
        {
            switch (squareID)
            {
                case 1:
                    return 9;

                case 3:
                    return 7;

                case 7:
                    return 3;

                case 9:
                    return 1;

                default:
                    return 100;
            }
        }

        private int LocateFirstCircle()
        {
            for (int i = 1; i < 10; i++)
            {
                if (SquareStatus[i] == 1)
                {
                    return i;
                }
            }

            return 0;
        }

        private int LocateFirstCross()
        {
            for (int i = 0; i < 9; i++)
            {
                if (SquareStatus[i] == 2)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        private void MakeFirstMove()
        {
            Random rnd = new Random();
            int randomValue = rnd.Next(1, 5);
            bool loop = true;

            if (moves == 1 && CheckIfFirstCricleIsInCorner())
            {
                bestSquare = 5;
            }
            else
            {
                while (loop)
                {
                    Debug.WriteLine("zjebales xd");
                    Debug.WriteLine(randomValue.ToString());
                    switch (randomValue)
                    {
                        case 1:
                            if (CheckIfAvailable(1))
                            {
                                bestSquare = 1;
                                loop = false; break;
                            }
                            else
                            {
                                randomValue = rnd.Next(1, 5);
                            }
                            break;

                        case 2:
                            if (CheckIfAvailable(3))
                            {
                                bestSquare = 3;
                                loop = false; break;
                            }
                            else
                            {
                                randomValue = rnd.Next(1, 5);
                            }
                            break;

                        case 3:
                            if (CheckIfAvailable(7))
                            {
                                bestSquare = 7;
                                loop = false; break;
                            }
                            else
                            {
                                randomValue = rnd.Next(1, 5);
                            }
                            break;

                        case 4:
                            if (CheckIfAvailable(9))
                            {
                                bestSquare = 9;
                                loop = false; break;
                            }
                            else
                            {
                                randomValue = rnd.Next(1, 5);
                            }
                            break;
                    }
                }
            }


        }

        private void MakeSecondMove()
        {
            if (CheckIfFirstCrossIsInCorner()) // bierze tez gdy x pojawi sie na srodku
            {
                if (CheckIfAvailable(OppositeCorner(LocateFirstCross())))
                {
                    bestSquare = OppositeCorner(LocateFirstCross());
                }
            }
            else if (CheckIfFirstCricleIsInCorner())
            {
                Random rng = new Random();
                List<bool> freeCorners = FreeCorners();

                int randomValue = rng.Next(4);
                bool loop = true;

                while (loop)
                {
                    switch (randomValue)
                    {
                        case 0:
                            if (freeCorners[0])
                            {
                                SetBestSquare(1);
                                loop = false;
                                break;
                            }

                            randomValue = rng.Next(4);
                            break;

                        case 1:
                            if (freeCorners[1])
                            {
                                SetBestSquare(3);
                                loop = false;
                                break;
                            }

                            randomValue = rng.Next(4);
                            break;

                        case 2:
                            if (freeCorners[2])
                            {
                                SetBestSquare(7);
                                loop = false;
                                break;
                            }

                            randomValue = rng.Next(4);
                            break;

                        case 3:
                            if (freeCorners[3])
                            {
                                SetBestSquare(9);
                                loop = false;
                                break;
                            }

                            randomValue = rng.Next(4);
                            break;
                    }
                }
            }
        }

        private void MakeThirdMove()
        {
            DecideThirdMove();
        }

        private void UndefinedRule()
        {
            Random rng = new Random();
            int randomValue = rng.Next(AvailableSquares.Count);

            SetBestSquare(AvailableSquares[randomValue]);
        }

        private List<bool> FreeCorners()
        {
            List<bool> outputList = new List<bool>
            {
                false,
                false,
                false,
                false
            };

            if (CheckIfAvailable(1))
            {
                outputList[0] = true;
            }
            if (CheckIfAvailable(3))
            {
                outputList[1] = true;
            }
            if (CheckIfAvailable(7))
            {
                outputList[2] = true;
            }
            if (CheckIfAvailable(9))
            {
                outputList[3] = true;
            }

            return outputList;
        }

        private bool CheckIfFirstCricleIsInCorner()
        {
            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 0:
                        if (SquareStatus[i] == 1) { return true; }
                        break;

                    case 2:
                        if (SquareStatus[i] == 1) { return true; }
                        break;

                    case 6:
                        if (SquareStatus[i] == 1) { return true; }
                        break;

                    case 8:
                        if (SquareStatus[i] == 1) { return true; }
                        break;
                }
            }

            return false;
        }

        private bool CheckIfFirstCrossIsInCorner()
        {
            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 0:
                        if (SquareStatus[i] == 2) { return true; }
                        break;

                    case 2:
                        if (SquareStatus[i] == 2) { return true; }
                        break;

                    case 6:
                        if (SquareStatus[i] == 2) { return true; }
                        break;

                    case 8:
                        if (SquareStatus[i] == 2) { return true; }
                        break;
                }
            }
            return false;
        }

        private List<int> LocateTwoCrosses()
        {
            List<int> outputList = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                if (SquareStatus[i] == 2)
                {
                    outputList.Add(i + 1);
                }
            }

            return outputList;
        }

        private int CheckCrossMoves()
        {
            int crossMoves = 0;

            foreach (int move in SquareStatus)
            {
                if (move == 2)
                {
                    crossMoves++;
                }
            }

            return crossMoves;
        }

        private int DecodeCorners(int corner)
        {
            switch (corner)
            {
                case 0:
                    return 1;

                case 1:
                    return 3;

                case 2:
                    return 7;

                case 3:
                    return 9;

                default:
                    return 0;
            }
        }

        private List<int> FreeConrenerID(List<bool> freeCorners)
        {
            List<int> outputList = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                if (freeCorners[i])
                {
                    outputList.Add(DecodeCorners(i));
                }
            }

            return outputList;
        }

        private void DecideThirdMove()
        {
            Random rng = new Random();
            int randomValue = rng.Next(0, 2);

            List<bool> freeCorners = FreeCorners();
            int numberOfFreeCorners = NumberOfFreeCorners(freeCorners);

            switch (numberOfFreeCorners)
            {
                case 1:
                    for (int i = 0; i < 4; i++)
                    {
                        if (freeCorners[i])
                        {
                            SetBestSquare(DecodeCorners(i));
                        }
                    }
                    break;

                case 2:
                    List<int> freeCornersID = FreeConrenerID(freeCorners);

                    randomValue = rng.Next(2);

                    SetBestSquare(freeCornersID[randomValue]);
                    break;
            }
        }

        private int NumberOfFreeCorners(List<bool> corners)
        {
            int result = 0;

            foreach (var corner in corners)
            {
                if (corner)
                {
                    result++;
                }
            }

            return result;
        }

        private bool CheckIfAvailable(int squareID)
        {
            Debug.WriteLine(squareID.ToString());

            if (SquareStatus[squareID - 1] != 0)
            {
                return false;
            }
            return true;
        }

        private void CheckTwoCircle()
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

            //defaul set as null
            int riskId = 4;


            riskId = CheckTwo(row1, WhoWon.Circle);
            if (riskId != 4)
            {
                SetBestSquare(riskId);
            }

            riskId = CheckTwo(row2, WhoWon.Circle);
            if (riskId != 4)
            {
                SetBestSquare(riskId + 3);
            }

            riskId = CheckTwo(row3, WhoWon.Circle);
            if (riskId != 4)
            {
                SetBestSquare(riskId + 6);
            }

            riskId = CheckTwo(col1, WhoWon.Circle);
            if (riskId != 4)
            {
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(1);
                        break;

                    case 2:
                        SetBestSquare(4);
                        break;

                    case 3:
                        SetBestSquare(7);
                        break;
                }
            }

            riskId = CheckTwo(col2, WhoWon.Circle);
            if (riskId != 4)
            {
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(2);
                        break;

                    case 2:
                        SetBestSquare(5);
                        break;

                    case 3:
                        SetBestSquare(8);
                        break;
                }
            }

            riskId = CheckTwo(col3, WhoWon.Circle);
            if (riskId != 4)
            {
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(3);
                        break;

                    case 2:
                        SetBestSquare(6);
                        break;

                    case 3:
                        SetBestSquare(9);
                        break;
                }
            }


            riskId = CheckTwo(slash1, WhoWon.Circle);
            if (riskId != 4)
            {
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(1);
                        break;

                    case 2:
                        SetBestSquare(5);
                        break;

                    case 3:
                        SetBestSquare(9);
                        break;
                }
            }

            riskId = CheckTwo(slash2, WhoWon.Circle);
            if (riskId != 4)
            {
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(3);
                        break;

                    case 2:
                        SetBestSquare(5);
                        break;

                    case 3:
                        SetBestSquare(7);
                        break;
                }
            }
        }

        private void SetBestSquare(int id)
        {
            Debug.WriteLine("setbest ID " + id);
            if (CheckIfAvailable(id))
            {
                bestSquare = id;
            }
        }

        private void CheckTwoCross()
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

            //defaul set as null
            int riskId = 4;


            riskId = CheckTwo(row1, WhoWon.Cross);
            if (riskId != 4)
            {
                Debug.WriteLine("entered row1 with riskid " + riskId);
                SetBestSquare(riskId);
            }

            riskId = CheckTwo(row2, WhoWon.Cross);
            if (riskId != 4)
            {
                Debug.WriteLine("entered row2 with riskid " + riskId);
                SetBestSquare(riskId + 3);
            }

            riskId = CheckTwo(row3, WhoWon.Cross);
            if (riskId != 4)
            {
                Debug.WriteLine("entered row3 with riskid " + riskId);
                SetBestSquare(riskId + 6);
            }

            riskId = CheckTwo(col1, WhoWon.Cross);
            if (riskId != 4)
            {
                Debug.WriteLine("entered col1 with riskid " + riskId);
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(1);
                        break;

                    case 2:
                        SetBestSquare(4);
                        break;

                    case 3:
                        SetBestSquare(7);
                        break;
                }
            }

            riskId = CheckTwo(col2, WhoWon.Cross);
            if (riskId != 4)
            {
                Debug.WriteLine("entered col2 with riskid " + riskId);
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(2);
                        break;

                    case 2:
                        SetBestSquare(5);
                        break;

                    case 3:
                        SetBestSquare(8);
                        break;
                }
            }

            riskId = CheckTwo(col3, WhoWon.Cross);
            if (riskId != 4)
            {
                Debug.WriteLine("entered col3 with riskid " + riskId);
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(3);
                        break;

                    case 2:
                        SetBestSquare(6);
                        break;

                    case 3:
                        SetBestSquare(9);
                        break;
                }
            }


            riskId = CheckTwo(slash1, WhoWon.Cross);
            if (riskId != 4)
            {
                Debug.WriteLine("entered slash1 with riskid " + riskId);
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(1);
                        break;

                    case 2:
                        SetBestSquare(5);
                        break;

                    case 3:
                        SetBestSquare(9);
                        break;
                }
            }

            riskId = CheckTwo(slash2, WhoWon.Cross);
            if (riskId != 4)
            {
                Debug.WriteLine("entered slash2 with riskid " + riskId);
                switch (riskId)
                {
                    case 1:
                        SetBestSquare(3);
                        break;

                    case 2:
                        SetBestSquare(5);
                        break;

                    case 3:
                        SetBestSquare(7);
                        break;
                }
            }
        }

        private int CheckTwo(List<int> set, WhoWon type)
        {
            // 4 works as null
            int id = 4;

            switch (type)
            {
                case WhoWon.Circle:

                    if (set[0] == 1 && set[1] == 1) //trzeba pomyslec jak to przekazywac bo wszystko moze sie spierdolic
                    {
                        id = 3;
                    }
                    if (set[0] == 1 && set[2] == 1)
                    {
                        id = 2;
                    }
                    if (set[1] == 1 && set[2] == 1)
                    {
                        id = 1;
                    }

                    break;

                case WhoWon.Cross:

                    if (set[0] == 2 && set[1] == 2)
                    {
                        id = 3;
                    }
                    if (set[0] == 2 && set[2] == 2)
                    {
                        id = 2;
                    }
                    if (set[1] == 2 && set[2] == 2)
                    {
                        id = 1;
                    }

                    break;
            }

            return id;
        }

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
