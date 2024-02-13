namespace UserInput
{
    public static class Program
    {
        private static ConsoleKeyInfo _cki;
        private static readonly Random Random = new Random();
        private static int _candyX;
        private static int _candyY;
        private static bool _hasCandy;
        private static int _score;
        private static readonly List<Segment> FrogBody = [new Segment(5, 5)];
        private static Direction _currentDirection;
        private static Direction _nextDirection = Direction.Right;
        private static bool _hasStarted;

        private static void Main()
        {
            _currentDirection = _cki.Key switch
            {
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                _ => _currentDirection
            };
            do
            {
                if (!_hasCandy)
                {
                    PlaceCandy();
                    _hasCandy = true;
                }

                ReadKey();
                if (_hasStarted) // Only move if the game has started
                {
                    MoveFrog();
                    CheckCollision();
                }
                
                DrawBox();
                DisplayScore();

                int sleepTime = 200 - (_score / 10 * 10); // Increase speed every 10 points
                sleepTime = Math.Max(sleepTime, 50); // Set a minimum sleep time
                Thread.Sleep(sleepTime); // Delay for movement

            } while (_cki.Key != ConsoleKey.X);
        }

        private static void ReadKey()
        {
            if (!Console.KeyAvailable) return;
            _cki = Console.ReadKey(true);

            if (!_hasStarted)
            {
                // Start the game on the first arrow key press
                _hasStarted = true;
            }

            _nextDirection = _cki.Key switch
            {
                ConsoleKey.LeftArrow when _currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when _currentDirection != Direction.Left => Direction.Right,
                ConsoleKey.UpArrow when _currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when _currentDirection != Direction.Up => Direction.Down,
                _ => _nextDirection
            };
        }

        private static void PlaceCandy()
        {
            do
            {
                _candyX = Random.Next(10);
                _candyY = Random.Next(10);
            } while (FrogBody.Any(segment => segment.X == _candyX && segment.Y == _candyY));
        }

        private static void MoveFrog()
        {
            _currentDirection = _nextDirection;

            int headX = FrogBody[0].X;
            int headY = FrogBody[0].Y;

            switch (_currentDirection)
            {
                case Direction.Left:
                    headX = (headX - 1 + 10) % 10; // Wrap around the left edge
                    break;
                case Direction.Right:
                    headX = (headX + 1) % 12; // Wrap around the right edge
                    break;
                case Direction.Up:
                    headY = (headY - 1 + 10) % 10; // Wrap around the top edge
                    break;
                case Direction.Down:
                    headY = (headY + 1) % 10; // Wrap around the bottom edge
                    break;
            }

            // Check if the frog has eaten the candy
            if (headX == _candyX && headY == _candyY)
            {
                _score++;
                _hasCandy = false;
            }

            FrogBody.Insert(0, new Segment(headX, headY));

            // Remove the last segment if the frog did not eat the candy
            if (headX != _candyX || headY != _candyY)
                FrogBody.RemoveAt(FrogBody.Count - 1);
        }

        private static void CheckCollision()
        {
            int headX = FrogBody[0].X;
            int headY = FrogBody[0].Y;

            // Check for self-collision
            for (int i = 1; i < FrogBody.Count; i++)
            {
                if (FrogBody[i].X != headX || FrogBody[i].Y != headY) continue;
                Console.WriteLine("Game Over! You collided with yourself.");
                Environment.Exit(0);
            }
        }

        private static void DrawBox()
        {
            Console.Clear();
            DrawTitle();
            Console.WriteLine("\u250f\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2513");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("\u2503");
                for (int j = 0; j < 12; j++)
                {
                    if (i == _candyY && j == _candyX)
                    {
                        Console.Write(" 🍎");
                    }
                    else
                    {
                        bool isFrogSegment = FrogBody.Any(segment => segment.X == j && segment.Y == i);

                        Console.Write(isFrogSegment ? " 🐸" : " + ");
                    }
                }

                Console.Write("\u2503\n");
            }

            Console.WriteLine("\u2517\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u251b");
            Console.WriteLine("Press X to exit game");
        }

        private static void DisplayScore()
        {
            Console.WriteLine($"Score: {_score}");
        }

        private class Segment(int x, int y)
        {
            public int X { get; } = x;
            public int Y { get; } = y;
        }

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        private static void DrawTitle()
        {
            Console.WriteLine("  ______                 _____ _____ ");
            Console.WriteLine(" |  ___|               |_   _|_   _|");
            Console.WriteLine(" | |_ _ __ ___   __ _    | |   | |  ");
            Console.WriteLine(" |  _| '__/ _ \\ / _` |   | |   | |  ");
            Console.WriteLine(" | | | | | (_) | (_| |  _| |_ _| |_ ");
            Console.WriteLine(" \\_| |_|  \\___/ \\__, |  \\___/ \\___/ ");
            Console.WriteLine("                 __/ |               ");
            Console.WriteLine("                |___/                ");
            Console.WriteLine();
        }
    }
}
