namespace mis_221_pa_5_rtmccanna
{
    public class Report
    {
        private Booking[] bookings;
        
        public Report (Booking[] bookings) {
            this.bookings = bookings;
        }

        // Menu start up
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

        // Displays the menu
        private void DisplayMenu() {
            Console.Clear();
            System.Console.WriteLine("What kind of a report would you like to generate?\n\n1:    Individual Customer Sessions:\n2:    Historical Customer Sessions\n3:    Historical Revenue Report\n4:    Exit");
            this.GetAllBookingsFromFile();
        }

        // Checks for the validity of the menu choice
        private bool ValidMenuChoice(string userInput){
            if (Convert.ToInt32(userInput) == 1 || Convert.ToInt32(userInput) == 2 || Convert.ToInt32(userInput) == 3 || Convert.ToInt32(userInput) == 4) {
            return true;
            }
            else {
                return false;
            }
        }

        // Routes the user, very similar to my PA3 menu logic so far
        private void Route(string userInput){
            if (Convert.ToInt32(userInput) == 1) {
                this.IndividualCustomerReport();
            }
            if (Convert.ToInt32(userInput) == 2) {
                this.HistoricCustomerSessions();
            }
            if (Convert.ToInt32(userInput) == 3) {
                this.HistoricalRevenueReport();
            }
        }

        // generates a report for an individual customer
        public void IndividualCustomerReport() {
            System.Console.WriteLine("Enter the Email of the Customer you would like to generate the report for:");
            string searchVal = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < Booking.GetCount(); i++) {
                int foundIndex = Find(searchVal);
                if (foundIndex != -1) {
                    System.Console.WriteLine(bookings[foundIndex]);
                    count++;
                }
            }
            System.Console.WriteLine($"This customer had a total of {count} session(s)\n\nPress Any Key to Continue...");
            Console.ReadLine();
        }

        // sorts the transactions file by date and then by customer, saves to the historicalreports.txt
        public void HistoricCustomerSessions() {
            this.Sort();
            this.PrintAllBookings();
            System.Console.WriteLine("Would you like to save this report?\n\n1:    Yes\n2:    No");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1) {
                Save();
            }
        }

        // Generates the overall historical revenue sorted by date, see comment on SortByTime() for details on how I sorted this.
        public void HistoricalRevenueReport() {
            this.SortByTime();
            this.PrintAllBookings();
            System.Console.WriteLine("Would you like to save this report?\n\n1:    Yes\n2:    No");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1) {
                Save();
            }
        }

        private int Find (string searchVal) {
            for (int i = 0; i < Booking.GetCount(); i++) {
                if(bookings[i].GetCustomerEmail().ToUpper() == searchVal.ToUpper()) {
                    return i;
                }
            }

            return -1;
        }

        // I decided to use Date Parse for the date sorting, initially I was thinking of pulling the dates out and treating them
        // as though they were '/' delimitted but decided to go with this as it was simpler and produced the same result
        public void SortByTime() {
            for (int i = 0; i < Booking.GetCount() - 1; i++) {
                int min = i;
                for (int j = i + 1; j < Booking.GetCount(); j++) {
                    if (DateTime.Parse(bookings[j].GetTrainingDate()) < DateTime.Parse((bookings[min].GetTrainingDate()))) {
                        min = j;
                    }
                }
                if(min != i) {
                    Swap(min, i);
                }
            }
        }

        // The sort method used for the customer date sort
        public void Sort() {
            for (int i = 0; i < Booking.GetCount() - 1; i++) {
                int min = 1;
                for (int j = i + 1; j < Booking.GetCount(); j++) {
                    if (bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName()) < 0 ||
                    (bookings[j].GetCustomerName() == bookings[min].GetCustomerName() && DateTime.Parse(bookings[j].GetTrainingDate()) < DateTime.Parse(bookings[min].GetTrainingDate()))
                    ) {
                        min = j;
                    }
                }
                if(min != i) {
                    Swap(min, i);
                }
            }
        }

        private void Swap(int x, int y) {
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }

        public void Save() {
            StreamWriter outFile = new StreamWriter("historicalreports.txt");

            for(int i = 0; i < Booking.GetCount(); i++) {
                outFile.WriteLine(bookings[i].ToFile());

            }

            outFile.Close();
        }

        public void GetAllBookingsFromFile() {
            StreamReader inFile = new StreamReader("transactions.txt");
            
            // process
            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null) {
                string[] temp = line.Split('#');
                // wordCount += temp.Length;
                bookings[Booking.GetCount()] = new Booking(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }
            // close
            inFile.Close();
        }

        public void PrintAllBookings() {
            for (int i = 0; i < Booking.GetCount(); i++){
                System.Console.Write($"{i+1}:    ");
                System.Console.WriteLine(bookings[i].ToString());
            }
        }
    }
}