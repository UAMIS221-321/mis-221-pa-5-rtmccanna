using mis_221_pa_5_rtmccanna;

// **** Start Main ****

Trainer[] trainers = new Trainer[50];
Listing[] listings = new Listing[50];
Booking[] bookings = new Booking[50];
TrainerUtility trainerUtility = new TrainerUtility(trainers);
BookingUtility bookingUtility = new BookingUtility(bookings);
ListingUtility listingUtility = new ListingUtility(listings);
Report report = new Report(bookings);

string userInput = GetMenuChoice();
while (userInput != "5") 
{
    Route(userInput);
    userInput = GetMenuChoice();
}

// **** End Main ****

static string GetMenuChoice(){
    DisplayMenu();
    string userInput = Console.ReadLine();

    while (!ValidMenuChoice(userInput))
    {
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
    System.Console.WriteLine("Welcome to the Crimson Gym!");
    System.Console.WriteLine("1:    Manage Trainer Data\n2:    Manage Listing Data\n3:    Manage Customer Booking Data\n4:    Run Reports\n5:    Exit");
}

static bool ValidMenuChoice(string userInput){
    if (Convert.ToInt32(userInput) == 1 || Convert.ToInt32(userInput) == 2 || Convert.ToInt32(userInput) == 3 || Convert.ToInt32(userInput) == 4 || Convert.ToInt32(userInput) == 5) {
        return true;
    }
    else {
        return false;
    }
}

void Route(string userInput){
    if (Convert.ToInt32(userInput) == 1) {
        trainerUtility.GetMenuChoice();
    }
    if (Convert.ToInt32(userInput) == 2) {
        listingUtility.GetMenuChoice();
    }
    if (Convert.ToInt32(userInput) == 3) {
        bookingUtility.GetMenuChoice();
    }
    if (Convert.ToInt32(userInput) == 4) {
        report.GetMenuChoice();
    }
}