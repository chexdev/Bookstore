using System;
using static System.Console;

namespace BookStore { 
    class Book { 
        //DATA FIELDS
        //Part B1 - create 2 pubic static arrays - categoryCode & categoryName 
        public static string[] categoryCodes = { "CS", "IS", "SE", "SO", "MI" };
        public static string[] categoryNames = {"Computer Science", "Information System", "Security", "Society", "Miscellaneous"};
        //Part B2 - create 2 data fields - bookId & categoryNameofBook 
        string bookId;
        string categoryName;
        //PROPERTIES
        //Part B3 - create 3 auto-implemented properties - BookTitle, NumofPages, Price 
        public string BookTitle { get; set; }
        public int NumOfPages { get; set; }
        public double Price { get; set; }
        //Part B4 - create 2 properties - book id & book category name
        //(a)Assume the set assessor will always receive a book id of valid format (e.g. CS125" is valid)
        //(b)Assume book ids also refer to known categories 'Computer Science' & 'Information Systems' etc.
        //(c)If book id does not refer to a known category, set assessor must retain the number (last 3 digits) and assign it to 'MI' category
        public string BookId {
            get {
                return bookId; 
            }
            set {
                bool found = false; // has a valid code been found?
                // check first 2 characters are a valid code
                string code = value.Substring(0, 2);
                for (int i = 0; i < categoryCodes.Length; i++) {
                    if (code == categoryCodes[i]) {
                        // found a valid code - so set found to true and stop looking - also set the value of bookId
                        bookId = value;
                        categoryName = categoryNames[i];
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    // not found - SET to MI[last 3 digits]
                    bookId = "MI" + value.Substring(2);
                    categoryName = "Miscellaneous";
                }
            }
        }
        //4. assign category property (read-only) a value when book id is set.
        public string CategoryName {  
            get {
                return categoryName;
            }
        }
        //CONSTRUCTORS
        // Part B5 - create 2 constructors - Book(), Book(id, title, pages, price) 
        public Book() {
        }
        public Book(string bookId, string bookTitle, int numPages, double price) {
            BookId = bookId;
            BookTitle = bookTitle; 
            NumOfPages = numPages; 
            Price = price; 
        }
        //METHODS
        //Part B6 - create ToString (pubic override) to return info of a book object using format given in screenshot: Information of all books
        public override string ToString () {
            return string.Format("{0}\t{1}\t{2}\t{3}", bookId, BookTitle, NumOfPages, Price.ToString("C2")); 
        }
    }
}