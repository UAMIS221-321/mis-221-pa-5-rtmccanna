namespace mis_221_pa_5_rtmccanna
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility (Listing[] listings) {
            this.listings = listings;
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

            while (userInput != "5") {
                Route(userInput);
                userInput = GetMenuChoice();
            }
            

            return userInput;
        }

        // Display menu, took me a minute to figure out to use '.this' instead of the utility object but it worked out in the end
        private void DisplayMenu() {
            Console.Clear();
            System.Console.WriteLine("Listing Options:\n\n1:    Add Listing\n2:    Edit Listing\n3:    Update Listing Status\n4:    Delete Listing\n5:    Exit\n\nListings:");
            this.GetAllListingsFromFile();
            this.PrintAllListings();
        }

        // Check for valid menu choice.
        static private bool ValidMenuChoice(string userInput){
            if (Convert.ToInt32(userInput) == 1 || Convert.ToInt32(userInput) == 2 || Convert.ToInt32(userInput) == 3 || Convert.ToInt32(userInput) == 4 || Convert.ToInt32(userInput) == 5) {
            return true;
            }
            else {
                return false;
            }
        }

        // Route to ensure a smooth menu experience, so far pretty similar menu logic to my PA3
        private void Route(string userInput){
            if (Convert.ToInt32(userInput) == 1) {
                this.AddListing();
            }
            if (Convert.ToInt32(userInput) == 2) {
                this.UpdateListing();
            }
            if (Convert.ToInt32(userInput) == 3) {
                this.UpdateStatus();
            }
            if (Convert.ToInt32(userInput) == 4) {
                this.Delete();
            }
        }

        // pulls all of the listings from the listings file and puts them into an array
        public void GetAllListingsFromFile() {
            StreamReader inFile = new StreamReader("listings.txt");
            
            // process
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null) {
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(temp[0], temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5]);
                Listing.IncCount();
                line = inFile.ReadLine();
            }
            // close
            inFile.Close();
        }

        // Adds a listing to the end of a file
        public void AddListing() {
            Listing myListing = new Listing();
            string displayID = this.MakeNewID();
            myListing.SetListingID(displayID);
            System.Console.WriteLine($"Your New Listing's ID is: {displayID}");
            System.Console.WriteLine("Please enter the Trainer's Name:");
            myListing.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the Listing Date:");
            myListing.SetDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the Listing's Time:");
            myListing.SetTime(Console.ReadLine());
            System.Console.WriteLine("Please enter the Listing's Price:");
            myListing.SetCost(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the Listing's Status:");
            myListing.SetStatus(Console.ReadLine());

            listings[Listing.GetCount()] = myListing;
            Listing.IncCount();

            Save();
        }

        // saves to file
        public void Save() {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++) {
                outFile.WriteLine(listings[i].ToFile());

            }

            outFile.Close();
        }

        // Conducts a search through the array of objects
        private int Find (int searchVal) {
            for (int i = 0; i < Listing.GetCount(); i++) {
                if(i == searchVal) {
                    return i;
                }
            }

            return -1;
        }

        // Updates an object's attributes, wanted to write individual methods to only change one to improve user experience
        // but couldn't get around to it
        public void UpdateListing() {
            System.Console.WriteLine("Please select the listing you wish to update from the menu:");
            int searchVal = int.Parse(Console.ReadLine());
            searchVal = searchVal-1;
            int foundIndex = Find(searchVal);

            if (foundIndex != -1) {
                System.Console.WriteLine("Please Enter Listing's ID:");
                listings[foundIndex].SetListingID(Console.ReadLine());
                System.Console.WriteLine("Please enter the corresponding Trainer's Name:");
                listings[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the Listing's Date:");
                listings[foundIndex].SetDate(Console.ReadLine());
                System.Console.WriteLine("Please enter the Listing's Time:");
                listings[foundIndex].SetTime(Console.ReadLine());
                System.Console.WriteLine("Please enter the Listing's Price:");
                listings[foundIndex].SetCost(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the Listing's Status:");
                listings[foundIndex].SetStatus(Console.ReadLine());
            
                Save();
            }

            

            else {
                System.Console.WriteLine("Listing Not Found");
            }
        }
        
        // Only updates the status of the object so that its more efficient when that is the only thing being changed
        public void UpdateStatus() {
            System.Console.WriteLine("Please select the Listing you wish to update the status of from the menu:");
            int searchVal = int.Parse(Console.ReadLine());
            searchVal = searchVal-1;
            int foundIndex = Find(searchVal);

            if (foundIndex != -1) {
                System.Console.WriteLine("Please select the Listing's new status:\n1:    Available\n2:    Taken");
                int userInput = int.Parse(Console.ReadLine());
                while (userInput == 1 && userInput == 2) {
                    Console.Clear();
                    System.Console.WriteLine("Please select one of the available options:\n1:    Available\n2:    Taken");
                    userInput = int.Parse(Console.ReadLine());
                }
                
                if (userInput == 1) {
                    listings[foundIndex].SetStatus("Available");
                }
                if (userInput == 2) {
                    listings[foundIndex].SetStatus("Taken");
                }

                Save();
            }
        }

        public void PrintAllListings() {
            for (int i = 0; i < Listing.GetCount(); i++){
                System.Console.Write($"{i+1}:    ");
                System.Console.WriteLine(listings[i].ToString());
            }
        }

        // Special thanks to David Hunt for helping me with this, I did have to modify it in order to work with my
        // menu selection logic so that it would rely upon the user picking specific numbers instead of an attribute of an object.
        public void Delete()
        {
            //EXTRA When deleting trainer use for loop to rewrite each trainer back one so that you don't have records filled with N/A
            System.Console.WriteLine("Please select the listing you would like to delete from the menu:");
            int searchVal = int.Parse(Console.ReadLine());
            searchVal = searchVal-1;
            int foundIndex = Find(searchVal);
 
            if(foundIndex != -1)
            {
                for(int i = foundIndex+1; i < Listing.GetCount(); i++)
                {
                    listings[i].SetListingID(listings[i].GetListingID());
                    listings[i-1] = listings[i];
                }
 
                //I was trying to delete a specific line but couldn't figure out how,
                //So what I'm doing is writing over the specific line, moving every line back one and then deleting the last
                //line of the file because it leaves a duplicate of the last record
 
                Save();
 
                string[] lines = File.ReadAllLines("listings.txt");
                File.WriteAllLines("listings.txt", lines.Take(lines.Length - 1).ToArray());
                Listing.DecCount();
            }
 
            else
            {
                System.Console.WriteLine("This listing does not exist.");
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