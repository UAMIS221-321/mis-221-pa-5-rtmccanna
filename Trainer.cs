namespace mis_221_pa_5_rtmccanna
{
    public class Trainer
    {
        private string name;
        private string ID;
        private string mailingAddress;
        private string emailAddress;

        static private int count;

        public Trainer() {

        }

        public Trainer(string name, string ID, string mailingAddress, string emailAddress) {
            this.name = name;
            this.ID = ID;
            this.mailingAddress = mailingAddress;
            this.emailAddress = emailAddress;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public string GetName () {
            return name;
        }

        public void SetID(string ID) {
            this.ID = ID;
        }

        public string GetID () {
            return ID;
        }

        public void SetMailingAddress(string mailingAddress) {
            this.mailingAddress = mailingAddress;
        }

        public string GetMailingAddress () {
            return mailingAddress;
        }

        public void SetEmailAddress(string emailAddress) {
            this.emailAddress = emailAddress;
        }

        public string GetEmailAddress() {
            return emailAddress;
        }

        static public void SetCount(int count) {
            Trainer.count = count;
        }

        static public void IncCount() {
            count++;
        }

        static public int GetCount() {
            return count;
        }

        public override string ToString()
        {
            return $"{name}    {ID}    {mailingAddress}    {emailAddress}";
        }

        public string ToFile()
        {
            return $"{name}#{ID}#{mailingAddress}#{emailAddress}";
        }
    }
}