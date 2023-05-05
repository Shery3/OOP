using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;

namespace constructor_game
{
    class Program
    {
        class game
        {
            public int playerX;
            public int playerY;

            public int enemyX;
            public int enemyY;

            public int bulletCount;
            public int bulletCountEnemy;

            public int score;
            public int health;
            public int enemyHealth;
            public bool gamestate;

            public game(int playerX, int playerY)
            {
                this.playerX = playerX;
                this.playerY = playerY;
            }

            public game(int enemyX, int enemyY,int enemyHealth)
            {
                this.enemyX = enemyX;
                this.enemyY = enemyY;
                this.enemyHealth = enemyHealth;
            }

            public game()
            {

            }


            
        }

        static int[] bulletX = new int[100];
        static int[] bulletY = new int[100];


        static int[] bulletXenemy = new int[100];
        static int[] bulletYenemy = new int[100];


        static char pface = Convert.ToChar(229);
        static char pbody = Convert.ToChar(186);

        static char eface = Convert.ToChar(169);


        static char[,] player1 = {{' ', pface, ' '},
                      {'/', pbody, '\\'},
                      { '/', ' ', '\\'}};

        static char[,] enemy1 = {{' ', eface, ' '},
                      {' ', '†', ' '},
                      { '/', ' ', '\\'}};


        static void Main(string[] args)
        {

            game p = new game(5,4);
            game e = new game(58,4);
            game play = new game();
           
            play.score = 0;
            play.health = 20;
            
            play.gamestate = true;

            play.bulletCount = 0;
            play.bulletCountEnemy = 0;

            //char start;
            char[,] maze = new char[18, 83];
            readData(maze);
            int option;
            //mainScreen();
            Console.Write("PRESS S TO START THE GAME..");
            
            do
            {
                Console.Clear();
                topHeader();
                option = mainMenu();

                if (option == 1)
                {
                    Console.Clear();
                    printMaze(maze);
                    //printCoins(play);
                    //printHealthPowerup(play);
                    //printScorePowerup(play);
                    printPlayer(p);
                    printEnemy(e);


                    while (play.gamestate == true)
                    {
                        Thread.Sleep(90);
                        printScore(play);
                        printHealth(play);
                        //printExitGate(play);

                        if (Keyboard.IsKeyPressed(Key.UpArrow))
                        {
                            movePlayerUp(p);
                        }
                        if (Keyboard.IsKeyPressed(Key.DownArrow))
                        {
                            movePlayerDown(p);
                        }
                        if (Keyboard.IsKeyPressed(Key.LeftArrow))
                        {
                            movePlayerLeft(p);
                        }
                        if (Keyboard.IsKeyPressed(Key.RightArrow))
                        {
                            movePlayerRight(p);
                        }
                        if (Keyboard.IsKeyPressed(Key.Space))
                        {
                            generateBullet(p);
                        }
                        if (play.playerX >= 43 && play.playerY == 4 && play.enemyHealth > 0)
                        {
                            generateEnemyBullet(e);
                            Thread.Sleep(90);
                        }

                        moveBullet(p);
                        moveEnemyBullet(e);
                        bulletCollision(e);
                        bulletCollisionPlayer(p);
                        //powerups(play);
                        gravityPlayer(p);
                        //removeEnemyAtZeroHealth(play);

                        if (play.health <= 0)
                        {
                            play.gamestate = false;
                        }

                        //gameWin(play);
                    }
                    Console.Clear();
                   // gameOver();

                }

                else if (option == 2)
                {
                    instructions();
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    play.gamestate = false;
                }
            } while (option != 3);
        }

        static void topHeader()
        {

            Console.WriteLine("______________________________________________________________________________________________________________________________");
            Console.WriteLine("______________________________________________________________________________________________________________________________");
            Console.WriteLine("||    .oooooo.     .oooooo.   ooo        ooooo ooo        ooooo       .o.       ooooo      ooo oooooooooo.     .oooooo.     ||");
            Console.WriteLine("||   d8P'  `Y8b   d8P'  `Y8b  `88.       .888' `88.       .888'      .888.      `888b.     `8' `888'   `Y8b   d8P'  `Y8b    ||");
            Console.WriteLine("||  888          888      888  888b     d'888   888b     d'888      .8'888.      8 `88b.    8   888      888 888      888   ||");
            Console.WriteLine("||  888          888      888  8 Y88. .P  888   8 Y88. .P  888     .8' `888.     8   `88b.  8   888      888 888      888   ||");
            Console.WriteLine("||  888          888      888  8  `888'   888   8  `888'   888    .88ooo8888.    8     `88b.8   888      888 888      888   ||");
            Console.WriteLine("||  `88b    ooo  `88b    d88'  8    Y     888   8    Y     888   .8'     `888.   8       `888   888     d88' `88b    d88'   ||");
            Console.WriteLine("||   `Y8bood8P'   `Y8bood8P'  o8o        o888o o8o        o888o o88o     o8888o o8o        `8  o888bood8P'    `Y8bood8P'    ||");
            Console.WriteLine("______________________________________________________________________________________________________________________________");
            Console.WriteLine("______________________________________________________________________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("");


        }

        static void printMaze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }

