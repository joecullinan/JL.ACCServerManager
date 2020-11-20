﻿using System;

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
        public int isFixedConditionQualification { get; set; }
    }

}
