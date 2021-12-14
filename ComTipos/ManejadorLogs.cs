using System;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

namespace ComTipos
{
    public class ManejadorLogs
    {
        public string sLogFormat;
        public string sErrorTime;
        public int CreateFolderNombre(string cRutaLog)
        {

            // Create Carpeta y/0 Create Carpeta y Ruta
            try
            {
                if (!Directory.Exists(cRutaLog))
                {
                    Directory.CreateDirectory(cRutaLog);

                    return 1;
                }
                else
                    return 2;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int DeleteFolderNombre(string Nombre, ref string strPathFinal)
        {
            string strPath;
            string strSeparator;
            strPath = "";
            if (Nombre.CompareTo("") == 0)
                return -1;
            else
            {

                /*
                System.Configuration.
                strSeparator = System.Configuration.ConfigurationManager.AppSettings("PathSeparator"); // ConfigurationSettings.AppSettings.Get("PathSeparator")
                strPath = System.Configuration.ConfigurationManager.AppSettings("initialPath"); // ConfigurationSettings.AppSettings.Get("initialPath") & strSeparator & Nombre
                strPathFinal = strPath;
                */
                try
                {
                    if (!Directory.Exists(strPath))
                        return 1;
                    else
                    {
                        Directory.Delete(strPath, true);
                        return 2;
                    }
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }


        public void CreateLogFiles()
        {
            try
            {
                // sLogFormat used to create log files format :
                // dd/MM/yyyy hh:mm:ss AM/PM ==> Log Message
                sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

                // this variable used to create log filename format "
                // for example filename : ErrorLogYYYYMMDD
                string sYear = DateTime.Now.Year.ToString();
                string sMonth = DateTime.Now.Month.ToString();
                string sDay = DateTime.Now.Day.ToString();
                sErrorTime = sYear + sMonth + sDay;
            }
            catch (Exception ex)
            {
            }
        }

        public void ErrorLog(string sPathName, string sErrMsg)
        {
            try
            {
                StreamWriter sw = new StreamWriter(sPathName + sErrorTime + ".txt", true);
                sw.WriteLine("");
                sw.WriteLine(sLogFormat + sErrMsg);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}