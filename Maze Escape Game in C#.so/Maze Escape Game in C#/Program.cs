namespace Maze_Escape_Game_in_C_
{

    class MazeGame
    {
        public static char[ , ] maze;
        public static int playRow;
        public static int playCol;
        public static int exitRow;
        public static int exitCol;

        
        static void InitiMaze()
        {
            // Initialize maze size and player/exit positions
            maze = new char[ , ]
            {
            {'#', '#', '#', '#', '#', '#', '#'},
            {'#', 'S', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', '#', '#', '#', ' ', '#'},
            {'#', ' ', '#', ' ', '#', ' ', '#'},
            {'#', '#', '#', '#', '#', 'E', '#'},
            };

            playRow = 1;
            playCol = 1;

            exitRow = 4;
            exitCol = 5;
        }

        static void DisplayMaze()
        {
            Console.Clear();
            Console.WriteLine("Generated Maze:");
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    Console.Write(maze[row, col] + " ");
                }
                Console.WriteLine($"{maze}");
            }
            Console.WriteLine("Use W, A, S, D to move. Your goal is to reach the Exit (E)!");
        }

        static bool IsValidMove(char move)
        {
            switch (move)
            {
                case 'U':
                    return playRow > 0 && maze[playRow - 1, playCol] != '#';
                case 'D':
                    return playRow < maze.GetLength(0) - 1 && maze[playRow + 1, playCol] != '#';
                case 'L':
                    return playCol > 0 && maze[playRow, playCol - 1] != '#';
                case 'R':
                    return playCol < maze.GetLength(1) - 1 && maze[playRow, playCol + 1] != '#';
                default:
                    return false;
            }
        }

        static void UpdatPosition(char move)
        {
            switch (move)
            {
                case 'U':
                    playRow--;
                    break;
                case 'D':
                    playRow++;
                    break;
                case 'L':
                    playCol--;
                    break;
                case 'R':
                    playCol++;
                    break;
            }
        }

        static bool IsExit()
        {
            return playRow == exitRow && playCol == exitCol;
        }

        static void Main()
        {
            Console.WriteLine("Welcome to the Maze Escape Challenge!");
            do
            {
                InitiMaze();
                DisplayMaze();

                int moves = 0;
                while (true)
                {
                    Console.WriteLine($"Current Position: ({playRow}, {playCol})");
                    Console.Write("Enter your move (U/L/D/R): ");
                    char move = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine($"{move}");

                    if (IsValidMove(move))
                    {
                        UpdatPosition(move);
                        DisplayMaze();
                        moves++;

                        if (IsExit())
                        {
                            Console.WriteLine($"Congratulations! You've reached the Exit (E) in {moves} moves!");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Try again.");
                    }
                }

                Console.Write("Do you want to play again? (Y/N): ");
            } while (Console.ReadKey().KeyChar == 'Y');

            Console.WriteLine("\nThank you for playing the Maze Escape Challenge!");
        }

    }
}
