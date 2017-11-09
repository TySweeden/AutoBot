using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteAutomation.Services.WebPageAutomation.ExecutionRoutines
{
    interface ICommonAutomations
    {
        void SetFirstName();
        void SetFullMiddleName();
        void SetInitialMiddleName();
        void SetLastName();
        void SetEmail();
        void SetPhoneNumber();
        void SetCoverLetter();
        void SetCoverLetterFile();
        void SetResumeFile();
    }
}
