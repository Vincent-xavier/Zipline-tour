﻿using Newtonsoft.Json;
using System;

namespace ZiplineTour.FrameWork.Helper
{
    public class ConfigSettings
    {
        public SMTPMailConfig SMTPMailConfig { get; set; }
    }

    public class SMTPMailConfig
    {
        public string? SendMailFlag { get; set; }
        public string? SMTPServer { get; set; }
        public string? SMTPPort { get; set; }
        public string? DisplayName { get; set; }
        public string? MUserName { get; set; }
        public string? MPassword { get; set; }
        public string? IsSSLEnabled { get; set; }
        public string? ContactUsMailId { get; set; }
        public string? CCMailId { get; set; }
        public string? LoginURL { get; set; }
        public string? BCCMailId { get; set; }
    }

    public class ConfigSettingsService
    {
        public ConfigSettings Settings = new ConfigSettings();

        public ConfigSettingsService()
        {
            Settings = LoadData();
        }

        /// <summary>
        /// To get the Value from json files
        /// </summary>
        /// <returns></returns>
        public ConfigSettings LoadData()
        {
            ConfigSettings? confSettings = new ConfigSettings();
            try
            {
                string sBaseDirectory = (AppDomain.CurrentDomain.BaseDirectory).Replace(@"\bin\Debug\netcoreapp2.2", "");
                string sCSSFileName = sBaseDirectory + @"\ConfigurationSettings.json";
                string? jsonString = System.IO.File.ReadAllText(sCSSFileName);
                confSettings = JsonConvert.DeserializeObject<ConfigSettings>(jsonString.ToString());
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return confSettings;
        }
    }
}