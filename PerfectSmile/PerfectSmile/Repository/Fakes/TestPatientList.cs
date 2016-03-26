using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;

namespace PerfectSmile.Repository.Fakes
{
    public static class TestPatientList
    {
        private static List<Patient> _patientList;

        public static List<Patient> PatientList
        {
            get
            {
                if (_patientList == null)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        _patientList.Add(new Patient
                        {
                            Name = "Patient" + i + 1,
                            CreatedAt = DateTime.Now,
                            CreatedBy = Environment.UserName,
                            Remark = "121231232" + i,
                        });
                    }
                }
                return _patientList;
            }
            set { _patientList = value; }
        }
    }
}
