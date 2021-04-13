using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validation.Models;

namespace Validation.Repository
{
    public interface IRegistrationRepository
    {
        void SaveRegistration(RegistraionModel model);
    }
}
