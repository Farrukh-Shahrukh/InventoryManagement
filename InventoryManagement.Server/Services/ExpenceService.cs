using AutoMapper;
using InventoryManagement.Server.Data;
using InventoryManagement.Server.Data.Models;
using InventoryManagement.Server.Data.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Server.Services
{
    public class ExpenceService : IExpenceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public ExpenceService(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        public IEnumerable<ExpencesDTO> GetAllExpences()
        {
            var expences = _context.Expences
                .Include(e => e.Project)
                .Include(e => e.ExpenceTypes)
                .ToList();
            return _mapper.Map<IEnumerable<ExpencesDTO>>(expences);
        }

        public ExpencesDTO GetExpenceById(int id)
        {
            var expence = _context.Expences
                .Include(e => e.Project)
                .Include(e => e.ExpenceTypes)
                .FirstOrDefault(e => e.Id == id);
            
            if (expence == null)
            {
                return null;
            }
            return _mapper.Map<ExpencesDTO>(expence);
        }

        public ExpencesDTO CreateExpence(ExpencesDTO expenceDto)
        {
            var expence = _mapper.Map<Expences>(expenceDto);
            _context.Expences.Add(expence);
            _context.SaveChanges();
            return _mapper.Map<ExpencesDTO>(expence);
        }

        public ExpencesDTO UpdateExpence(int id, ExpencesDTO expenceDto)
        {
            var expence = _context.Expences.Find(id);
            if (expence == null)
            {
                return null;
            }

            expence.Date = expenceDto.Date;
            expence.Amount = (long)expenceDto.Amount;
            expence.Description = expenceDto.Description;
            expence.PicturePath = expenceDto.PicturePath;
            expence.ProjectId = expenceDto.ProjectId;
            expence.ExpenceTypeId = expenceDto.ItemId;

            _context.SaveChanges();
            return _mapper.Map<ExpencesDTO>(expence);
        }

        public bool DeleteExpence(int id)
        {
            var expence = _context.Expences.Find(id);
            if (expence == null)
            {
                return false;
            }

            // Delete the picture file if it exists
            if (!string.IsNullOrEmpty(expence.PicturePath))
            {
                var filePath = Path.Combine(_environment.WebRootPath, expence.PicturePath.TrimStart('/'));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            _context.Expences.Remove(expence);
            _context.SaveChanges();
            return true;
        }

        public async Task<string> UploadExpensePicture(int expenceId, IFormFile file)
        {
            var expence = _context.Expences.Find(expenceId);
            if (expence == null)
            {
                throw new Exception("Expence not found");
            }

            if (file == null || file.Length == 0)
            {
                throw new Exception("Invalid file");
            }

            // Validate file type
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".pdf" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new Exception("Invalid file type. Only images and PDF files are allowed.");
            }

            // Delete old picture if exists
            if (!string.IsNullOrEmpty(expence.PicturePath))
            {
                var oldFilePath = Path.Combine(_environment.WebRootPath, expence.PicturePath.TrimStart('/'));
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
            }

            // Create uploads directory if it doesn't exist
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "expences");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate unique filename
            var uniqueFileName = $"{expenceId}_{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Save file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Update expence with new picture path
            expence.PicturePath = $"/uploads/expences/{uniqueFileName}";
            _context.SaveChanges();

            return expence.PicturePath;
        }
    }
}
