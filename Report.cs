namespace mis_221_pa_5_rtmccanna
{
    public class Report
    {
        private Booking[] bookings;

        public Report (Booking[] bookings) {
            this.bookings = bookings;
        }

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

        private void DisplayMenu() {
            Console.Clear();
            System.Console.WriteLine("What kind of a report would you like to generate?\n\n1:    Individual Customer Sessions:\n2:    Historical Customer Sessions\n3:    Historical Revenue Report\n4:    Exit");
        }

        private bool ValidMenuChoice(string userInput){
            if (Convert.ToInt32(userInput) == 1 || Convert.ToInt32(userInput) == 2 || Convert.ToInt32(userInput) == 3 || Convert.ToInt32(userInput) == 4) {
            return true;
            }
            else {
                return false;
            }
        }

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

        public void IndividualCustomerReport() {
            System.Console.WriteLine("Enter the Email of the Customer you would like to generate the report for:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != -1) {
                
            }
        }

        public void HistoricCustomerSessions() {

        }

        public void HistoricalRevenueReport() {

        }

        private int Find (int searchVal) {
            for (int i = 0; i < Booking.GetCount(); i++) {
                if(i == searchVal) {
                    return i;
                }
            }

            return -1;
        }
    }
}