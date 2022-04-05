namespace api.Database
{
    public class DBConnection
    {
        public string cs { get; set; }

        public DBConnection(){
            string server = "kutnpvrhom7lki7u.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "un2ddjg2c0ihozqb";
            string port = "3306";
            string userName = "wx2ykgotf1dy58no";
            string password = "t2wbik9q96udhkqz";
            
            cs = $@"server = {server};user={userName};database={database};port={port};password={password};";
        }

    }
}