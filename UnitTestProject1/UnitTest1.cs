using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviePlexTheatre;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AdminCorrectPasswordCheck()

        {
            Administrator admin = new Administrator();
            var isPasswordCorrect = admin.VerifyAdmin("Admin");
            Assert.IsTrue(isPasswordCorrect);
        }


        [TestMethod]
        public void AdminWrongPasswordCheck()

        {
            Administrator admin = new Administrator();
            var isPasswordWrong = admin.VerifyAdmin("xyz");
            Assert.IsFalse(isPasswordWrong);
        }

        [TestMethod]
        
        public void MovieCountGreaterthan10()
        {
            Administrator admin = new Administrator();
            var numberIncorrect= admin.MovieCountCheck(11);
            Assert.IsFalse(numberIncorrect);

        }
        [TestMethod]

        public void MovieCountLesserthan0()
        {
            Administrator admin = new Administrator();
            var numberIncorrect = admin.MovieCountCheck(11);
            Assert.IsFalse(numberIncorrect);

        }

        [TestMethod]

        public void MovieCountCorrect()
        {
            Administrator admin = new Administrator();
            var numberCorrect = admin.MovieCountCheck(1);
            Assert.IsTrue(numberCorrect);

        }
        [TestMethod]

        public void MovieCorrectRating()
        {
            Administrator admin = new Administrator();
            var isRatingCorrect = admin.MovieRatingCheck("G");
            Assert.IsTrue(isRatingCorrect);

        }
        [TestMethod]
        public void MovieInCorrectRating()
        {
            Administrator admin = new Administrator();
            var isRatingCorrect = admin.MovieRatingCheck("Ggggg");
            Assert.IsFalse(isRatingCorrect);
        }
        [TestMethod]
        public void MovieIncorrectAgeCheck()
        {

            Administrator admin = new Administrator();
            var isAgeCorrect = admin.MovieAgeCheck(199);
            Assert.IsFalse(isAgeCorrect);
        }

        [TestMethod]
        public void MovieAgeCheck()
        {

            Administrator admin = new Administrator();
            var isAgeCorrect = admin.MovieAgeCheck(22);
            Assert.IsTrue(isAgeCorrect);
        }

        [TestMethod]
        public void UserChoiceMovieInCorrect()
        {
            Guest guest = new Guest();
            Administrator.movieNamesArray = new string[] { "xyz" };
            var isUserChoiceMovieInCorrect = guest.verifyUserChoiceMovie("gfhrerycn");
            // Console.WriteLine(isUserChoiceMovieInCorrect);
            Assert.IsFalse(isUserChoiceMovieInCorrect);
            


        }
        

    }
    }

