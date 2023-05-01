namespace mis_221_pa_5_rtmccanna
{
    public class TrainerReport
    {
        Trainer[] Trainers;

        public TrainerReport(Trainer[] Trainers) {
            this.Trainers = Trainers;
        }

        public void PrintAllTrainers() {
            for (int i = 0; i < Trainer.GetCount(); i++){
                System.Console.WriteLine(Trainers[i].ToString());
            }
        }

        // public void IDsByName() {
        //     string curr = Trainers[0].GetName();
        //     int count = Trainers[0].GetID();
        //     for (int i = 1; i < Trainer.GetCount(); i++) {
        //         if(Trainers[i].GetName() == curr) {
        //             count += Trainers[i].GetID();
        //         } else{
        //             ProcessBreak(ref curr, ref count, Trainers[i]);
        //         }
        //     }
        //     ProcessBreak(curr,count);
        // }

        // public void ProcessBreak(ref string curr, ref int count, Trainer newTrainer) {
        //     System.Console.WriteLine($"{curr}\t{count}");
        //     curr = newTrainer.GetName();
        //     count = newTrainer.GetID();
        // }
        
        // public void ProcessBreak(string curr, int count) {
        //     System.Console.WriteLine($"{curr}\t{count}");
        // }
    }
}