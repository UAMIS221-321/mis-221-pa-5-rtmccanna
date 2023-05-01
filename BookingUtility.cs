namespace mis_221_pa_5_rtmccanna
{
    public class BookingUtility
    {
        private Booking[] bookings;

        public BookingUtility (Booking[] bookings) {
            this.bookings = bookings;
        }

        static string GetMenuChoice(){
            DisplayMenu();
            string userInput = Console.ReadLine();

            while (!ValidMenuChoice(userInput)) {
            Console.WriteLine("Invalid menu choice!\nPlease Enter a Valid Menu Choice.");
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();

            DisplayMenu();
            userInput = Console.ReadLine();
            }

            return userInput;
        }

        static void DisplayMenu() {
            Console.Clear();
            System.Console.WriteLine("1:    Add Booking\n2:    Edit Booking\n3:    Delete Booking\n4:    Exit");
            PrintAllBookings();
        }

        static bool ValidMenuChoice(string userInput){
            if (Convert.ToInt32(userInput) == 1 || Convert.ToInt32(userInput) == 2 || Convert.ToInt32(userInput) == 3 || Convert.ToInt32(userInput) == 4) {
            return true;
            }
            else {
                return false;
            }
        }

        static void Route(string userInput){
            if (Convert.ToInt32(userInput) == 1) {
                AddBooking();
            }
            if (Convert.ToInt32(userInput) == 2) {
                UpdateBooking();
            }
            if (Convert.ToInt32(userInput) == 3) {
        
            }
        }

        public void GetAllBookings() {
            Booking.SetCount(0);
            System.Console.WriteLine("Please enter the Session ID or stop to stop");
            string userInput = Console.ReadLine();
            while(userInput.ToUpper() != "STOP") {
                bookings[Booking.GetCount()] = new Booking();
                bookings[Booking.GetCount()].SetSessionID(userInput);

                System.Console.WriteLine("Please Enter the Session ID:");
                bookings[Booking.GetCount()].SetSessionID(Console.ReadLine());

                System.Console.WriteLine("Please Enter the number of Customer Name:");
                bookings[Booking.GetCount()].SetCustomerName(Console.ReadLine());
                
                System.Console.WriteLine("Please Enter the Customer Email:");
                bookings[Booking.GetCount()].SetCustomerEmail(Console.ReadLine());

                System.Console.WriteLine("Please Enter the Training Date:");
                bookings[Booking.GetCount()].SetTrainingDate(Console.ReadLine());

                System.Console.WriteLine("Please Enter the Trainer ID:");
                bookings[Booking.GetCount()].SetTrainerID(Console.ReadLine());

                System.Console.WriteLine("Please Enter the Trainer Name:");
                bookings[Booking.GetCount()].SetTrainerID(Console.ReadLine());

                System.Console.WriteLine("Please Enter the Status:");
                bookings[Booking.GetCount()].SetStatus(Console.ReadLine());
                Booking.IncCount();

                System.Console.WriteLine("Please enter the Name or stop to stop");
                userInput = Console.ReadLine();
            }
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
        public void AddBooking() {
            System.Console.WriteLine("Please Enter the Session ID:");
            Booking myBooking = new Booking();
            myBooking.SetSessionID(Console.ReadLine());
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

        public void Save() {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Booking.GetCount(); i++) {
                outFile.WriteLine(bookings[i].ToFile());

            }

            outFile.Close();
        }

        private int Find (string searchVal) {
            for (int i = 0; i < Booking.GetCount(); i++) {
                if(bookings[i].GetSessionID().ToUpper() == searchVal.ToUpper()) {
                    return i;
                }
            }

            return -1;
        }

        public void UpdateBooking() {
            System.Console.WriteLine("Please select the booking's corresponding menu number that you would like to update:");
            string searchVal = Console.ReadLine();
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

        // public void Sort() {
        //     for (int i = 0; i < Booking.GetCount() - 1; i++) {
        //         int min = i;
        //         for (int j = i + 1; j < Booking.GetCount(); j++) {
        //             if (bookings[j].GetName().CompareTo(bookings[min].GetName()) < 0 ||
        //             (bookings[j].GetName() == bookings[min].GetName() && bookings[j].GetID() < bookings[min].GetID())
        //             ) {
        //                 min = j;
        //             }
        //         }
        //         if(min != i) {
        //             Swap(min, i);
        //         }
        //     }
        // }

        private void Swap(int x, int y) {
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }

        public void PrintAllBookings() {
            for (int i = 0; i < Booking.GetCount(); i++){
                System.Console.WriteLine(bookings[i].ToString());
            }
        }
    }
}