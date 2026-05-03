using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tools
{
    public static class LogManager
    {
        private static string LogPath = "Log";

        // מחזיר את השנה הנוכחית
        public static string getYearFolder()
        {
            return LogPath + "/" + DateTime.Now.Year.ToString();
        }

        //מחזיר את השנה ואת החודש
        public static string getFolderMonth()
        {
            return getYearFolder() + "/" + DateTime.Now.Month.ToString();
        }

        //מחזיר את הקובץ הנוכחי בתוך החודש
        public static string getFile()
        {
            return getFolderMonth() + "/" + DateTime.Now.Year.ToString() + ".txt";
        }

        public static void WriteToLog(string projectName, string funcName, string message)
        {
            // יצירת נתיב התיקייה (בלי שם הקובץ) בצורה בטוחה
            string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogPath, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());

            // יצירת נתיב הקובץ המלא
            string filePath = System.IO.Path.Combine(folderPath, DateTime.Now.Year.ToString() + ".txt");

            try
            {
                // יוצר את כל היררכיית התיקיות בבת אחת אם הן לא קיימות
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                // כתיבה לקובץ (Append: true מאפשר להוסיף שורות ולא לדרוס את הקובץ בכל פעם)
                using (StreamWriter writerText = new StreamWriter(filePath, true))
                {
                    writerText.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}\t{projectName}.{funcName}:\t {message}");
                }
            }
            catch (Exception ex)
            {
                // למנוע קריסה של הטסטים בגלל לוגים ולהציג את השגיאה בחלון ה-Output
                Console.WriteLine("Failed to write to log: " + ex.Message);
            }
        }

        //פונקציה שמוחקת את ה2 החודשים האחרונים ובודקת האם קיימים
        public static void DeleteOldFolder()
        {
            if (!System.IO.Directory.Exists(getFile()))
                return;

            string[] nameFolders = System.IO.Directory.GetDirectories(LogPath);

            foreach (string dir in nameFolders)
            {
                string[] dateFolder = dir.Split('/');
                if (dateFolder.Length > 2)
                    continue;
                int year = (int.Parse(dateFolder[0]));
                int month = (int.Parse(dateFolder[1]));
                if (year == DateTime.Now.Year)
                {
                    if (month + 2 < DateTime.Now.Month)
                    {
                        System.IO.Directory.Delete(dir, true);
                    }
                }
                else
                {
                    if (DateTime.Now.Month == 1)
                    {
                        if (month != 11 && month != 12)
                        {
                            System.IO.Directory.Delete(dir, true);
                        }
                    }
                    if (DateTime.Now.Month == 2)
                    {
                        if (month != 12)
                        {
                            System.IO.Directory.Delete(dir, true);
                        }
                    }
                }
            }
        }
    }
}