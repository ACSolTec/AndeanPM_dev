using Andeanpm.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Andeanpm.Server.Data
{
    public class AndeampDBContext : DbContext
    {
        public AndeampDBContext(DbContextOptions<AndeampDBContext> options) : base(options)
        { }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Banner> Banners { get; set; }  
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<InvestorReport> InvestorReports { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Banners

            modelBuilder.Entity<Banner>().HasData(
                new Banner
                {
                    Id = 1,
                    Module = "Our Company",
                    Url = "assets/banners/ourcompany.jpg"
                },
                new Banner
                {
                    Id = 2,
                    Module = "Our People",
                    Url = "assets/banners/ourpeople.jpg"
                },
                new Banner
                {
                    Id = 3,
                    Module = "Careers",
                    Url = "assets/banners/careers.jpg"
                },
                new Banner
                {
                    Id = 4,
                    Module = "Cerro Rico Mine",
                    Url = "assets/banners/cerroricomine.jpg"
                },
                new Banner
                {
                    Id = 5,
                    Module = "Cachi Laguna",
                    Url = "assets/banners/cachilaguna.jpg"
                },
                new Banner
                {
                    Id = 6,
                    Module = "Cerro Rico Deposits",
                    Url = "assets/banners/cerroricodeposits.jpg"
                },
                new Banner
                {
                    Id = 7,
                    Module = "Ore Purchasing",
                    Url = "assets/banners/orepurchasing.jpg"
                },
                new Banner
                {
                    Id = 8,
                    Module = "El Asiento",
                    Url = "assets/banners/elasiento.jpg"
                },
                new Banner
                {
                    Id = 9,
                    Module = "Tatasi Portugalete",
                    Url = "assets/banners/tatasiportugalete.jpg"
                },
                new Banner
                {
                    Id = 10,
                    Module = "Monserrat",
                    Url = "assets/banners/monserrat.jpg"
                },
                new Banner
                {
                    Id = 11,
                    Module = "San Bartolome",
                    Url = "assets/banners/sanbartolome.jpg"
                },
                new Banner
                {
                    Id = 12,
                    Module = "Exploration",
                    Url = "assets/banners/exploration.jpg"
                },
                new Banner
                {
                    Id = 13,
                    Module = "San Pablo",
                    Url = "assets/banners/sanpablo.jpg"
                },
                new Banner
                {
                    Id = 14,
                    Module = "Rio Blanco",
                    Url = "assets/banners/rioblanco.jpg"
                },
                new Banner
                {
                    Id = 15,
                    Module = "Sustainability",
                    Url = "assets/banners/sustainability.jpg"
                },
                new Banner
                {
                    Id = 16,
                    Module = "Esg",
                    Url = "assets/banners/esg.jpg"
                },
                new Banner
                {
                    Id = 17,
                    Module = "Governance",
                    Url = "assets/banners/governance.jpg"
                },
                new Banner
                {
                    Id = 18,
                    Module = "Investors",
                    Url = "assets/banners/investors.jpg"
                },
                new Banner
                {
                    Id = 19,
                    Module = "News",
                    Url = "assets/banners/news.jpg"
                },
                new Banner
                {
                    Id = 20,
                    Module = "Contact",
                    Url = "assets/banners/contact.jpg"
                },
                new Banner
                {
                    Id = 21,
                    Module = "Customer Care",
                    Url = "assets/banners/customercare.jpg"
                }
                );

            #endregion

            #region InvestorReports
            modelBuilder.Entity<InvestorReport>().HasData(
                new InvestorReport
                {
                    Id = 1,
                    Title = "FOR THE YEARS ENDED DECEMBER 31, 2020 AND 2019",
                    SubTitle = "Financial Statements",
                    Url = "assets/investors/FinancialReports/1254688 BC Ltd FY2020 Financial Statements.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 2,
                    Title = "YEAR ENDED DECEMBER 31, 2020",
                    SubTitle = "MD&A",
                    Url = "assets/investors/FinancialReports/1254688 BC Ltd FY2020 MD&A.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 3,
                    Title = "FOR THE THREE MONTHS ENDED MARCH 31, 2021 AND 2020",
                    SubTitle = "Financial Statements",
                    Url = "assets/investors/FinancialReports/FY2021 Q1 APM FS.pd",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 4,
                    Title = "FIRST QUARTER REPORT MARCH 31, 2021",
                    SubTitle = "MD&A",
                    Url = "assets/investors/FinancialReports/FY2021 Q1 APM MDA.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 5,
                    Title = "FOR THE THREE AND SIX MONTHS ENDED JUNE 30, 2021 AND 2020",
                    SubTitle = "Financial Statements",
                    Url = "assets/investors/FinancialReports/FY2021 Q2 APM FS.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 6,
                    Title = "SECOND QUARTER REPORT JUNE 30, 2021",
                    SubTitle = "MD&A",
                    Url = "assets/investors/FinancialReports/FY2021 Q2 APM MDA.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 7,
                    Title = "FOR THE THREE AND NINE MONTHS ENDED SEPTEMBER 30, 2021 AND 2020",
                    SubTitle = "Financial Statements",
                    Url = "assets/investors/FinancialReports/FY2021 Q3 APM FS.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 8,
                    Title = "THIRD QUARTER REPORT SEPTEMBER 30, 2021",
                    SubTitle = "MD&A",
                    Url = "assets/investors/FinancialReports/FY2021 Q3 APM MDA.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 9,
                    Title = "FOR THE YEARS ENDED DECEMBER 31, 2021 AND 2020",
                    SubTitle = "Financial Statements",
                    Url = "assets/investors/FinancialReports/FY2021 Q4 YE APM FS.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 10,
                    Title = "FOR THE YEAR ENDED DECEMBER 31, 2021",
                    SubTitle = "MD&A",
                    Url = "assets/investors/FinancialReports/FY2021 Q4 APM MDA.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 11,
                    Title = "FOR THE THREE MONTHS ENDED MARCH 31, 2022 AND 2021",
                    SubTitle = "Financial Statements",
                    Url = "assets/investors/FinancialReports/APM FS Q1 2022-Final.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 12,
                    Title = "FIRST QUARTER REPORT MARCH 31, 2022",
                    SubTitle = "MD&A",
                    Url = "assets/investors/FinancialReports/APM MDA Q1 2022-Final.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 13,
                    Title = "FOR THE THREE AND SIX MONTHS ENDED JUNE 30, 2022 AND 2021",
                    SubTitle = "Financial Statements",
                    Url = "assets/investors/FinancialReports/APM FS Q2 2022 Financial Statements.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 14,
                    Title = "SECOND QUARTER REPORT JUNE 30, 2022",
                    SubTitle = "MD&A",
                    Url = "assets/investors/FinancialReports/APM MDA Q2 2022 Management Dissc Analysis.pdf.pdf",
                    Module = "FinancialReports",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 15,
                    Title = "Bolivia Properties Technical Report",
                    SubTitle = "PDF",
                    Url = "assets/investors/TechnicalReports/TR_Bolivia.pdf",
                    Module = "TechnicalReports",
                    DateCreate = new DateTime(2020, 09, 01)
                },
                new InvestorReport
                {
                    Id = 16,
                    Title = "San Bartolome Technical Report 2022",
                    SubTitle = "PDF",
                    Url = "assets/investors/TechnicalReports/San Bartolome Technical Report 2022.pdf",
                    Module = "TechnicalReports",
                    DateCreate = new DateTime(2022, 03, 25)
                },
                new InvestorReport
                {
                    Id = 17,
                    Title = "SUSTAINABILITY FRAMEWORK 2021",
                    SubTitle = "PDF",
                    Url = "assets/investors/Sustainability/SUSTAINABILITY FRAMEWORK AndeanPM.PDF",
                    Module = "Sustainability",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 18,
                    Title = "Financial Statement request form",
                    SubTitle = "PDF",
                    Url = "assets/investors/AGSM/Financial Statement Request Form.pdf",
                    Module = "AGSM",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 19,
                    Title = "Notice And Access Notification",
                    SubTitle = "PDF",
                    Url = "assets/investors/AGSM/Notice and Access Notification.pdf",
                    Module = "AGSM",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 20,
                    Title = "Voting Instruction Form",
                    SubTitle = "PDF",
                    Url = "assets/investors/AGSM/Voting Instruction Form.pdf",
                    Module = "AGSM",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 21,
                    Title = "Form of Proxy",
                    SubTitle = "PDF",
                    Url = "assets/investors/AGSM/Form of Proxy.pdf",
                    Module = "AGSM",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 22,
                    Title = "Information Circular",
                    SubTitle = "PDF",
                    Url = "assets/investors/AGSM/Information Circular.pdf",
                    Module = "AGSM",
                    DateCreate = DateTime.Now
                },
                new InvestorReport
                {
                    Id = 23,
                    Title = "Meeting Notice",
                    SubTitle = "PDF",
                    Url = "assets/investors/AGSM/Meeting_Notice.pdf",
                    Module = "AGSM",
                    DateCreate = DateTime.Now
                }
            );
            #endregion

            #region Operations
            modelBuilder.Entity<Operation>().HasData(
                new Operation
                {
                    Id = 1,
                    ImageLink = "assets/operations/cl_1_big.jpg",
                    Module = "CachiLaguna"
                },
                new Operation
                {
                    Id = 2,
                    ImageLink = "assets/operations/cl_gallery01.jpg",
                    Module = "CachiLaguna"
                },
                new Operation
                {
                    Id = 3,
                    ImageLink = "assets/operations/cl_gallery02.jpg",
                    Module = "CachiLaguna"
                },
                new Operation
                {
                    Id = 4,
                    ImageLink = "assets/operations/cl_gallery03.jpg",
                    Module = "CachiLaguna"
                },
                new Operation
                {
                    Id = 5,
                    ImageLink = "assets/operations/cl_gallery04.jpg",
                    Module = "CachiLaguna"
                },
                new Operation
                {
                    Id = 6,
                    ImageLink = "assets/operations/sb_gallery01.jpg",
                    Module = "CerroRicoDeposits"
                },
                new Operation
                {
                    Id = 7,
                    ImageLink = "assets/operations/sb_gallery02.jpg",
                    Module = "CerroRicoDeposits"
                },
                new Operation
                {
                    Id = 8,
                    ImageLink = "assets/operations/sb_gallery03.jpg",
                    Module = "CerroRicoDeposits"
                },
                new Operation
                {
                    Id = 9,
                    ImageLink = "assets/operations/sb_gallery04.jpg",
                    Module = "CerroRicoDeposits"
                },
                new Operation
                {
                    Id = 10,
                    ImageLink = "assets/operations/sb_1_big.jpg",
                    Module = "CerroRicoDeposits"
                },
                new Operation
                {
                    Id = 11,
                    ImageLink = "assets/operations/sb_2_big.jpg",
                    Module = "CerroRicoDeposits"
                },
                new Operation
                {
                    Id = 12,
                    ImageLink = "assets/operations/sb_3_big.jpg",
                    Module = "CerroRicoDeposits"
                },
                new Operation
                {
                    Id = 13,
                    ImageLink = "assets/operations/ea_gallery01.jpg",
                    Module = "ElAsiento"
                },
                new Operation
                {
                    Id = 14,
                    ImageLink = "assets/operations/ea_gallery02.jpg",
                    Module = "ElAsiento"
                },
                new Operation
                {
                    Id = 15,
                    ImageLink = "assets/operations/ea_gallery03.jpg",
                    Module = "ElAsiento"
                },
                new Operation
                {
                    Id = 16,
                    ImageLink = "assets/operations/ea_gallery04.jpg",
                    Module = "ElAsiento"
                },
                new Operation
                {
                    Id = 17,
                    ImageLink = "assets/operations/ea_1_big.jpg",
                    Module = "ElAsiento"
                },
                new Operation
                {
                    Id = 18,
                    ImageLink = "assets/operations/ea_2_big.jpg",
                    Module = "ElAsiento"
                },
                new Operation
                {
                    Id = 19,
                    ImageLink = "assets/operations/ea_3_big.jpg",
                    Module = "ElAsiento"
                },
                new Operation
                {
                    Id = 20,
                    ImageLink = "assets/operations/tp_gallery01.jpg",
                    Module = "TatasiPortugalete"
                },
                new Operation
                {
                    Id = 21,
                    ImageLink = "assets/operations/tp_gallery02.jpg",
                    Module = "TatasiPortugalete"
                },
                new Operation
                {
                    Id = 22,
                    ImageLink = "assets/operations/tp_gallery03.jpg",
                    Module = "TatasiPortugalete"
                },
                new Operation
                {
                    Id = 23,
                    ImageLink = "assets/operations/tp_gallery04.jpg",
                    Module = "TatasiPortugalete"
                },
                new Operation
                {
                    Id = 24,
                    ImageLink = "assets/operations/tp_1_big.jpg",
                    Module = "TatasiPortugalete"
                },
                new Operation
                {
                    Id = 25,
                    ImageLink = "assets/operations/tp_2_big.jpg",
                    Module = "TatasiPortugalete"
                },
                new Operation
                {
                    Id = 26,
                    ImageLink = "assets/operations/tp_3_big.jpg",
                    Module = "TatasiPortugalete"
                },
                new Operation
                {
                    Id = 27,
                    ImageLink = "assets/operations/mt_gallery01.jpg",
                    Module = "Monserrat"
                },
                new Operation
                {
                    Id = 28,
                    ImageLink = "assets/operations/mt_gallery02.jpg",
                    Module = "Monserrat"
                },
                new Operation
                {
                    Id = 29,
                    ImageLink = "assets/operations/mt_gallery03.jpg",
                    Module = "Monserrat"
                },
                new Operation
                {
                    Id = 30,
                    ImageLink = "assets/operations/mt_gallery04.jpg",
                    Module = "Monserrat"
                },
                new Operation
                {
                    Id = 31,
                    ImageLink = "assets/operations/mt_1_big.jpg",
                    Module = "Monserrat"
                },
                new Operation
                {
                    Id = 32,
                    ImageLink = "assets/operations/mt_2_big.jpg",
                    Module = "Monserrat"
                },
                new Operation
                {
                    Id = 33,
                    ImageLink = "assets/operations/mt_3_big.jpg",
                    Module = "Monserrat"
                },
                new Operation
                {
                    Id = 34,
                    ImageLink = "assets/operations/sp_gallery01.jpg",
                    Module = "SanPablo"
                },
                new Operation
                {
                    Id = 35,
                    ImageLink = "assets/operations/sp_gallery02.jpg",
                    Module = "SanPablo"
                },
                new Operation
                {
                    Id = 36,
                    ImageLink = "assets/operations/sp_gallery03.jpg",
                    Module = "SanPablo"
                },
                new Operation
                {
                    Id = 37,
                    ImageLink = "assets/operations/sp_gallery04.jpg",
                    Module = "SanPablo"
                },
                new Operation
                {
                    Id = 38,
                    ImageLink = "assets/operations/sp_1_big.jpg",
                    Module = "SanPablo"
                },
                new Operation
                {
                    Id = 39,
                    ImageLink = "assets/operations/sp_2_big.jpg",
                    Module = "SanPablo"
                },
                new Operation
                {
                    Id = 40,
                    ImageLink = "assets/operations/sp_3_big.jpg",
                    Module = "SanPablo"
                },
                new Operation
                {
                    Id = 41,
                    ImageLink = "assets/operations/rb_gallery01.jpg",
                    Module = "RioBlanco"
                },
                new Operation
                {
                    Id = 42,
                    ImageLink = "assets/operations/rb_gallery02.jpg",
                    Module = "RioBlanco"
                },
                new Operation
                {
                    Id = 43,
                    ImageLink = "assets/operations/rb_gallery03.jpg",
                    Module = "RioBlanco"
                },
                new Operation
                {
                    Id = 44,
                    ImageLink = "assets/operations/rb_gallery04.jpg",
                    Module = "RioBlanco"
                },
                new Operation
                {
                    Id = 45,
                    ImageLink = "assets/operations/rb_1_big.jpg",
                    Module = "RioBlanco"
                },
                new Operation
                {
                    Id = 46,
                    ImageLink = "assets/operations/rb_2_big.jpg",
                    Module = "RioBlanco"
                },
                new Operation
                {
                    Id = 47,
                    ImageLink = "assets/operations/rb_3_big.jpg",
                    Module = "RioBlanco"
                },
                new Operation
                {
                    Id = 48,
                    ImageLink = "assets/operations/rb_4_big.jpg",
                    Module = "RioBlanco"
                },
                new Operation
                {
                    Id = 49,
                    ImageLink = "assets/operations/rb_5_big.jpg",
                    Module = "RioBlanco"
                },
                new Operation
                {
                    Id = 50,
                    ImageLink = "assets/operations/rb_6_big.jpg",
                    Module = "RioBlanco"
                }

            );
            #endregion

            #region People Seed

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    PathImage = "assets/our-people/Foto.png",
                    Title = "ALBERTO MORALES",
                    Subtitle = "Founder, Executive Chairman & Director",
                    Content = "Alberto Morales is founder of Andean Precious Metals Corp, and has over 30 years of experience specialized in corporate finance, mergers and acquisitions and corporate restructurings. He has also participated individually in other private equity and venture capital projects as co-developer, investor and/or advisor in telecommunications, aviation, tourism, financial services and asset management, mining and alternative energy. He has participated in the planning, formation, development and consolidating stages of various start-up business ventures. He holds a Bachelors degree in Law from the University of Monterrey (1984) and a Masters degree in Compared Law from the New York University School of Law (1987), and was admitted to practice law in Mexico in 1985 and in the State of New York in 1989.",
                    Team = "Leadership",
                    Position = 1
                },
                new Person
                {
                    Id = 2,
                    PathImage = "assets/our-people/Simon-Griffiths.png",
                    Title = "SIMON GRIFFITHS",
                    Subtitle = "President & Chief Executive Officer",
                    Content = "Simon Griffiths has extensive global experience in the resources industry and has held senior positions in private and public companies in both developed and emerging economies. He is a Chartered Mining Engineer and Qualified Person (QP) having held senior technical and operational leadership roles. At OceanaGold (TSX/ASX) he was Director of Operations at the Haile Gold mine after leading the technical due diligence for the $480million acquisition. He managed multiple technical studies at Newcrest Mining (ASX), TWSP Ltd and Solid Energy (NZX) for major resource projects in Australia, West Africa, Mozambique, Philippines, Indonesia, New Zealand and USA. Mr. Griffiths has an undergraduate B.Eng degree and Masters in Mining Engineering from Camborne School of Mines and a Masters in Mineral Economics from Curtin Business School, Western Australia. He has championed environmental engineering in mine design, ore reserve governance protocols and re-engineered major mining operations delivering significant valuation uplift",
                    Team = "Leadership",
                    Position = 2
                },
                new Person
                {
                    Id = 3,
                    PathImage = "assets/our-people/Jeff-Chan.png",
                    Title = "JEFF CHAN",
                    Subtitle = "Chief Financial Officer",
                    Content = "Mr. Chan is an experienced financial executive in the mining and healthcare industries, having held senior leadership roles in several Canadian publicly held companies on the TSX, TSX-V and CSE. Most recently, Mr. Chan was the CFO of a privately held cannabinoid technology company. Previously, he served as Interim CFO and Vice President, Finance at Liberty Health Sciences, where he led the growth of its financial operations subsequent to Liberty\'s spinoff from Aphria Inc., and Vice President, Finance at Orvana Minerals Corp. where he closed several transformational debt financings. Mr. Chan is a Chartered Professional Accountant (CA, CPA) and holds a B.Comm from the University of Toronto.",
                    Team = "Leadership",
                    Position = 3
                },
                new Person
                {
                    Id = 4,
                    PathImage = "assets/our-people/Fraser-Buchan.png",
                    Title = "FRASER BUCHAN",
                    Subtitle = "Corporate Development & Investor Relations",
                    Content = "Fraser Buchan has been involved in the mining industry since 2006, when he joined the institutional sales desk at GMP Securities in Toronto and then GMP Europe in London. Mr. Buchan has served as an executive of Newcastle Gold, Elgin Mining and Touchstone Gold and has served as a director of several publicly traded resource companies. Most recently, Mr. Buchan co-founded Tradewind Markets in partnership with IEX Group and Sprott Inc. Backed by leading companies in the precious metals industry, Tradewind provides institutions with a suite of digital solutions in trading, supply chain management, settlement and custody of precious metals. Mr. Buchan holds a degree in Economics from McGill University.",
                    Team = "Leadership",
                    Position = 4
                },
                new Person
                {
                    Id = 5,
                    PathImage = "assets/our-people/Humberto-Rada.png",
                    Title = "BEN MCCORMICK",
                    Subtitle = "VP Treasury and Corporate Development",
                    Content = "Ben McCormick has worked in senior roles for multinational corporations in the mining and resources sector for over twenty years. Most recently, he was the General Manager Projects and Chief Financial Officer of Rincon Mining Pty Limited where he was instrumental in the successful turnaround and sale of the Lithium asset in Argentina and the Bicarbonate of Soda asset in Colorado, USA. Prior to joining Rincon, Ben was Group Treasury of Newcrest Mining Ltd (ASX, TSX) and Western Mining Ltd (ASX). Ben holds a Bachelor of Business - Accounting from Monash University, is a Certified Practicing Accountant (CPA), and has extensive experience in Accounting, Treasury, Insurance, M&A, Business Turnaround, Project Management and Supply and logistics",
                    Team = "Leadership",
                    Position = 5
                }, new Person
                {
                    Id = 6,
                    PathImage = "assets/our-people/BEN-MCCORMICK-MC.png",
                    Title = "Humberto Rada Gómez",
                    Subtitle = "President of Manquiri (since July 2008)",
                    Content = "Mr. Rada Gomez has a degree in Business Administration, Economics and Public Accounting from the Catholic University of Chile. He is a member of the Board of the American Chamber of Commerce of Bolivia and a member of the Consultative Council of the Confederation of Private Entrepreneurs of Bolivia. He was President of the Association of Medium Miners, Director of Radio Fides and Fundación Nuevo Norte. His professional career was widely recognized by national and international institutions as a leader in the application of the best mining practices in relation to the Environment, Social and Business Responsibility, receiving more than 20 business and personal awards.",
                    Team = "Bolivia Management",
                    Position = 1
                },
                new Person
                {
                    Id = 7,
                    PathImage = "assets/our-people/Dante-Rodriguez.png",
                    Title = "Dante Rodríguez Montes",
                    Subtitle = "Chief Operation Officer of Bolivian Operations",
                    Content = "Dante Rodriguez graduated from the Geology School at the University of San Luis Potosi, Mexico (1985). He has been in the mining industry since 1986 in senior geology and exploration positions including General Manager of the Mining Unit and Vice-President of Explorations. He has worked for Peña Colorada, Minas de San Luis, Goldcorp, Starcore International Mines and was the Operations Manager in Santacruz Silver Mining",
                    Team = "Bolivia Management",
                    Position = 2
                },
                new Person
                {
                    Id = 8,
                    PathImage = "assets/our-people/Miguel-Torrres.png",
                    Title = "Miguel Ángel Torres Herrera",
                    Subtitle = "General Manager of Manquiri",
                    Content = "Miguel Torres graduated from the Faculty of Earth Sciences at the Autonomous University of Zacatecas, Mexico in 2004. He has extensive geology and exploration experience and has held Project Manager and Superintendent roles at companies including Gold Corp, Starcore, Oroco Resources and Santacruz Silver Mining",
                    Team = "Bolivia Management",
                    Position = 3
                },
                new Person
                {
                    Id = 9,
                    PathImage = "assets/our-people/Milhencka-Fisher.png",
                    Title = "Milhencka Paola Fischer Díaz",
                    Subtitle = "Environmental Manager",
                    Content = "Milhencka Fischer graduated as an Industrial Engineer from the Engineering National Faculty of Oruro, Bolivia in 2002. She has worked in Environmental management for over 15 years, in industries including mining, hydrocarbons and construction. Over the last 10 years, she has developed her professional career though Environmental Head Positions in Mining. Currently, she oversees compliance of all environmental Bolivian regulation and international regulations",
                    Team = "Bolivia Management",
                    Position = 4
                },
                new Person
                {
                    Id = 10,
                    PathImage = "",
                    Title = "ALBERTO MORALES",
                    Subtitle = "Founder, Executive Chairman & Director\r\nMember of the Nomination and Corporate Governance Committee",
                    Content = "Alberto Morales is founder of Andean Precious Metals Corp, and has over 30 years of experience specialized in corporate finance, mergers and acquisitions and corporate restructurings. He has also participated individually in other private equity and venture capital projects as co-developer, investor and/or advisor in telecommunications, aviation, tourism, financial services and asset management, mining and alternative energy. He has participated in the planning, formation, development and consolidating stages of various start-up business ventures. He holds a Bachelors degree in Law from the University of Monterrey (1984) and a Masters degree in Compared Law from the New York University School of Law (1987), and was admitted to practice law in Mexico in 1985 and in the State of New York in 1989.",
                    Team = "Board of Directors",
                    Position = 1
                },
                new Person
                {
                    Id = 11,
                    PathImage = "",
                    Title = "SIMON GRIFFITHS",
                    Subtitle = "Director\r\nPresident & Chief Executive Officer\r\nMember of the Health, Safety, Environment, Social and Sustainability Committee",
                    Content = "Simon Griffiths has extensive global experience in the resources industry, both public and private companies in developed and emerging economies. He is a Chartered Mining Engineer and Qualified Person (QP) having held senior technical and operational leadership roles. At TSX/ASX listed OceanaGold he was Director of Operations at Haile Gold mine after leading the technical due diligence for the $480million acquisition. At Newcrest Mining (ASX), TWSP Ltd and Solid Energy (NZX) Simon has managed multiple technical studies for major resource projects in Australia, West Africa, Mozambique, Philippines, Indonesia, New Zealand and USA. Mr. Griffiths has an undergraduate B.Eng degree and Masters in Mining Engineering from Camborne School of Mines and a Masters in Mineral Economics from Curtin Business School, Western Australia. He has championed environmental engineering in mine design, ore reserve governance protocols and re-engineered major mining operations delivering significant valuation uplift.",
                    Team = "Board of Directors",
                    Position = 2
                },
                new Person
                {
                    Id = 12,
                    PathImage = "",
                    Title = "PETER GUNDY",
                    Subtitle = "Independent Director\r\nChairman of the Audit Committee\r\nChairman of the Nomination And Corporate Governance Committee\r\nMember of the Audit Committee",
                    Content = "Peter Gundy is the founder of Neo Material Technologies Inc (“NEM”), serving as CEO and chairman from 1992 to 2008. Mr. Gundy created one of Canada’s most successful small/medium enterprises operated by Canadians in China and South East Asia. With manufacturing plants in China and Thailand, NEM became #1 in the world in powerful high-tech magnetic materials for the world’s electronic industries (NEM’s proprietary material was used in every hard drive manufactured). NEM became # 1 globally in the production of advanced rare earths also used in the global electronics industries and automotive sector. In 2012, NEM was sold to Molycorp for $1.1 billion. Mr. Gundy has served as a director with numerous publicly traded companies, including Banro Corp., True Gold Mining Inc., and Clifton Star Resources Corp.",
                    Team = "Board of Directors",
                    Position = 3
                },
                new Person
                {
                    Id = 13,
                    PathImage = "",
                    Title = "GRANT ANGWIN",
                    Subtitle = "Independent Director\r\nChairman of Health, Safety, Environment, Social and Sustainability Committee\r\nMember of the Audit Committee\r\nMember of the Compensation Committee\r\nMember of the Nomination and Corporate Governance Committee",
                    Content = "Grant Angwin has nearly 40 years’ experience in precious metals. He was, until recently, the President of Asahi Refining NA – the world’s largest gold and silver refiners with 3 manufacturing operations in North America. Prior to the sale of the business in 2015, he worked for Johnson Matthey, both in the UK and USA, where he held various senior management roles. His experience includes being the former Chair of the London Bullion Market Association, past Member of the Shanghai Gold Exchange International Advisory Board and a Board Member of the Silver Institute. He currently sits on the ICE Benchmark Precious Metals Oversight Committee for the LBMA Gold and Silver prices. He studied Chemistry and Business and Finance at the University of Hertfordshire as well as the Executive Management Programme at Queens School of Business, Ontario.",
                    Team = "Board of Directors",
                    Position = 4
                },
                new Person
                {
                    Id = 14,
                    PathImage = "",
                    Title = "FELIPE CANALES",
                    Subtitle = "Independent Director\r\nMember of the Audit Committee\r\nMember of the Compensation Committee",
                    Content = "Mr. Felipe Canales has 40 years of experience in the corporate finance and strategy areas, with over 25 years in top executive positions at major public companies. He has personally led and successfully executed large and complex corporate finance transactions, multi-jurisdictional debt restructurings, mergers and acquisitions, joint-ventures, and capital raisings. He is currently Co-CEO at Rose Hill, a Nasdaq SPAC focused on Latin America, among other international advising positions. Mr. Canales was CFO of Axtel, a major Mexican telecom company, from 2009 to 2017. Prior to Axtel he was CFO of Sigma Alimentos, the food division of Alfa, a global Mexican conglomerate with operations in Canada, the United States, Latin America, Europe and Asia, where he held other positions during his 30-year career at that company. Mr. Canales has an MBA degree from the Wharton School at the University of Pennsylvania and a B.Sc. in Industrial Engineering from Instituto Tecnológico de Monterrey.",
                    Team = "Board of Directors",
                    Position = 5
                },
                new Person
                {
                    Id = 15,
                    PathImage = "",
                    Title = "RAMIRO VILLARREAL",
                    Subtitle = "Independent Director\r\nMember of the Nomination and Corporate Governance Committee",
                    Content = "He graduated from the Universidad Autonoma de Nuevo Leon (UANL) where he obtained his Law Degree with Honorary mention. He also earned a Master's Degree in Finance from the University of Wisconsin and enrolled as an Honor Student. Before joining CEMEX, he was Deputy General Director of Regional Banking, responsible for all aspects (Credit, Legal, etc.) related to the Bank’s operation in its 121 local branches from 1985 to 1987. He joined CEMEX, S.A.B. de C.V., in 1987 and served as General Legal Director until June 2014, when he was promoted to Legal Executive Vice President in 2017. Mr. Villarreal also held the position as a consultant to the Chairman of the Board of Directors and to the CEO of CEMEX, until December 31th, 2017. Furthermore, he served as Secretary of the Board of Directors of CEMEX, from 1995 to 2017. And figured as Secretary of the Board of Directors of CEMEX Mexico until February 2017. Mr. Villarreal has been a member of the Board of Directors of CEMEX, S.A.B. of C.V. since 2017. He is also a member of the Board of Directors of several Companies, such as Grupo Cementos de Chihuahua, S.A. de C.V., Vinte Viviendas Integrales, S.A.B. of C.V., Banco Bancrea, S.A. Institución de Banca Múltiple y Arendal, S. de R.L. de C.V., until February 2012; Mr. Villarreal held the position of Secretary of the Board of Directors of Enseñanza e Investigación Superior, A.C., a company that manages the Instituto Tecnológico y de Estudios Superiores de Monterrey (ITESM).",
                    Team = "Board of Directors",
                    Position = 6
                }
            );

            #endregion

            #region Statistic
            modelBuilder.Entity<Statistic>().HasData(
                new Statistic
                {
                    Id = 1,
                    Maximum = 5500,
                    Minimum = 1,
                    Val = 0
                },
                new Statistic
                {
                    Id = 2,
                    Maximum = 12,
                    Minimum = 1,
                    Val = 0
                },
                new Statistic
                {
                    Id = 3,
                    Maximum = 65,
                    Minimum = 10,
                    Val = 0
                },
                new Statistic
                {
                    Id = 4,
                    Maximum = 280,
                    Minimum = 50,
                    Val = 0
                },
                new Statistic
                {
                    Id = 5,
                    Maximum = 60,
                    Minimum = 1,
                    Val = 0
                }
            );

            #endregion

            #region User Seed
            CreatePasswordHash("Admin123!", out byte[] passwordHash, out byte[] passwordSalt);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "cesarv@acsoltec.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    DateCreated = DateTime.Now,
                    Role = "Admi"
                }
            );
            #endregion

            
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
