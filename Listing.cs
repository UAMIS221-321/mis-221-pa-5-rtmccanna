namespace mis_221_pa_5_rtmccanna
{
    public class Listing
    {
        // Object variables
        private string listingID;
        private string trainerName;
        private string date;
        private string time;
        private int cost;
        private string status;

        static int count;

        public Listing() {

        }

        // Listing Constructor
        public Listing(string listingID, string trainerName, string date, string time, int cost, string status) {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.status = status;
        }

        // Getters and Setters, initially I had the random ID generator in here but decided to just move it to utility
        public void SetListingID(string listingID) {
            this.listingID = listingID;
        }

        public string GetListingID() {
            return listingID;
        }

        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public string GetTrainerName() {
            return trainerName;
        }

        public void SetDate(string date) {
            this.date = date;
        }

        public string GetDate() {
            return date;
        }

        public void SetTime(string time) {
            this.time = time;
        }

        public string GetTime() {
            return time;
        }

        public void SetCost(int cost) {
            this.cost = cost;
        }

        public int GetCost() {
            return cost;
        }

        public void SetStatus(string status) {
            this.status = status;
        }

        public string GetStatus() {
            return status;
        }

        static public void SetCount(int count) {
            Listing.count = count;
        }

        static public void IncCount() {
            count++;
        }

        // DecCount for the deletion method
        static public void DecCount() {
            count--;
        }

        static public int GetCount() {
            return count;
        }

        // ToString to convert objects into string format to be written.
        public override string ToString()
        {
            return $"{listingID}    {trainerName}    {date}    {time}    {cost}    {status}";
        }

        // ToFile, packs the object up to be stored in the corresponding .txt file
        public string ToFile()
        {
            return $"{listingID}#{trainerName}#{date}#{time}#{cost}#{status}";
        }

    }
}