using System;
using System.Data.SqlTypes;

namespace Quiz_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int answersCorrect = 0;
            Console.WriteLine("==============================");
            Console.WriteLine("Hi! Welcome to the quizz game!");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine("This game has 2 rounds, and you can only enter another round once you have scored atleast 70%");
            Console.WriteLine("Are you ready Y/N");
            Console.WriteLine();
            string ready = Console.ReadLine();
            if (ready == "Y")
            {
                Console.WriteLine();
                Console.WriteLine("Let the game begin");
                Console.WriteLine();
                int round1Score = RoundOne();
                double percentage = ((double)round1Score / 10) * 100;
                Console.WriteLine($"Round 1 complete! You scored {round1Score} out of 10, which is {percentage}%");
                if (percentage >= 70)
                {
                    Console.WriteLine("Congratulations, you willl now move on to the next round");
                    Console.WriteLine();
                    Console.WriteLine("==============================");
                    Console.WriteLine("Round 2");
                    Console.WriteLine("==============================");
                    Console.WriteLine();
                    Console.WriteLine("This round will consist 10 questions based off general knowledge");

                    int round2Score = RoundTwo();
                    double percentage2 = ((double)round2Score / 10) * 100;
                    Console.WriteLine($"Round 2 complete! You scored {round2Score} out of 10, which is {percentage2}%");

                    if (percentage2 >= 70)
                    {
                        Console.WriteLine("Congratulations, you willl now move on to the next and final round");
                        Console.WriteLine();
                        Console.WriteLine("==============================");
                        Console.WriteLine("Round 3 (The ultimate one)");
                        Console.WriteLine("==============================");
                        Console.WriteLine();
                        Console.WriteLine("The final round will also consist 10 questions based off common geographical knowledge");

                        int round3Score = RoundThree();
                        double percentage3 = ((double)round3Score / 10) * 100;
                        Console.WriteLine($"Round 2 complete! You scored {round3Score} out of 10, which is {percentage3}%");
                        double average = ((double)round3Score + (double)round1Score + (double) round2Score) / 3;
                        int total = round2Score + round1Score + round3Score;
                        Console.WriteLine($"Your average mark across the 3 rounds was {average}, with your total being {total} marks out of 30");

                        Console.WriteLine("Would you like a certificate?");
                        string certificate = Console.ReadLine();

                        if (certificate == "yes")
                        {
                            Console.Write("Enter your name for your official certificate: ");
                            string playerName = Console.ReadLine();
                            GenerateCertificate(playerName, total);
                        }

                    }


                }
                else
                {
                    Console.WriteLine("You still did a decent job!");
                }
            }
            else
            {
                Console.WriteLine("We're sorry to let you go");
            }

        }

        static int RoundOne()
        {
            Console.WriteLine("Here's the first question:\n");

            string[] questions =
            {
                "What does CPU stand for?",
                "Which legislation in the UK protects personal data held by organizations and gives individuals rights over their information?",
                "What is open-source software?",
                "Which protocol is used for securely transmitting web pages over the internet (indicated by the lock icon in browsers)?",
                "Under the UK Computer Misuse Act 1990, which of these is an illegal offense?",
                "What does \"ASCII\" stand for in data representation?",
                "Which of these storage devices uses magnetic platters?",
                "What is cloud computing?",
                "Which component translates high-level source code line-by-line into machine code during execution?",
                "What is the main role of a router in a computer network?"
            };

            // 2D Array: 10 rows (one for each question), 4 columns (for the 4 choices)
            string[,] options =
            {
                { "Central Processing Unit", "Computer Personal Unit", "Central Processing Universal", "Central Plate Unit" },
                { "Computer Misuse Act 1990", "Data Protection Act", "Copyright Act", "Health and Safety Act" },
                { "Software with free source code to inspect and modify", "Software that costs money", "Software locked to Linux", "AI-generated software" },
                { "FTP", "SMTP", "HTTPS", "POP3" },
                { "Writing Python math scripts", "Unauthorized access with intent to commit a crime", "Upgrading your RAM", "Downloading GitHub games" },
                { "American Standard Code for Information Interchange", "Automated System for Coding Internet", "Advanced Software Control", "Algorithmic Sequence" },
                { "Solid State Drive (SSD)", "RAM", "Hard Disk Drive (HDD)", "USB Flash Drive" },
                { "Storing and accessing data over the internet", "Predicting weather with supercomputers", "Writing offline code", "Using wireless mice" },
                { "Compiler", "Interpreter", "Assembler", "Defragmenter" },
                { "Display web pages", "Forward data packets between different networks", "Convert analog signals", "Store backup files" }
            };

            int[] correctAnswers = { 1, 2, 1, 3, 2, 1, 3, 1, 2, 2 };
            int roundScore = 0;

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");

                // Loop through the 4 options for this question using the 2D array syntax [i, j]
                for (int j = 0; j < options.GetLength(1); j++)
                {
                    Console.WriteLine($"{j + 1}) {options[i, j]}");
                }

                Console.Write("Enter your choice (1, 2, 3, or 4): ");
                string userAnswer = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(userAnswer, out int userChoice))
                {
                    if (userChoice == correctAnswers[i])
                    {
                        Console.WriteLine("Correct!\n");
                        roundScore++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Marked as incorrect.\n");
                }
            }

            return roundScore;
        }

        static int RoundTwo()
        {
            Console.WriteLine("Welcome to Round 2: General Knowledge!\n");

            string[] questions =
            {
                "What is the capital city of Australia?",
                "Which planet is known as the Red Planet?",
                "In what year did the Titanic sink on its maiden voyage?",
                "How many strings does a standard guitar have?",
                "Which country is the origin of sushi?",
                "What is the chemical symbol for gold on the periodic table?",
                "Who painted the famous artwork The Mona Lisa?",
                "What is the tallest mountain in the world above sea level?",
                "Which animal is the fastest land mammal on Earth?",
                "How many continents are there on Earth (using the standard 7-continent model)?"
            };

            string[,] options =
            {
                { "Canberra", "Sydney", "Melbourne", "Brisbane" },
                { "Venus", "Jupiter", "Saturn", "Mars" },
                { "1905", "1918", "1912", "1923" },
                { "6", "4", "5", "8" },
                { "China", "Thailand", "South Korea", "Japan" },
                { "Go", "Au", "Gd", "Ag" },
                { "Leonardo da Vinci", "Vincent van Gogh", "Pablo Picasso", "Claude Monet" },
                { "K2", "Kilimanjaro", "Mount Everest", "Mont Blanc" },
                { "Lion", "Pronghorn", "Leopard", "Cheetah" },
                { "5", "7", "6", "8" }
            };

            // Corresponding correct answer numbers (1 through 4)
            int[] correctAnswers = { 1, 4, 3, 1, 4, 2, 1, 3, 4, 2 };
            int roundScore = 0;

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");

                for (int j = 0; j < options.GetLength(1); j++)
                {
                    Console.WriteLine($"{j + 1}) {options[i, j]}");
                }

                Console.Write("Enter your choice (1, 2, 3, or 4): ");
                string userAnswer = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(userAnswer, out int userChoice))
                {
                    if (userChoice == correctAnswers[i])
                    {
                        Console.WriteLine("Correct!\n");
                        roundScore++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Marked as incorrect.\n");
                }
            }

            return roundScore;
        }

        static int RoundThree()
        {
            Console.WriteLine("Welcome to Round 3: Common Geography!\n");

            string[] questions =
            {
                "Which country has the longest coastline in the world?",
                "What is the capital city of Brazil?",
                "In which mountain range is Mount Everest located?",
                "Which desert is the largest hot desert in the world?",
                "Through which country does the Amazon River primarily flow?",
                "What is the smallest country in the world by land area?",
                "Which African nation has the largest population?",
                "Which US state contains the most active volcanoes?",
                "Which major European river flows through Vienna, Budapest, and Belgrade?",
                "What is the capital of New Zealand?"
            };

            // Options mapped so correct answers are nicely randomized (4, 1, 3, 4, 2, 3, 1, 4, 2, 3)
            string[,] options =
            {
                { "USA", "Russia", "Australia", "Canada" },
                { "Brasília", "Rio de Janeiro", "São Paulo", "Salvador" },
                { "Andes", "Rockies", "Himalayas", "Alps" },
                { "Gobi", "Kalahari", "Mojave", "Sahara" },
                { "Peru", "Brazil", "Colombia", "Argentina" },
                { "Monaco", "San Marino", "Vatican City", "Liechtenstein" },
                { "Nigeria", "Egypt", "Ethiopia", "South Africa" },
                { "Hawaii", "California", "Washington", "Alaska" },
                { "Rhine", "Danube", "Thames", "Seine" },
                { "Auckland", "Christchurch", "Wellington", "Queenstown" }
            };

            int[] correctAnswers = { 4, 1, 3, 4, 2, 3, 1, 4, 2, 3 };
            int roundScore = 0;

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");

                for (int j = 0; j < options.GetLength(1); j++)
                {
                    Console.WriteLine($"{j + 1}) {options[i, j]}");
                }

                Console.Write("Enter your choice (1, 2, 3, or 4): ");
                string userAnswer = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(userAnswer, out int userChoice))
                {
                    if (userChoice == correctAnswers[i])
                    {
                        Console.WriteLine("Correct!\n");
                        roundScore++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Marked as incorrect.\n");
                }
            }

            return roundScore;
        }

        static void GenerateCertificate(string playerName, int finalScore)
        {
            string certificate = $@"
            ==================================================================
                                  END OF QUIZZ CEREMONY
                           OFFICIAL CERTIFICATE OF COMPLETION
            ==================================================================
            
              This certificate is proudly presented to:
              
                                  {playerName}
              
              For successfully conquering all rounds of the Multi-Round Quiz Game!
              Final Score: {finalScore} out of 30
              
              Awarded in recognition of great GCSE computing knowledge alongside
              geographical and general knowledge.
              
            ==================================================================
            ";

            Console.WriteLine(certificate);

            string fileName = $"{playerName}_Certificate.txt";
            File.WriteAllText(fileName, certificate);

            Console.WriteLine($"Success! Your certificate has been saved as '{fileName}'.");
        }
    }
}
