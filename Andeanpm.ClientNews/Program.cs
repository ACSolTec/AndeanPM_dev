using Andeanpm.ClientNews.Data;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Xml;

//Global Variables
string url = "https://newsroom.newsfilecorp.com/6409";
List<News> news = new();

//Configuration
IConfiguration iconfiguration;
var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
iconfiguration = builder.Build();

MapperConfiguration config = new MapperConfiguration(cfg => {
    cfg.CreateMap<News, Andeanpm.Shared.Models.News>()
    .ForMember(dest => dest.PKNews, opt => opt.MapFrom(src => src.nfSubmissionID))
    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title.CdataSection))
    .ForMember(dest => dest.Subtitle, opt => opt.MapFrom(src => src.subtitle.CdataSection))
    .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.content.CdataSection))
    .ForMember(dest => dest.dateJson, opt => opt.MapFrom(src => src.date));
});

IMapper mapper = config.CreateMapper();

string Test(string date)
{
    return "hola";
}

//Connection DB
var conectionDB = new ConnectionDB(iconfiguration);

//Get url XML
string str = GetXML(url);

Root root = JsonConvert.DeserializeObject<Root>(str);

foreach (var item in root.resultset.item)
{
    str = GetXML(item.link);
    RootNews rootNews = JsonConvert.DeserializeObject<RootNews>(str);
    news.Add(rootNews.news);

    //DownloadPDF(rootNews.news.pdf_url, rootNews.news.nfSubmissionID);
}

//Mapper Model to Model DB
var dst = mapper.Map<List<News>, List<Andeanpm.Shared.Models.News>>(news);

//Get previously saved  news
var listNews = conectionDB.GetList();

///Compare both list 
var difference = dst.Where(a => !listNews.Any(b => b.PKNews == a.PKNews)).ToList();

difference.ToList().ForEach(cc => cc.dateJson = cc.dateJson.Split(" ")[0]);
difference.ToList().ForEach(cc => cc.DateNews = Convert.ToDateTime(cc.dateJson.Split(" ")[0], new CultureInfo("en-US")));
difference.ToList().ForEach(cc => cc.Year = GetYear(cc.dateJson));
difference.ToList().ForEach(cc => cc.PDFURL = $"assets/news/pdfs/{cc.PKNews}.pdf");

int GetYear(string DateNews)
{
    return Convert.ToDateTime(DateNews, new CultureInfo("en-US")).Year;
}

difference.Reverse();

//save DB
conectionDB.Insert(difference);

Console.WriteLine();


///Method to get data xml and convert to string;
string GetXML(string url)
{
    string xml = string.Empty;

    using (WebClient wc = new WebClient())
    {
        xml = wc.DownloadString(url);
    }

    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);

    return JsonConvert.SerializeXmlNode(doc);
}

///Metho to downloadPDF and save on folder
async Task DownloadPDF(string pdfUrl, string name)
{
    using (var client = new WebClient())
    {
        try
        {
            client.DownloadFile(pdfUrl, @$"C:\Cesar\PDF\{name}.pdf");

        }
        catch (Exception ex)
        {
            var x = ex.Message;
        }
    }
}

public class Root
{
    public Resultset resultset { get; set; }
}
public class Resultset
{
    public List<Item> item { get; set; }
}

public class Item
{
    public string link { get; set; }
}

public class RootNews
{
    public News news { get; set; }
}

public class News
{
    public string date { get; set; }
    public Title title { get; set; }
    public Subtitle subtitle { get; set; }
    public Content content { get; set; }
    public string nfSubmissionID { get; set; }
    public string print { get; set; }
    public string pdf_url { get; set; }
}

public class Title
{
    [JsonProperty("#cdata-section")]
    public string CdataSection { get; set; }
}

public class Subtitle
{
    [JsonProperty("#cdata-section")]
    public string CdataSection { get; set; }
}

public class Content
{
    [JsonProperty("#cdata-section")]
    public string CdataSection { get; set; }
}