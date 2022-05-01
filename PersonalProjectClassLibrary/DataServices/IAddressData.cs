using PersonalProjectClassLibrary.Dto;
using System;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataServices
{
    public interface IAddressData
    {
        Task DeleteAddress(Guid employeeId, DeleteAddressDto addressDto);
        Task InsertAddress(Guid employeeId, InsertAddressDto addressDto);
    }
}