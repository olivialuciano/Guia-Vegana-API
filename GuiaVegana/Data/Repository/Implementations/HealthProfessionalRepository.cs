using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class HealthProfessionalRepository : IHealthProfessionalRepository
    {
        private readonly GuiaVeganaContext _context;

        public HealthProfessionalRepository(GuiaVeganaContext context)
        {
            _context = context;
        }

        // GET: Get all health professionals
        public IEnumerable<HealthProfessionalDTO> GetAll()
        {
            var professionals = _context.HealthProfessionals.ToList();
            return professionals.Select(p => new HealthProfessionalDTO
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Specialty = p.Specialty,
                License = p.License,
                SocialMediaUsername = p.SocialMediaUsername,
                SocialMediaLink = p.SocialMediaLink,
                WhatsappNumber = p.WhatsappNumber,
                Email = p.Email,
                UserId = p.UserId
            }).ToList();
        }

        // GET: Get health professional by ID
        public HealthProfessionalDTO GetById(int id)
        {
            var professional = _context.HealthProfessionals.FirstOrDefault(p => p.Id == id);
            if (professional == null) return null;

            return new HealthProfessionalDTO
            {
                Id = professional.Id,
                Name = professional.Name,
                Image = professional.Image,
                Specialty = professional.Specialty,
                License = professional.License,
                SocialMediaUsername = professional.SocialMediaUsername,
                SocialMediaLink = professional.SocialMediaLink,
                WhatsappNumber = professional.WhatsappNumber,
                Email = professional.Email,
                UserId = professional.UserId
            };
        }

        // POST: Add a new health professional
        public void Add(HealthProfessionalToCreateDTO healthProfessionalToCreate)
        {
            var professional = new HealthProfessional
            {
                Name = healthProfessionalToCreate.Name,
                Image = healthProfessionalToCreate.Image,
                Specialty = healthProfessionalToCreate.Specialty,
                License = healthProfessionalToCreate.License,
                SocialMediaUsername = healthProfessionalToCreate.SocialMediaUsername,
                SocialMediaLink = healthProfessionalToCreate.SocialMediaLink,
                WhatsappNumber = healthProfessionalToCreate.WhatsappNumber,
                Email = healthProfessionalToCreate.Email,
                UserId = healthProfessionalToCreate.UserId
            };

            _context.HealthProfessionals.Add(professional);
            _context.SaveChanges();
        }

        // PUT: Update an existing health professional
        public void Update(int id, HealthProfessionalToCreateDTO healthProfessionalToUpdate)
        {
            var existingProfessional = _context.HealthProfessionals.FirstOrDefault(p => p.Id == id);
            if (existingProfessional == null)
            {
                throw new KeyNotFoundException($"No se encontró un profesional de salud con ID {id}.");
            }

            existingProfessional.Name = healthProfessionalToUpdate.Name;
            existingProfessional.Image = healthProfessionalToUpdate.Image;
            existingProfessional.Specialty = healthProfessionalToUpdate.Specialty;
            existingProfessional.License = healthProfessionalToUpdate.License;
            existingProfessional.SocialMediaUsername = healthProfessionalToUpdate.SocialMediaUsername;
            existingProfessional.SocialMediaLink = healthProfessionalToUpdate.SocialMediaLink;
            existingProfessional.WhatsappNumber = healthProfessionalToUpdate.WhatsappNumber;
            existingProfessional.Email = healthProfessionalToUpdate.Email;
            existingProfessional.UserId = healthProfessionalToUpdate.UserId;

            _context.SaveChanges();
        }

        // DELETE: Remove a health professional by ID
        public void Delete(int id)
        {
            var professional = _context.HealthProfessionals.FirstOrDefault(p => p.Id == id);
            if (professional == null)
            {
                throw new KeyNotFoundException($"No se encontró un profesional de salud con ID {id}.");
            }

            _context.HealthProfessionals.Remove(professional);
            _context.SaveChanges();
        }
    }
}
