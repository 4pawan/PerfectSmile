﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.EF;
using PerfectSmile.ViewModels;
using PerfectSmile.Views.UserControl.AutoCompleteTextBox;

namespace PerfectSmile.Repository.Abstract
{
    public interface IPatientRepository : IRepository
    {
        int AddPatientBasicInfo(PatientBasicFormViewModel model);
        ObservableCollection<AutoCompleteEntry> GetAllPatient();
    }
}