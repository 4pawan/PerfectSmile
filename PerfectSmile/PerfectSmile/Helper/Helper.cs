﻿using System;
using System.Collections.Generic;
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
            get { return Environment.UserName; }
        }

        public static Patient ConvertToPatientModel(PatientBasicFormViewModel vm)
        {
            return new Patient
            {
                Name = vm.Name,
                Phone = vm.Phone,
                Remark = vm.Remark,
                CreatedBy = LoggedInUser,
                CreatedAt = DateTime.Now,
                ModifiedBy = LoggedInUser,
                ModifiedAt = DateTime.Now
            };
        }

        public static PatientHistory ConvertToPatientHistoryModel(PatientHistoryFormViewModel vm)
        {
            return new PatientHistory
            {
                PaymentDone = vm.PaymentDone,
                TreatmentDone = vm.TreatmentDone,
                Balance = vm.Balance,
                CreatedBy = LoggedInUser,
                CreatedAt = DateTime.Now,
                NextAppointment = Convert.ToDateTime(vm.NextAppointment),
                AdditionalComment = vm.AdditionalComment,
                PatientId = long.Parse(vm.Patient)
            };
        }
    }
}
