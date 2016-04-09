using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;
using PerfectSmile.ViewModels;

namespace PerfectSmile.Helper
{
    public class Helper
    {

        public static string LoggedInUser
        {
            get { return StorageManager.Get<string>(Constant.Constant.DictionaryKey.LoggedInUser); }
        }

        public static DateTime? TryParse(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? (DateTime?) date : null;
        }
        public static long TryParseToLong(string text)
        {
            long result = 0;
            return long.TryParse(text, out result) ? result : 0;
        }

        public static decimal TryParseToDecimal(string text)
        {
            decimal result = 0;
            return decimal.TryParse(text, out result) ? result : 0;
        }


        public static Patient ConvertToPatientModel(PatientBasicFormViewModel vm)
        {
            return new Patient
            {
                Name = vm.Name,
                Phone = vm.Phone,
                Remark = vm.Remark,
                ModifiedBy = LoggedInUser,
                ModifiedAt = DateTime.Now,
                Id = vm.PatientId
            };
        }

        public static PatientHistory ConvertToPatientHistoryModel(PatientHistoryFormViewModel vm)
        {
           
            return new PatientHistory
            {
                PaymentDone = TryParseToDecimal(vm.PaymentDone) ,
                TreatmentDone = vm.TreatmentDone,
                Balance = TryParseToDecimal(vm.Balance),
                CreatedBy = LoggedInUser,
                CreatedAt = DateTime.Now,
                NextAppointment = TryParse(vm.NextAppointment),
                AdditionalComment = vm.AdditionalComment,
                PatientId = TryParseToLong(vm.PatientId)
            };
        }




        public static void WriteLogToEventViewer(string message)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(message, EventLogEntryType.Error, 101, 1);
            }
        }
    }
}
