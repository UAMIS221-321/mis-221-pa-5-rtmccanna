namespace mis_221_pa_5_rtmccanna
{
    public class BookingUtility
    {
        private Booking[] bookings;

        public BookingUtility (Booking[] bookings) {
            this.bookings = bookings;
        }

        // Menu Startup, decided to put it in here because it helps focus and compartimentalize the menus on their corresponding
        // classes and functions.
        public string GetMenuChoice(){
            this.DisplayMenu();
            string userInput = Console.ReadLine();

            while (!ValidMenuChoice(userInput)) {
            Console.Clear();
            Console.WriteLine("Invalid menu choice!\nPlease Enter a Valid Menu Choice.");
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();

            this.DisplayMenu();
            userInput = Console.ReadLine();
            }
            while (userInput != "4") {
                Route(userInput);
                userInput = GetMenuChoice();
            }

            return userInput;
        }

        // Display menu, took me a minute to figure out to use '.this' instead of the utility object but it worked out in the end
        private void DisplayMenu() {
            Console.Clear();
            System.Console.WriteLine("Booking Options:\n\n1:    Add Booking\n2:    Edit Booking\n3:    Delete Booking\n4:    Exit\n\nBookings:");
            this.GetAllBookingsFromFile();
            this.PrintAllBookings();
        }

        // Check for valid menu choice.
        private bool ValidMenuChoice(string userInput){
            if (Convert.ToInt32(userInput) == 1 || Convert.ToInt32(userInput) == 2 || Convert.ToInt32(userInput) == 3 || Convert.ToInt32(userInput) == 4) {
            return true;
            }
            else {
                return false;
            }
        }

        // Route to ensure a smooth menu experience, so far pretty similar menu logic to my PA3
        private void Route(string userInput){
            if (Convert.ToInt32(userInput) == 1) {
                this.AddBooking();
            }
            if (Convert.ToInt32(userInput) == 2) {
                this.UpdateBooking();
            }
            if (Convert.ToInt32(userInput) == 3) {
                this.Delete();
            }
        }

        // pulls all of the bookings from the transactions file and puts them into an array
        public void GetAllBookingsFromFile() {
            StreamReader inFile = new StreamReader("transactions.txt");
            
            // process
            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null) {
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }
            // close
            inFile.Close();
        }

        // Adds a booking to the end of the file
        public void AddBooking() {
            Booking myBooking = new Booking();
            string displayID = this.MakeNewID();
            myBooking.SetSessionID(displayID);
            System.Console.WriteLine($"Your New Session's ID is: {displayID}");
            System.Console.WriteLine("Please enter the Customer Name:");
            myBooking.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the Customer's Email:");
            myBooking.SetCustomerEmail(Console.ReadLine());
            System.Console.WriteLine("Please enter the Training Date:");
            myBooking.SetTrainingDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the Trainer's ID:");
            myBooking.SetTrainerID(Console.ReadLine());
            System.Console.WriteLine("Please enter the Trainer's Name:");
            myBooking.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the Booking Status:");
            myBooking.SetStatus(Console.ReadLine());

            bookings[Booking.GetCount()] = myBooking;
            Booking.IncCount();

            Save();
        }

        // Saves to file
        public void Save() {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Booking.GetCount(); i++) {
                outFile.WriteLine(bookings[i].ToFile());

            }

            outFile.Close();
        }

        // Conducts a search through the array of objects
        private int Find (int searchVal) {
            for (int i = 0; i < Booking.GetCount(); i++) {
                if(i == searchVal) {
                    return i;
                }
            }

            return -1;
        }

        // Updates an object's attributes, wanted to write individual methods to only change one to improve user experience
        // but couldn't get around to it
        public void UpdateBooking() {
            System.Console.WriteLine("Please select the booking you would like to update from the menu:");
            int searchVal = int.Parse(Console.ReadLine());
            searchVal = searchVal-1;
            int foundIndex = Find(searchVal);

            if (foundIndex != -1) {
                System.Console.WriteLine("Please Enter the Session's ID:");
                bookings[foundIndex].SetSessionID(Console.ReadLine());
                System.Console.WriteLine("Please enter the Associated Customer's Name:");
                bookings[foundIndex].SetCustomerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the Customer's Email Address:");
                bookings[foundIndex].SetCustomerEmail(Console.ReadLine());
                System.Console.WriteLine("Please enter the Date of the Session:");
                bookings[foundIndex].SetTrainingDate(Console.ReadLine());
                System.Console.WriteLine("Please enter the associtated Trainer's ID:");
                bookings[foundIndex].SetTrainerID(Console.ReadLine());
                System.Console.WriteLine("Please enter the associated Trainer's Name:");
                bookings[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the Status of the Session:");
                bookings[foundIndex].SetStatus(Console.ReadLine());
            
                Save();
            }

            else {
                System.Console.WriteLine("Booking Not Found");
            }
        }

        // Only updates the status of the object so that its more efficient when that is the only thing being changed
        public void UpdateStatus() {
            System.Console.WriteLine("Please select the Booking you wish to update the status of from the menu:");
            int searchVal = int.Parse(Console.ReadLine());
            searchVal = searchVal-1;
            int foundIndex = Find(searchVal);

            if (foundIndex != -1) {
                System.Console.WriteLine("Please select the Booking's new status:\n1:    Completed\n2:    Cancelled");
                int userInput = int.Parse(Console.ReadLine());
                while (userInput == 1 && userInput == 2) {
                    Console.Clear();
                    System.Console.WriteLine("Please select one of the available options:\n1:    Completed\n2:    Cancelled");
                    userInput = int.Parse(Console.ReadLine());
                }
                
                if (userInput == 1) {
                    bookings[foundIndex].SetStatus("Completed");
                }
                if (userInput == 2) {
                    bookings[foundIndex].SetStatus("Cancelled");
                }

                Save();
            }
        }

        public void PrintAllBookings() {
            for (int i = 0; i < Booking.GetCount(); i++){
                System.Console.Write($"{i+1}:    ");
                System.Console.WriteLine(bookings[i].ToString());
            }
        }

        // Special thanks to David Hunt for helping me with this, I did have to modify it in order to work with my
        // menu selection logic so that it would rely upon the user picking specific numbers instead of an attribute of an object.
        public void Delete()
        {
            //EXTRA When deleting trainer use for loop to rewrite each trainer back one so that you don't have records filled with N/A
            System.Console.WriteLine("Please select the session you would like to delete from the menu:");
            int searchVal = int.Parse(Console.ReadLine());
            searchVal = searchVal-1;
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                for(int i = foundIndex+1; i < Booking.GetCount(); i++)
                {
                    bookings[i].SetSessionID(bookings[i].GetSessionID());
                    bookings[i-1] = bookings[i];
                }
 
                //I was trying to delete a specific line but couldn't figure out how,
                //So what I'm doing is writing over the specific line, moving every line back one and then deleting the last
                //line of the file because it leaves a duplicate of the last record
 
                Save();
 
                string[] lines = File.ReadAllLines("transactions.txt");
                File.WriteAllLines("transactions.txt", lines.Take(lines.Length - 1).ToArray());
                Booking.DecCount();
            }
 
            else
            {
                System.Console.WriteLine("This booking does not exist.");
                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // Random ID Generator, concatenates after the first cycle of the for loop
        public string MakeNewID() {
            string newID = "";
            for (int i = 0; i < 6; i++) {
                Random rnd = new Random();
                int num = rnd.Next(0,9);
                if (i == 0) {
                    newID = num.ToString();
                }
                if (i > 0) {
                    newID = newID + num.ToString();
                }
            }
            return newID;
        }
    }
}