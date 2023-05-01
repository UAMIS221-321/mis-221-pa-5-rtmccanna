namespace mis_221_pa_5_rtmccanna
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility (Trainer[] trainers) {
            this.trainers = trainers;
        }

        public void GetAlltrainers() {
            Trainer.SetCount(0);
            System.Console.WriteLine("Please enter the Name or stop to stop");
            string userInput = Console.ReadLine();
            while(userInput.ToUpper() != "STOP") {
                trainers[Trainer.GetCount()] = new Trainer();
                trainers[Trainer.GetCount()].SetName(userInput);

                System.Console.WriteLine("Please Enter the ID:");
                trainers[Trainer.GetCount()].SetID(Console.ReadLine());

                System.Console.WriteLine("Please Enter the number of Pages:");
                trainers[Trainer.GetCount()].SetEmailAddress(Console.ReadLine());
                
                System.Console.WriteLine("Please Enter the Genre:");
                trainers[Trainer.GetCount()].SetMailingAddress(Console.ReadLine());
                Trainer.IncCount();

                System.Console.WriteLine("Please enter the Name or stop to stop");
                userInput = Console.ReadLine();
            }
        }

        public void GetAlltrainersFromFile() {
            StreamReader inFile = new StreamReader("trainers.txt");
            
            // process
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while (line != null) {
                string[] temp = line.Split('#');
                // wordCount += temp.Length;
                trainers[Trainer.GetCount()] = new Trainer(temp[0], temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }
            // close
            inFile.Close();
        }
        public void AddTrainer() {
            System.Console.WriteLine("Please Enter your Name:");
            Trainer myTrainer = new Trainer();
            myTrainer.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter your ID:");
            myTrainer.SetID(Console.ReadLine());
            System.Console.WriteLine("Please enter your Email Address:");
            myTrainer.SetEmailAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter your Mailing Address:");
            myTrainer.SetMailingAddress(Console.ReadLine());

            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncCount();

            Save();
        }

        public void Save() {
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetCount(); i++) {
                outFile.WriteLine(trainers[i].ToFile());

            }

            outFile.Close();
        }

        private int Find (string searchVal) {
            for (int i = 0; i < Trainer.GetCount(); i++) {
                if(trainers[i].GetName().ToUpper() == searchVal.ToUpper()) {
                    return i;
                }
            }

            return -1;
        }

        public void UpdateTrainer() {
            System.Console.WriteLine("What is the Name of the Trainer that you would like to update?");
            string searchVal = Console.ReadLine();
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

        // public void Sort() {
        //     for (int i = 0; i < Trainer.GetCount() - 1; i++) {
        //         int min = i;
        //         for (int j = i + 1; j < Trainer.GetCount(); j++) {
        //             if (trainers[j].GetName().CompareTo(trainers[min].GetName()) < 0 ||
        //             (trainers[j].GetName() == trainers[min].GetName() && trainers[j].GetID() < trainers[min].GetID())
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
            Trainer temp = trainers[x];
            trainers[x] = trainers[y];
            trainers[y] = temp;
        }
    }
}