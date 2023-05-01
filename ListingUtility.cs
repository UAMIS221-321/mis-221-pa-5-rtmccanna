namespace mis_221_pa_5_rtmccanna
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility (Listing[] listings) {
            this.listings = listings;
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

            while (userInput != "5") {
                Route(userInput);
                userInput = GetMenuChoice();
            }
            

            return userInput;
        }

        private void DisplayMenu() {
            Console.Clear();
            System.Console.WriteLine("Listing Options:\n\n1:    Add Listing\n2:    Edit Listing\n3:    Update Listing Status\n4:    Delete Listing\n5:    Exit\n\nListings:");
            listingUtility.GetAllListingsFromFile();
            this.PrintAllListings();
        }

        static private bool ValidMenuChoice(string userInput){
            if (Convert.ToInt32(userInput) == 1 || Convert.ToInt32(userInput) == 2 || Convert.ToInt32(userInput) == 3 || Convert.ToInt32(userInput) == 4 || Convert.ToInt32(userInput) == 5) {
            return true;
            }
            else {
                return false;
            }
        }

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

        public void GetAlllistings() {
            Listing.SetCount(0);
            System.Console.WriteLine("Please enter the Listing ID or stop to stop");
            string userInput = Console.ReadLine();
            while(userInput.ToUpper() != "STOP") {
                listings[Listing.GetCount()] = new Listing();
                listings[Listing.GetCount()].SetListingID(userInput);

                System.Console.WriteLine("Please Enter the Listing's ID:");
                listings[Listing.GetCount()].SetListingID(Console.ReadLine());

                System.Console.WriteLine("Please Enter the corresponding Trainer's Name:");
                listings[Listing.GetCount()].SetTrainerName(Console.ReadLine());
                
                System.Console.WriteLine("Please Enter the corresponding Date:");
                listings[Listing.GetCount()].SetDate(Console.ReadLine());

                System.Console.WriteLine("Please Enter the corresponding Time:");
                listings[Listing.GetCount()].SetTime(Console.ReadLine());

                System.Console.WriteLine("Please Enter the corresponding Price:");
                listings[Listing.GetCount()].SetCost(int.Parse(Console.ReadLine()));

                System.Console.WriteLine("Please Enter the Listing's Status:");
                listings[Listing.GetCount()].SetStatus(Console.ReadLine());
                Listing.IncCount();

                System.Console.WriteLine("Please enter the Name or stop to stop");
                userInput = Console.ReadLine();
            }
        }

        public void GetAllListingsFromFile() {
            StreamReader inFile = new StreamReader("listings.txt");
            
            // process
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null) {
                string[] temp = line.Split('#');
                // wordCount += temp.Length;
                listings[Listing.GetCount()] = new Listing(temp[0], temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5]);
                Listing.IncCount();
                line = inFile.ReadLine();
            }
            // close
            inFile.Close();
        }
        public void AddListing() {
            System.Console.WriteLine("Please enter the Listing ID:");
            Listing myListing = new Listing();
            myListing.SetListingID(Console.ReadLine());
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

        public void Save() {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++) {
                outFile.WriteLine(listings[i].ToFile());

            }

            outFile.Close();
        }

        private int Find (int searchVal) {
            for (int i = 0; i < Listing.GetCount(); i++) {
                if(i == searchVal) {
                    return i;
                }
            }

            return -1;
        }

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
        
        // Method dedicated to just updating the status of a listing
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

        // public void Sort() {
        //     for (int i = 0; i < Listing.GetCount() - 1; i++) {
        //         int min = i;
        //         for (int j = i + 1; j < Listing.GetCount(); j++) {
        //             if (listings[j].GetName().CompareTo(listings[min].GetName()) < 0 ||
        //             (listings[j].GetName() == listings[min].GetName() && listings[j].GetID() < listings[min].GetID())
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
            Listing temp = listings[x];
            listings[x] = listings[y];
            listings[y] = temp;
        }

        public void PrintAllListings() {
            for (int i = 0; i < Listing.GetCount(); i++){
                System.Console.Write($"{i+1}:    ");
                System.Console.WriteLine(listings[i].ToString());
            }
        }


        public void Delete()
        {
            //EXTRA When deleting trainer use for loop to rewrite each trainer back one so that you don't have records filled with N/A
            System.Console.WriteLine("Please Selection the listing you would like to delete from the menu:");
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
    }
}