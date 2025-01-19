using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;
using System.Collections.Generic;
using System.Linq;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class ActivismRepository : IActivismRepository
    {
        private readonly GuiaVeganaContext _context;

        public ActivismRepository(GuiaVeganaContext context)
        {
            _context = context;
        }

        // GET: Get all activism entities
        public IEnumerable<ActivismDTO> GetAll()
        {
            return _context.Activisms.Select(a => new ActivismDTO
            {
                Id = a.Id,
                Name = a.Name,
                Image = a.Image,
                Contact = a.Contact,
                SocialMediaUsername = a.SocialMediaUsername,
                SocialMediaLink = a.SocialMediaLink,
                Description = a.Description,
                UserId = a.UserId
            }).ToList();
        }

        // GET: Get activism entity by ID
        public ActivismDTO GetById(int id)
        {
            var activism = _context.Activisms.FirstOrDefault(a => a.Id == id);
            if (activism == null)
                return null;

            return new ActivismDTO
            {
                Id = activism.Id,
                Name = activism.Name,
                Image = activism.Image,
                Contact = activism.Contact,
                SocialMediaUsername = activism.SocialMediaUsername,
                SocialMediaLink = activism.SocialMediaLink,
                Description = activism.Description,
                UserId = activism.UserId
            };
        }

        // POST: Add a new activism entity
        public void Add(ActivismToCreateDTO activismToCreate)
        {
            var activism = new Activism
            {
                Name = activismToCreate.Name,
                Image = activismToCreate.Image,
                Contact = activismToCreate.Contact,
                SocialMediaUsername = activismToCreate.SocialMediaUsername,
                SocialMediaLink = activismToCreate.SocialMediaLink,
                Description = activismToCreate.Description,
                UserId = activismToCreate.UserId
            };

            _context.Activisms.Add(activism);
            _context.SaveChanges();
        }

        // PUT: Update an existing activism entity
        public void Update(int id, ActivismToCreateDTO activismToUpdate)
        {
            var existingActivism = _context.Activisms.FirstOrDefault(a => a.Id == id);
            if (existingActivism != null)
            {
                existingActivism.Name = activismToUpdate.Name;
                existingActivism.Image = activismToUpdate.Image;
                existingActivism.Contact = activismToUpdate.Contact;
                existingActivism.SocialMediaUsername = activismToUpdate.SocialMediaUsername;
                existingActivism.SocialMediaLink = activismToUpdate.SocialMediaLink;
                existingActivism.Description = activismToUpdate.Description;
                existingActivism.UserId = activismToUpdate.UserId;

                _context.SaveChanges();
            }
        }

        // DELETE: Remove an activism entity by ID
        public void Delete(int id)
        {
            var activism = _context.Activisms.FirstOrDefault(a => a.Id == id);
            if (activism != null)
            {
                _context.Activisms.Remove(activism);
                _context.SaveChanges();
            }
        }
    }
}
