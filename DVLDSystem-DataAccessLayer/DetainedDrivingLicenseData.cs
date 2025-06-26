using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDSystem_DataAccessLayer
{
    public static class clsDetainedDrivingLicenseData
    {
        //Private Methods :-
        private static bool _IsEmpty(string Text)
        {
            return string.IsNullOrWhiteSpace(Text);
        }

        private static string _GetValueFromReader(SqlDataReader reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
            {
                return "";
            }
            else
            {
                return (string)reader[columnName];
            }
        }

        private static int _GetIntFromReader(SqlDataReader reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
            {
                return -1;
            }
            else
            {
                return (int)reader[columnName];
            }
        }

        private static DateTime _GetDateTimeFromReader(SqlDataReader reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
            {
                return DateTime.MaxValue;
            }
            else
            {
                return (DateTime)reader[columnName];
            }
        }

        private static void _AddParameterWithNullCheck(SqlCommand command, string parameterName, string value)
        {
            if (_IsEmpty(value))
            {
                command.Parameters.AddWithValue(parameterName, System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue(parameterName, value);
            }
        }

        private static void _AddParameterWithNullCheck(SqlCommand command, string parameterName, DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                command.Parameters.AddWithValue(parameterName, System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue(parameterName, value);
            }
        }

        private static void _AddParameterWithNullCheck(SqlCommand command, string parameterName, int value)
        {
            if (value == -1)
            {
                command.Parameters.AddWithValue(parameterName, System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue(parameterName, value);
            }
        }


        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedDrivingLicenses;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }


        //Get All Custom Info :-
        public static DataTable GetAllCustomInfo()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT
                           	    D.DetainID,
                           	    D.DrivingLicenseID,
                           	    P.NationalNo AS NationalNo,
                           	    Concat(P.FirstName , ' ' , P.SecondName , ' ' , P.ThirdName , ' ' , P.LastName) AS FullName,
                           	    D.DetainDate,
                           	    D.FineFees,
                           	    D.IsReleased,
                           	    IsNull(Cast(D.ReleaseDate AS Varchar), 'Not Available') AS ReleaseDate,
                           	    IsNull(Cast(D.ReleaseApplicationID AS Varchar), 'Not Available') AS ReleaseApplicationID
                           FROM DetainedDrivingLicenses D
                           INNER JOIN DrivingLicenses
                           ON D.DrivingLicenseID = DrivingLicenses.DrivingLicenseID
                           INNER JOIN Drivers 
                           ON DrivingLicenses.DriverID = Drivers.DriverID
                           INNER JOIN People P
                           ON Drivers.PersonID = P.PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }


        //Is Exist By ID :-
        public static bool IsExist(int ID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM DetainedDrivingLicenses
                           WHERE DetainedDrivingLicenses.DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Exist By ID :-
            command.Parameters.AddWithValue("@DetainID", ID);

            try
            {
                connection.Open();
                Object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        //Is Exist By DrivingLicenseID :-
        public static bool IsExistBy(int DrivingLicenseID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM DetainedDrivingLicenses
                           WHERE DetainedDrivingLicenses.DrivingLicenseID = @DrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Exist By DrivingLicenseID :-
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        //Get Info By ID :-
        public static bool GetInfo(int DetainID, ref DateTime DetainDate, ref int DrivingLicenseID, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedDrivingLicenses
                           WHERE DetainedDrivingLicenses.DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By ID :-
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DetainDate = (DateTime)reader["DetainDate"];
                    DrivingLicenseID = (int)reader["DrivingLicenseID"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    ReleasedByUserID = _GetIntFromReader(reader, "ReleasedByUserID");
                    ReleaseApplicationID = _GetIntFromReader(reader, "ReleaseApplicationID");
                    ReleaseDate = _GetDateTimeFromReader(reader, "ReleaseDate");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        //Get Info By DrivingLicenseID :-
        public static bool GetInfoBy(int DrivingLicenseID, ref int DetainID, ref DateTime DetainDate, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedDrivingLicenses
                           WHERE DetainedDrivingLicenses.DrivingLicenseID = @DrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By DrivingLicenseID :-
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    ReleaseDate = _GetDateTimeFromReader(reader, "ReleaseDate");
                    ReleasedByUserID = _GetIntFromReader(reader, "ReleasedByUserID");
                    ReleaseApplicationID = _GetIntFromReader(reader, "ReleaseApplicationID");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        //Add New :-
        public static int AddNew(DateTime DetainDate, int DrivingLicenseID, float FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"INSERT INTO DetainedDrivingLicenses
                           (DetainDate , DrivingLicenseID , FineFees , CreatedByUserID , IsReleased , ReleaseDate , ReleasedByUserID , ReleaseApplicationID)
                           VALUES
                           (@DetainDate , @DrivingLicenseID , @FineFees , @CreatedByUserID , @IsReleased , @ReleaseDate , @ReleasedByUserID , @ReleaseApplicationID);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

            _AddParameterWithNullCheck(command, "@ReleaseDate", ReleaseDate);
            _AddParameterWithNullCheck(command, "@ReleasedByUserID", ReleasedByUserID);
            _AddParameterWithNullCheck(command, "@ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ID;
        }


        //Update By ID :-
        public static bool Update(int DetainID, DateTime DetainDate, int DrivingLicenseID, float FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"UPDATE DetainedDrivingLicenses
                           SET DetainDate = @DetainDate , DrivingLicenseID = @DrivingLicenseID , FineFees = @FineFees , CreatedByUserID = @CreatedByUserID , 
                           IsReleased = @IsReleased , ReleaseDate = @ReleaseDate , ReleasedByUserID = @ReleasedByUserID , ReleaseApplicationID = @ReleaseApplicationID
                           Where DetainedDrivingLicenses.DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

            _AddParameterWithNullCheck(command, "@ReleaseDate", ReleaseDate);
            _AddParameterWithNullCheck(command, "@ReleasedByUserID", ReleasedByUserID);
            _AddParameterWithNullCheck(command, "@ReleaseApplicationID", ReleaseApplicationID);

            //Update By ID :-
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


        //Delete By ID :-
        public static bool Delete(int ID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"DELETE FROM DetainedDrivingLicenses
                           WHERE DetainedDrivingLicenses.DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Delete By ID :-
            command.Parameters.AddWithValue("@DetainID", ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


        //Is IsReleased By DrivingLicenseID :-
        public static bool IsReleased(int DrivingLicenseID)
        {
            bool isReleased = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT DetainedDrivingLicenses.IsReleased FROM DetainedDrivingLicenses
                           WHERE DetainedDrivingLicenses.DrivingLicenseID = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is IsReleased By DrivingLicenseID :-
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    isReleased = true;
                }
            }
            catch (Exception ex)
            {
                isReleased = false;
            }
            finally
            {
                connection.Close();
            }
            return isReleased;
        }
    }
}