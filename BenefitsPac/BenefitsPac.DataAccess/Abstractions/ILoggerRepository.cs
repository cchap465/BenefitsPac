using System;
using System.Threading.Tasks;

namespace BenefitsPac.DataAccess.Abstractions
{
    public interface ILoggerRepository
    {
        Task Log(Exception exception);
    }
}
