using GuiaVegana.Entities;
using GuiaVegana.Models;
using System;
using System.Collections.Generic;

namespace GuiaVegana.Data.Repository.Interfaces
{
    public interface IBusinessRepository
    {
        // Métodos GET
        IEnumerable<BusinessDTO> GetAllBusinesses(); // Obtener todos los negocios
        BusinessDTO GetBusinessById(int id); // Obtener un negocio por ID

        // Métodos POST
        void AddBusiness(BusinessToCreateDTO businessDTO); // Agregar un nuevo negocio

        // Métodos PUT
        void UpdateBusiness(BusinessDTO businessDTO); // Actualizar un negocio existente

        // Métodos DELETE
        void DeleteBusiness(int id); // Eliminar un negocio por ID
    }
}