        static void printPlayer(game play)
        {

            for (int idx = 0; idx < 3; idx++)
            {
                Console.SetCursorPosition(play.playerX, play.playerY + idx);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(player1[idx, i]);
                }
            }
        }

        static void printEnemy(game play)
        {

            for (int idx = 0; idx < 3; idx++)
            {
                Console.SetCursorPosition(play.enemyX, play.enemyY + idx);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(enemy1[idx, i]);
                }
            }
        }

        static void removeEnemy(game play)
        {

            for (int idx = 0; idx < 3; idx++)
            {
                Console.SetCursorPosition(play.enemyX, play.enemyY + idx);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(" ");
                }
            }
        }

        static void removePlayer(game play)
        {

            for (int idx = 0; idx < 3; idx++)
            {
                Console.SetCursorPosition(play.playerX, play.playerY + idx);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(" ");
                }
            }
        }

        static void printScore(game play)
        {
            Console.SetCursorPosition(1, 20);
            Console.Write("SCORE: {0} ", play.score);
        }

        static void printHealth(game play)
        {
            Console.SetCursorPosition(20, 20);
            Console.Write("HEALTH: {0} ", play.health);
        }

        static void movePlayerUp(game play)
        {
            char up = GetCharAtXY(play.playerX, play.playerY - 1);
            char up1 = GetCharAtXY(play.playerX + 1, play.playerY - 1);
            char up2 = GetCharAtXY(play.playerX + 2, play.playerY - 1);
            if (up == ' ' && up1 == ' ' && up2 == ' ')
            {
                removePlayer(play);
                play.playerY--;
                printPlayer(play);
            }

            else if (up == '@' || up1 == '@' || up2 == '@')
            {
                play.score = play.score + 2;
                removePlayer(play);
                play.playerY--;
                printPlayer(play);
            }


        }

        static void movePlayerDown(game play)
        {
            char down = GetCharAtXY(play.playerX, play.playerY + 3);
            char down1 = GetCharAtXY(play.playerX + 1, play.playerY + 3);
            char down2 = GetCharAtXY(play.playerX + 2, play.playerY + 3);
            if (down == ' ' && down1 == ' ' && down2 == ' ')
            {
                removePlayer(play);
                play.playerY++;
                printPlayer(play);
            }

            else if (down == '@' || down1 == '@' || down2 == '@')
            {
                play.score = play.score + 2;
                removePlayer(play);
                play.playerY++;
                printPlayer(play);
            }

        }
        static void movePlayerLeft(game play)
        {
            char left = GetCharAtXY(play.playerX - 1, play.playerY);
            char left1 = GetCharAtXY(play.playerX - 1, play.playerY + 1);
            char left2 = GetCharAtXY(play.playerX - 1, play.playerY + 2);
            if (left == ' ' && left1 == ' ' && left2 == ' ')
            {
                removePlayer(play);
                play.playerX--;
                printPlayer(play);
            }

            else if (left == '@' || left1 == '@' || left2 == '@')
            {
                play.score = play.score + 2;
                removePlayer(play);
                play.playerX--;
                printPlayer(play);
            }
        }
        static void movePlayerRight(game play)
        {
            char right = GetCharAtXY(play.playerX + 3, play.playerY);
            char right1 = GetCharAtXY(play.playerX + 3, play.playerY + 1);
            char right2 = GetCharAtXY(play.playerX + 3, play.playerY + 2);
            if (right == ' ' && right1 == ' ' && right2 == ' ' || right == 'H' || right1 == 'H' || right2 == 'H')
            {
                removePlayer(play);
                play.playerX++;
                printPlayer(play);
            }

            if (right == '@' || right1 == '@' || right2 == '@')
            {
                play.score = play.score + 2;
                removePlayer(play);
                play.playerX++;
                printPlayer(play);
            }
        }

        static void generateBullet(game play)
        {
            bulletX[play.bulletCount] = play.playerX + 4;
            bulletY[play.bulletCount] = play.playerY;
            Console.SetCursorPosition(play.playerX + 4, play.playerY);
            Console.Write(".");
            play.bulletCount++;
        }

        static void generateEnemyBullet(game play)
        {
            bulletXenemy[play.bulletCountEnemy] = play.enemyX - 1;
            bulletYenemy[play.bulletCountEnemy] = play.enemyY;
            Console.SetCursorPosition(play.enemyX - 1, play.enemyY);
            Console.Write("-");
            play.bulletCountEnemy++;
        }

        static void moveBullet(game play)
        {
            for (int idx = 0; idx < play.bulletCount; idx++)
            {
                char move = GetCharAtXY(bulletX[idx] + 1, bulletY[idx] + 1);
                if (move != ' ')
                {
                    eraseBullet(bulletX[idx], bulletY[idx]);
                    removeBulletFromArray(play, idx);
                }
                else
                {
                    eraseBullet(bulletX[idx], bulletY[idx]);
                    bulletX[idx] = bulletX[idx] + 1;
                    printBullet(bulletX[idx], bulletY[idx]);
                }
            }
        }

        static void moveEnemyBullet(game play)
        {
            for (int i = 0; i < play.bulletCountEnemy; i++)
            {
                char next = GetCharAtXY(bulletXenemy[i] - 1, bulletYenemy[i]);
                if (next != ' ')
                {
                    eraseBulletEnemy(bulletXenemy[i], bulletYenemy[i]);
                    removeBulletFromEnemyArray(play, i);
                }

                else
                {
                    eraseBulletEnemy(bulletXenemy[i], bulletYenemy[i]);
                    bulletXenemy[i] = bulletXenemy[i] - 1;
                    printBulletEnemy(bulletXenemy[i], bulletYenemy[i]);
                }
            }
        }

        static void printBulletEnemy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }

        static void eraseBulletEnemy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        static void removeBulletFromEnemyArray(game play, int idx)
        {
            for (int i = idx; i < play.bulletCountEnemy - 1; i++)
            {
                bulletXenemy[i] = bulletXenemy[i + 1];
                bulletYenemy[i] = bulletYenemy[i + 1];
            }
            play.bulletCountEnemy--;
        }




        static void printBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(".");
        }

        static void eraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        static void removeBulletFromArray(game play, int idx)
        {
            for (int i = idx; i < play.bulletCount - 1; i++)
            {
                bulletX[i] = bulletX[i + 1];
                bulletY[i] = bulletY[i + 1];
            }
            play.bulletCount--;
        }

        static void bulletCollision(game play)
        {
            for (int i = 0; i < play.bulletCount; i++)
            {
                if (bulletX[i] + 1 == play.enemyX && (bulletY[i] == play.enemyY || bulletY[i] == play.enemyY + 1 ||
                    bulletY[i] == play.enemyY + 2 || bulletY[i] == play.enemyY + 3))
                {

                    play.score++;

                    eraseBullet(bulletX[i], bulletY[i]);
                    removeBulletFromArray(play, i);
                    play.enemyHealth--;
                }
            }
        }

        static void bulletCollisionPlayer(game play)
        {
            for (int i = 0; i < play.bulletCountEnemy; i++)
            {
                if (bulletXenemy[i] - 1 == play.playerX && bulletXenemy[i] - 1 == play.playerX && (bulletYenemy[i] == play.playerY || bulletYenemy[i] == play.playerY + 1 || bulletYenemy[i] == play.playerY + 2))
                {

                    play.health--;
                    eraseBullet(bulletXenemy[i], bulletYenemy[i]);
                    removeBulletFromArray(play, i);
                }


            }
        }

        static void gravityPlayer(game play)
        {
            bool flag = true;
            char next;
            char next1;

            while (flag)
            {
                next = GetCharAtXY(play.playerX, play.playerY + 3);
                next1 = GetCharAtXY(play.playerX + 2, play.playerY + 3);

                if (next == ' ' && next1 == ' ')
                {
                    removePlayer(play);
                    play.playerY++;
                    printPlayer(play);
                }

                else
                {
                    flag = false;
                }
            }
        }


        static void instructions()
        {
            Console.Clear();
            topHeader();
            Console.WriteLine("KEYS");
            Console.WriteLine("------------------------------");
            Console.WriteLine(" Move up    >>  Arrow Up     ");
            Console.WriteLine(" Move Down  >>  Arrow Down ");
            Console.WriteLine(" Move Left  >>  Arrow Left  ");
            Console.WriteLine(" Move Right >>  Arrow Right ");
            Console.WriteLine(" Shoot      >>  Space ");
        }


        static int mainMenu()
        {
            int option;

            Console.WriteLine(" 1. Start Game  ");
            Console.WriteLine(" 2. Keys ");
            Console.WriteLine(" 3. Exit ");
            Console.Write("ENTER YOUR OPTION TO CONTINUE...");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static void readData(char[,] maze)
        {
            string path = "D:\\PF\\OOP\\programs\\Game\\maze.txt";
            StreamReader fp = new StreamReader(path);
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 82; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            fp.Close();
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct CHAR_INFO
        {
            public ushort UnicodeChar;
            public ushort Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SMALL_RECT
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        private const int STD_OUTPUT_HANDLE = -11;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadConsoleOutput(
            IntPtr hConsoleOutput,
            out CHAR_INFO lpBuffer,
            COORD dwBufferSize,
            COORD dwBufferCoord,
            ref SMALL_RECT lpReadRegion);

        static char GetCharAtXY(int x, int y)
        {
            CHAR_INFO ci;
            COORD coordBufSize = new COORD { X = 1, Y = 1 };
            COORD coordBufCoord = new COORD { X = 0, Y = 0 };
            SMALL_RECT srctReadRect = new SMALL_RECT { Left = (short)x, Top = (short)y, Right = (short)x, Bottom = (short)y };

            bool success = ReadConsoleOutput(
                GetStdHandle(STD_OUTPUT_HANDLE),
                out ci,
                coordBufSize,
                coordBufCoord,
                ref srctReadRect);

            return success ? (char)ci.UnicodeChar : ' ';
        }


    }
}
