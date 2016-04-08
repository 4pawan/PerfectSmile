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
            if (DateTime.TryParse(text, out date))
            {
                return date;
            }
            else
            {
                return null;
            }
        }

        public static long TryParseToLong(long? text)
        {
            long result = 0;
            if (long.TryParse(text?.ToString(), out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
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
                Id = TryParseToLong(vm.PatientId)
            };
        }

        public static PatientHistory ConvertToPatientHistoryModel(PatientHistoryFormViewModel vm)
        {
            long resultPatientId = 0;
            long.TryParse(vm.PatientId, out resultPatientId);
            return new PatientHistory
            {
                PaymentDone = vm.PaymentDone,
                TreatmentDone = vm.TreatmentDone,
                Balance = vm.Balance,
                CreatedBy = LoggedInUser,
                CreatedAt = DateTime.Now,
                NextAppointment = TryParse(vm.NextAppointment),
                AdditionalComment = vm.AdditionalComment,
                PatientId = resultPatientId
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
