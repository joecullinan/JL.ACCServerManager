using System;

namespace JL.ACCServerManager.Models
{
    public class Class1
    {
    }


    public class Event
    {
        public Track track { get; set; }
        public int preRaceWaitingTimeSeconds { get; set; }
        public int sessionOverTimeSeconds { get; set; }
        public int ambientTemp { get; set; }
        public float cloudLevel { get; set; }
        public float rain { get; set; }
        public int weatherRandomness { get; set; }
        public Session[] sessions { get; set; }
        public int configVersion { get; set; }
    }

    public class Session
    {
        public int hourOfDay { get; set; }
        public int dayOfWeekend { get; set; }
        public int timeMultiplier { get; set; }
        public string sessionType { get; set; }
        public int sessionDurationMinutes { get; set; }
    }

    public enum Track
    {
        barcelona,
        barcelona_2019,
        brands_hatch,
        brands_hatch_2019,
        kyalami_2019,
        laguna_seca_2019,
        hungaroring,
        hungaroring_2019,
        misano,
        misano_2019,
        monza,
        monza_2019,
        mount_panorama_2019,
        nurburgring,
        nurburgring_2019,
        paul_ricard,
        paul_ricard_2019,
        silverstone,
        silverstone_2019,
        spa,
        spa_2019,
        suzuka_2019,
        zolder,
        zolder_2019,
        zandvoort,
        zandvoort_2019
    }

}
