using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using wingateCSharp.Interfaces;

namespace wingateCSharp
{
    class FileReader : IFileReader
    {
        private string Path {get; set;}
        private Logger logger { get; set; }

        public FileReader(string path, Logger logger)
        {
            if (String.IsNullOrEmpty(path))
            {
                logger.Info("Path couldn't be null");
                throw new Exception("Path couldn't be null or empty");
            }

            if (logger != null)
            {
                logger.Info("Logger can't be null");
                throw new Exception("Logger can't be null");
            }

            this.Path = path;
            this.logger = logger;
        } 

        
        public bool TrySplit(string values, out List<wingateSchema> data)
        {
            data = null;
            return true;
        }

        /// <summary>
        /// fake trySplit method
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool TrySplit (out List<wingateSchema> data)
        {
            List<wingateSchema> temp = new List<wingateSchema>();
            for (int i = 0; i < 5; i++)
            {
                wingateSchema x = new wingateSchema()
                {
                    RowId = i,
                    SupplierName = "Sameh" + i,
                    CardholderFirstName = "sameh" + i,
                    CardholderLastName = "Ahmed" + i,
                    TransactionLineAmount = 4m + i,
                    TransactionLineCodingGLAccountNumber = "111111",
                    Amount = 1.0M + i,
                    TransactionNotes = "Hi People"
                };
                temp.Add(x);
            }

            this.logger.Info("Return fake data");

            data = temp;
            return true;
        }
        public bool TryRead(out string values)
        {
            if (File.Exists(this.Path))
            {
                this.logger.Info("Start reading the file");
                values = File.ReadAllText(Path);
                this.logger.Debug("The file read successfully");

                return true;
            }

            this.logger.Info("Failed reading the file");

            values = null;
            return false;
        }
    }
}
