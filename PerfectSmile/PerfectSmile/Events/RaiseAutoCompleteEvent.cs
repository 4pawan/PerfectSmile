﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace PerfectSmile.Events
{
    public class RaiseAutoCompleteEvent : PubSubEvent<bool>
    {
    }

    public class RaiseNextAppointmentEvent : PubSubEvent<bool>
    {
    }
}