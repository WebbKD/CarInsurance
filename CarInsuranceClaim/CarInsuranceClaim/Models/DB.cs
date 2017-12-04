using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CarInsuranceClaim.Models
{
    public class DB
    {
        //creating a signleton
        private static SqlConnection aConn = null;

        public static SqlConnection Instance()
        {
            SqlConnection myConnection;

            if (DB.aConn != null)
            {
                myConnection = DB.aConn;
            }
            else
            {
                myConnection = new SqlConnection();
            }

            return myConnection;
        }
        //creating an object
        private List<claim> aListOfClaims = new List<claim>();

        //creating methods
        public bool addClaim(string id, string Des, string claimRepairOneD, decimal claimRepairOneE, string claimRepairTwoD, decimal claimRepairTwoE, string claimIMG, string involedPolicyNumber, string involedLicensePlate, string seceneLocation, string claimDate, string claimTime, bool claimStats) {

            bool aFlag = false;
            string aSQL1 = "INSERT INTO tbl_claims(userID, claimDescription, claimRepairShopOneDetails, claimRepairShopOneEstimate, claimRepairShopTwoDetails, claimRepairShopTwoEstimate, claimIMG, personInvoledPolicyNumber, personInvoledLicensePlate, seceneLocation, claimDate, claimTime, claimStats) VALUES ( @userID, @claimDescription, @claimRepairShopOneDetails, @claimRepairShopOneEstimate, @claimRepairShopTwoDetails, @claimRepairShopTwoEstimate, @claimIMG, @personInvoledPolicyNumber, @personInvoledLicensePlate, @seceneLocation, @claimDate, @claimTime, @claimStats)";

            aConn = DB.Instance();
            aConn.ConnectionString = @"Data Source=LAPTOP-6MQIPCEV\SQLEXPRESS;Initial Catalog=accident; Integrated Security =SSPI";

            using (SqlCommand aCommand = new SqlCommand(aSQL1, aConn))
            {

                aCommand.CommandType = System.Data.CommandType.Text;
                aCommand.Parameters.AddWithValue("@userID", id);
                aCommand.Parameters.AddWithValue("@claimDescription", Des);
                aCommand.Parameters.AddWithValue("@claimRepairShopOneDetails", claimRepairOneD);
                aCommand.Parameters.AddWithValue("@claimRepairShopOneEstimate", claimRepairOneE);
                aCommand.Parameters.AddWithValue("@claimRepairShopTwoDetails", claimRepairTwoD);
                aCommand.Parameters.AddWithValue("@claimRepairShopTwoEstimate", claimRepairTwoE);
                aCommand.Parameters.AddWithValue("@claimIMG", claimIMG);
                aCommand.Parameters.AddWithValue("@personInvoledPolicyNumber", involedPolicyNumber);
                aCommand.Parameters.AddWithValue("@personInvoledLicensePlate", involedLicensePlate);
                aCommand.Parameters.AddWithValue("@seceneLocation", seceneLocation);
                aCommand.Parameters.AddWithValue("@claimDate", claimDate);
                aCommand.Parameters.AddWithValue("@claimTime", claimTime);
                aCommand.Parameters.AddWithValue("@claimStats", claimStats);
                aConn.Open();
                aCommand.ExecuteNonQuery();
            }
            aFlag = true;
            aConn.Close();
            return aFlag;
        }

        public List<claim> ViewAllClaimHistory()
        {
            string SQL = "SELECT * FROM tbl_claims";
            aConn = DB.Instance();
            aConn.ConnectionString = @"Data Source=LAPTOP-6MQIPCEV\SQLEXPRESS;Initial Catalog=accident; Integrated Security =SSPI";
            aConn.Open();
            SqlCommand aCommand = aConn.CreateCommand();
            aCommand.CommandText = SQL;

            SqlDataReader aReader = aCommand.ExecuteReader();
            while (aReader.Read())
            {
                int aClaimID = (int)(aReader)["claimID"];
                string aUserID = (string)(aReader)["userID"];
                string aClaimDescription = (string)(aReader)["ClaimDescription"];
                string aClaimRepairShopOneDetails = (string)(aReader)["ClaimRepairShopOneDetails"];
                decimal aClaimRepairShopOneEstimate = (decimal)(aReader)["ClaimRepairShopOneEstimate"];
                string aClaimRepairShopTwoDetails = (string)(aReader)["ClaimRepairShopTwoDetails"];
                decimal aClaimRepairShopTwoEstimate = (decimal)(aReader)["ClaimRepairShopTwoEstimate"];
                string aClaimIMG = (string)(aReader)["claimIMG"];
                string aPersonInvoledPolicyNumber = (string)(aReader)["PersonInvoledPolicyNumber"];
                string aPersonInvoledLicensePlate = (string)(aReader)["PersonInvoledLicensePlate"];
                string aSeceneLocation = (string)(aReader)["seceneLocation"];
                string aClaimDate = Convert.ToString((aReader)["claimDate"]);
                string aClaimTime = (string)(aReader)["claimTime"];
                bool aClaimStats = (bool)(aReader)["claimStats"];

                claim aClaim = new claim();
                aClaim.ClaimID = aClaimID;
                aClaim.UserID = aUserID;
                aClaim.ClaimDescription = aClaimDescription;
                aClaim.ClaimRepairShopOneDetails = aClaimRepairShopOneDetails;
                aClaim.ClaimRepairShopOneEstimate = aClaimRepairShopOneEstimate;
                aClaim.ClaimRepairShopTwoDetails = aClaimRepairShopTwoDetails;
                aClaim.ClaimRepairShopTwoEstimate = aClaimRepairShopTwoEstimate;
                aClaim.ClaimIMG = aClaimIMG;
                aClaim.PersonInvoledPolicyNumber = aPersonInvoledPolicyNumber;
                aClaim.PersonInvoledLicensePlate = aPersonInvoledLicensePlate;
                aClaim.SeceneLocation = aSeceneLocation;
                aClaim.ClaimDate = aClaimDate;
                aClaim.ClaimTime = aClaimTime;
                aClaim.ClaimStats = aClaimStats;

                aListOfClaims.Add(aClaim);
            }

            aConn.Close();
            return aListOfClaims;

        }

        public List<claim> ViewYourClaimHistory(string id)
        {
            string SQL = "SELECT * FROM tbl_claims WHERE userID = @id ";
            aConn = DB.Instance();
            aConn.ConnectionString = @"Data Source=LAPTOP-6MQIPCEV\SQLEXPRESS;Initial Catalog=accident; Integrated Security =SSPI";

            using (SqlCommand aCommand = new SqlCommand(SQL, aConn))
            {
                aCommand.CommandType = System.Data.CommandType.Text;
                aCommand.Parameters.AddWithValue("@id", id);

                aConn.Open();

                using (SqlDataReader aReader = aCommand.ExecuteReader()) { 
                while (aReader.Read())
                {
                    int aClaimID = (int)(aReader)["claimID"];
                    string aUserID = (string)(aReader)["userID"];
                    string aClaimDescription = (string)(aReader)["ClaimDescription"];
                    string aClaimRepairShopOneDetails = (string)(aReader)["ClaimRepairShopOneDetails"];
                    decimal aClaimRepairShopOneEstimate = (decimal)(aReader)["ClaimRepairShopOneEstimate"];
                    string aClaimRepairShopTwoDetails = (string)(aReader)["ClaimRepairShopTwoDetails"];
                    decimal aClaimRepairShopTwoEstimate = (decimal)(aReader)["ClaimRepairShopTwoEstimate"];
                    string aClaimIMG = (string)(aReader)["claimIMG"];
                    string aPersonInvoledPolicyNumber = (string)(aReader)["PersonInvoledPolicyNumber"];
                    string aPersonInvoledLicensePlate = (string)(aReader)["PersonInvoledLicensePlate"];
                    string aSeceneLocation = (string)(aReader)["seceneLocation"];
                    string aClaimDate = Convert.ToString((aReader)["claimDate"]);
                    string aClaimTime = (string)(aReader)["claimTime"];
                    bool aClaimStats = (bool)(aReader)["claimStats"];

                    claim aClaim = new claim();
                    aClaim.ClaimID = aClaimID;
                    aClaim.UserID = aUserID;
                    aClaim.ClaimDescription = aClaimDescription;
                    aClaim.ClaimRepairShopOneDetails = aClaimRepairShopOneDetails;
                    aClaim.ClaimRepairShopOneEstimate = aClaimRepairShopOneEstimate;
                    aClaim.ClaimRepairShopTwoDetails = aClaimRepairShopTwoDetails;
                    aClaim.ClaimRepairShopTwoEstimate = aClaimRepairShopTwoEstimate;
                    aClaim.ClaimIMG = aClaimIMG;
                    aClaim.PersonInvoledPolicyNumber = aPersonInvoledPolicyNumber;
                    aClaim.PersonInvoledLicensePlate = aPersonInvoledLicensePlate;
                    aClaim.SeceneLocation = aSeceneLocation;
                    aClaim.ClaimDate = aClaimDate;
                    aClaim.ClaimTime = aClaimTime;
                    aClaim.ClaimStats = aClaimStats;

                    aListOfClaims.Add(aClaim);
                }
            }

                aConn.Close();
            }
            return aListOfClaims;

        }


    }
} 