using System;
using static System.Console; 

namespace BookStore { 
    class Program {
        //declare variables
        const int MIN = 1; const int MAX = 30;

        static void Main() {
            //Part C4- Main Method
            //Call A1- Prompt user for number of books (1-30)
            int numberOfBooks = InputValue(MIN, MAX);  
            //Call C1 - Create array of books inputted by user
            Book[] books = new Book[numberOfBooks];
            GetBookData(numberOfBooks, books);
            //Call C2 - Display all books in array
            DisplayAllBooks(books);
            //Call C3 - Allow user to input a category code and see information in the category
            GetLists(numberOfBooks, books);
        }
        //Part A1 - input no. of books (1-30) & check valid 
        public static int InputValue(int min, int max) { 
            int inputNum;
            Write("\nEnter a number (of books) which is in the range of 1 and 30>> ");
            inputNum = Convert.ToInt32(ReadLine());
            Write("************************ ********* ************************");

            while (!(inputNum >= min && inputNum <= max)) {
                Write("Incorrect number entered, please re-enter number in range of 1 and 30>> ");
                inputNum = Convert.ToInt32(ReadLine());
            }
            return inputNum;  //this returns correct number of books entered. 
        }
        //Part A2 - check an input string (e.g. book ID) entered is valid (true/false) - string length = 5, string starts with 2 uppercase letters, ends with 3 digits
        public static bool isValid(string id) {
            int lastThreeDigits;
            if (((id.Length == 5) && (id[0] >= 65 && id[0] <= 90) && (id[1] >= 65 && id[1] <= 90)) && (int.TryParse(id.Substring(2, 3), out lastThreeDigits))) {
                return lastThreeDigits >= 0;
            }
            else {
                return false;
            }
        }
        //Method - input book ID 
        public static string InputBookID() {
            Write("\nEnter book ID which starts with a category code (2 uppercase letters) and ends with 3-digits>> ");
            return ReadLine();
        }
        //Part C1 - Create method to fill an array of books inputted from user 
        private static void GetBookData(int num, Book[] books) {
            for (int i = 0; i < num; i++)
            {
                //1. Prompt for book title
                //Enter book title/name
                string bookTitle; 
                Write("\nEnter Book name/title>> ");
                bookTitle = ReadLine();

                //2.Display list of valid book categories - Prompt for user to enter valid book id (e.g. CS123)
                DisplayListBookCategories();
                string bookId = InputBookID();
                while (!isValid(bookId)) {
                    Write("Invalid bookID entered, please re-enter book id which starts with a category code and ends with a 3-digit number>>");
                    bookId = InputBookID();
                }
                //Enter book price
                double price;
                Write("Enter book price>> ");
                price = Convert.ToDouble(ReadLine());
                //Enter book pages
                int numPages; 
                Write("Enter book number of pages>> ");
                numPages = Convert.ToInt32(ReadLine());
                //Create a new book each time through array
                Book aBook = new Book(bookId, bookTitle, numPages, price);
                books[i] = aBook;
            }
        }
        //Part C2 - Create method to display info of all book inputted - order num, book id, title, no. of pages, price
        //This method should call the ToString method created in Book class
        public static void DisplayAllBooks(Book[] books){
            WriteLine("\n");
            Write("\n************************ ********* ************************");
            Write("\nInformation of all books");
            WriteLine(""); 
            //get data entry input of all book info from Part C1 by calling ToString method from Part B6 
            for (int x = 0; x < books.Length; x++)
            {
                WriteLine("\nBook {0}:\t\t{1}", x + 1, books[x].ToString());
            }
            Write("\n************************ ********* ************************");
        }
        //Part C3
        // 1. Method to display valid book categories &
        // 2. continuously prompts user to enter category codes
        // 3. display information of all books in category & no. of books in category --> unable to solve this
        // 4. appropriate messages displayed if entered category code is not valid
        private static void GetLists(int num, Book[] books) {
            //Display list of valid book categories
            WriteLine("\n");
            DisplayListBookCategories();
            //Prompt user continously for category codes until Z entered to quit
            const string QUIT = "Z";
            string inputCode;
            Write("\nEnter a category code or {0} to quit >> ", QUIT);
            inputCode = ReadLine();
            while (inputCode != QUIT ) {
                for (int x = 0; x < Book.categoryCodes[x].Length; x++) {
                    if (inputCode == Book.categoryCodes[x]) {
                        Write("\nNo books in the category {0}", Book.categoryNames[x]);
                        break;
                    }
                    else if (inputCode != Book.categoryCodes[x]) {
                        Write("\n{0} is not a valid category code.", inputCode);
                        Write("\nEnter a category code or {0} to quit >> ", QUIT);
                        inputCode = ReadLine();
                    }
                    else {
                        Write("\nBooks with category code {0} are:", inputCode);
                        Write("\n");
                        Write("\nNumber of books in the category {0}: {1}", Book.categoryNames[x], x);
                        break;
                    }
                }
            }
        }
        public static void DisplayListBookCategories(){
            WriteLine("Category codes are:");
            WriteLine("\tCS\tComputer Science");
            WriteLine("\tIS\tInformation System");
            WriteLine("\tSE\tSecurity");
            WriteLine("\tSO\tSociety");
            WriteLine("\tMI\tMiscellaneous");
        }

    }
}
