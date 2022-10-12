using FastMember;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Andeanpm.ClientNews.Data
{
    public class ConnectionDB
    {
        private string connectionString;
        public ConnectionDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AndeampConnection");
        }
        public List<Shared.Models.News> GetList()
        {
            var listNews = new List<Shared.Models.News>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT * FROM News";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        listNews.Add(new Shared.Models.News
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            PKNews = rdr[1].ToString(),
                            Title = rdr[2].ToString(),
                            Subtitle = rdr[3].ToString(),
                            Content = rdr[4].ToString(),
                            PDFURL = rdr[5].ToString(),
                            DateNews = (DateTime)rdr[6]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listNews;
        }

        public void Insert(List<Shared.Models.News> list)
        {
            try
            {
                var copyParameters = new[]
                {
                        nameof(Shared.Models.News.Id),
                        nameof(Shared.Models.News.PKNews),
                        nameof(Shared.Models.News.Title),
                        nameof(Shared.Models.News.Subtitle),
                        nameof(Shared.Models.News.Content),
                        nameof(Shared.Models.News.PDFURL),
                        nameof(Shared.Models.News.DateNews),
                        nameof(Shared.Models.News.Year)

                };

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                    {
                        bulkcopy.BulkCopyTimeout = 660;
                        bulkcopy.DestinationTableName = "News";
                        using (var reader = ObjectReader.Create(list, copyParameters))
                        {
                            bulkcopy.WriteToServer(reader);
                        }
                        bulkcopy.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
