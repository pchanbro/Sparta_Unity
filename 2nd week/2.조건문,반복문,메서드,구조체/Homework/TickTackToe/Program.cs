using System.Reflection.Metadata.Ecma335;

namespace TickTackToe
{
    internal class Program
    {
        // 마크할 위치를 제대로 선택 했는지 여부 확인
        static bool IsCorrectInput(char[,] board, int row, int column)
        {
            if (row < 0 || column < 0 || row > 2 || column > 2)
            {
                Console.WriteLine("행 혹은 열의 범위를 벗어났습니다. 다시 선택하세요");
                return false;
            }
            if (((board[row, column].CompareTo('O') == 0)) || ((board[row, column].CompareTo('X') == 0)))
            {
                Console.WriteLine("이미 선택된 곳입니다. 다시 선택하세요");
                return false;
            }
            return true;
        }

        // 빙고 한줄이 완성됐는지 확인
        static bool IsWin(char[,] board, int playerNum)
        {
            int number = 0;

            // 가로줄 확인
            for (int row = 0; row < 3; row++)
            {
                number = 0;

                if (board[row, 0] == 'I')
                {
                    break;
                }

                for (int column = 0; column < 3; column++)
                {
                    if (board[row, 0] == board[row, column])
                    {
                        number++;
                    }
                }

                if (number == 3)
                {
                    Console.WriteLine("{0}번 플레이어의 승리!", playerNum);
                    return true;
                }
            }

            // 세로줄 확인
            for (int column = 0; column < 3; column++)
            {
                number = 0;

                if (board[0, column] == 'I')
                {
                    break;
                }

                for (int row = 0; row < 3; row++)
                {
                    if (board[0, column] == board[row, column])
                    {
                        number++;
                    }
                }

                if (number == 3)
                {
                    Console.WriteLine("{0}번 플레이어의 승리!", playerNum);
                    return true;
                }
            }

            // 왼쪽 위에서 시작하는 대가선 확인
            number = 0;
            for (int i = 0; i < 3; i++)
            {
                if (board[0, 0] == 'I')
                {
                    break;
                }

                if (board[0, 0] == board[i, i])
                {
                    number++;
                }

                if (number == 3)
                {
                    Console.WriteLine("{0}번 플레이어의 승리!", playerNum);
                    return true;
                }
            }

            // 오른쪽 위에서 시작하는 대각선 확인
            number = 0;
            for (int i = 0; i < 3; i++)
            {
                if (board[0, 2] == 'I')
                {
                    break;
                }

                if (board[0, 2] == board[i, 2 - i])
                {
                    number++;
                }

                if (number == 3)
                {
                    Console.WriteLine("{0}번 플레이어의 승리!", playerNum);
                    return true;
                }
            }

            return false;
        }


        static void Main(string[] args)
        {
            char[,] board = new char[3, 3]
            {
                {'I', 'I', 'I'},
                {'I', 'I', 'I'},
                {'I', 'I', 'I'}
            };

            int playerNum = 1;
            int turnNum = 1;

            while (turnNum < 10)
            {
                for (int line = 0; line < 3; line++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        Console.Write(board[line, row] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("{0}번 플레이어 차례", playerNum);

                Console.Write("체크할 행을 선택하세요(0 ~ 2) : ");
                int choosedLine = int.Parse(Console.ReadLine());

                Console.Write("체크할 열을 선택하세요(0 ~ 2) : ");
                int choosedColumn = int.Parse(Console.ReadLine());

                if (IsCorrectInput(board, choosedLine, choosedColumn) == false)
                {
                    continue;
                }

                if (playerNum == 1)
                {
                    board[choosedLine, choosedColumn] = 'O';
                    if (IsWin(board, playerNum))
                    {
                        break;
                    }
                    playerNum = 2;
                }
                else
                {
                    board[choosedLine, choosedColumn] = 'X';
                    if (IsWin(board, playerNum))
                    {
                        break;
                    }
                    playerNum = 1;
                }
            }
        }
    }
}
