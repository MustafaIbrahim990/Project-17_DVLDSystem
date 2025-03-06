using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DVLDSystem_BusinessLayer;
using DVLDSystem.Gobal_Classes;

namespace DVLDSystem.DVLD.Global_User
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUserNameANDPassWord(string UserName, string PassWord)
        {
            try
            {
                //This We Get The Current Project Directory Folder :-
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = CurrentDirectory + @"\Data.txt";

                if (clsValidation.IsEmpty(UserName) && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;
                }

                string DataTosave = UserName + "#//#" + PassWord;

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.WriteLine(DataTosave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string UserName, ref string PassWord)
        {
            try
            {
                //This We Get The Current Project Directory Folder :-
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = CurrentDirectory + @"\Data.txt";

                if (File.Exists(FilePath))
                {
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string Line = "";

                        while ((Line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(Line);
                            string[] result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            UserName = result[0];
                            PassWord = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}