namespace mis_221_pa_5_rtmccanna
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility (Listing[] listings) {
            this.listings = listings;
        }

        public void GetAlllistings() {
            Listing.SetCount(0);
            System.Console.WriteLine("Please enter the Name or stop to stop");
            string userInput = Console.ReadLine();
            while(userInput.ToUpper() != "STOP") {
                listings[Listing.GetCount()] = new Listing();
                listings[Listing.GetCount()].SetName(userInput);

                System.Console.WriteLine("Please Enter the ID:");
                listings[Listing.GetCount()].SetID(Console.ReadLine());

                System.Console.WriteLine("Please Enter the number of Pages:");
                listings[Listing.GetCount()].SetEmailAddress(Console.ReadLine());
                
                System.Console.WriteLine("Please Enter the Genre:");
                listings[Listing.GetCount()].SetMailingAddress(Console.ReadLine());
                Listing.IncCount();

                System.Console.WriteLine("Please enter the Name or stop to stop");
                userInput = Console.ReadLine();
            }
        }

        public void GetAlllistingsFromFile() {
            StreamReader inFile = new StreamReader("listings.txt");
            
            // process
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null) {
                string[] temp = line.Split('#');
                // wordCount += temp.Length;
                listings[Listing.GetCount()] = new Listing(temp[0], temp[1], temp[2], temp[3]);
                Listing.IncCount();
                line = inFile.ReadLine();
            }
            // close
            inFile.Close();
        }
        public void AddListing() {
            System.Console.WriteLine("Please Enter your Name:");
            Listing myListing = new Listing();
            myListing.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter your ID:");
            myListing.SetID(Console.ReadLine());
            System.Console.WriteLine("Please enter your Email Address:");
            myListing.SetEmailAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter your Mailing Address:");
            myListing.SetMailingAddress(Console.ReadLine());

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
                if(listings[i].GetName().ToUpper() == searchVal.ToUpper()) {
                    return i;
                }
            }

            return -1;
        }

        public void UpdateListing() {
            System.Console.WriteLine("What is the Name of the Listing that you would like to update?");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if (foundIndex != -1) {
                System.Console.WriteLine("Please Enter Listing's Name:");
                listings[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the Listing's ID:");
                listings[foundIndex].SetID(Console.ReadLine());
                System.Console.WriteLine("Please enter the Listing's Email Address:");
                listings[foundIndex].SetEmailAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the Listing's Mailing Address:");
                listings[foundIndex].SetMailingAddress(Console.ReadLine());
            
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
    }
}