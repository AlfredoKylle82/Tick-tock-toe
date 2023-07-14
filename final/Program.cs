
using System;
using final;
using System.Threading;
using System.Collections.Generic;

namespace TIC_TAC_TOE

{


    class Program
    {
        static string[] pos = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // Array that contains board positions, 0 isnt used --------------------------------

        static void DrawBoard() // Draw board method ==========================================
        {
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[1], pos[2], pos[3]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[4], pos[5], pos[6]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[7], pos[8], pos[9]);
        }

        static void Main(string[] args) // Main Program ==============================================
        {
            string player1 = "", player2 = "";
            int choice = 0, turn = 1, score1 = 0, score2 = 0;
            bool winFlag = false, playing = true, correctInput = false;

            QuestionPool question = new QuestionPool();
            question.addQuestion(QuestionFactory.createQuestion("What is the function of the Skeletal System?", "[1] Serves as support for your body", "[2] Helps your body move with muscles",
                                                                "[3] Protects your organs", "[4] All of the above", "4"));

            question.addQuestion(QuestionFactory.createQuestion("Lungs are the primary organs of this system.", "[1] Muscular System", "[2] Nervous System",
                                                                "[3] Circulatory System", "[4] Respiratory System", "4"));

            question.addQuestion(QuestionFactory.createQuestion("Which system absorbs oxygen and releases carbon dioxide?", "[1] Respiratory System", "[2] Excretory System",
                                                                "[3] Endocrine System", "[4] Immune System", "1"));

            question.addQuestion(QuestionFactory.createQuestion("This system supports the body and protects vital organs.", "[1] Skeletal System", "[2] Muscular System",
                                                                "[3] Circulatory System", "[4] Nervous System", "1"));

            question.addQuestion(QuestionFactory.createQuestion("What is included in the Nervous System?", "[1] Heart", "[2] Skin",
                                                                "[3] Brain", "[4] Lungs", "3"));

            question.addQuestion(QuestionFactory.createQuestion("Which example best shows structures that make up the digestive system?", "[1] Lungs, Heart, Arteries", "[2] Brain, Spinal Cord, Nerves",
                                                                "[3] Stomach, Intestines, Esophagus", "[4] Nose, Lungs", "3"));

            question.addQuestion(QuestionFactory.createQuestion("This system breaks down food into nutrients that the body can absorb.", "[1] Digestive System", "[2] Excretory System",
                                                                "[3] Reproductive System", "[4] Immune System", "1"));

            question.addQuestion(QuestionFactory.createQuestion("This system transports oxygen and nutrients around the body.", "[1] Circulatory System", "[2] Respiratory System",
                                                                "[3] Skeletal System", "[4] Digestive System", "1"));

            question.addQuestion(QuestionFactory.createQuestion("Which system is the esophagus in?", "[1] Digestive System", "[2] Urinary System",
                                                                "[3] Integumentary System", "[4] Respiratory System", "1"));

            question.addQuestion(QuestionFactory.createQuestion("Which system is the stomach in?", "[1] Respiratory System", "[2] Digestive System",
                                                                "[3] Nervous System", "[4] Skeletal System", "2"));


            

            

            

            string titlee = @"████████ ██  ██████ ██   ██   ████████  ██████   ██████ ██   ██   ████████  ██████  ███████ 
   ██    ██ ██      ██  ██       ██    ██    ██ ██      ██  ██       ██    ██    ██ ██      
   ██    ██ ██      █████  █████ ██    ██    ██ ██      █████  █████ ██    ██    ██ █████   
   ██    ██ ██      ██  ██       ██    ██    ██ ██      ██  ██       ██    ██    ██ ██      
   ██    ██  ██████ ██   ██      ██     ██████   ██████ ██   ██      ██     ██████  ███████ 
                                                                                            
                                                                          ";
            Console.WriteLine("\n" + titlee);
            Console.WriteLine("Greetings, players!\n");
            Console.Write("- What is your name, Player 1?: ");
            player1 = Console.ReadLine();

            Console.Write("\n- What your name, Player 2?: ");
            player2 = Console.ReadLine();

            string lolhello = "\nWelcome to Tick-Tock-Toe, " + player1 + " & " + player2 + "! " + player1 + " is 'O' and " + player2 + " is 'X'" + ".         \n";

            foreach (char c in lolhello)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine("\n{0} will be going first. \n\nPress 'enter' to start.", player1);

            Console.ReadLine();
            Console.Clear();
            string loading = @"    ┌┬┐┬ ┬┌─┐  ┌─┐┌─┐┌┬┐┌─┐  ┬┌─┐          
     │ ├─┤├┤   │ ┬├─┤│││├┤   │└─┐          
     ┴ ┴ ┴└─┘  └─┘┴ ┴┴ ┴└─┘  ┴└─┘          
┌─┐┌┐ ┌─┐┬ ┬┌┬┐  ┌┬┐┌─┐  ┌─┐┌┬┐┌─┐┬─┐┌┬┐   
├─┤├┴┐│ ││ │ │    │ │ │  └─┐ │ ├─┤├┬┘ │    
┴ ┴└─┘└─┘└─┘ ┴    ┴ └─┘  └─┘ ┴ ┴ ┴┴└─ ┴   o                                                                                 ";
            foreach (char e in loading)
            {
                Console.Write(e);
                System.Threading.Thread.Sleep(5);
            }
            Console.Clear();


            int qIdx = 0;
            Question[] questionsArr =  question.GetQuestions().ToArray();

            while (playing == true)
            {
                while (winFlag == false) // Game loop ------------------------------------------------------
                {
                    string titlee1 = @"████████ ██  ██████ ██   ██   ████████  ██████   ██████ ██   ██   ████████  ██████  ███████ 
   ██    ██ ██      ██  ██       ██    ██    ██ ██      ██  ██       ██    ██    ██ ██      
   ██    ██ ██      █████  █████ ██    ██    ██ ██      █████  █████ ██    ██    ██ █████   
   ██    ██ ██      ██  ██       ██    ██    ██ ██      ██  ██       ██    ██    ██ ██      
   ██    ██  ██████ ██   ██      ██     ██████   ██████ ██   ██      ██     ██████  ███████ 
                                                                                            
                                                                          ";




                    
                    Console.WriteLine("\n" + titlee1);
                    DrawBoard();
                    Console.WriteLine("");

                    Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                    if (turn == 1)
                    {
                        Console.WriteLine("\nIt is currently {0}'s (O) turn.\n", player1);
                    }
                    if (turn == 2)
                    {
                        Console.WriteLine("It is currently {0}'s (X) turn.\n", player2);
                    }

                    while (correctInput == false)
                    {

                        string answer;
                        
                        Question q = questionsArr[qIdx]; 
                        Console.WriteLine(q.getquestionText());
                        Console.WriteLine(q.getchoice1());
                        Console.WriteLine(q.getchoice2());
                        Console.WriteLine(q.getchoice3());
                        Console.WriteLine(q.getchoice4());

                        answer = Console.ReadLine();

                        if (answer.Equals(q.getcorrectChoice()))
                        {
                            qIdx++;
                            Console.WriteLine("Correct Answer!");
                            Console.WriteLine("\nWhich position would you like to take?");
                            choice = int.Parse(Console.ReadLine()); 

                            if (choice > 0 && choice < 10)
                            {
                                correctInput = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Answer, Please Try Again.");
                        }
                       
                    }

                    correctInput = false; // Reset -------

                    if (turn == 1)
                    {
                        if (pos[choice] == "X") // Checks to see if spot is taken already --------------------
                        {
                            Console.WriteLine("You can't steal positions! ");
                            Console.Write("Try again.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            pos[choice] = "O";
                        }
                    }
                    if (turn == 2)
                    {
                        if (pos[choice] == "O") // Checks to see if spot is taken already -------------------
                        {
                            Console.WriteLine("You can't steal positions! ");
                            Console.Write("Try again.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            pos[choice] = "X";
                        }
                    }

                    winFlag = CheckWin();

                    if (winFlag == false)
                    {
                        if (turn == 1)
                        {
                            turn = 2;
                        }
                        else if (turn == 2)
                        {
                            turn = 1;
                        }
                        Console.Clear();
                    }
                }

                Console.Clear();

                DrawBoard();

                for (int i = 1; i < 10; i++) // Resets board ------------------------
                {
                    pos[i] = i.ToString();
                }

                if (winFlag == false) // No one won ---------------------------
                {
                    Console.WriteLine("It's a draw!");
                    Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                    Console.WriteLine("");
                    Console.WriteLine("What would you like to do now?");
                    Console.WriteLine("1. Play again");
                    Console.WriteLine("2. Leave");
                    Console.WriteLine("");

                    while (correctInput == false)

                    {
                        Console.WriteLine("Enter your option: ");
                        choice = int.Parse(Console.ReadLine());

                        if (choice > 0 && choice < 3)
                        {
                            correctInput = true;
                        }
                    }

                    correctInput = false; // Reset -------------

                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                            playing = false;
                            break;
                    }
                }

                if (winFlag == true) // Someone won -----------------------------
                {
                    if (turn == 1)
                    {
                        score1++;
                        Console.WriteLine("{0} wins!", player1);
                        Console.WriteLine("What would you like to do now?");
                        Console.WriteLine("1. Play again");
                        Console.WriteLine("2. Leave");

                        while (correctInput == false)
                        {
                            Console.WriteLine("Enter your option: ");
                            choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 3)
                            {
                                correctInput = true;
                            }
                        }

                        correctInput = false; // Reset --------------

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Thanks for playing!");
                                Console.ReadLine();
                                playing = false;
                                break;
                        }
                    }

                    if (turn == 2)
                    {
                        score2++;
                        Console.WriteLine("Congratulations, {0}! You won!", player2);
                        Console.WriteLine("What would you like to do now?");
                        Console.WriteLine("1. Play again.");
                        Console.WriteLine("2. Leave.");

                        while (correctInput == false)
                        {
                            Console.WriteLine("Please enter your option (1,2): ");
                            choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 3)
                            {
                                correctInput = true;
                            }
                        }

                        correctInput = false; // Reset -----------------

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Thank you for playing! Hope you both enjoyed!");
                                Console.ReadLine();
                                playing = false;
                                break;
                        }
                    }
                }
            }
        }

        static bool CheckWin() // Win checker method ================================================
        {
            if (pos[1] == "O" && pos[2] == "O" && pos[3] == "O") // Horizontal ----------------------------------------
            {
                return true;
            }
            else if (pos[4] == "O" && pos[5] == "O" && pos[6] == "O")
            {
                return true;
            }
            else if (pos[7] == "O" && pos[8] == "O" && pos[9] == "O")
            {
                return true;
            }

            else if (pos[1] == "O" && pos[5] == "O" && pos[9] == "O") // Diagonal -----------------------------------------
            {
                return true;
            }
            else if (pos[7] == "O" && pos[5] == "O" && pos[3] == "O")
            {
                return true;
            }

            else if (pos[1] == "O" && pos[4] == "O" && pos[7] == "O")// Coloumns ------------------------------------------
            {
                return true;
            }
            else if (pos[2] == "O" && pos[5] == "O" && pos[8] == "O")
            {
                return true;
            }
            else if (pos[3] == "O" && pos[6] == "O" && pos[9] == "O")
            {
                return true;
            }

            if (pos[1] == "X" && pos[2] == "X" && pos[3] == "X") // Horizontal ----------------------------------------
            {
                return true;
            }
            else if (pos[4] == "X" && pos[5] == "X" && pos[6] == "X")
            {
                return true;
            }
            else if (pos[7] == "X" && pos[8] == "X" && pos[9] == "X")
            {
                return true;
            }

            else if (pos[1] == "X" && pos[5] == "X" && pos[9] == "X") // Diagonal -----------------------------------------
            {
                return true;
            }
            else if (pos[7] == "X" && pos[5] == "X" && pos[3] == "X")
            {
                return true;
            }

            else if (pos[1] == "X" && pos[4] == "X" && pos[7] == "X") // Coloumns ------------------------------------------
            {
                return true;
            }
            else if (pos[2] == "X" && pos[5] == "X" && pos[8] == "X")
            {
                return true;
            }
            else if (pos[3] == "X" && pos[6] == "X" && pos[9] == "X")
            {
                return true;
            }
            else // No winner ----------------------------------------------
            {
                return false;
            }
        }
    }
}