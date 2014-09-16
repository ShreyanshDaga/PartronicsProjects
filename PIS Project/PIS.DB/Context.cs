using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DB
{
    public class MyContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Route> Routes { get; set; }
       
       
        public MyContext()
            : base("DBCS")
        {
        }

        public void SeedData()
        {
            var myContext = this;

            // Delete DB Here
            myContext.Database.Delete();

            Console.WriteLine("Generating Seed Database...");
            // Add Five Routes
            var Route1 = new Route { RouteName = "Pune To Mumbai" };
            var Route2 = new Route { RouteName = "Pune To Kolhapur" };
            var Route3 = new Route { RouteName = "Pune To Solapur" };
            var Route4 = new Route { RouteName = "Pune To Bhusawal" };
            var Route5 = new Route { RouteName = "Bhusawal To Nagpur" };

            // Add Stations
            // Stations for Route 1
            var Station1R1 = new Station { StationCode = "PUNE", StationName = "PUNE JN", StationRoute = Route1 };
            var Station2R1 = new Station { StationCode = "SVJR", StationName = "SHIVAJINAGAR", StationRoute = Route1 };
            var Station3R1 = new Station { StationCode = "KK",   StationName = "KHADAKI", StationRoute = Route1 };
            var Station4R1 = new Station { StationCode = "DAPD", StationName = "DAPODI", StationRoute = Route1 };
            var Station5R1 = new Station { StationCode = "KSWD", StationName = "KASARWADI", StationRoute = Route1 };
            var Station6R1 = new Station { StationCode = "PMP",  StationName = "PIMPRI", StationRoute = Route1 };
            var Station7R1 = new Station { StationCode = "CCH",  StationName = "CHINCHWAD", StationRoute = Route1 };
            var Station8R1 = new Station { StationCode = "AKRD", StationName = "AKURDI", StationRoute = Route1 };
            var Station9R1 = new Station { StationCode = "DEHR", StationName = "DEHU RD", StationRoute = Route1 };
            var Station10R1 = new Station{ StationCode = "BGW",  StationName = "BEGDEWADI", StationRoute = Route1 };
            var Station11R1 = new Station{ StationCode = "SLRW", StationName = "SHELARWADI", StationRoute = Route1 };
            var Station12R1 = new Station{ StationCode = "GRWAD",StationName = "GHORAWADI", StationRoute = Route1 };
            var Station13R1 = new Station{ StationCode = "TGN",  StationName = "TALEGAON", StationRoute = Route1 };
            var Station14R1 = new Station{ StationCode = "VDH",  StationName = "VADGAON", StationRoute = Route1 };
            var Station15R1 = new Station{ StationCode = "KNHE", StationName = "KANHE", StationRoute = Route1 };
            var Station16R1 = new Station{ StationCode = "KMST", StationName = "KAMSHET", StationRoute = Route1 };
            var Station17R1 = new Station { StationCode = "MVL", StationName = "MALAVLI", StationRoute = Route1 };
            var Station18R1 = new Station { StationCode = "LNL", StationName = "LONAVALA", StationRoute = Route1 };
            var Station19R1 = new Station { StationCode = "KAD", StationName = "KHANDALA", StationRoute = Route1 };
            var Station20R1 = new Station { StationCode = "MHLC",StationName = "MONKEY HILLS", StationRoute = Route1 };
            var Station21R1 = new Station { StationCode = "NAGC",StationName = "NAGARGALI", StationRoute = Route1 };
            var Station22R1 = new Station { StationCode = "NNCN",StationName = "NAGNATH CABIN", StationRoute = Route1 };
            var Station23R1 = new Station { StationCode = "TKW", StationName = "THAKURVADI", StationRoute = Route1 };
            var Station24R1 = new Station { StationCode = "PDI", StationName = "PALASDHARI", StationRoute = Route1 };
            var Station25R1 = new Station { StationCode = "KJT", StationName = "KARJAT JN", StationRoute = Route1 };
            var Station26R1 = new Station { StationCode = "BVS", StationName = "BHIVPURI RD", StationRoute = Route1 };
            var Station27R1 = new Station { StationCode = "NRL", StationName = "NERAL JN ", StationRoute = Route1 };
            var Station28R1 = new Station { StationCode = "SHLU",StationName = "SHELU", StationRoute = Route1 };
            var Station29R1 = new Station { StationCode = "VGI", StationName = "VANGANI", StationRoute = Route1 };
            var Station30R1 = new Station { StationCode = "BUD", StationName = "BADALAPUR", StationRoute = Route1 };
            var Station31R1 = new Station { StationCode = "ABH", StationName = "AMBERNAATH", StationRoute = Route1 };
            var Station32R1 = new Station { StationCode = "ULNR",StationName = "ULHASNAGAR", StationRoute = Route1 };
            var Station33R1 = new Station { StationCode = "VLDI",StationName = "VITHALWADI", StationRoute = Route1 };
            var Station34R1 = new Station { StationCode = "KYN", StationName = "KALYAN JN", StationRoute = Route1 };
            var Station35R1 = new Station { StationCode = "THK", StationName = "THAKURLI", StationRoute = Route1 };
            var Station36R1 = new Station { StationCode = "DI",  StationName = "DOMBIVALI", StationRoute = Route1 };
            var Station37R1 = new Station { StationCode = "KOPR",StationName = "KOPAR", StationRoute = Route1 };
            var Station38R1 = new Station { StationCode = "DIVA",StationName = "DIVA JN", StationRoute = Route1 };
            var Station39R1 = new Station { StationCode = "MBQ", StationName = "MUMBRA", StationRoute = Route1 };
            var Station40R1 = new Station { StationCode = "KLVA",StationName = "KALVA", StationRoute = Route1 };
            var Station41R1 = new Station { StationCode = "TNA", StationName = "THANE JN", StationRoute = Route1 };
            var Station42R1 = new Station { StationCode = "MLND",StationName = "MULUND", StationRoute = Route1 };
            var Station43R1 = new Station { StationCode = "NHU", StationName = "NAHUR", StationRoute = Route1 };
            var Station44R1 = new Station { StationCode = "BND", StationName = "BHANDUP", StationRoute = Route1 };
            var Station45R1 = new Station { StationCode = "KJMG",StationName = "KANJURMARG", StationRoute = Route1 };
            var Station46R1 = new Station { StationCode = "VK",  StationName = "VIKHROLI", StationRoute = Route1 };
            var Station47R1 = new Station { StationCode = "GC",  StationName = "GHATKOPAR", StationRoute = Route1 };
            var Station48R1 = new Station { StationCode = "VVH", StationName = "VIDYAVIHAR", StationRoute = Route1 };
            var Station49R1 = new Station { StationCode = "LTT", StationName = "LOKMANYA TILAK TERMINUS", StationRoute = Route1 };
            var Station50R1 = new Station { StationCode = "SIN", StationName = "SION", StationRoute = Route1 };
            var Station51R1 = new Station { StationCode = "MTN", StationName = "MATUNGA", StationRoute = Route1 };
            var Station52R1 = new Station { StationCode = "DR",  StationName = "DADAR CENTRAL", StationRoute = Route1 };
            var Station53R1 = new Station { StationCode = "PR",  StationName = "PAREL", StationRoute = Route1 };
            var Station54R1 = new Station { StationCode = "CRD", StationName = "CURRY RD", StationRoute = Route1 };
            var Station55R1 = new Station { StationCode = "CHG", StationName = "CHINCHPOKALI", StationRoute = Route1 };
            var Station56R1 = new Station { StationCode = "BY",  StationName = "BYCULLA", StationRoute = Route1 };
            var Station57R1 = new Station { StationCode = "SNRD",StationName = "SANDHURST RD ", StationRoute = Route1 };
            var Station58R1 = new Station { StationCode = "MSD", StationName = "MASJID BANDAR", StationRoute = Route1 };
            var Station59R1 = new Station { StationCode = "CSTM",StationName = "CHHATRAPATI SHIVAJI MAHARAJ TERMINUS MUMBAI", StationRoute = Route1 };
            
            // Stations for Route 2
            var Station1R2 = new Station { StationCode = "PUNE", StationName = "PUNE JN", StationRoute = Route2 };
            var Station2R2 = new Station { StationCode = "GPR",  StationName = "GHORPURI", StationRoute = Route2 };
            var Station3R2 = new Station { StationCode = "GIT",  StationName = "GHORPURI TRANSH", StationRoute = Route2 };
            var Station4R2 = new Station { StationCode = "SSV",  StationName = "SASVAD RD", StationRoute = Route2 };
            var Station5R2 = new Station { StationCode = "FSG",  StationName = "PHURSUNGI", StationRoute = Route2 };
            var Station6R2 = new Station { StationCode = "ALN",  StationName = "ALANDI ", StationRoute = Route2 };
            var Station7R2 = new Station { StationCode = "SHIV", StationName = "SHINDAWANE", StationRoute = Route2 };
            var Station8R2 = new Station { StationCode = "ABLE", StationName = "AMBALE", StationRoute = Route2 };
            var Station9R2 = new Station { StationCode = "RJW",  StationName = "RAJEWADI", StationRoute = Route2 };
            var Station10R2 = new Station{ StationCode = "JJR",  StationName = "JEJURI", StationRoute = Route2 };
            var Station11R2 = new Station{ StationCode = "DNJ",  StationName = "DAUNDAJ", StationRoute = Route2 };
            var Station12R2 = new Station{ StationCode = "WLH",  StationName = "VALHA", StationRoute = Route2 };
            var Station13R2 = new Station{ StationCode = "NIRA", StationName = "NIRA", StationRoute = Route2 };
            var Station14R2 = new Station{ StationCode = "LNN",  StationName = "LONAND", StationRoute = Route2 };
            var Station15R2 = new Station{ StationCode = "SPL",  StationName = "SALPE", StationRoute = Route2 };
            var Station16R2 = new Station{ StationCode = "AKI",  StationName = "AKARDI", StationRoute = Route2 };
            var Station17R2 = new Station{ StationCode = "WTR",  StationName = "WATHAR", StationRoute = Route2 };
            var Station18R2 = new Station{ StationCode = "PLV",  StationName = "PALSI", StationRoute = Route2 };
            var Station19R2 = new Station{ StationCode = "JSV",  StationName = "JARANDESHWAR", StationRoute = Route2 };
            var Station20R2 = new Station{ StationCode = "STR",  StationName = "SATARA", StationRoute = Route2 };
            var Station21R2 = new Station{ StationCode = "KRG",  StationName = "KOREGAON", StationRoute = Route2 };
            var Station22R2 = new Station{ StationCode = "RMP",  StationName = "RAHIMATPUR", StationRoute = Route2 };
            var Station23R2 = new Station{ StationCode = "TAZ",  StationName = "TARGAON", StationRoute = Route2 };
            var Station24R2 = new Station{ StationCode = "MSR",  StationName = "MASUR", StationRoute = Route2 };
            var Station25R2 = new Station{ StationCode = "SIW",  StationName = "SHIRRAVDE", StationRoute = Route2 };
            var Station26R2 = new Station{ StationCode = "KRD",  StationName = "KARAD", StationRoute = Route2 };
            var Station27R2 = new Station{ StationCode = "SNE",  StationName = "SHENOLI", StationRoute = Route2 };
            var Station28R2 = new Station{ StationCode = "BVNR", StationName = "BHAVANINAGAR", StationRoute = Route2 };
            var Station29R2 = new Station{ StationCode = "TKR",  StationName = "TAKARI", StationRoute = Route2 };
            var Station30R2 = new Station{ StationCode = "KOV",  StationName = "KIRLOSKARWADI", StationRoute = Route2 };
            var Station31R2 = new Station{ StationCode = "ANQ",  StationName = "AMNAPUR", StationRoute = Route2 };
            var Station32R2 = new Station{ StationCode = "BVQ",  StationName = "BHILAVDI", StationRoute = Route2 };
            var Station33R2 = new Station{ StationCode = "NDE",  StationName = "NANDRE", StationRoute = Route2 };
            var Station34R2 = new Station{ StationCode = "MDVR", StationName = "MADHAVNAGAR", StationRoute = Route2 };
            var Station35R2 = new Station{ StationCode = "SLI",  StationName = "SANGALI", StationRoute = Route2 };
            var Station36R2 = new Station{ StationCode = "VRB",  StationName = "VISHRAMBAG", StationRoute = Route2 };
            var Station37R2 = new Station{ StationCode = "MRJ",  StationName = "MIRAJ JN", StationRoute = Route2 };
            var Station38R2 = new Station{ StationCode = "JSP",  StationName = "JAYSINGPUR", StationRoute = Route2 };
            var Station39R2 = new Station{ StationCode = "NMGT", StationName = "NIMSHIRGAON TAMDAL", StationRoute = Route2 };
            var Station40R2 = new Station{ StationCode = "HTK",  StationName = "HATKANAGLE", StationRoute = Route2 };
            var Station41R2 = new Station{ StationCode = "RKD",  StationName = "RUKADI", StationRoute = Route2 };
            var Station42R2 = new Station{ StationCode = "VV",   StationName = "VALIVADE", StationRoute = Route2 };
            var Station43R2 = new Station{ StationCode = "GRMT", StationName = "GUR MARKET", StationRoute = Route2 };
            var Station44R2 = new Station{ StationCode = "KOP",  StationName = "CHHATRAPATI SHAHUMAHARAJ TERMINUS KOLHAPUR", StationRoute = Route2 };
                        
            // Stations for Route 3
            var Station1R3 = new Station { StationCode = "PUNE", StationName = "PUNE JN", StationRoute = Route3 };
            var Station2R3 = new Station { StationCode = "GPRW", StationName = "GHORPURI WEST", StationRoute = Route3 };
            var Station3R3 = new Station { StationCode = "HDP",  StationName = "HADAPSAR", StationRoute = Route3 };
            var Station4R3 = new Station { StationCode = "MJBK", StationName = "MANJIRI BUDRUK", StationRoute = Route3 };
            var Station5R3 = new Station { StationCode = "LONI", StationName = "LONI", StationRoute = Route3 };
            var Station6R3 = new Station { StationCode = "URI",  StationName = "URALI", StationRoute = Route3 };
            var Station7R3 = new Station { StationCode = "YT",   StationName = "YEVAT", StationRoute = Route3 };
            var Station8R3 = new Station { StationCode = "KTT",  StationName = "KHUTBAV", StationRoute = Route3 };
            var Station9R3 = new Station { StationCode = "KDG",  StationName = "KEDGAON", StationRoute = Route3 };
            var Station10R3 = new Station{ StationCode = "KDTN", StationName = "KADENATH", StationRoute = Route3 };
            var Station11R3 = new Station{ StationCode = "PAA",  StationName = "PATAS", StationRoute = Route3 };
            var Station12R3 = new Station{ StationCode = "DD",   StationName = "DAUND JN", StationRoute = Route3 };
            var Station13R3 = new Station{ StationCode = "BRB",  StationName = "BORIBEL", StationRoute = Route3 };
            var Station14R3 = new Station{ StationCode = "MLM",  StationName = "MALTHAN", StationRoute = Route3 };
            var Station15R3 = new Station{ StationCode = "BGVN", StationName = "BHIGWAN", StationRoute = Route3 };
            var Station16R3 = new Station{ StationCode = "JNTR", StationName = "JINTI RD", StationRoute = Route3 };
            var Station17R3 = new Station{ StationCode = "PRWD", StationName = "PAREWADI", StationRoute = Route3 };
            var Station18R3 = new Station{ StationCode = "WSB",  StationName = "WASHIMBE", StationRoute = Route3 };
            var Station19R3 = new Station{ StationCode = "PPJ",  StationName = "POPLHAJ", StationRoute = Route3 };
            var Station20R3 = new Station{ StationCode = "JEUR", StationName = "JEUR", StationRoute = Route3 };
            var Station21R3 = new Station{ StationCode = "BLNI", StationName = "BHLWANI", StationRoute = Route3 };
            var Station22R3 = new Station{ StationCode = "KEM",  StationName = "KEM", StationRoute = Route3 };
            var Station23R3 = new Station{ StationCode = "DHS",  StationName = "DHAVLAS", StationRoute = Route3 };
            var Station24R3 = new Station{ StationCode = "KWV",  StationName = "KURUDWADI JN", StationRoute = Route3 };
            var Station25R3 = new Station{ StationCode = "WDS",  StationName = "WADSINGE", StationRoute = Route3 };
            var Station26R3 = new Station{ StationCode = "MA",   StationName = "MADHA", StationRoute = Route3 };
            var Station27R3 = new Station{ StationCode = "WKA",  StationName = "VAKAV", StationRoute = Route3 };
            var Station28R3 = new Station{ StationCode = "AAG",  StationName = "ANGAR", StationRoute = Route3 };
            var Station29R3 = new Station{ StationCode = "MKPT", StationName = "MALIKPETH", StationRoute = Route3 };
            var Station30R3 = new Station{ StationCode = "MO",   StationName = "MOHOL", StationRoute = Route3 };
            var Station31R3 = new Station{ StationCode = "MVE",  StationName = "MUNDHEWADI", StationRoute = Route3 };
            var Station32R3 = new Station{ StationCode = "PK",   StationName = "PAKNI", StationRoute = Route3 };
            var Station33R3 = new Station{ StationCode = "BALE", StationName = "BALE", StationRoute = Route3 };
            var Station34R3 = new Station{ StationCode = "SUR",  StationName = "SOLAPUR", StationRoute = Route3 };
            
            // Stations for Route 4
            var Station1R4 = new Station { StationCode = "PUNE", StationName = "PUNE JN", StationRoute = Route4 };
            var Station2R4 = new Station { StationCode = "SVJR", StationName = "SHIVAJINAGAR", StationRoute = Route4 };
            var Station3R4 = new Station { StationCode = "KK",   StationName = "KHADKI", StationRoute = Route4 };
            var Station4R4 = new Station { StationCode = "DAPD", StationName = "DAPODI", StationRoute = Route4 };
            var Station5R4 = new Station { StationCode = "KSWD", StationName = "KASARWADI", StationRoute = Route4 };
            var Station6R4 = new Station { StationCode = "PMP",  StationName = "PIMPRI", StationRoute = Route4 };
            var Station7R4 = new Station { StationCode = "CCH",  StationName = "CHNCHWAD", StationRoute = Route4 };
            var Station8R4 = new Station { StationCode = "AKRD", StationName = "AKURDI", StationRoute = Route4 };
            var Station9R4 = new Station { StationCode = "DEHU", StationName = "DEHU RD", StationRoute = Route4 };
            var Station10R4 = new Station{ StationCode = "BGW",  StationName = "BEGDEWADI", StationRoute = Route4 };
            var Station11R4 = new Station{ StationCode = "BGWI", StationName = "BEGDAEWADI", StationRoute = Route4 };
            var Station12R4 = new Station{ StationCode = "SLRW", StationName = "SHELARWADI", StationRoute = Route4 };
            var Station13R4 = new Station{ StationCode = "GRWD", StationName = "GHORAWADI", StationRoute = Route4 };
            var Station14R4 = new Station{ StationCode = "TGN",  StationName = "TALEGAON", StationRoute = Route4 };
            var Station15R4 = new Station{ StationCode = "VDN",  StationName = "VADGAON", StationRoute = Route4 };
            var Station16R4 = new Station{ StationCode = "KNHE", StationName = "KANHE", StationRoute = Route4 };
            var Station17R4 = new Station{ StationCode = "KMST", StationName = "KAMSHET", StationRoute = Route4 };
            var Station18R4 = new Station{ StationCode = "MVL",  StationName = "MALAVLI", StationRoute = Route4 };
            var Station19R4 = new Station{ StationCode = "LNL",  StationName = "LONAVALA", StationRoute = Route4 };
            var Station20R4 = new Station{ StationCode = "KAD",  StationName = "KHANDALA", StationRoute = Route4 };
            var Station21R4 = new Station{ StationCode = "MHLC", StationName = "MONKEY HILL", StationRoute = Route4 };
            var Station22R4 = new Station{ StationCode = "NAGC", StationName = "NAGARGALI", StationRoute = Route4 };
            var Station23R4 = new Station{ StationCode = "NNCN", StationName = "NAGNATH CABIN", StationRoute = Route4 };
            var Station24R4 = new Station{ StationCode = "PDI",  StationName = "PALASDHARI", StationRoute = Route4 };
            var Station25R4 = new Station{ StationCode = "KJT",  StationName = "KARJAT JN", StationRoute = Route4 };
            var Station26R4 = new Station{ StationCode = "CHOK", StationName = "CHOWK", StationRoute = Route4 };
            var Station27R4 = new Station{ StationCode = "MHPE", StationName = "MOHAPE", StationRoute = Route4 };
            var Station28R4 = new Station{ StationCode = "CKHS", StationName = "CHIKHALE", StationRoute = Route4 };
            var Station29R4 = new Station{ StationCode = "PNVL", StationName = "PANVEL JN", StationRoute = Route4 };
            var Station30R4 = new Station{ StationCode = "KLMC", StationName = "KALAMBOLI", StationRoute = Route4 };
            var Station31R4 = new Station{ StationCode = "KLMG", StationName = "KALAMBOLI GOODS", StationRoute = Route4 };
            var Station32R4 = new Station{ StationCode = "NVRD", StationName = "NAVADE RD", StationRoute = Route4 };
            var Station33R4 = new Station{ StationCode = "TPND", StationName = "TALOJE PANCHNAND", StationRoute = Route4 };
            var Station34R4 = new Station{ StationCode = "NIIJ", StationName = "NILAJE", StationRoute = Route4 };
            var Station35R4 = new Station{ StationCode = "DTVL", StationName = "DATIVLI", StationRoute = Route4 };
            var Station36R4 = new Station{ StationCode = "DI",   StationName = "DOMBIVLI", StationRoute = Route4 };
            var Station37R4 = new Station{ StationCode = "THK",  StationName = "THAKURLI", StationRoute = Route4 };
            var Station38R4 = new Station{ StationCode = "KYN",  StationName = "KALYAN JN", StationRoute = Route4 };
            var Station39R4 = new Station{ StationCode = "SHAD", StationName = "SHAHAD", StationRoute = Route4 };
            var Station40R4 = new Station{ StationCode = "ABY",  StationName = "AMBIVLI", StationRoute = Route4 };
            var Station41R4 = new Station{ StationCode = "TLA",  StationName = "TITWALA", StationRoute = Route4 };
            var Station42R4 = new Station{ StationCode = "KDV",  StationName = "KHADAVLI", StationRoute = Route4 };
            var Station43R4 = new Station{ StationCode = "VSD",  StationName = "VASIND", StationRoute = Route4 };
            var Station44R4 = new Station{ StationCode = "ASO",  StationName = "ASANGAON", StationRoute = Route4 };
            var Station45R4 = new Station{ StationCode = "ATG",  StationName = "ATGAON", StationRoute = Route4 };
            var Station46R4 = new Station{ StationCode = "THS",  StationName = "THANSIT", StationRoute = Route4 };
            var Station47R4 = new Station{ StationCode = "KE",   StationName = "KHARDI", StationRoute = Route4 };
            var Station48R4 = new Station{ StationCode = "OMB",  StationName = "OOMBERMALI", StationRoute = Route4 };
            var Station49R4 = new Station{ StationCode = "KSRA", StationName = "KASARA", StationRoute = Route4 };
            var Station50R4 = new Station{ StationCode = "TGR3", StationName = "BLOCK & CATCH SIDING CABIN3", StationRoute = Route4 };
            var Station51R4 = new Station{ StationCode = "TGR2", StationName = "BLOCK & CATCH SIDING CABIN2", StationRoute = Route4 };
            var Station52R4 = new Station{ StationCode = "IGP",  StationName = "IGATPURI", StationRoute = Route4 };
            var Station53R4 = new Station{ StationCode = "GO",   StationName = "GHOTI", StationRoute = Route4 };
            var Station54R4 = new Station{ StationCode = "PI",   StationName = "PADLI", StationRoute = Route4 };
            var Station55R4 = new Station{ StationCode = "AV",   StationName = "ASVALI", StationRoute = Route4 };
            var Station56R4 = new Station{ StationCode = "LT",   StationName = "LAHAVIT", StationRoute = Route4 };
            var Station57R4 = new Station{ StationCode = "DVL",  StationName = "DEVLALI", StationRoute = Route4 };
            var Station58R4 = new Station{ StationCode = "NK",   StationName = "NASIK ROAD", StationRoute = Route4 };
            var Station59R4 = new Station{ StationCode = "ODHA", StationName = "ODHA", StationRoute = Route4 };
            var Station60R4 = new Station{ StationCode = "KW",   StationName = "KHERVADI", StationRoute = Route4 };
            var Station61R4 = new Station{ StationCode = "KBSN", StationName = "KASBE SUKENE", StationRoute = Route4 };
            var Station62R4 = new Station{ StationCode = "NR",   StationName = "NIPHAD", StationRoute = Route4 };
            var Station63R4 = new Station{ StationCode = "UGN",  StationName = "UGAON", StationRoute = Route4 };
            var Station64R4 = new Station{ StationCode = "LS",   StationName = "LASALGAON", StationRoute = Route4 };
            var Station65R4 = new Station{ StationCode = "SUM",  StationName = "SUMMIT", StationRoute = Route4 };
            var Station66R4 = new Station{ StationCode = "MMR",  StationName = "MANMAD JN", StationRoute = Route4 };
            var Station67R4 = new Station{ StationCode = "PNV",  StationName = "PANEVADI", StationRoute = Route4 };
            var Station68R4 = new Station{ StationCode = "HSL",  StationName = "HISVAHAL", StationRoute = Route4 };
            var Station69R4 = new Station{ StationCode = "PJN",  StationName = "PANJHAN", StationRoute = Route4 };
            var Station70R4 = new Station{ StationCode = "NGN",  StationName = "NANDGAON", StationRoute = Route4 };
            var Station71R4 = new Station{ StationCode = "PKE",  StationName = "PIMPARKHED", StationRoute = Route4 };
            var Station72R4 = new Station{ StationCode = "NI",   StationName = "NAYDONGRI", StationRoute = Route4 };
            var Station73R4 = new Station{ StationCode = "RHNE", StationName = "ROHINI", StationRoute = Route4 };
            var Station74R4 = new Station{ StationCode = "HPR",  StationName = "HIRAPUR", StationRoute = Route4 };
            var Station75R4 = new Station{ StationCode = "CSN",  StationName = "CHALISGAON JN", StationRoute = Route4 };
            var Station76R4 = new Station{ StationCode = "VGL",  StationName = "VAGHLI", StationRoute = Route4 };
            var Station77R4 = new Station{ StationCode = "KJ",   StationName = "KAJGAON", StationRoute = Route4 };
            var Station78R4 = new Station{ StationCode = "NGD",  StationName = "NAGARDEVLA", StationRoute = Route4 };
            var Station79R4 = new Station{ StationCode = "GAA",  StationName = "GALAN", StationRoute = Route4 };
            var Station80R4 = new Station{ StationCode = "PC",   StationName = "PACHORA JN", StationRoute = Route4 };
            var Station81R4 = new Station{ StationCode = "PHQ",  StationName = "PARDHANDE", StationRoute = Route4 };
            var Station82R4 = new Station{ StationCode = "MYJ",  StationName = "MAHEJI", StationRoute = Route4 };
            var Station83R4 = new Station{ StationCode = "MWD",  StationName = "MHASAVAD", StationRoute = Route4 };
            var Station84R4 = new Station{ StationCode = "SS",   StationName = "SHIRSOLI", StationRoute = Route4 };
            var Station85R4 = new Station{ StationCode = "JL",   StationName = "JALGAON JN", StationRoute = Route4 };
            var Station86R4 = new Station{ StationCode = "TRW",  StationName = "TARSOD", StationRoute = Route4 };
            var Station87R4 = new Station{ StationCode = "BDI",  StationName = "BHADLI", StationRoute = Route4 };
            var Station88R4 = new Station{ StationCode = "BSL",  StationName = "BHUSAVAL JN", StationRoute = Route4 };


            // Stations for Route 5
            var Station1R5 = new Station { StationCode = "BSL",  StationName = "BHUSAWAL JN", StationRoute = Route5 };
            var Station2R5 = new Station { StationCode = "VNA",  StationName = "VARANGAON", StationRoute = Route5 };
            var Station3R5 = new Station { StationCode = "ACG",  StationName = "ACHEGAON", StationRoute = Route5 };
            var Station4R5 = new Station { StationCode = "BDWD", StationName = "BODWAD", StationRoute = Route5 };
            var Station5R5 = new Station { StationCode = "KLHD", StationName = "KOLHADI", StationRoute = Route5 };
            var Station6R5 = new Station { StationCode = "KMKD", StationName = "KAMKHED", StationRoute = Route5 };
            var Station7R5 = new Station { StationCode = "MKU",  StationName = "MALKAPUR", StationRoute = Route5 };
            var Station8R5 = new Station { StationCode = "WADO", StationName = "WADODA", StationRoute = Route5 };
            var Station9R5 = new Station { StationCode = "BIS",  StationName = "BISWA BRIDGE", StationRoute = Route5 };
            var Station10R5 = new Station { StationCode = "KJL", StationName = "KHUMGAON", StationRoute = Route5 };
            var Station11R5 = new Station { StationCode = "NN",  StationName = "NANDURA", StationRoute = Route5 };
            var Station12R5 = new Station { StationCode = "JM",  StationName = "JALAMB", StationRoute = Route5 };
            var Station13R5 = new Station { StationCode = "SEG", StationName = "SHEGAON", StationRoute = Route5 };
            var Station14R5 = new Station { StationCode = "NGZ", StationName = "NAGJIHARI", StationRoute = Route5 };
            var Station15R5 = new Station { StationCode = "PS",  StationName = "PARAS", StationRoute = Route5 };
            var Station16R5 = new Station { StationCode = "GAO", StationName = "GAIGAON", StationRoute = Route5 };
            var Station17R5 = new Station { StationCode = "AK",  StationName = "AKOLA", StationRoute = Route5 };
            var Station18R5 = new Station { StationCode = "YAD", StationName = "YEULKHED", StationRoute = Route5 };
            var Station19R5 = new Station { StationCode = "BGN", StationName = "BORGAON", StationRoute = Route5 };
            var Station20R5 = new Station { StationCode = "KTP", StationName = "KATEPURNA", StationRoute = Route5 };
            var Station21R5 = new Station { StationCode = "MZR", StationName = "MURTIZAPUR", StationRoute = Route5 };
            var Station22R5 = new Station { StationCode = "MANA",StationName = "MANA", StationRoute = Route5 };
            var Station23R5 = new Station { StationCode = "MNDA",StationName = "MANDURA", StationRoute = Route5 };
            var Station24R5 = new Station { StationCode = "KUM", StationName = "KURAM", StationRoute = Route5 };
            var Station25R5 = new Station { StationCode = "TKI", StationName = "TAKARI", StationRoute = Route5 };
            var Station26R5 = new Station { StationCode = "BD",  StationName = "BADNERA", StationRoute = Route5 };
            var Station27R5 = new Station { StationCode = "TMT", StationName = "TIMTALA", StationRoute = Route5 };
            var Station28R5 = new Station { StationCode = "MLR", StationName = "MALKHED", StationRoute = Route5 };
            var Station29R5 = new Station { StationCode = "CND", StationName = "CHANDUR", StationRoute = Route5 };
            var Station30R5 = new Station { StationCode = "DIP", StationName = "DIPURE", StationRoute = Route5 };
            var Station31R5 = new Station { StationCode = "DMN", StationName = "DHAMANGAON", StationRoute = Route5 };
            var Station32R5 = new Station { StationCode = "TLN", StationName = "TALNI", StationRoute = Route5 };
            var Station33R5 = new Station { StationCode = "PLO", StationName = "PULGAON", StationRoute = Route5 };
            var Station34R5 = new Station { StationCode = "KAOT",StationName = "KAOTHA", StationRoute = Route5 };
            var Station35R5 = new Station { StationCode = "DAE", StationName = "DEHAGAON", StationRoute = Route5 };
            var Station36R5 = new Station { StationCode = "SEGM",StationName = "SEWAGRAM", StationRoute = Route5 };
            var Station37R5 = new Station { StationCode = "SLOR",StationName = "SELOO RD", StationRoute = Route5 };
            var Station38R5 = new Station { StationCode = "TGP", StationName = "TULIAPUR", StationRoute = Route5 };
            var Station39R5 = new Station { StationCode = "SNI", StationName = "SINDI", StationRoute = Route5 };
            var Station40R5 = new Station { StationCode = "BOK", StationName = "BORKHEDI", StationRoute = Route5 };
            var Station41R5 = new Station { StationCode = "BTBR",StationName = "BUTI BORI", StationRoute = Route5 };
            var Station42R5 = new Station { StationCode = "GMG", StationName = "GUMGAON", StationRoute = Route5 };
            var Station43R5 = new Station { StationCode = "KRI", StationName = "KHAPRI", StationRoute = Route5 };
            var Station44R5 = new Station { StationCode = "AJNI",StationName = "AJNI", StationRoute = Route5 };
            var Station45R5 = new Station { StationCode = "NGP", StationName = "NAGPUR JN", StationRoute = Route5 };
            
            // Add Trains
            // Trains for Route 1
            var Train1R1 = new Train { TrainName = "Indriyani Express",   TrainNumber = "22106 ", TrainRoute = Route1 };
            var Train2R1 = new Train { TrainName = "Singhad Express",     TrainNumber = "11024 ", TrainRoute = Route1 };
            var Train3R1 = new Train { TrainName = "Sahyadri Express",    TrainNumber = "11010 ", TrainRoute = Route1 };
            var Train4R1 = new Train { TrainName = "Intercity Express",   TrainNumber = "12128 ", TrainRoute = Route1 };
            var Train5R1 = new Train { TrainName = "DeccanQueen Express", TrainNumber = "12124 ", TrainRoute = Route1 };
            var Train6R1 = new Train { TrainName = "Siddheshwar Express", TrainNumber = "12149 ", TrainRoute = Route1 };

            // Trains for Route 2
            var Train1R2 = new Train { TrainName = "Maharashtra Express",  TrainNumber = "11040 ", TrainRoute = Route2 };
            var Train2R2 = new Train { TrainName = "Koyna Express",        TrainNumber = "11029 ", TrainRoute = Route2 };
            var Train3R2 = new Train { TrainName = "Mahalaxmi Express",    TrainNumber = "17411 ", TrainRoute = Route2 };
            var Train4R2 = new Train { TrainName = "Sharavati Express",    TrainNumber = "11035 ", TrainRoute = Route2 };
            var Train5R2 = new Train { TrainName = "Goa Express",          TrainNumber = "12870 ", TrainRoute = Route2 };
            var Train6R2 = new Train { TrainName = "Deekshabhoomi Express",TrainNumber = "11046 ", TrainRoute = Route2 };

            // Trains for Route 3
            var Train1R3 = new Train { TrainName = "Hutatma Express",      TrainNumber = "12157 ", TrainRoute = Route3 };
            var Train2R3 = new Train { TrainName = "Intercity Express",    TrainNumber = "12127 ", TrainRoute = Route3 };
            var Train3R3 = new Train { TrainName = "Siddheshwar Express",  TrainNumber = "12150 ", TrainRoute = Route3 };
            var Train4R3 = new Train { TrainName = "Nagercoil Express",    TrainNumber = "16339 ", TrainRoute = Route3 };
            var Train5R3 = new Train { TrainName = "Hussainsagar Express", TrainNumber = "12124 ", TrainRoute = Route3 };
            var Train6R3 = new Train { TrainName = "Udyan Express",        TrainNumber = "11030 ", TrainRoute = Route3 };

            // Trains for Route 4
            var Train1R4 = new Train { TrainName = "Maharashtra Express",    TrainNumber = "11039 ", TrainRoute = Route4 };
            var Train2R4 = new Train { TrainName = "Aazhad Hind Express",    TrainNumber = "12129 ", TrainRoute = Route4 };
            var Train3R4 = new Train { TrainName = "Jhelum Express",         TrainNumber = "11077 ", TrainRoute = Route4 };
            var Train4R4 = new Train { TrainName = "Pune Nagupr Express",    TrainNumber = "12135 ", TrainRoute = Route4 };
            var Train5R4 = new Train { TrainName = "Garibrath Express",      TrainNumber = "12113 ", TrainRoute = Route4 };
            var Train6R4 = new Train { TrainName = "Goa Express",            TrainNumber = "12779 ", TrainRoute = Route4 };

            // Trains for Route 5
            var Train1R5 = new Train { TrainName = "Vidrabha Express",    TrainNumber = "12105 ", TrainRoute = Route5 };
            var Train2R5 = new Train { TrainName = "Aazhad Hind Express", TrainNumber = "12129 ", TrainRoute = Route5 };
            var Train3R5 = new Train { TrainName = "Geetanjali Express",  TrainNumber = "12859 ", TrainRoute = Route5 };
            var Train4R5 = new Train { TrainName = "Maharashtra Express", TrainNumber = "11039 ", TrainRoute = Route5 };
            var Train5R5 = new Train { TrainName = "Sewagram Express",    TrainNumber = "12139 ", TrainRoute = Route5 };
            var Train6R5 = new Train { TrainName = "Samarsata Express",   TrainNumber = "12151 ", TrainRoute = Route5 };

            Console.WriteLine("Adding Routes to DB...");

            // Add everything to DB
            myContext.Routes.Add(Route1);
            myContext.Routes.Add(Route2);
            myContext.Routes.Add(Route3);
            myContext.Routes.Add(Route4);
            myContext.Routes.Add(Route5);

            Console.WriteLine("Adding Stations to DB...");
            // Add Route 1 Stations
            myContext.Stations.Add(Station1R1);
            myContext.Stations.Add(Station2R1);
            myContext.Stations.Add(Station3R1);
            myContext.Stations.Add(Station4R1);
            myContext.Stations.Add(Station5R1);
            myContext.Stations.Add(Station6R1);
            myContext.Stations.Add(Station7R1);
            myContext.Stations.Add(Station8R1);
            myContext.Stations.Add(Station9R1);
            myContext.Stations.Add(Station10R1);
            myContext.Stations.Add(Station11R1);
            myContext.Stations.Add(Station12R1);
            myContext.Stations.Add(Station13R1);
            myContext.Stations.Add(Station14R1);
            myContext.Stations.Add(Station15R1);
            myContext.Stations.Add(Station16R1);
            myContext.Stations.Add(Station17R1);
            myContext.Stations.Add(Station18R1);
            myContext.Stations.Add(Station19R1);
            myContext.Stations.Add(Station20R1);
            myContext.Stations.Add(Station21R1);
            myContext.Stations.Add(Station22R1);
            myContext.Stations.Add(Station23R1);
            myContext.Stations.Add(Station24R1);
            myContext.Stations.Add(Station25R1);
            myContext.Stations.Add(Station26R1);
            myContext.Stations.Add(Station27R1);
            myContext.Stations.Add(Station28R1);
            myContext.Stations.Add(Station29R1);
            myContext.Stations.Add(Station30R1);
            myContext.Stations.Add(Station31R1);
            myContext.Stations.Add(Station32R1);
            myContext.Stations.Add(Station33R1);
            myContext.Stations.Add(Station34R1);
            myContext.Stations.Add(Station35R1);
            myContext.Stations.Add(Station36R1);
            myContext.Stations.Add(Station37R1);
            myContext.Stations.Add(Station38R1);
            myContext.Stations.Add(Station39R1);
            myContext.Stations.Add(Station40R1);
            myContext.Stations.Add(Station41R1);
            myContext.Stations.Add(Station42R1);
            myContext.Stations.Add(Station43R1);
            myContext.Stations.Add(Station44R1);
            myContext.Stations.Add(Station45R1);
            myContext.Stations.Add(Station46R1);
            myContext.Stations.Add(Station47R1);
            myContext.Stations.Add(Station48R1);
            myContext.Stations.Add(Station49R1);
            myContext.Stations.Add(Station50R1);
            myContext.Stations.Add(Station51R1);
            myContext.Stations.Add(Station52R1);
            myContext.Stations.Add(Station53R1);
            myContext.Stations.Add(Station54R1);
            myContext.Stations.Add(Station55R1);
            myContext.Stations.Add(Station56R1);
            myContext.Stations.Add(Station57R1);
            myContext.Stations.Add(Station58R1);
            myContext.Stations.Add(Station59R1);
            
            // Add Route 2 Stations
            myContext.Stations.Add(Station1R2);
            myContext.Stations.Add(Station2R2);
            myContext.Stations.Add(Station3R2);
            myContext.Stations.Add(Station4R2);
            myContext.Stations.Add(Station5R2);
            myContext.Stations.Add(Station6R2);
            myContext.Stations.Add(Station7R2);
            myContext.Stations.Add(Station8R2);
            myContext.Stations.Add(Station9R2);
            myContext.Stations.Add(Station10R2);
            myContext.Stations.Add(Station11R2);
            myContext.Stations.Add(Station12R2);
            myContext.Stations.Add(Station13R2);
            myContext.Stations.Add(Station14R2);
            myContext.Stations.Add(Station15R2);
            myContext.Stations.Add(Station16R2);
            myContext.Stations.Add(Station17R2);
            myContext.Stations.Add(Station18R2);
            myContext.Stations.Add(Station19R2);
            myContext.Stations.Add(Station20R2);
            myContext.Stations.Add(Station21R2);
            myContext.Stations.Add(Station22R2);
            myContext.Stations.Add(Station23R2);
            myContext.Stations.Add(Station24R2);
            myContext.Stations.Add(Station25R2);
            myContext.Stations.Add(Station26R2);
            myContext.Stations.Add(Station27R2);
            myContext.Stations.Add(Station28R2);
            myContext.Stations.Add(Station29R2);
            myContext.Stations.Add(Station30R2);
            myContext.Stations.Add(Station31R2);
            myContext.Stations.Add(Station32R2);
            myContext.Stations.Add(Station33R2);
            myContext.Stations.Add(Station34R2);
            myContext.Stations.Add(Station35R2);
            myContext.Stations.Add(Station36R2);
            myContext.Stations.Add(Station37R2);
            myContext.Stations.Add(Station38R2);
            myContext.Stations.Add(Station39R2);
            myContext.Stations.Add(Station40R2);
            myContext.Stations.Add(Station41R2);
            myContext.Stations.Add(Station42R2);
            myContext.Stations.Add(Station43R2);
            myContext.Stations.Add(Station44R2);

            // Add Route 3 Stations
            myContext.Stations.Add(Station1R3);
            myContext.Stations.Add(Station2R3);
            myContext.Stations.Add(Station3R3);
            myContext.Stations.Add(Station4R3);
            myContext.Stations.Add(Station5R3);
            myContext.Stations.Add(Station6R3);
            myContext.Stations.Add(Station7R3);
            myContext.Stations.Add(Station8R3);
            myContext.Stations.Add(Station9R3);
            myContext.Stations.Add(Station10R3);
            myContext.Stations.Add(Station11R3);
            myContext.Stations.Add(Station12R3);
            myContext.Stations.Add(Station13R3);
            myContext.Stations.Add(Station14R3);
            myContext.Stations.Add(Station15R3);
            myContext.Stations.Add(Station16R3);
            myContext.Stations.Add(Station17R3);
            myContext.Stations.Add(Station18R3);
            myContext.Stations.Add(Station19R3);
            myContext.Stations.Add(Station20R3);
            myContext.Stations.Add(Station21R3);
            myContext.Stations.Add(Station22R3);
            myContext.Stations.Add(Station23R3);
            myContext.Stations.Add(Station24R3);
            myContext.Stations.Add(Station25R3);
            myContext.Stations.Add(Station26R3);
            myContext.Stations.Add(Station27R3);
            myContext.Stations.Add(Station28R3);
            myContext.Stations.Add(Station29R3);
            myContext.Stations.Add(Station30R3);
            myContext.Stations.Add(Station31R3);
            myContext.Stations.Add(Station32R3);
            myContext.Stations.Add(Station33R3);
            myContext.Stations.Add(Station34R3);

            // Add Route 4 Stations
            myContext.Stations.Add(Station1R4);
            myContext.Stations.Add(Station2R4);
            myContext.Stations.Add(Station3R4);
            myContext.Stations.Add(Station4R4);
            myContext.Stations.Add(Station5R4);
            myContext.Stations.Add(Station6R4);
            myContext.Stations.Add(Station7R4);
            myContext.Stations.Add(Station8R4);
            myContext.Stations.Add(Station9R4);
            myContext.Stations.Add(Station10R4);
            myContext.Stations.Add(Station11R4);
            myContext.Stations.Add(Station12R4);
            myContext.Stations.Add(Station13R4);
            myContext.Stations.Add(Station14R4);
            myContext.Stations.Add(Station15R4);
            myContext.Stations.Add(Station16R4);
            myContext.Stations.Add(Station17R4);
            myContext.Stations.Add(Station18R4);
            myContext.Stations.Add(Station19R4);
            myContext.Stations.Add(Station20R4);
            myContext.Stations.Add(Station21R4);
            myContext.Stations.Add(Station22R4);
            myContext.Stations.Add(Station23R4);
            myContext.Stations.Add(Station24R4);
            myContext.Stations.Add(Station25R4);
            myContext.Stations.Add(Station26R4);
            myContext.Stations.Add(Station27R4);
            myContext.Stations.Add(Station28R4);
            myContext.Stations.Add(Station29R4);
            myContext.Stations.Add(Station30R4);
            myContext.Stations.Add(Station31R4);
            myContext.Stations.Add(Station32R4);
            myContext.Stations.Add(Station33R4);
            myContext.Stations.Add(Station34R4);
            myContext.Stations.Add(Station35R4);
            myContext.Stations.Add(Station36R4);
            myContext.Stations.Add(Station37R4);
            myContext.Stations.Add(Station38R4);
            myContext.Stations.Add(Station39R4);
            myContext.Stations.Add(Station40R4);
            myContext.Stations.Add(Station41R4);
            myContext.Stations.Add(Station42R4);
            myContext.Stations.Add(Station43R4);
            myContext.Stations.Add(Station44R4);
            myContext.Stations.Add(Station45R4); 
            myContext.Stations.Add(Station46R4);
            myContext.Stations.Add(Station47R4);
            myContext.Stations.Add(Station48R4);
            myContext.Stations.Add(Station49R4);
            myContext.Stations.Add(Station50R4);
            myContext.Stations.Add(Station51R4);
            myContext.Stations.Add(Station52R4);
            myContext.Stations.Add(Station53R4);
            myContext.Stations.Add(Station54R4);
            myContext.Stations.Add(Station55R4);
            myContext.Stations.Add(Station56R4);
            myContext.Stations.Add(Station57R4);
            myContext.Stations.Add(Station58R4);
            myContext.Stations.Add(Station59R4);
            myContext.Stations.Add(Station60R4);
            myContext.Stations.Add(Station61R4);
            myContext.Stations.Add(Station62R4);
            myContext.Stations.Add(Station63R4);
            myContext.Stations.Add(Station64R4);
            myContext.Stations.Add(Station65R4);
            myContext.Stations.Add(Station66R4);
            myContext.Stations.Add(Station67R4);
            myContext.Stations.Add(Station68R4);
            myContext.Stations.Add(Station69R4);
            myContext.Stations.Add(Station70R4);
            myContext.Stations.Add(Station71R4);
            myContext.Stations.Add(Station72R4);
            myContext.Stations.Add(Station73R4);
            myContext.Stations.Add(Station74R4);
            myContext.Stations.Add(Station75R4);
            myContext.Stations.Add(Station76R4);
            myContext.Stations.Add(Station77R4);
            myContext.Stations.Add(Station78R4);
            myContext.Stations.Add(Station79R4);
            myContext.Stations.Add(Station80R4);
            myContext.Stations.Add(Station81R4);
            myContext.Stations.Add(Station82R4);
            myContext.Stations.Add(Station83R4);
            myContext.Stations.Add(Station84R4);
            myContext.Stations.Add(Station85R4);
            myContext.Stations.Add(Station86R4);
            myContext.Stations.Add(Station87R4);
            myContext.Stations.Add(Station88R4);


            // Add Route 5 Stations
            myContext.Stations.Add(Station1R5);
            myContext.Stations.Add(Station2R5);
            myContext.Stations.Add(Station3R5);
            myContext.Stations.Add(Station4R5);
            myContext.Stations.Add(Station5R5);
            myContext.Stations.Add(Station6R5);
            myContext.Stations.Add(Station7R5);
            myContext.Stations.Add(Station8R5);
            myContext.Stations.Add(Station9R5);
            myContext.Stations.Add(Station10R1);
            myContext.Stations.Add(Station11R5);
            myContext.Stations.Add(Station12R5);
            myContext.Stations.Add(Station13R5);
            myContext.Stations.Add(Station14R5);
            myContext.Stations.Add(Station15R5);
            myContext.Stations.Add(Station16R5);
            myContext.Stations.Add(Station17R5);
            myContext.Stations.Add(Station18R5);
            myContext.Stations.Add(Station19R5);
            myContext.Stations.Add(Station20R5);
            myContext.Stations.Add(Station21R5);
            myContext.Stations.Add(Station22R5);
            myContext.Stations.Add(Station23R5);
            myContext.Stations.Add(Station24R5);
            myContext.Stations.Add(Station25R5);
            myContext.Stations.Add(Station26R5);
            myContext.Stations.Add(Station27R5);
            myContext.Stations.Add(Station28R5);
            myContext.Stations.Add(Station29R5);
            myContext.Stations.Add(Station30R5);
            myContext.Stations.Add(Station31R5);
            myContext.Stations.Add(Station32R5);
            myContext.Stations.Add(Station33R5);
            myContext.Stations.Add(Station34R5);
            myContext.Stations.Add(Station35R5);
            myContext.Stations.Add(Station36R5);
            myContext.Stations.Add(Station37R5);
            myContext.Stations.Add(Station38R5);
            myContext.Stations.Add(Station39R5);
            myContext.Stations.Add(Station40R5);
            myContext.Stations.Add(Station41R5);
            myContext.Stations.Add(Station42R5);
            myContext.Stations.Add(Station43R5);
            myContext.Stations.Add(Station44R5);
            myContext.Stations.Add(Station45R5);

            Console.WriteLine("Adding Trains to DB...");

            // Add Route 1 Trains
            myContext.Trains.Add(Train1R1);
            myContext.Trains.Add(Train2R1);
            myContext.Trains.Add(Train3R1);
            myContext.Trains.Add(Train4R1);
            myContext.Trains.Add(Train5R1);
            myContext.Trains.Add(Train6R1);

            // Add Route 2 Trains
            myContext.Trains.Add(Train1R2);
            myContext.Trains.Add(Train2R2);
            myContext.Trains.Add(Train3R2);
            myContext.Trains.Add(Train4R2);
            myContext.Trains.Add(Train5R2);
            myContext.Trains.Add(Train6R2);

            // Add Route 3 Trains
            myContext.Trains.Add(Train1R3);
            myContext.Trains.Add(Train2R3);
            myContext.Trains.Add(Train3R3);
            myContext.Trains.Add(Train4R3);
            myContext.Trains.Add(Train5R3);
            myContext.Trains.Add(Train6R3);

            // Add Route 4 Trains
            myContext.Trains.Add(Train1R4);
            myContext.Trains.Add(Train2R4);
            myContext.Trains.Add(Train3R4);
            myContext.Trains.Add(Train4R4);
            myContext.Trains.Add(Train5R4);
            myContext.Trains.Add(Train6R4);

            // Add Route 5 Trains
            myContext.Trains.Add(Train1R5);
            myContext.Trains.Add(Train2R5);
            myContext.Trains.Add(Train3R5);
            myContext.Trains.Add(Train4R5);
            myContext.Trains.Add(Train5R5);
            myContext.Trains.Add(Train6R5);

            myContext.SaveChanges();
        }
    }
}
