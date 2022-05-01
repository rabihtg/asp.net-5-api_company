using Dapper;
using PersonalProjectClassLibrary.DataAccess;
using PersonalProjectClassLibrary.Dto;
using PersonalProjectClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataServices
{
    public class AddressData : IAddressData
    {
        private readonly ISqlDataAccess _db;

        public AddressData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task InsertAddress(Guid employeeId, InsertAddressDto addressDto)
        {
            var dp = new DynamicParameters();

            dp.AddDynamicParams(addressDto);
            dp.Add("Id", Guid.NewGuid());
            dp.Add("EmployeeId", employeeId);

            await _db.SaveData("dbo.spAddress_Insert", dp);
        }

        public async Task DeleteAddress(Guid employeeId, DeleteAddressDto addressDto)
        {
            var dp = new DynamicParameters();

            dp.AddDynamicParams(addressDto);
            dp.Add("EmployeeId", employeeId);

            await _db.SaveData("dbo.spAddress_Delete", dp);
        }
    }
}
