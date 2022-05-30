using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data;
using TestingSystem.Models;
using TestingSystem.ViewModels;

namespace TestingSystem.Models
{
    public class ProfileModel
    {
        public List<TestInfo> passedTests { get; }

        private User _user;
        public User User { get => _user; }

        public ProfileModel()
        {
            passedTests = new List<TestInfo>();
            _user = User.Nobody;
            SummaryViewModel.TestEndEvent += OnTestEnd;
        }


        public ProfileModel(User user)
        {
            _user = user;
            passedTests = DB.DBWorkerFactory.GetDBWorker().GetPassedTests(User.id);
            SummaryViewModel.TestEndEvent += OnTestEnd;
        }

        private void OnTestEnd(double obj)
        {
            _user.countOfTests++;
        }


        public void SaveProfile()
        {
            // TODO Сохрание изменений
            //DB.DBWorkerFactory.GetDBWorker().SaveProfile(this);
        }
    }
}
