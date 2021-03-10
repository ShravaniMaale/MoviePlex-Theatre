using System;
using System.Linq;
using System.Collections.Generic;

namespace MoviePlexTheatre
{
    public class Home
    {
        static int selection = 0;
        string userSelection;

        public void HomePage()
        {
            Console.WriteLine("\t\t\t\t\t**************************************************************");
            Console.WriteLine("\t\t\t\t\t**************** Welcome to Movieplex Theatre ****************");
            Console.WriteLine("\t\t\t\t\t**************************************************************");
            Console.WriteLine();
            Console.WriteLine();
            // Ask the user to choose an option.
            Console.WriteLine("Please select from the following options:");
            Console.WriteLine("\t1: Administrator");
            Console.WriteLine("\t2: Guest");
            Console.Write("Selection: ");
            userSelection = Console.ReadLine();
            do
            {
                if (Int32.TryParse(userSelection, out selection))
                {
                    if (selection == 1)
                    {
                        Administrator Admin = new Administrator();
                        Admin.Admin_Validation();
                        break;
                    }
                    if (selection == 2)
                    {
                        Guest guest = new Guest();
                        guest.GuestPage();
                        break;
                    }
                    if (selection != 1 || selection != 2)
                    {
                        Console.WriteLine("Please select from the options provided. Returning back to Home Screen\n\n");
                        HomePage();
                        break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Please select from the options provided. Returning back to Home Screen\n\n");
                    HomePage();
                    break;
                }
            } while (selection != 1 || selection != 2);
        }

    }

    public class Administrator
    {
        public static int movieCount = 0;
        public static string[] movieNamesArray;
        public static string[] movieRatingsArray;
        public static IList<string> movieNamesList = new List<string>();
        public static IList<string> movieRatingsList = new List<string>();
        public string AdminPassword = "Admin";
        public bool VerifyAdmin(string incomingstring)
        {
            movieNamesList.Clear();
            movieRatingsList.Clear();
            return string.Equals(incomingstring, AdminPassword);
           
        }

