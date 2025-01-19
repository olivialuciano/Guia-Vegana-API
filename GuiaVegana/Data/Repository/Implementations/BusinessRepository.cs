using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly GuiaVeganaContext _context;

        public BusinessRepository(GuiaVeganaContext context)
        {
            _context = context;
        }

        // Métodos GET

        // 1. Traer todos los negocios
        public IEnumerable<BusinessDTO> GetAllBusinesses()
        {
            return _context.Businesses
                .Include(b => b.OpeningHours)
                .Include(b => b.VeganOptions)
                .ToList()
                .Select(MapToBusinessDTO);
        }

        // 2. Traer un negocio por ID
        public BusinessDTO GetBusinessById(int id)
        {
            var business = _context.Businesses
                .Include(b => b.OpeningHours)
                .Include(b => b.VeganOptions)
                .FirstOrDefault(b => b.Id == id);

            return business != null ? MapToBusinessDTO(business) : null;
        }

        // Métodos POST

        // 10. Agregar un nuevo negocio
        public void AddBusiness(BusinessToCreateDTO businessDTO)
        {
            var business = MapToBusinessEntity(businessDTO);
            _context.Businesses.Add(business);
            _context.SaveChanges();
        }

        // Métodos PUT

        // 11. Actualizar datos de un negocio existente
        public void UpdateBusiness(BusinessDTO businessDTO)
        {
            var business = MapToBusinessEntity(businessDTO);
            _context.Businesses.Update(business);
            _context.SaveChanges();
        }

        // Métodos DELETE

        // 12. Eliminar un negocio por ID
        public void DeleteBusiness(int id)
        {
            var business = _context.Businesses.Find(id);
            if (business != null)
            {
                _context.Businesses.Remove(business);
                _context.SaveChanges();
            }
        }

        // Métodos privados para mapear manualmente
        private BusinessDTO MapToBusinessDTO(Business business)
        {
            return new BusinessDTO
            {
                Id = business.Id,
                Name = business.Name,
                Image = business.Image,
                SocialMediaUsername = business.SocialMediaUsername,
                SocialMediaLink = business.SocialMediaLink,
                Address = business.Address,
                Zone = business.Zone,
                Delivery = business.Delivery,
                GlutenFree = business.GlutenFree,
                AllPlantBased = business.AllPlantBased,
                Rating = business.Rating,
                BusinessType = business.BusinessType,
                LastUpdate = business.LastUpdate,
                UserId = business.UserId
            };
        }

        private Business MapToBusinessEntity(BusinessToCreateDTO businessDTO)
        {
            return new Business
            {
                Name = businessDTO.Name,
                Image = businessDTO.Image,
                SocialMediaUsername = businessDTO.SocialMediaUsername,
                SocialMediaLink = businessDTO.SocialMediaLink,
                Address = businessDTO.Address,
                Zone = businessDTO.Zone,
                Delivery = businessDTO.Delivery,
                GlutenFree = businessDTO.GlutenFree,
                AllPlantBased = businessDTO.AllPlantBased,
                Rating = businessDTO.Rating,
                BusinessType = businessDTO.BusinessType,
                UserId = businessDTO.UserId,
                LastUpdate = DateTime.Now
            };
        }

        private Business MapToBusinessEntity(BusinessDTO businessDTO)
        {
            return new Business
            {
                Id = businessDTO.Id,
                Name = businessDTO.Name,
                Image = businessDTO.Image,
                SocialMediaUsername = businessDTO.SocialMediaUsername,
                SocialMediaLink = businessDTO.SocialMediaLink,
                Address = businessDTO.Address,
                Zone = businessDTO.Zone,
                Delivery = businessDTO.Delivery,
                GlutenFree = businessDTO.GlutenFree,
                AllPlantBased = businessDTO.AllPlantBased,
                Rating = businessDTO.Rating,
                BusinessType = businessDTO.BusinessType,
                UserId = businessDTO.UserId,
                LastUpdate = businessDTO.LastUpdate
            };
        }
    }
}
