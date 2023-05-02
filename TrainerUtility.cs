namespace mis_221_pa_5_rtmccanna
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility (Trainer[] trainers) {
            this.trainers = trainers;
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
            System.Console.WriteLine("Trainer Options:\n\n1:    Add Trainer\n2:    Edit Trainer\n3:    Delete Trainer\n4:    Exit\n\nTrainers:");
            this.GetAlltrainersFromFile();
            this.PrintAllTrainers();
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
                this.AddTrainer();
            }
            if (Convert.ToInt32(userInput) == 2) {
                this.UpdateTrainer();
            }
            if (Convert.ToInt32(userInput) == 3) {
                this.Delete();
            }
        }

        // Loads trainers into an array when the program starts up
        public void GetAlltrainersFromFile() {
            StreamReader inFile = new StreamReader("trainers.txt");
            
            // process
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null) {
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(temp[0], temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }
            // close
            inFile.Close();
        }

        // Adds trainer and then saves them to file with the save method
        public void AddTrainer() {
            Trainer myTrainer = new Trainer();
            string displayID = this.MakeNewID();
            myTrainer.SetID(displayID);
            System.Console.WriteLine($"The New Trainer's ID is: {displayID}");
            System.Console.WriteLine("Please enter the trainer's Name:");
            myTrainer.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter your Mailing Address:");
            myTrainer.SetMailingAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter your Email Address:");
            myTrainer.SetEmailAddress(Console.ReadLine());

            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncCount();

            Save();
        }

        // saves to file
        public void Save() {
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetCount(); i++) {
                outFile.WriteLine(trainers[i].ToFile());

            }

            outFile.Close();
        }

        // Processes search value, since the update process uses numbered menu selection all that was needed to be searched for is i
        private int Find (int searchVal) {
            for (int i = 0; i < Trainer.GetCount(); i++) {
                if(i == searchVal) {
                    return i;
                }
            }

            return -1;
        }

        // Modified update method, subtracts 1 from search val to account for the +1 added in the PrintAllTrainers method, accounting for array placement starting at 0
        public void UpdateTrainer() {
            System.Console.WriteLine("Please Select the Trainer you wish to update from the menu:");
            int searchVal = int.Parse(Console.ReadLine());
            searchVal = searchVal-1;
            int foundIndex = Find(searchVal);

            if (foundIndex != -1) {
                System.Console.WriteLine("Please Enter trainer's Name:");
                trainers[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer's ID:");
                trainers[foundIndex].SetID(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer's Email Address:");
                trainers[foundIndex].SetEmailAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer's Mailing Address:");
                trainers[foundIndex].SetMailingAddress(Console.ReadLine());
            
                Save();
            }

            else {
                System.Console.WriteLine("Trainer Not Found");
            }
        }

        // Prints all trainers, to display on the menu it adds 1 to account for i having to start at 0
        public void PrintAllTrainers() {
            for (int i = 0; i < Trainer.GetCount(); i++){
                System.Console.Write($"{i+1}:    ");
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

        // Special thanks to David Hunt for helping me with this, I did have to modify it in order to work with my
        // menu selection logic so that it would rely upon the user picking specific numbers instead of an attribute of an object.
        public void Delete()
        {
            //EXTRA When deleting trainer use for loop to rewrite each trainer back one so that you don't have records filled with N/A
            System.Console.WriteLine("Please select the trainer you would like to delete from the menu:");
            int searchVal = int.Parse(Console.ReadLine());
            searchVal = searchVal-1;
            int foundIndex = Find(searchVal);
 
            if(foundIndex != -1)
            {
                for(int i = foundIndex+1; i < Trainer.GetCount(); i++)
                {
                    trainers[i].SetName(trainers[i].GetName());
                    trainers[i-1] = trainers[i];
                }
 
                //I was trying to delete a specific line but couldn't figure out how,
                //So what I'm doing is writing over the specific line, moving every line back one and then deleting the last
                //line of the file because it leaves a duplicate of the last record
 
                Save();
 
                string[] lines = File.ReadAllLines("trainers.txt");
                File.WriteAllLines("trainers.txt", lines.Take(lines.Length - 1).ToArray());
                Trainer.DecCount();
            }
 
            else
            {
                System.Console.WriteLine("This trainer does not exist.");
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