namespace mis_221_pa_5_rtmccanna
{
    public class Booking
    {
        private string sessionID;
        private string customerName;
        private string customerEmail;
        private string trainingDate;
        private string trainerID;
        private string trainerName;
        private string status = "booked";
        static private int count;

        public Booking() {

        }

        public Booking(string sessionID, string customerName, string customerEmail, string trainingDate, string trainerID, string trainerName, string status) {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }

        public void SetSessionID(string sessionID) {
            this.sessionID = sessionID;
        }

        public void GetSessionID() {
            return sessionID;
        }

        public void SetCustomerName(string customerName) {
            this.trainerName = trainerName;
        }

        public void GetCustomerName() {
            return customerName;
        }

        public void SetCustomerEmail(string customerEmail) {
            this.customerEmail = customerEmail;
        }

        public void GetCustomerEamil() {
            return customerEmail;
        }

        public void SetTrainingDate(string trainingDate) {
            this.trainingDate = trainingDate;
        }

        public void GetTrainingDate() {
            return trainingDate;
        }

        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public void GetTrainerName() {
            return trainerName;
        }

        public void SetTrainerID(string trainerID) {
            this.trainerID = trainerID;
        }

        public void GetTrainerID() {
            return trainerID;
        }

        public void SetStatus(string status) {
            this.status = status;
        }

        public void GetStatus() {
            return status;
        }

        static public void SetCount(int count) {
            Booking.count = count;
        }

        static public void IncCount() {
            count++;
        }

        static public int GetCount() {
            return count;
        }

        public override string ToString()
        {
            return $"{count}:    {sessionID}    {customerName}    {customerEmail}    {trainingDate}    {trainerID}    {trainerName}    {status}";
        }

        public string ToFile()
        {
            return $"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{status}";
        }
    }
}