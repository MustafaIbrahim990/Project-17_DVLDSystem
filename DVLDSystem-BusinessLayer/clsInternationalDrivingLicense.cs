using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsInternationalDrivingLicense
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        //Properties :-
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingDrivingLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpriationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsApplication ApplicationInfo;
        public clsDriver DriverInfo;
        public clsDrivingLicense IssuedUsingDrivingLicenseInfo;
        public clsUser CreatedByUserInfo;

        //Constructor :-
        public clsInternationalDrivingLicense()
        {
            _Mode = enMode.AddNew;
            ID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingDrivingLicenseID = -1;
            IssueDate = new DateTime();
            ExpriationDate = new DateTime();
            IsActive = false;
            CreatedByUserID = -1;

            ApplicationInfo = null;
            DriverInfo = null;
            IssuedUsingDrivingLicenseInfo = null;
            CreatedByUserInfo = null;
        }
        private clsInternationalDrivingLicense(int DrivingLicenseID, int ApplicationID, int DriverID, int IssuedUsingDrivingLicenseID, DateTime IssueDate, DateTime ExpriationDate, bool IsActive, int CreatedByUserID)
        {
            _Mode = enMode.Update;
            this.ID = DrivingLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingDrivingLicenseID = IssuedUsingDrivingLicenseID;
            this.IssueDate = IssueDate;
            this.ExpriationDate = ExpriationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.ApplicationInfo = clsApplication.Find(ApplicationID);
            this.DriverInfo = clsDriver.Find(DriverID);
            this.IssuedUsingDrivingLicenseInfo = clsDrivingLicense.Find(IssuedUsingDrivingLicenseID);
            this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);
        }


        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            return clsInternationalDrivingLicenseData.GetAllInfo();
        }


        //Get All International Driving License Lists :-
        public static DataTable GetAllInternationalDrivingLicenseApplications()
        {
            return clsInternationalDrivingLicenseData.GetAllInternationalDrivingLicenseApplications();
        }


        //Is Exist By PersonID :-
        public static bool IsExist(int ID)
        {
            return clsInternationalDrivingLicenseData.IsExist(ID);
        }


        //Get Info By PersonID :-
        public static clsInternationalDrivingLicense Find(int ID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingDrivingLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = new DateTime(), ExpriationDate = new DateTime();
            bool IsActive = false;


            if (clsInternationalDrivingLicenseData.GetInfo(ID, ref ApplicationID, ref DriverID, ref IssuedUsingDrivingLicenseID, ref IssueDate, ref ExpriationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalDrivingLicense(ID, ApplicationID, DriverID, IssuedUsingDrivingLicenseID, IssueDate, ExpriationDate, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        //Add New :-
        private bool _AddNew()
        {
            //int PersonID = -1;
            this.ID = clsInternationalDrivingLicenseData.AddNew(this.ApplicationID, this.DriverID, this.IssuedUsingDrivingLicenseID, this.IssueDate, this.ExpriationDate, this.IsActive, this.CreatedByUserID);
            return (this.ID != -1);
        }


        //Update Person :-
        private bool _Update()
        {
            return clsInternationalDrivingLicenseData.Update(this.ID, this.ApplicationID, this.DriverID, this.IssuedUsingDrivingLicenseID, this.IssueDate, this.ExpriationDate, this.IsActive, this.CreatedByUserID);
        }


        //Save Mode in (Add New && Update) :-
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _Update();
                    }
                default:
                    {
                        return false;
                    }
            }
        }


        //Delete Person :-
        public static bool Delete(int ID)
        {
            return clsInternationalDrivingLicenseData.Delete(ID);
        }


        //Get All Driving Licenses For Driver By DriverID :-
        public static DataTable GetDrivingLicensesForDriver(int DriverID)
        {
            return clsInternationalDrivingLicenseData.GetDrivingLicensesForDriver(DriverID);
        }
    }
}