        public void Admin_Validation()
        {


            int PwdValidationChances = 5;

            // Administration

            while (PwdValidationChances != 0)
            {
                Console.WriteLine("\nPlease enter the Admin password: ");
                string userEnteredPwd = Console.ReadLine();
                if (!VerifyAdmin(userEnteredPwd))
                {
                    PwdValidationChances--;
                    Console.WriteLine("You entered an Invalid password.");
                    Console.WriteLine("You have {0} more attempts to enter the correct password OR press B to go back to the previous screen.", PwdValidationChances);
                    if (PwdValidationChances == 0)
                    {
                        Console.WriteLine("\nAll the 5 attempts are completed. Goind back to the Home Screen.\n");
                        Home home1 = new Home();
                        home1.HomePage();
                    }
                    else if (userEnteredPwd.ToUpper() == "B")
                    {
                        Home home1 = new Home();
                        home1.HomePage();
                    }
                }

                else
                {
                    // call administration program
                    Admin_block();
                }
            }
        }
        public void Admin_block()
        {
            Console.WriteLine("\nWelcome MoviePlex Administrator");
            Console.WriteLine("How many movies are playing today? ");
            var count = Console.ReadLine();
            if (int.TryParse(count, out movieCount))
            {
                if (!MovieCountCheck(movieCount))
                {
                    Admin_block();
                }
                else
                {
                    MovieDetails(movieCount);
                }

            }
            else
            {
                Console.WriteLine("Please Enter a Valid Number");
                Admin_block();
            }
        }
        public bool MovieCountCheck(int movieCount)
        {
           
            if (movieCount > 0 && movieCount <= 10)
            {

                return true;
            }

            else if (movieCount <= 0)
            {
                Console.WriteLine("Number of Movies should be greater than 0. Please Enter a Valid Number.");
                return false;

            }
            else
            {
                Console.WriteLine("Maximum Number of Movies that can be Played are 10. Please Enter a Valid Number.");
                return false;


            }
        }
        public void MovieDetails(int movieCount)
        {
            string index = " ";
            string adminRating;
            string AdminSatisfy;

            for (int i = 0; i < movieCount; i++)
            {
                switch (i)
                {
                    case 0:
                        index = "First";
                        break;
                    case 1:
                        index = "Second";
                        break;
                    case 2:
                        index = "Third";
                        break;
                    case 3:
                        index = "Fourth";
                        break;
                    case 4:
                        index = "Fifth";
                        break;
                    case 5:
                        index = "Sixth";
                        break;
                    case 6:
                        index = "Seventh";
                        break;
                    case 7:
                        index = "Eighth";
                        break;
                    case 8:
                        index = "Ninth";
                        break;
                    case 9:
                        index = "Tenth";
                        break;
                }
                string AdminMovieInput;
                while (true)
                {
                    Console.WriteLine("\nPlease Enter The {0} Movie's Name: ", index);
                    AdminMovieInput = Console.ReadLine().Trim();

                    if (AdminMovieInput == String.Empty || AdminMovieInput == null)
                    {
                        Console.WriteLine("\nMovie Name Cannot be Null.");

                    }

                    else
                    {
                        movieNamesList.Add(AdminMovieInput);
                        break;
                    }
                }

                while (true)
                {

                    Console.WriteLine("The available Ratings are: \n { G } \n { PG } \n { R } \n { PG-13 } \n { NC-17 }");
                    Console.WriteLine("\nPlease Enter The Age Limit or Rating For The {0} Movie: ", index);
                    adminRating = Console.ReadLine().ToUpper().Trim();
                    if (MovieRatingCheck(adminRating))
                    {
                        movieRatingsList.Add(adminRating);
                        break;

                    }
                 
                    else
                    {
                        bool isNumber= int.TryParse(adminRating, out int n);
                        if (isNumber)
                        {
                            if (MovieAgeCheck(n))
                            {
                                movieRatingsList.Add(adminRating);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Age should be between 0 and 118. Please enter the Correct Value.");
                                continue;

                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Please choose the ratings from the list given");
                            continue;

                        }
                        

                    }
                   
                 }


                }
                
            
            
            movieNamesArray = movieNamesList.ToArray();
            movieRatingsArray = movieRatingsList.ToArray();
            Console.WriteLine("\nMovies playing for Today: ");
            for (int j = 0; j < movieCount; j++)
            {
                Console.WriteLine(j + 1 + ". " + movieNamesArray[j] + "{" + movieRatingsArray[j] + "}");
            }
            do
            {
                Console.WriteLine("\nYour Movies Playing Today Are Listed Above. Are You Satisfied? (Y/N)?");
                AdminSatisfy = Console.ReadLine().ToUpper();
                if (AdminSatisfy == "Y")
                {
                    //Open the home page
                    Home home1 = new Home();
                    home1.HomePage();
                    break;
                }
                else if (AdminSatisfy == "N")
                {
                    movieNamesList.Clear();
                    movieRatingsList.Clear();
                    // Open the Admin starting Page to enter the number of movies.
                    Admin_block();
                    break;
                }
            } while (AdminSatisfy != "Y" || AdminSatisfy != "N");
        }
    
    public bool MovieRatingCheck(string adminRating)
    {
            if (adminRating == "G" || adminRating == "PG" || adminRating == "R" || adminRating == "PG-13" || adminRating == "NC-17")
            {
                return true;
            }
            else
            {

                return false;
            }
    }



    public bool MovieAgeCheck(int  n)
    {
       
            if (n < 0 || n > 118)
            {
                return false;
            }
            else
            {
                return true;
            }


     }
     
  }

