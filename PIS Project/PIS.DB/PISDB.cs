using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DB
{
    public class Station
    {
        // Basic Properties
        public int Id { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        // Navigation Properties
        public virtual Route StationRoute { get; set; }
        
    }

    public class Route
    {
        // Basic Properties
        public int Id { get; set; }
        public string RouteName { get; set; }

        // Navigation Properties
        public virtual ICollection<Train> Trains { get; set; }
        public virtual ICollection<Station> Stations { get; set; }
    }

    public class Train
    {
        // Basic Properties
        public int Id { get; set; }
        public string TrainName { get; set; }
        public string TrainNumber { get; set; }

        // Navigation Properties
        public virtual Route TrainRoute { get; set; }
    }
}
