using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSmile.Constant
{
    public static class Constant
    {
        public static class View
        {
            public const string Login = "LoginView";
            public const string Shell = "Shell";
            public const string PatientList = "PatientList";
            public const string NextAppointment = "NextAppointment";
            public const string PatientBasicForm = "PatientBasicForm";
            public const string PatientHistoryForm = "PatientHistoryForm";
        }

        public static class DictionaryKey
        {
            public const string ShellContext = "ShellContext";
            public const string LoggedInUser = "LoggedInUser";
        }


        public static class Login
        {
            public const string LoginErrorMesage = "Invalid user name or password !";
            public const string Title = "Login Screen-Perfect Smile Dental Clinic";
        }

        public static class Shell
        {
            public const string Title = "Main Screen-Perfect Smile Dental Clinic";
        }


        public static class Region
        {
            public const string MainRegion = "MainRegion";
        }

    }
}
