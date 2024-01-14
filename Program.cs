using System;
using Google.Cloud.BigQuery.V2;

namespace BigQueryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonKeyFilePath = "C:\\Users\\JM\\source\\repos\\GCP2Console\\michalbaran21infnwnl4-e49cb45b06a9.json";//Sciezka do klucza json z IAM Admin z GCP dla konta serwisowego

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", jsonKeyFilePath);

            var client = BigQueryClient.Create("michalbaran21infnwnl4");
            var table = client.GetTable("michalbaran21infnwnl4", "DQL", "bike");
            var sql = "SELECT * FROM `michalbaran21infnwnl4.DQL.bike` LIMIT 1000";

            var results = client.ExecuteQuery(sql, parameters: null);

            foreach (var row in results)
            {
                
                foreach (var field in row.Schema.Fields)
                {
                    Console.WriteLine($"{field.Name}: {row[field.Name]}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}