    public class Guest
        {
            Administrator Admin1 = new Administrator();
            Home home1 = new Home();
            static string userSelectedMovie;
            static string userSelectedRating;
            static int ageLimitForMovie;
            static int userChoiceMovie;
            static int noOfMovies = Administrator.movieCount;
            string backHomeOption;
            int ageInt;
            public void GuestPage()
            {
                if (Administrator.movieCount == 0)
                {
                    Console.WriteLine("There are no movies Playing Today.");
                    string backHome;
                    do
                    {
                        Console.WriteLine("Press 'H' to go back to Home Screen");
                        backHome = Console.ReadLine().Trim().ToUpper();
                        if (backHome == "H")
                        {
                            home1.HomePage();
                        }
                    } while (backHome != "H");
                }
                else
                {
                    if (noOfMovies == 1)
                    {
                        Console.WriteLine("\n\nThere is only {0} movie playing today. Please Select Your Movie:", noOfMovies);
                    }
                    else
                    {
                        Console.WriteLine("\n\nThere are {0} movies playing today. Please choose from the following movies:", noOfMovies);
                    }
                    for (int k = 0; k < Administrator.movieCount; k++)
                    {
                        Console.WriteLine(k + 1 + ". " + Administrator.movieNamesArray[k] + " {" + Administrator.movieRatingsArray[k] + "}");
                    }
                    Console.Write("\n\nWhich Movie Would You Like To watch: ");
                    var userChoice = Console.ReadLine();
                    // int movieIndex;
                    Console.WriteLine();

                if (verifyUserChoiceMovie(userChoice))
                {
                    Console.WriteLine();
                }
                else
                    {
                        Console.WriteLine("Please Select a Movie From The List Provided.");
                        GuestPage();
                    }

                    if (userSelectedRating == "G")
                    {
                        ageLimitForMovie = 0;
                    }
                    else if (userSelectedRating == "PG")
                    {
                        ageLimitForMovie = 10;
                    }
                    else if (userSelectedRating == "PG-13")
                    {
                        ageLimitForMovie = 13;
                    }
                    else if (userSelectedRating == "R")
                    {
                        ageLimitForMovie = 15;
                    }
                    else if (userSelectedRating == "NC-17")
                    {
                        ageLimitForMovie = 17;
                    }
                    else if (int.TryParse(userSelectedRating, out int rating))
                    {
                        ageLimitForMovie = rating;
                    }


                    Console.WriteLine("Selected Movie: \n" + userSelectedMovie + "{" + userSelectedRating + "}");
                    string ageString;
                    do
                    {
                        Console.Write("\n\nPlease Enter Your Age For Verification: ");
                        ageString = Console.ReadLine();
                        if (int.TryParse(ageString, out int age))
                        {
                            ageInt = age;
                            if (age > 118 || age < 0)
                            {
                                Console.WriteLine("\n\nAge Should be Between 0 and 118. Please Enter Valid Age to Continue");
                                continue;
                            }
                            else if (age >= ageLimitForMovie)
                            {
                                Console.WriteLine("\n\n\t\t\t\tEnjoy the movie!!");
                                do
                                {
                                    Console.WriteLine("\nSelect 'B' to go back to Guest Screen OR 'H' to go back to Home Screen");
                                    backHomeOption = Console.ReadLine().ToUpper();
                                    if (backHomeOption == "B")
                                    {
                                        GuestPage();
                                    }
                                    else if (backHomeOption == "H")
                                    {
                                        Administrator.movieNamesList.Clear();
                                        Administrator.movieRatingsList.Clear();
                                        home1.HomePage();

                                    }

                                } while (backHomeOption != "B" || backHomeOption != "H");
                                break;
                            }
                            else if (ageLimitForMovie > age)
                            {
                                Console.WriteLine("\n\nYou are not allowed to watch this movie. \nThis movie requires a minimum age of {0}", ageLimitForMovie);
                                GuestPage();
                                break;
                            }
                            break;
                        }
                        else
                        {
                            ageInt = -1;
                            Console.WriteLine("please enter a valid age to continue");
                            continue;
                        }
                    } while (ageInt > 118 || ageInt < 0);


                }


            }
        public bool verifyUserChoiceMovie(string userMovie)
        {
            int movieIndex;
            if (Administrator.movieNamesArray.Contains(userMovie))
            {
                userSelectedMovie = userMovie;
                movieIndex = Array.IndexOf(Administrator.movieNamesArray, userSelectedMovie);
                userSelectedRating = Administrator.movieRatingsArray[movieIndex];
                return true;
            }
            else if (int.TryParse(userMovie, out userChoiceMovie))
            {
                if (userChoiceMovie > noOfMovies || userChoiceMovie <= 0)
                {
                    Console.WriteLine("Please select a Movie from the provided List.");
                    GuestPage();
                    return false;
                }
                else
                {
                    userSelectedMovie = Administrator.movieNamesArray[userChoiceMovie - 1];
                    userSelectedRating = Administrator.movieRatingsArray[userChoiceMovie - 1];
                    return true;
                }
            }
            return false;


        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                Home home = new Home();
                home.HomePage();


            }
        }
   } 


