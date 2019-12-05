using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeWcfService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeWcfService
    {
        [OperationContract]
        Employee GetEmployee(int Id);

        [OperationContract]
        void SaveEmployee(Employee Employee);

        [OperationContract]
        void DeleteEmployee(int Id);
    }
}
