namespace mis_221_pa_5_rtmccanna
{
    public class Listing
    {
        private string listingID;
        private string trainerName;
        private string date;
        private string time;
        private int cost;
        private string status;

        static int count;

        public Listing() {

        }

        public Listing(string listingID, string trainerName, string date, string time, int cost, string status) {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.status = status;
        }

        public void SetListingID(string listingID) {
            this.listingID = listingID;
        }

        public void GetListingID() {
            return listingID;
        }

        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public void GetTrainerName() {
            return trainerName;
        }

        public void SetDate(string date) {
            this.date = date;
        }

        public void GetDate() {
            return date;
        }

        public void SetTime(string time) {
            this.time = time;
        }

        public void GetTime() {
            return time;
        }

        public void SetCost(string cost) {
            this.cost = cost;
        }

        public void GetCost() {
            return cost;
        }

        public void SetStatus(string status) {
            this.status = status;
        }

        public void GetStatus() {
            return status;
        }

        public void SetCount() {
            this.count = count;
        }

        public void GetCount() {
            return count;
        }

        public override string ToString()
        {
            return $"";
        }

        public string ToFile()
        {
            return $"";
        }

    }
}