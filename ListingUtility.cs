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
            System.Console.WriteLine("1:    Add Listing\n2:    Edit Listing\n3:    Delete Listing\n4:    Exit");
            this.PrintAllListings();
        }

        static private bool ValidMenuChoice(string userInput){
            if (Convert.ToInt32(userInput) == 1 || Convert.ToInt32(userInput) == 2 || Convert.ToInt32(userInput) == 3 || Convert.ToInt32(userInput) == 4) {
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

        private int Find (string searchVal) {
            for (int i = 0; i < Listing.GetCount(); i++) {
                if(listings[i].GetListingID().ToUpper() == searchVal.ToUpper()) {
                    return i;
                }
            }

            return -1;
        }

        public void UpdateListing() {
            System.Console.WriteLine("What is the Listing ID of the listing you would like to update?");
            string searchVal = Console.ReadLine();
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
                System.Console.WriteLine(listings[i].ToString());
            }
        }
    }
}