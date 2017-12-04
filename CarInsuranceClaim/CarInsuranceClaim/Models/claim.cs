using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceClaim.Models
{
    public class claim
    {
        //setting private varibles
        private int claimID = 0;
        private string userID = "";
        private string claimDescription = "";
        private string claimRepairShopOneDetails = "";
        private decimal claimRepairShopOneEstimate = 0.0M;
        private string claimRepairShopTwoDetails = "";
        private decimal claimRepairShopTwoEstimate = 0.0M;
        private string claimIMG = "";
        private string personInvoledPolicyNumber = "";
        private string personInvoledLicensePlate = "";
        private string seceneLocation = "";
        private string claimDate = "";
        private string claimTime = "";
        private bool claimStats;

        //get and sets
        public int ClaimID
        {
            get { return this.claimID; }
            set { this.claimID = value; }
        }

        public string UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        public string ClaimDescription
        {
            get { return this.claimDescription; }
            set { this.claimDescription = value; }
        }

        public string ClaimRepairShopOneDetails
        {
            get { return this.claimRepairShopOneDetails; }
            set { this.claimRepairShopOneDetails = value; }
        }

        public decimal ClaimRepairShopOneEstimate
        {
            get { return this.claimRepairShopOneEstimate; }
            set { this.claimRepairShopOneEstimate = value; }
        }

        public string ClaimRepairShopTwoDetails
        {
            get { return this.claimRepairShopTwoDetails; }
            set { this.claimRepairShopTwoDetails = value; }
        }

        public decimal ClaimRepairShopTwoEstimate
        {
            get { return this.claimRepairShopTwoEstimate; }
            set { this.claimRepairShopTwoEstimate = value; }
        }

        public string ClaimIMG
        {
            get { return this.claimIMG; }
            set { this.claimIMG = value; }
        }

        public string PersonInvoledPolicyNumber
        {
            get { return this.personInvoledPolicyNumber; }
            set { this.personInvoledPolicyNumber = value; }
        }

        public string PersonInvoledLicensePlate
        {
            get { return this.personInvoledLicensePlate; }
            set { this.personInvoledLicensePlate = value; }
        }

        public string SeceneLocation
        {
            get { return this.seceneLocation; }
            set { this.seceneLocation = value; }
        }

        public string ClaimDate
        {
            get { return this.claimDate; }
            set { this.claimDate = value; }
        }

        public string ClaimTime
        {
            get { return this.claimTime; }
            set { this.claimTime = value; }
        }
        public bool ClaimStats
        {
            get { return this.claimStats; }
            set { this.claimStats = value; }
        }

        //constructors
        public claim()
        { }

        public claim(int aClaimID, string aUserID, string aClaimDescription, string aClaimRepairShopOneDetails, decimal aClaimRepairShopOneEstimate, string aClaimRepairShopTwoDetails, decimal aClaimRepairShopTwoEstimate, string aClaimIMG, 
            string aPersonInvoledPolicyNumber, string aPersonInvoledLicensePlate, string aSeceneLocation, string aClaimDate, string aClaimTime ,bool aClaimStats)
        {
            this.ClaimID = aClaimID;
            this.UserID = aUserID;
            this.ClaimDescription = aClaimDescription;
            this.ClaimRepairShopOneDetails = aClaimRepairShopOneDetails;
            this.ClaimRepairShopOneEstimate = aClaimRepairShopOneEstimate;
            this.ClaimRepairShopTwoDetails = aClaimRepairShopTwoDetails;
            this.ClaimRepairShopTwoEstimate = aClaimRepairShopTwoEstimate;
            this.ClaimIMG = aClaimIMG;
            this.PersonInvoledPolicyNumber = aPersonInvoledPolicyNumber;
            this.PersonInvoledLicensePlate = aPersonInvoledLicensePlate;
            this.SeceneLocation = aSeceneLocation;
            this.ClaimDate = aClaimDate;
            this.ClaimTime = aClaimTime;

        }

    }
}