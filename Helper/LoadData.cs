using CsvHelper;
using Microsoft.Extensions.Configuration;
using ReadExcelWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReadExcelWebMVC.Helper
{
    public class LoadData
    {
        // This function reads data from accounting.csv file and loads data into the DataTable
        public DataTable LoadDataFromFile()
        {
            var dt = new DataTable();
            dt.Columns.Add("Trans ID", typeof(int));
            dt.Columns.Add("Order", typeof(string));
            dt.Columns.Add("Trans Type", typeof(string));
            dt.Columns.Add("Trans Date", typeof(string));
            dt.Columns.Add("Name", typeof(string));

            string filepath = "C:\\Data\\accounting.csv";
            
            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    dt.Load(dr);
                }
            }

            DataTable sortdt;
            dt.DefaultView.Sort = "Name ASC";
            sortdt = dt.DefaultView.ToTable();
            return sortdt;
        }
        // This funtion calculates the total obligation amounts and paid amount of the soldiers
        public void AddData(DataRow r, ref List<RecordIndividualDetails> data)
        {
            RecordIndividualDetails RecordToUpdate = null;

            if (data.Count > 0)
            {
                RecordToUpdate = data.FirstOrDefault(s => s.Name.Trim().ToUpper() == r["Name"].ToString().Trim().ToUpper());
            }
            if (r["Trans Type"].ToString().Trim().ToUpper() == "OBLIGATION") // obligation
            {
                // updates amount
                if (RecordToUpdate != null)
                {
                    RecordToUpdate.ObligationAmount = RecordToUpdate.ObligationAmount + double.Parse(r["Amount"].ToString());
                }
                else // add new record
                {
                    RecordToUpdate = new RecordIndividualDetails()
                    {
                        Name = r["Name"].ToString().Trim().ToUpper(),
                        ObligationAmount = double.Parse(r["Amount"].ToString())
                    };

                    data.Add(RecordToUpdate);
                }
            }
            else // payment
            {
                /// updates amount
                if (RecordToUpdate != null)
                {
                    RecordToUpdate.PaymentAmount = RecordToUpdate.PaymentAmount + double.Parse(r["Amount"].ToString());
                }
                else /// add new record
                {
                    RecordToUpdate = new RecordIndividualDetails()
                    {
                        Name = r["Name"].ToString().Trim().ToUpper(),
                        PaymentAmount = double.Parse(r["Amount"].ToString())
                    };

                    data.Add(RecordToUpdate);
                }
            }
        }
    }
}
